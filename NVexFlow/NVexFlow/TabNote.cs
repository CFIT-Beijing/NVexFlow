using System;
//tabnote.js
using System.Collections.Generic;
using NVexFlow.Model;
using System.Linq;
namespace NVexFlow
{
    /// <summary>
    ///  ## Description
    //
    // The file implements notes for Tablature notation. This consists of one or
    // more fret positions, and can either be drawn with or without stems.
    //
    // See `tests/tabnote_tests.js` for usage examples
    /// </summary>
    public class TabNote : StemmableNote
    {
        #region js直译部分
        public TabNote(TabNoteStruct tabStruct, bool drawStem)
            : base(tabStruct)
        { Init(tabStruct, drawStem); }
        /// <summary>
        /// Initialize the TabNote with a `tab_struct` full of properties and whether to `draw_stem` when rendering the note
        /// </summary>
        private void Init(TabNoteStruct tabStruct, bool drawStem)
        {
            this.ghost = false; // Renders parenthesis around notes
            // Note properties
            //
            // The fret positions in the note. An array of `{ str: X, fret: X }`

            this.positions = tabStruct.positions;

            // Render Options
            // font size for note heads and rests
            (this.renderOptions as TabNoteRenderOpts).glyphFontScale = 30;
            // Flag to draw a stem
            (this.renderOptions as TabNoteRenderOpts).drawStem = drawStem;
            // Flag to draw dot modifiers
            (this.renderOptions as TabNoteRenderOpts).drawDots = drawStem;
            // Flag to extend the main stem through the stave and fret positions
            (this.renderOptions as TabNoteRenderOpts).drawStemThroughStave = false;

            this.glyph = Flow.DurationToGlyph(this.duration, this.noteType);
            if (this.glyph == null)
            {
                throw new Exception("BadArguments,Invalid note initialization data (No glyph found): ");//
                //  throw new Vex.RuntimeError("BadArguments",
                //      "Invalid note initialization data (No glyph found): " +
                //      JSON.stringify(tab_struct));
                //}
            }
            this.BuildStem();
            this.StemDirection = Stem.UP;

            // Renders parenthesis around notes
            this.ghost = false;
            this.UpdateWidth();
        }
        /// <summary>
        /// The ModifierContext category
        /// </summary>
        public override string Category
        {
            get
            {
                return "tabnotes";
            }
        }
        /// <summary>
        /// Set as ghost `TabNote`, surrounds the fret positions with parenthesis.Often used for indicating frets that are being bent to
        /// </summary>
        public bool Ghost
        {
            set
            {
                this.ghost = value;
                UpdateWidth();
            }
        }
        /// <summary>
        /// Determine if the note has a stem
        /// </summary>
        public override bool HasStem()
        {
            return (this.renderOptions as TabNoteRenderOpts).drawStem;
        }
        /// <summary>
        /// Get the default stem extension for the note
        /// </summary>
        public double GetStemExtension()
        {
            Glyph4Note glyph = this.Glyph;
            if (this.stemExtensionOverride != null)
            {
                return this.stemExtensionOverride.Value;
            }
            if (glyph != null)
            {//this.StemDirection == 1在里程碑2时用类似this.StemDirection == Stem.UP的形式替代
                //完成
                return this.StemDirection == Stem.UP ? glyph.tabnoteStemUpExtension : glyph.tabnoteStemDownExtension;
            }
            return 0;
        }
        /// <summary>
        /// Add a dot to the note
        /// </summary>
        public TabNote AddDot()
        {
            Dot dot = new Dot();
            this.dots++;
            this.AddModifier(dot, 0);
            return this;
        }
        /// <summary>
        /// Calculate and store the width of the note
        /// </summary>
        public void UpdateWidth()
        {
            this.glyphs = new List<Glyph4Note>();
            this.width = 0;
            for (int i = 0;
            i < this.positions.Count();
            i++)
            {
                string fret = this.positions[i].fret.ToString();
                if (this.ghost)
                    fret = "(" + fret + ")";
                Glyph4TabNote glyph = Flow.TabToGlyph(fret);
                this.glyphs.Add(glyph);
                this.width = (glyph.width > this.width) ? glyph.width : this.width;
            }
        }
        /// <summary>
        /// Set the `stave` to the note
        /// </summary>
        public override Stave Stave
        {
            set
            {
                base.Stave = value;
                this.context = value.context;
                this.width = 0;

                // Calculate the fret number width based on font used
                int i;
                if (this.context != null)
                {
                    for (i = 0;
                    i < this.glyphs.Count();
                    i++)
                    {
                        string text = "" + (this.glyphs[i] as Glyph4TabNote).text;
                        if (text.ToUpper() != "X")
                        {
                            (this.glyphs[i] as Glyph4TabNote).width = this.context.MeasureText(text).width;
                        }
                        this.width = (this.glyphs[i] as Glyph4TabNote).width > this.width ? (this.glyphs[i] as Glyph4TabNote).width : this.width;
                    }
                }
                IList<double> ys = new List<double>();
                // Setup y coordinates for score.
                for (i = 0;
                i < this.positions.Count();
                i++)
                {
                    int line = this.positions[i].str;
                    ys.Add(this.stave.GetYForLine(line - 1));
                }
                this.Ys = ys;
            }
        }
        /// <summary>
        /// Get the fret positions for the note
        /// </summary>
        public IList<TabNotePos> Positions
        {
            get
            { return this.positions; }
        }
        /// <summary>
        /// Add self to the provided modifier context `mc`
        /// </summary>
        public new TabNote AddToModifierContext(ModifierContext mc)
        {
            this.ModifierContext = mc;
            for (int i = 0;
            i < this.modifiers.Count();
            i++)
            {
                this.modifierContext.AddModifier(this.modifiers[i]);
            }
            this.modifierContext.AddModifier(this);
            this.preFormatted = false;
            return this;
        }
        /// <summary>
        /// Get the `x` coordinate to the right of the note
        /// </summary>
        public double GetTieRightX()
        {
            double tieStartX = this.AbsoluteX;
            double noteGlyphWidth = this.glyph.headWidth;
            tieStartX += noteGlyphWidth / 2;
            tieStartX += -this.width / 2 + this.width + 2;
            return tieStartX;
        }
        /// <summary>
        /// Get the `x` coordinate to the left of the note
        /// </summary>
        public double GetTieLeftX()
        {
            double tieEndX = this.AbsoluteX;
            double noteGlyphWidth = this.glyph.headWidth;
            tieEndX += noteGlyphWidth / 2;
            tieEndX -= this.width / 2 + 2;
            return tieEndX;
        }
        /// <summary>
        /// Get the default `x` and `y` coordinates for a modifier at a specific `position` at a fret position `index`
        /// </summary>
        public object GetModifierStartXY(Modifier.ModifierPosition position, int index)
        {
            if (!this.preFormatted)
                throw new Exception("UnformattedNote,Can't call GetModifierStartXY on an unformatted note");
            //               if (!this.preFormatted) throw new Vex.RERR("UnformattedNote",
            //    "Can't call GetModifierStartXY on an unformatted note");
            if (this.ys.Count() <= 0)
                throw new Exception("NoYValues,No Y-Values calculated for this note.");
            double x = 0;
            if (position == Modifier.ModifierPosition.LEFT)
            {
                x = -1 * 2;// extra_left_px
            }
            else if (position == Modifier.ModifierPosition.RIGHT)
            {
                x = this.width + 2;// extra_right_px
            }
            else if (position == Modifier.ModifierPosition.BELOW || position == Modifier.ModifierPosition.ABOVE)
            {
                double noteGlyphWidth = this.glyph.headWidth;
                x = noteGlyphWidth / 2;
            }
            return new TabNoteModifierStartXY() { x = this.AbsoluteX + x, y = this.ys[index] };
        }
        /// <summary>
        /// Get the default line for rest
        /// </summary>
        public int GetLineForRest()
        {
            return this.positions[0].str;
        }
        /// <summary>
        /// Pre-render formatting
        /// </summary>
        public override void PreFormat()
        {
            if (this.preFormatted)
                return;
            if (this.modifierContext != null)
                this.modifierContext.PreFormat();
            // width is already set during init()
            this.PreFormatted = true;
        }
        /// <summary>
        /// Get the x position for the stem
        /// </summary>
        public double GetStemX()
        {
            return this.CenterGlyphX;
        }
        /// <summary>
        /// Get the y position for the stem
        /// </summary>
        public double GetStemY()
        {
            double numLines = this.stave.NumLines;
            // The decimal staff line amounts provide optimal spacing between the fret number and the stem
            double stemUpLine = -0.5;
            double stemDownLine = numLines - 0.5;
            double stemStartLine = Stem.UP == this.stemDirection ? stemUpLine : stemDownLine;
            return this.stave.GetYForLine(stemStartLine);
        }
        /// <summary>
        /// Get the stem extents for the tabnote
        /// </summary>
        public TabNoteStemExtents GetStemExtents()
        {
            //              var stem_base_y = this.getStemY();
            //var stem_top_y = stem_base_y + (Stem.HEIGHT * -this.stem_direction);
            double stemBaseY = this.GetStemY();
            double stemTopY = stemBaseY + Stem.HEIGHT * -this.stemDirection.Value;
            return new TabNoteStemExtents() { baseY = stemBaseY, topY = stemTopY };
        }
        /// <summary>
        /// Draw the fal onto the context
        /// </summary>
        public void DrawFlag()
        {
            bool renderStem = this.beam == null && (this.renderOptions as TabNoteRenderOpts).drawStem;
            bool renderFlag = this.beam == null && renderStem;
            // Now it's the flag's turn.
            if (this.glyph.flag && renderFlag)
            {
                double flagX = this.StemX + 1;
                double flagY = this.GetStemY() - this.stem.GetHeight();
                object flagCode;
                if (this.stemDirection == Stem.DOWN)
                {
                    // Down stems have flags on the left.
                    flagCode = (this.glyph as Glyph4TabNote).codeFlagDownStem;
                }
                else
                {
                    flagCode = (this.glyph as Glyph4TabNote).codeFlagUpStem;
                }
                // Draw the Flag
                Flow.RenderGlyph(this.context, flagX, flagY, (this.renderOptions as TabNoteRenderOpts).glyphFontScale, flagCode);
            }
        }
        /// <summary>
        /// Render the modifiers onto the context
        /// </summary>
        public void DrawModifiers()
        {
            //          // Draw the modifiers
            //this.modifiers.forEach(function(modifier) {
            //  // Only draw the dots if enabled
            //  if (modifier.getCategory() === 'dots' && !this.render_options.draw_dots) return;

            //  modifier.setContext(this.context);
            //  modifier.draw();
            //}, this);
        }
        /// <summary>
        /// Render the stem extension through the fret positions
        /// </summary>
        public void DrawStemThrough()
        {
            //          var stem_x = this.getStemX();
            //var stem_y = this.getStemY();
            //var ctx = this.context;

            //var stem_through = this.render_options.draw_stem_through_stave;
            //var draw_stem = this.render_options.draw_stem;
            //if (draw_stem && stem_through) {
            //  var total_lines = this.stave.getNumLines();
            //  var strings_used = this.positions.map(function(position) {
            //    return position.str;
            //  });

            //  var unused_strings = getUnusedStringGroups(total_lines, strings_used);
            //  var stem_lines = getPartialStemLines(stem_y, unused_strings,
            //                        this.getStave(), this.getStemDirection());

            //  // Fine tune x position to match default stem
            //  if (!this.beam || this.getStemDirection() === 1) {
            //    stem_x += (Stem.WIDTH / 2);
            //  }

            //  ctx.save();
            //  ctx.setLineWidth(Stem.WIDTH);
            //  stem_lines.forEach(function(bounds) {
            //    ctx.beginPath();
            //    ctx.moveTo(stem_x, bounds[0]);
            //    ctx.lineTo(stem_x, bounds[bounds.length - 1]);
            //    ctx.stroke();
            //    ctx.closePath();
            //  });
            //  ctx.restore();
            //}
        }
        /// <summary>
        /// Render the fret positions onto the context
        /// </summary>
        public void DrawPositions()
        {
            //var ctx = this.context;
            //var x = this.getAbsoluteX();
            //var ys = this.ys;
            //var y;

            //for (var i = 0; i < this.positions.length; ++i)
            //{
            //    y = ys[i];

            //    var glyph = this.glyphs[i];

            //    // Center the fret text beneath the notation note head
            //    var note_glyph_width = this.glyph.head_width;
            //    var tab_x = x + (note_glyph_width / 2) - (glyph.width / 2);

            //    ctx.clearRect(tab_x - 2, y - 3, glyph.width + 4, 6);

            //    if (glyph.code)
            //    {
            //        Vex.Flow.renderGlyph(ctx, tab_x, y + 5 + glyph.shift_y,
            //            this.render_options.glyph_font_scale, glyph.code);
            //    }
            //    else
            //    {
            //        var text = glyph.text.toString();
            //        ctx.fillText(text, tab_x, y + 5);
            //    }
            //}
        }
        /// <summary>
        /// The main rendering function for the entire note
        /// </summary>
        public void Draw()
        {
            //             if (!this.context) throw new Vex.RERR("NoCanvasContext",
            //      "Can't draw without a canvas context.");
            //  if (!this.stave) throw new Vex.RERR("NoStave", "Can't draw without a stave.");
            //  if (this.ys.length === 0) throw new Vex.RERR("NoYValues",
            //      "Can't draw note without Y values.");

            //  var render_stem = this.beam == null && this.render_options.draw_stem;

            //  this.drawPositions();
            //  this.drawStemThrough();

            //  var stem_x = this.getStemX();
            //  var stem_y = this.getStemY();
            //  if (render_stem) {
            //    this.drawStem({
            //      x_begin: stem_x,
            //      x_end: stem_x,
            //      y_top: stem_y,
            //      y_bottom: stem_y,
            //      y_extend: 0,
            //      stem_extension: this.getStemExtension(),
            //      stem_direction: this.stem_direction
            //    });
            //  }

            //  this.drawFlag();
            //  this.drawModifiers();
            //}
        }

        // ## Private Helpers
        //
        /// <summary>
        /// Gets the unused strings grouped together if consecutive.
        //
        // Parameters:
        // * num_lines - The number of lines
        // * strings_used - An array of numbers representing which strings have fret positions
        /// </summary>
        /// <param name="num_lines"></param>
        /// <param name="strings_used"></param>
        /// <returns></returns>
        private object GetUnusedStringGroups(int numLines, object stringsUsed)
        {

            //                var stem_through = [];
            //var group = [];
            //for (var string = 1; string <= num_lines ; string++) {
            //  var is_used = strings_used.indexOf(string) > -1;

            //  if (!is_used) {
            //    group.push(string);
            //  } else {
            //    stem_through.push(group);
            //    group = [];
            //  }
            //}
            //if (group.length > 0) stem_through.push(group);

            //return stem_through;
            return null;
        }
        /// <summary>
        /// Gets groups of points that outline the partial stem lines between fret positions
        // 
        // Parameters:
        // * stem_Y - The `y` coordinate the stem is located on
        // * unused_strings - An array of groups of unused strings
        // * stave - The stave to use for reference
        // * stem_direction - The direction of the stem
        /// </summary>
        /// <param name="stem_y"></param>
        /// <param name="unused_strings"></param>
        /// <param name="stave"></param>
        /// <param name="stem_direction"></param>
        /// <returns></returns>
        private object GetPartialStemLines(double stem_y, object unused_strings, object stave, object stem_direction)
        {
            //                var up_stem = stem_direction !== 1;
            //var down_stem = stem_direction !== -1;

            //var line_spacing = stave.getSpacingBetweenLines();
            //var total_lines = stave.getNumLines();

            //var stem_lines = [];

            //unused_strings.forEach(function(strings) {
            //  var containsLastString = strings.indexOf(total_lines) > -1;
            //  var containsFirstString =  strings.indexOf(1) > -1;

            //  if ((up_stem && containsFirstString) ||
            //     (down_stem && containsLastString)) {
            //    return;
            //  }

            //  // If there's only one string in the group, push a duplicate value.
            //  // We do this because we need 2 strings to convert into upper/lower y
            //  // values.
            //  if (strings.length === 1) {
            //    strings.push(strings[0]);
            //  }

            //  var line_ys = [];
            //  // Iterate through each group string and store it's y position
            //  strings.forEach(function(string, index, strings) {
            //    var isTopBound = string === 1;
            //    var isBottomBound = string === total_lines;

            //    // Get the y value for the appropriate staff line,
            //    // we adjust for a 0 index array, since string numbers are index 1
            //    var y = stave.getYForLine(string - 1);

            //    // Unless the string is the first or last, add padding to each side
            //    // of the line
            //    if (index === 0 && !isTopBound) {
            //      y -= line_spacing/2 - 1;
            //    } else if (index === strings.length - 1 && !isBottomBound){
            //      y += line_spacing/2 - 1;
            //    }

            //    // Store the y value
            //    line_ys.push(y);

            //    // Store a subsequent y value connecting this group to the main
            //    // stem above/below the stave if it's the top/bottom string
            //    if (stem_direction === 1 && isTopBound) {
            //      line_ys.push(stem_y - 2);
            //    } else if (stem_direction === -1 && isBottomBound) {
            //      line_ys.push(stem_y + 2);
            //    }
            //  });

            //  // Add the sorted y values to the
            //  stem_lines.push(line_ys.sort(function(a, b) {
            //    return a - b;
            //  }));
            //});

            //return stem_lines;
            return null;
        }
        #endregion



        #region 隐含字段
        protected bool ghost;
        protected new IList<TabNotePos> positions;//暂时不知道note里的positions是什么类型，所以子类先自己定义一个positions
        protected IList<Glyph4Note> glyphs;
        #endregion



    }
}
