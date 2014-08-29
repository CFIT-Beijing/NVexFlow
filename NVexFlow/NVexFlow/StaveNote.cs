// 对应 stavenote.js
using System;
using System.Collections.Generic;
using System.Linq;
using NVexFlow.Model;

namespace NVexFlow
{
    /// <summary>
    /// ## Description
    //
    // This file implements notes for standard notation. This consists of one or 
    // more `NoteHeads`, an optional stem, and an optional flag.
    //
    // *Throughout these comments, a "note" refers to the entire `StaveNote`,
    // and a "key" refers to a specific pitch/notehead within a note.*
    //
    // See `tests/stavenote_tests.js` for usage examples.
    /// </summary>
    public class StaveNote:StemmableNote
    {
        #region js直译部分
        public StaveNote(StaveNoteStruct noteStruct)
            : base(noteStruct)
        {

            Init(noteStruct);

        }
        /// <summary>
        /// Stem directions
        /// </summary>
        public static int STEM_UP = Stem.UP;
        public static int STEM_DOWN = Stem.DOWN;
        private void Init(StaveNoteStruct noteStruct)
        {
            this.keys = noteStruct.keys;
            this.clef = noteStruct.clef;
            this.beam = null;
            // Pull note rendering properties
            this.glyph = Flow.DurationToGlyph(this.duration,this.noteType);
            if(this.glyph == null)
            {
                throw new Exception("BadArguments,Invalid note initialization data (No glyph found): ");
                // 冒号后面+JSON.stringify(note_struct)
            }

            // if true, displace note to right
            this.displaced = false;
            this.dotShiftY = 0;
            // per-pitch properties
            this.keyProps = new List<NoteProps>();
            //for displaced ledger lines
            this.useDefaultHeadX = false;

            // Drawing
            this.noteHeads = new List<NoteHead>();
            this.modifiers = new List<Modifier>();

            this.renderOptions = new StaveNoteRenderOpts() {
                // font size for note heads and rests
                glyphFontScale = 35,
                // number of stroke px to the left and right of head
                strokePx = 3
            };

            this.CalculateKeyProps();
            this.BuildStem();

            // Set the stem direction
            if(noteStruct.autoStem.HasValue)
            {
                this.AutoStem();
            }
            else
            {
                this.StemDirection = noteStruct.stemDirection;
            }
            this.BuildNoteHeads();
            // Calculate left/right padding
            this.CalcExtraPx();
        }
        /// <summary>
        /// Builds a `Stem` for the note
        /// </summary>
        public new void BuildStem()
        {
            Glyph4StaveNote glyph = this.Glyph as Glyph4StaveNote;
            double yExtend = 0;
            //里程碑2时把codeHead改成枚举类型而不是字符串
            //需要研究这两个glyph在音乐上的名称
            if(glyph.codeHead == "v95" || glyph.codeHead == "v3e")
            {
                yExtend = -4;
            }

            Stem stem = new Stem(new StemOpts() { yExtend = yExtend });
            //里程碑2时将IsRest()重命名为IsARestNote()
            if(this.IsRest())
            {
                stem.hide = true;
            }
            this.Stem = stem;
        }
        /// <summary>
        /// Builds a `NoteHead` for each key in the note
        /// </summary>
        public void BuildNoteHeads()
        {
            int? stemDirection = this.StemDirection;
            IList<string> keys = this.Keys;

            double? lastLine = null;
            double? lineDiff = null;
            bool displaced = false;

            // Draw notes from bottom to top.
            int startI = 0;
            int endI = keys.Count();
            int stepI = 1;

            // For down-stem notes, we draw from top to bottom.
            if(stemDirection.Value == Stem.DOWN)
            {
                startI = keys.Count() - 1;
                endI = -1;
                stepI = -1;
            }
            //这里!=不能用用<替代，因为stepI可以是负数，<判断会导致几乎遍历所有32位整数
            for(int i = startI;i != endI;i += stepI)
            {
                NoteProps noteProps = this.keyProps[i];
                double line = noteProps.line;
                // Keep track of last line with a note head, so that consecutive heads are correctly displaced.
                if(lastLine == null)
                {
                    lastLine = line;
                }
                else
                {
                    lineDiff = Math.Abs(lastLine.Value - line);
                    if(lineDiff == 0 || lineDiff == 0.5)
                    {
                        displaced = !displaced;
                    }
                    else
                    {
                        displaced = false;
                        this.useDefaultHeadX = true;
                    }
                }
                lastLine = line;

                NoteHead noteHead = new NoteHead(new NoteHeadStruct() {
                    duration = this.duration,
                    noteType = this.noteType,
                    displaced = displaced,
                    stemDirection = stemDirection,
                    customGlyphCode = noteProps.code,
                    glyphFontScale = (this.renderOptions as StaveNoteRenderOpts).glyphFontScale,
                    xShift = noteProps.shiftRight,
                    line = noteProps.line
                });
                this.noteHeads[i] = noteHead;
            }
        }
        /// <summary>
        /// Automatically sets the stem direction based on the keys in the note
        /// </summary>
        public void AutoStem()
        {
            int autoStemDirection;

            // Figure out optimal stem direction based on given notes
            this.minLine = this.keyProps[0].line;
            this.maxLine = this.keyProps[this.keyProps.Count() - 1].line;
            double decider = (this.minLine + this.maxLine) / 2;
            //里程碑2时考虑这个3是否需要抽象出参数而非写死的
            //让人这个3可能和五线谱中线对应，那就可以写死，除非要做不是5线的谱
            if(decider < 3)
            {
                autoStemDirection = Stem.UP;
            }
            else
            {
                autoStemDirection = Stem.DOWN;
            }
            this.StemDirection = autoStemDirection;
        }
        /// <summary>
        /// Calculates and stores the properties for each key in the note
        /// </summary>
        public void CalculateKeyProps()
        {
            double? lastLine = null;
            for(int i = 0;i < this.keys.Count();i++)
            {
                string key = this.keys[i];

                // All rests use the same position on the line.
                if(this.glyph.rest)
                    this.glyph.position = key;
                NoteProps props = Flow.KeyProperties(key,this.clef);
                if(props == null)
                {
                    throw new Exception("BadArguments,Invalid key for note properties: " + key);
                }

                // Calculate displacement of this note
                double line = props.line;
                if(lastLine == null)
                {
                    lastLine = line;
                }
                else
                {
                    //一个double等于0.5不是一个好的判别
                    //里程碑2时考虑使用Fraction类型判断是否等于new Fracion(1,2)
                    if(Math.Abs(lastLine.Value - line) == 0.5)
                    {
                        this.displaced = true;
                        props.displaced = true;
                        // Have to mark the previous note as
                        // displaced as well, for modifier placement
                        if(this.keyProps.Count() > 0)
                        {
                            this.keyProps[i].displaced = true;
                        }
                    }
                }
                lastLine = line;
                this.keyProps.Add(props);
            }

            // Sort the notes from lowest line to highest line
            this.keyProps = this.keyProps.OrderBy(props => props.line).ToList();
            //检查一下这个LINQ是否符合原js本意，及按照line从小到大排序。
        }
        /// <summary>
        /// Get modifier category for `ModifierContext`
        /// </summary>
        public override string Category
        {
            get
            {
                return "stavenotes";
            }
        }
        /// <summary>
        /// Get the `BoundingBox` for the entire note
        /// </summary>
        public override object BoundingBox
        {
            get
            {
                if(!this.preFormatted)
                {
                    throw new Exception("UnformattedNote,Can't call getBoundingBox on an unformatted note.");
                }

                NoteMetrics metrics = this.Metrics;
                double w = metrics.width;
                double x = this.AbsoluteX - metrics.modLeftPx - metrics.extraLeftPx;

                double? minY = 0;
                double? maxY = 0;
                double halfLineSpacing = this.Stave.GetSpacingBetweenLines() / 2;
                double lineSpacing = halfLineSpacing * 2;

                if(this.IsRest())
                {
                    double y = this.ys[0];
                    //里程碑2阶段duration改用Fraction类型。
                    if(this.duration == "w" || this.duration == "h" || this.duration == "1" || this.duration == "2")
                    {
                        minY = y - halfLineSpacing;
                        maxY = y + halfLineSpacing;
                    }
                    else
                    {
                        minY = y - this.glyph.lineAbove * lineSpacing;
                        maxY = y + this.glyph.lineBelow * lineSpacing;
                    }
                }
                else if(this.glyph.stem)
                {
                    StemExtents ys = this.StemExtents;
                    ys.baseY += halfLineSpacing * this.stemDirection.Value;
                    minY = Math.Min(ys.topY,ys.baseY);
                    maxY = Math.Max(ys.topY,ys.baseY);
                }
                else
                {
                    minY = null;
                    maxY = null;
                    for(int i = 0;i < this.ys.Count();i++)
                    {
                        double yy = this.ys[i];
                        if(i == 0)
                        {
                            minY = yy;
                            maxY = yy;
                        }
                        else
                        {
                            minY = Math.Min(yy,minY.Value);
                            maxY = Math.Max(yy,maxY.Value);
                        }
                        minY -= halfLineSpacing;
                        maxY += halfLineSpacing;
                    }
                }
                return new BoundingBox(x,minY.Value,w,maxY.Value - minY.Value);
            }
        }
        /// <summary>
        /// Gets the line number of the top or bottom note in the chord. If `is_top_note` is `true` then get the top note
        /// </summary>
        public double GetLineNumber(bool isTopNote)
        {
            if(this.keyProps.Count() <= 0)
            {
                throw new Exception("NoKeyProps,Can't get bottom note line, because note is not initialized properly.");
            }
            double resultLine = this.keyProps[0].line;
            // No precondition assumed for sortedness of keyProps array
            for(int i = 0;i < this.keyProps.Count();i++)
            {
                double thisLine = this.keyProps[i].line;
                //原js太容易歧义了，VS的嵌套层次识别和作者本意就不同
                //下面这样才是本意
                if((isTopNote && thisLine > resultLine) ||
                    (!isTopNote && thisLine < resultLine))
                    resultLine = thisLine;
            }
            return resultLine;
        }
        /// <summary>
        /// Determine if current note is a rest
        /// </summary>
        public override bool IsRest()
        {
            return this.glyph.rest;
        }
        /// <summary>
        /// Determine if the current note is a chord
        /// </summary>
        public bool IsChord()
        {
            return !this.IsRest() && this.keys.Count() > 1;
        }
        /// <summary>
        /// Determine if the `StaveNote` has a stem
        /// </summary>
        public new bool HasStem()
        {
            return this.glyph.stem;
        }
        /// <summary>
        /// Get the `y` coordinate for text placed on the top/bottom of a note at a desired `text_line`
        /// </summary>
        public override double GetYForTopText(double textLine)
        {
            StemExtents extents = this.StemExtents;
            return Math.Min(this.stave.GetYForTopText(textLine),
                extents.topY - (this.renderOptions.annotationSpacing * (textLine + 1)));
        }
        public double GetYForBottomText(double textLine)
        {
            StemExtents extents = this.StemExtents;
            return Math.Max(this.stave.GetYForTopText(textLine),
                extents.baseY + (this.renderOptions.annotationSpacing * textLine));
        }
        /// <summary>
        /// Sets the current note to the provided `stave`. This applies `y` values to the `NoteHeads`.
        /// </summary>
        public override Stave Stave
        {
            set
            {
                base.Stave = value;
                //LINQ可以实现从js的高度对应直译
                IList<double> ys = this.noteHeads.Select(noteHead => {
                    noteHead.Stave = value;
                    return noteHead.Y;
                }).ToList();
                this.Ys = ys;

                NoteHeadBounds bounds = this.GetNoteHeadBounds();
                this.stem.SetYBounds(bounds.yTop,bounds.yBottom);
            }
        }
        /// <summary>
        /// Get the pitches in the note
        /// </summary>
        public IList<string> Keys
        {
            get
            { return this.keys; }
        }
        /// <summary>
        /// Get the properties for all the keys in the note
        /// </summary>
        public IList<NoteProps> KeyProps
        {
            get
            { return this.keyProps; }
        }
        /// <summary>
        /// Check if note is shifted to the right
        /// </summary>
        public bool IsDisplaced()
        {
            return this.displaced;
        }
        /// <summary>
        /// Sets whether shift note to the right. `displaced` is a `boolean`
        /// </summary>
        public bool NoteDisplaced
        {
            set
            {
                this.displaced = value;
            }
        }
        /// <summary>
        /// Get the starting `x` coordinate for a `StaveTie`
        /// </summary>
        public double GetTieRightX()
        {
            double tieStartX = this.AbsoluteX;
            tieStartX += this.glyph.headWidth + this.xShift + this.extraRightPx;
            if(this.modifierContext != null)
            {
                tieStartX += this.modifierContext.GetExtraRightPx();
            }
            return tieStartX;
        }
        /// <summary>
        /// Get the ending `x` coordinate for a `StaveTie`
        /// </summary>
        public double GetTieLeftX()
        {
            double tieEndX = this.AbsoluteX;
            tieEndX += this.xShift = this.extraLeftPx;
            return tieEndX;
        }
        /// <summary>
        /// Get the stave line on which to place a rest
        /// </summary>
        public double GetLineForRest()
        {
            double restLine = this.keyProps[0].line;
            if(this.keyProps.Count() > 1)
            {
                //提前做了里程碑2阶段的事情，一个小优化，增加代码可读性
                double lastLine = this.keyProps.Last().line;
                //double lastLine = this.keyProps[this.keyProps.Count() - 1].line;
                double top = Math.Max(restLine,lastLine);
                double bot = Math.Min(restLine,lastLine);
                restLine = Vex.MidLine(top,bot);
            }
            return restLine;
        }
        /// <summary>
        /// Get the default `x` and `y` coordinates for the provided `position` and key `index`
        /// </summary>
        public ModifierStartXY GetModifierStartXY(Modifier.ModifierPosition position,int index)
        {
            if(!this.preFormatted)
            {
                throw new Exception("UnformattedNote,Can't call GetModifierStartXY on an unformatted note");
            }
            if(this.ys.Count() == 0)
            {
                throw new Exception("NoYValues,No Y-Values calculated for this note.");
            }

            double x = 0;
            if(position == Modifier.ModifierPosition.LEFT)
            {
                // extra_left_px
                x = -1 * 2;
            }
            else if(position == Modifier.ModifierPosition.RIGHT)
            {
                // extra_right_px
                x = this.glyph.headWidth + this.xShift + 2;
            }
            else if(position == Modifier.ModifierPosition.BELOW || position == Modifier.ModifierPosition.ABOVE)
            {
                x = this.glyph.headWidth / 2;
            }

            return new ModifierStartXY() { x = this.AbsoluteX + x,y = this.ys[index] };
        }
        /// <summary>
        /// Sets the notehead at `index` to the provided coloring `style`.
        //`style` is an `object` with the following properties: `shadowColor`, `shadowBlur`, `fillStyle`, `strokeStyle`
        /// </summary>
        public StaveNote SetKeyStyle(int index,NoteHeadStyle style)
        {
            this.noteHeads[index].Style = style;
            return this;
        }
        /// <summary>
        /// Add self to modifier context. `mContext` is the `ModifierContext`  to be added to.
        /// </summary>
        public new StaveNote AddToModifierContext(ModifierContext mContext)
        {
            this.modifierContext = mContext;
            for(int i = 0;i < this.modifiers.Count();i++)
            {
                this.modifierContext.AddModifier(this.modifiers[i]);
            }
            //还不确定modifierContext.AddModifier方法的参数类型。目前是obj
            this.modifierContext.AddModifier(this);
            this.PreFormatted = false;
            return this;
        }
        /// <summary>
        ///Generic function to add modifiers to a note
        /// 
        /// Parameters:
        /// * `index`: The index of the key that we're modifying
        /// * `modifier`: The modifier to add
        /// </summary>
        public StaveNote AddModifier(int index,Modifier modifier)
        {
            modifier.Note = this;
            modifier.Index = index;
            this.modifiers.Add(modifier);
            this.PreFormatted = false;
            return this;
        }
        /// <summary>
        /// Helper function to add an accidental to a key
        /// </summary>
        public StaveNote AddAccidental(int index,Accidental accidental)
        {
            return this.AddModifier(index,accidental);
        }
        /// <summary>
        /// Helper function to add an articulation to a key
        /// </summary>
        public StaveNote AddArticulation(int index,Articulation articulation)
        {
            return this.AddModifier(index,articulation);
        }
        /// <summary>
        /// Helper function to add an annotation to a key
        /// </summary>
        public StaveNote AddAnnotation(int index,Annotation annotation)
        {
            return this.AddModifier(index,annotation);
        }
        /// <summary>
        /// Helper function to add a dot on a specific key
        /// </summary>
        //里程碑2时把这类方法抽象到基类中减少重复实现
        public StaveNote AddDot(int index)
        {
            Dot dot = new Dot();
            dot.DotShiftY = this.glyph.dot_shiftY;
            this.dots++;
            return this.AddModifier(index,dot);
        }
        /// <summary>
        /// Convenience method to add dot to all keys in note
        /// </summary>
        public StaveNote AddDotToAll()
        {
            for(int i = 0;i < this.keys.Count();++i)
            {
                this.AddDot(i);
            }
            return this;
        }
        /// <summary>
        /// Get all accidentals in the `ModifierContext`
        /// </summary>
        public object GetAccidentals()
        {
            return this.modifierContext.GetModifiers("accidentals");
        }
        /// <summary>
        /// Get all dots in the `ModifierContext`
        /// </summary>
        public object GetDots()
        {
            return this.modifierContext.GetModifiers("dots");
        }
        /// <summary>
        /// Get the width of the note if it is displaced. Used for `Voice` formatting
        /// </summary>
        public double GetVoiceShiftWidth()
        {
            // TODO: may need to accomodate for dot here.
            return this.glyph.headWidth * (this.displaced ? 2 : 1);
        }
        /// <summary>
        /// Calculates and sets the extra pixels to the left or right if the note is displaced
        /// </summary>
        public void CalcExtraPx()
        {
            this.ExtraLeftPx = this.displaced && this.stemDirection == Stem.DOWN ? this.glyph.headWidth : 0;
            this.ExtraRightPx = this.displaced && this.stemDirection == Stem.UP ? this.glyph.headWidth : 0;
        }
        /// <summary>
        /// Pre-render formatting
        /// </summary>
        public override void PreFormat()
        {
            if(this.preFormatted)
                return;
            if(this.modifierContext != null)
                this.modifierContext.PreFormat();

            double width = this.glyph.headWidth + this.extraLeftPx + this.extraRightPx;

            // For upward flagged notes, the width of the flag needs to be added
            if(this.glyph.flag && this.beam == null && this.stemDirection == Stem.UP)
            {
                width += this.glyph.headWidth;
            }
            this.SetWidth(width);
            this.PreFormatted = true;
        }
        /// <summary>
        /// Gets the staff line and y value for the highest and lowest noteheads
        /// </summary>
        public NoteHeadBounds GetNoteHeadBounds()
        {
            // Top and bottom Y values for stem.
            double? yTop = null;
            double? yBottom = null;

            double highestLine = this.stave.GetNumLines();
            double lowestLine = 1;

            foreach(var noteHead in this.noteHeads)
            {
                double line = noteHead.Line;
                double y = noteHead.Y;
                if(yTop == null || y < yTop.Value)
                {
                    yTop = y;
                }
                if(yBottom == null || y > yBottom)
                {
                    yBottom = y;
                }
                highestLine = line > highestLine ? line : highestLine;
                lowestLine = line < lowestLine ? line : lowestLine;
            }
            return new NoteHeadBounds() {
                yTop = yTop.Value,
                yBottom = yBottom.Value,
                highestLine = highestLine,
                lowestLine = lowestLine
            };
        }
        /// <summary>
        /// Get the starting `x` coordinate for the noteheads
        /// </summary>
        public double GetNoteHeadBeginX()
        {
            return this.AbsoluteX + this.xShift;
        }
        /// <summary>
        /// Get the ending `x` coordinate for the noteheads
        /// </summary>
        public double GetNoteHeadEndX()
        {
            double xBegin = this.GetNoteHeadBeginX();
            return xBegin + this.glyph.headWidth - (Flow.STEM_WIDTH / 2);
        }
        /// <summary>
        /// Draw the ledger lines between the stave and the highest/lowest keys
        /// </summary>
        public void DrawLedgerLines()
        {
            //           if (!this.context) throw new Vex.RERR("NoCanvasContext",
            //    "Can't draw without a canvas context.");
            //var ctx = this.context;

            //var bounds = this.getNoteHeadBounds();
            //var highest_line = bounds.highest_line;
            //var lowest_line = bounds.lowest_line;
            //var head_x = this.note_heads[0].getAbsoluteX();

            //var that = this;
            //function stroke(y) {
            //  if (that.use_default_head_x === true)  {
            //    head_x = that.getAbsoluteX() + that.x_shift;
            //  }
            //  var x = head_x - that.render_options.stroke_px;
            //  var length = ((head_x + that.glyph.head_width) - head_x) +
            //    (that.render_options.stroke_px * 2);

            //  ctx.fillRect(x, y, length, 1);
            //}

            //var line; // iterator
            //for (line = 6; line <= highest_line; ++line) {
            //  stroke(this.stave.getYForNote(line));
            //}

            //for (line = 0; line >= lowest_line; --line) {
            //  stroke(this.stave.getYForNote(line));
            //}
        }
        /// <summary>
        /// Draw all key modifiers
        /// </summary>
        public void DrawModifiers()
        {
            //      if (!this.context) throw new Vex.RERR("NoCanvasContext",
            //"Can't draw without a canvas context.");
            //      var ctx = this.context;
            //      for (var i = 0; i < this.modifiers.length; i++)
            //      {
            //          var mod = this.modifiers[i];
            //          var note_head = this.note_heads[mod.getIndex()];
            //          var key_style = note_head.getStyle();
            //          if (key_style)
            //          {
            //              ctx.save();
            //              note_head.applyKeyStyle(ctx);
            //          }
            //          mod.setContext(ctx);
            //          mod.draw();
            //          if (key_style)
            //          {
            //              ctx.restore();
            //          }
            //      }
        }
        /// <summary>
        /// Draw the flag for the note
        /// </summary>
        public void DrawFlag()
        {
            //           if (!this.context) throw new Vex.RERR("NoCanvasContext",
            //    "Can't draw without a canvas context.");
            //var ctx = this.context;
            //var glyph = this.getGlyph();
            //var render_flag = this.beam === null;
            //var bounds = this.getNoteHeadBounds();

            //var x_begin = this.getNoteHeadBeginX();
            //var x_end = this.getNoteHeadEndX();

            //if (glyph.flag && render_flag) {
            //  var note_stem_height = this.stem.getHeight();
            //  var flag_x, flag_y, flag_code;

            //  if (this.getStemDirection() === Stem.DOWN) {
            //    // Down stems have flags on the left.
            //    flag_x = x_begin + 1;
            //    flag_y = bounds.y_top - note_stem_height + 2;
            //    flag_code = glyph.code_flag_downstem;

            //  } else {
            //    // Up stems have flags on the left.
            //    flag_x = x_end + 1;
            //    flag_y = bounds.y_bottom - note_stem_height - 2;
            //    flag_code = glyph.code_flag_upstem;
            //  }

            //  // Draw the Flag
            //  Vex.Flow.renderGlyph(ctx, flag_x, flag_y,
            //      this.render_options.glyph_font_scale, flag_code);
            //}
        }
        /// <summary>
        /// Draw the NoteHeads
        /// </summary>
        public void DrawNoteHeads()
        {
            //          this.note_heads.forEach(function(note_head) {
            //  note_head.setContext(this.context).draw();
            //}, this);
        }
        /// <summary>
        /// Render the stem onto the canvas
        /// </summary>
        public void DrawStem()
        {
            //      if (!this.context) throw new Vex.RERR("NoCanvasContext",
            //"Can't draw without a canvas context.");

            //      if (stem_struct)
            //      {
            //          this.setStem(new Stem(stem_struct));
            //      }

            //      this.stem.setContext(this.context).draw();
        }
        /// <summary>
        /// Draws all the `StaveNote` parts. This is the main drawing method.
        /// </summary>
        public virtual void Draw()
        {
            //            if (!this.context) throw new Vex.RERR("NoCanvasContext",
            //      "Can't draw without a canvas context.");
            //  if (!this.stave) throw new Vex.RERR("NoStave",
            //      "Can't draw without a stave.");
            //  if (this.ys.length === 0) throw new Vex.RERR("NoYValues",
            //      "Can't draw note without Y values.");

            //  var x_begin = this.getNoteHeadBeginX();
            //  var x_end = this.getNoteHeadEndX();

            //  var render_stem = this.hasStem() && !this.beam;

            //  // Format note head x positions
            //  this.note_heads.forEach(function(note_head) {
            //    note_head.setX(x_begin);
            //  }, this);

            //  // Format stem x positions
            //  this.stem.setNoteHeadXBounds(x_begin, x_end);

            //  L("Rendering ", this.isChord() ? "chord :" : "note :", this.keys);

            //  // Draw each part of the note
            //  this.drawLedgerLines();
            //  if (render_stem) this.drawStem();
            //  this.drawNoteHeads();
            //  this.drawFlag();
            //  this.drawModifiers();
            //}
        }
        #endregion


        #region 隐含字段
        protected string clef;
        protected double dotShiftY;
        protected bool useDefaultHeadX;
        IList<NoteHead> noteHeads;
        IList<string> keys;
        IList<NoteProps> keyProps;
        bool displaced;
        double minLine;
        double maxLine;
        #endregion
    }
}
