//stave.js
using System.Collections.Generic;
using NVexFlow.Model;
using System.Linq;
using System;

namespace NVexFlow
{
    public class Stave
    {
        #region js直译部分
        public Stave(double x, double y, double width, StaveOpts options = null)
        {
            Init(x, y, width, options);
        }
        double THICKNESS = Flow.STAVE_LINE_THICKNESS > 1 ? Flow.STAVE_LINE_THICKNESS : 0;
        private void Init(double x, double y, double width, StaveOpts options)
        {
            //        init: function(x, y, width, options) {
            this.x = x;
            this.y = y;
            this.width = width;
            this.glyphStartX = x + 5;
            this.glyphEndX = x + width;
            this.startX = this.glyphStartX;
            this.endX = this.glyphEndX;
            this.context = null;
            this.glyphs = new List<Glyph>();
            this.endGlyphs = new List<Glyph>();
            this.modifiers = new List<object>(); ;  // non-glyph stave items (barlines, coda, segno, etc.)
            this.measure = 0;
            this.clef = "treble";
            this.font = new Font()
            {
                family = "sans-serif",
                size = 8,
                weight = ""
            };
            this.options = new StaveOpts()
            {
                verticalBarWidth = 10,       // Width around vertical bar end-marker
                glyphSpacingPx = 10,
                numLines = 5,
                fillStyle = "#999999",
                spacingBetweenLinesPx = 10, // in pixels
                spaceAboveStaffIn = 4,      // in staff lines
                spaceBelowStaffIn = 4,      // in staff lines
                topTextPosition = 1          // in staff lines
            };
            this.bounds = new BoundingBox(this.x, this.y, this.width, 0);

            #region 此处现不写，还没找到外界传进来的options是什么+Vex.Merge(this.options, options);
            if (options != null)
            {

            }
            #endregion

            this.ResetLines();
            this.modifiers.Add(new Barline(Barline.BarlineType.SINGLE, this.x));// beg bar
            this.modifiers.Add(new Barline(Barline.BarlineType.SINGLE, this.x + this.width));// end bar
        }
        public void ResetLines()
        {
            this.options.lineConfig = new List<LineConfig>();
            for (int i = 0; i < this.options.numLines; i++)
            {
                this.options.lineConfig.Add(new LineConfig() { visible = true });
            }
            this.height = (this.options.numLines.Value + this.options.spaceAboveStaffIn.Value) + this.options.spacingBetweenLinesPx.Value;
            this.options.bottomTextPosition = this.options.numLines.Value + 1;
        }
        public Stave SetNoteStartX(double x)
        {
            this.startX = x;
            return this;
        }
        public double GetNoteStartX()
        {
            double startX = this.startX;
            // Add additional space if left barline is REPEAT_BEGIN and there are other start modifiers than barlines
            if ((this.modifiers[0] as Barline).barLine == Barline.BarlineType.REPEAT_BEGIN && this.modifiers.Count() > 2)
            {
                startX += 20;
            }
            return startX;
        }
        public double GetNoteEndX()
        {
            return this.endX;
        }
        public double GetTieStartX()
        {
            return this.startX;
        }
        public double GetTieEndX()
        {
            return this.endX;
        }
        public CanvasContext GetContext()
        {
            return this.context;
        }
        public Stave SetContext(CanvasContext context)
        {
            this.context = context;
            return this;
        }
        public double GetX()
        {
            return this.x;
        }
        public int GetNumLines()
        {
            return this.numLines;
        }
        public Stave SetNumLines(int lines)
        {
            this.options.numLines = lines;
            this.ResetLines();
            return this;
        }
        public Stave SetY(double y)
        {
            this.y = y;
            return this;
        }
        public Stave SetWidth(double width)
        {
            this.width = width;
            this.glyphEndX = this.x + width;
            this.endX = this.glyphEndX;
            // reset the x position of the end barline
            (this.modifiers[1] as Barline).SetX(this.endX);
            return this;
        }
        public double GetWidth()
        {
            return this.width;
        }
        public Stave SetMeasure(int measure)
        {
            this.measure = measure;
            return this;
        }
        // Bar Line functions
        public Stave SetBegBarType(Barline.BarlineType type)
        {
            // Only valid bar types at beginning of stave is none, single or begin repeat
            if (type == Barline.BarlineType.SINGLE ||
               type == Barline.BarlineType.REPEAT_BEGIN ||
                type == Barline.BarlineType.NONE)
            {
                this.modifiers[0] = new Barline(type, this.x);
            }
            return this;
        }
        public Stave SetEndBarType(Barline.BarlineType type)
        {
            // Repeat end not valid at end of stave
            if (type != Barline.BarlineType.REPEAT_BEGIN)
            {
                this.modifiers[1] = new Barline(type, this.x + this.width);
            }
            return this;
        }
        /**
 * Gets the pixels to shift from the beginning of the stave
 * following the modifier at the provided index
 * @param  {Number} index The index from which to determine the shift
 * @return {Number}       The amount of pixels shifted
 */
        public double GetModifierXShift(int? index)
        {
            if (!index.HasValue)
            {
                index = this.glyphs.Count() - 1;
            }
            double x = this.glyphStartX;
            double barXShift = 0;
            for (int i = 0; i < index + 1; ++i)
            {
                Glyph glyph = this.glyphs[i];
                x += glyph.GetMetrics().width;
                barXShift += glyph.GetMetrics().width;
            }
            // Add padding after clef, time sig, key sig
            if (barXShift > 0)
            {
                barXShift += this.options.verticalBarWidth.Value + 10;
            }
            return barXShift;
        }
        // Coda & Segno Symbol functions
        public Stave SetRepetitionTypeLeft(Repetition.RepetitionType type, double y)
        {
            // Coda & Segno Symbol functions
            this.modifiers.Add(new Repetition(type, this.x, y));
            return this;
        }
        public Stave SetRepetitionTypeRight(Repetition.RepetitionType type, double y)
        {
            this.modifiers.Add(new Repetition(type, this.x, y));
            return this;
        }
        // Volta functions
        public Stave SetVoltaType(Volta.VoltaType type, int numberT, double y)
        {
            this.modifiers.Add(new Volta(type, numberT, this.x, y));
            return this;
        }
        // Section functions
        public Stave SetSection(object section, double y)
        {
            this.modifiers.Add(new StaveSection(section, this.x, y));
            return this;
        }
        // Tempo functions
        public Stave SetTempo(Tempo tempo, double y)
        {
            this.modifiers.Add(new StaveTempo(tempo, this.x, y));
            return this;
        }
        // Text functions
        public Stave SetText(string text, Modifier.ModifierPosition position, StaveTextOpts options)
        {
            this.modifiers.Add(new StaveText(text, position, options));
            return this;
        }
        public double GetHeight()
        {
            return this.height;
        }
        public double GetSpacingBetweenLines()
        {
            return this.options.spacingBetweenLinesPx.Value;
        }
        public BoundingBox GetBoundingBox()
        {
            return new BoundingBox(this.x, this.y, this.width, this.GetBottomY() - this.y);
            // body...
        }
        public double GetBottomY()
        {
            StaveOpts options = this.options;
            double spacing = options.spacingBetweenLinesPx.Value;
            double scoreBottom = this.GetYForLine(options.numLines.Value) + options.spaceBelowStaffIn.Value * spacing;
            return scoreBottom;
        }
        public double BottomLineY()
        {
            return this.GetYForLine(this.options.numLines.Value);
        }
        public double GetYForLine(double line)
        {
            StaveOpts options = this.options;
            double spacing = options.spacingBetweenLinesPx.Value;
            double headRoom = options.spaceAboveStaffIn.Value;

            double y = this.y + (line * spacing + headRoom * spacing - THICKNESS / 2);
            return y;
        }
        public double GetYForTopText(double? line)
        {
            double l = line ?? 0;
            return this.GetYForLine(-l - this.options.topTextPosition.Value);
        }
        public double GetYForBottomText(double? line)
        {
            double l = line ?? 0;
            return this.GetYForLine(this.options.bottomTextPosition.Value + l);
        }
        public double GetYForNote(double line)
        {
            StaveOpts options = this.options;
            double spacing = options.spacingBetweenLinesPx.Value;
            double headRoom = options.spaceAboveStaffIn.Value;
            double y = this.y + headRoom * spacing + 5 * spacing - line * spacing;
            return y;
        }
        public virtual double GetYForGlyphs()
        {
            return this.GetYForLine(3);
        }
        public Stave AddGlyph(Glyph glyph)
        {
            glyph.Stave = this;//GlypySetStave方法今后改（不用Stave属性）
            this.glyphs.Add(glyph);
            this.startX += glyph.GetMetrics().width;
            return this;
        }
        public Stave AddEndGlyph(Glyph glyph)
        {
            glyph.Stave = this;//GlypySetStave方法今后改（不用Stave属性）
            this.endGlyphs.Add(glyph);
            this.endX -= glyph.GetMetrics().width;
            return this;
        }
        public Stave AddModifier(StaveModifier modifier)
        {
            this.modifiers.Add(modifier);
            modifier.AddToStave(this, this.glyphs.Count == 0);
            return this;
        }
        public Stave AddEndModifier(StaveModifier modifier)
        {
            this.modifiers.Add(modifier);
            modifier.AddToStaveEnd(this, this.endGlyphs.Count() == 0);
            return this;
        }
        public Stave AddKeySignature(string keySpec)
        {
            this.AddModifier(new KeySignature(keySpec));
            return this;
        }
        public Stave AddClef(string clef)
        {
            this.clef = clef;
            this.AddModifier(new Clef(clef));
            return this;
        }
        public Stave AddEndClef(string clef)
        {
            this.AddEndModifier(new Clef(clef));
            return this;
        }
        public Stave AddTimeSignature(string timeSpec, double? customPadding = null)
        {
            this.AddModifier(new TimeSignature(timeSpec, customPadding));
            return this;
        }
        public void AddEndTimeSignature(string timeSpec, double? customPadding = null)
        {
            this.AddEndModifier(new TimeSignature(timeSpec, customPadding));
        }
        public Stave AddTrebleGlyph()
        {
            this.clef = "treble";
            this.AddGlyph(new Glyph("v83", 40));
            return this;
        }

        /**
    * All drawing functions below need the context to be set.
    */
        public void Draw()
        {
            //draw: function() {
            //  if (!this.context) throw new Vex.RERR("NoCanvasContext",
            //      "Can't draw stave without canvas context.");

            //  var num_lines = this.options.num_lines;
            //  var width = this.width;
            //  var x = this.x;
            //  var y;
            //  var glyph;

            //  // Render lines
            //  for (var line=0; line < num_lines; line++) {
            //    y = this.getYForLine(line);

            //    this.context.save();
            //    this.context.setFillStyle(this.options.fill_style);
            //    this.context.setStrokeStyle(this.options.fill_style);
            //    if (this.options.line_config[line].visible) {
            //      this.context.fillRect(x, y, width, Vex.Flow.STAVE_LINE_THICKNESS);
            //    }
            //    this.context.restore();
            //  }

            //  // Render glyphs
            //  x = this.glyph_start_x;
            //  for (var i = 0; i < this.glyphs.length; ++i) {
            //    glyph = this.glyphs[i];
            //    if (!glyph.getContext()) {
            //      glyph.setContext(this.context);
            //    }
            //    glyph.renderToStave(x);
            //    x += glyph.getMetrics().width;
            //  }

            //  // Render end glyphs
            //  x = this.glyph_end_x;
            //  for (i = 0; i < this.end_glyphs.length; ++i) {
            //    glyph = this.end_glyphs[i];
            //    if (!glyph.getContext()) {
            //      glyph.setContext(this.context);
            //    }
            //    x -= glyph.getMetrics().width;
            //    glyph.renderToStave(x);
            //  }

            //  // Draw the modifiers (bar lines, coda, segno, repeat brackets, etc.)
            //  for (i = 0; i < this.modifiers.length; i++) {
            //    // Only draw modifier if it has a draw function
            //    if (typeof this.modifiers[i].draw == "function")
            //      this.modifiers[i].draw(this, this.getModifierXShift());
            //  }

            //  // Render measure numbers
            //  if (this.measure > 0) {
            //    this.context.save();
            //    this.context.setFont(this.font.family, this.font.size, this.font.weight);
            //    var text_width = this.context.measureText("" + this.measure).width;
            //    y = this.getYForTopText(0) + 3;
            //    this.context.fillText("" + this.measure, this.x - text_width / 2, y);
            //    this.context.restore();
            //  }

            //  return this;
            //},
        }


        // Draw Simple barlines for backward compatability
        // Do not delete - draws the beginning bar of the stave
        public void DrawVertical(double x, object isDouble)
        {
            //        drawVertical: function(x, isDouble) {
            //  this.drawVerticalFixed(this.x + x, isDouble);
            //},
        }

        public void DrawVerticalFixed(double x, object isDouble)
        {
            //        drawVerticalFixed: function(x, isDouble) {
            //  if (!this.context) throw new Vex.RERR("NoCanvasContext",
            //      "Can't draw stave without canvas context.");

            //  var top_line = this.getYForLine(0);
            //  var bottom_line = this.getYForLine(this.options.num_lines - 1);
            //  if (isDouble)
            //    this.context.fillRect(x - 3, top_line, 1, bottom_line - top_line + 1);
            //  this.context.fillRect(x, top_line, 1, bottom_line - top_line + 1);
            //},
        }

        public void DrawVerticalBar(object x)
        {
            //    drawVerticalBar: function(x) {
            //  this.drawVerticalBarFixed(this.x + x, false);
            //},
        }

        public void DrawVerticalBarFixed(object x)
        {
            //        drawVerticalBarFixed: function(x) {
            //  if (!this.context) throw new Vex.RERR("NoCanvasContext",
            //      "Can't draw stave without canvas context.");

            //  var top_line = this.getYForLine(0);
            //  var bottom_line = this.getYForLine(this.options.num_lines - 1);
            //  this.context.fillRect(x, top_line, 1, bottom_line - top_line + 1);
            //},
        }
        /**
    * Get the current configuration for the Stave.
    * @return {Array} An array of configuration objects.
    */
        public object GetConfigForLines()
        {
            return this.options.lineConfig;
        }
        /**
 * Configure properties of the lines in the Stave
 * @param line_number The index of the line to configure.
 * @param line_config An configuration object for the specified line.
 * @throws Vex.RERR "StaveConfigError" When the specified line number is out of
 *   range of the number of lines specified in the constructor.
 */
        public Stave SetConfigForLine(int lineNumber, LineConfig lineConfig)
        {
            if (lineNumber >= this.options.numLines || lineNumber < 0)
            {
                throw new Exception("StaveConfigError,The line number must be within the range of the number of lines in the Stave.");
            }
            this.options.lineConfig[lineNumber] = lineConfig;
            return this;
        }
        /**
    * Set the staff line configuration array for all of the lines at once.
    * @param lines_configuration An array of line configuration objects.  These objects
    *   are of the same format as the single one passed in to setLineConfiguration().
    *   The caller can set null for any line config entry if it is desired that the default be used
    * @throws Vex.RERR "StaveConfigError" When the lines_configuration array does not have
    *   exactly the same number of elements as the num_lines configuration object set in
    *   the constructor.
    */
        //这段代码你看看吧，我有点儿不行了- -！
        //    setConfigForLines: function(lines_configuration) {
        //  if (lines_configuration.length !== this.options.num_lines) {
        //    throw new Vex.RERR("StaveConfigError",
        //      "The length of the lines configuration array must match the number of lines in the Stave");
        //  }

        //  // Make sure the defaults are present in case an incomplete set of
        //  //  configuration options were supplied.
        //  for (var line_config in lines_configuration) {
        //    // Allow 'null' to be used if the caller just wants the default for a particular node.
        //    if (!lines_configuration[line_config]) {
        //      lines_configuration[line_config] = this.options.line_config[line_config];
        //    }
        //    Vex.Merge(this.options.line_config[line_config], lines_configuration[line_config]);
        //  }

        //  this.options.line_config = lines_configuration;

        //  return this;
        //}

        public Stave SetConfigForLines(IList<LineConfig> linesConfiguration)
        {
            if (linesConfiguration.Count() != this.options.numLines)
            {
                throw new Exception("StaveConfigError,The length of the lines configuration array must match the number of lines in the Stave");
            }
            // Make sure the defaults are present in case an incomplete set of  configuration options were supplied.
            //以下代码的逻辑挺吓人的。。。你看看吧
            for (int lineConfig = 0; lineConfig < linesConfiguration.Count(); lineConfig++)
            {
                // Allow 'null' to be used if the caller just wants the default for a particular node.
                if (linesConfiguration[lineConfig] == null)
                {
                    linesConfiguration[lineConfig] = this.options.lineConfig[lineConfig];
                }
                //目前只发现一个属性visible
                this.options.lineConfig[lineConfig].visible = linesConfiguration[lineConfig].visible;
            }
            this.options.lineConfig = linesConfiguration;
            return this;
        }
        #endregion


        #region 隐含字段
        public double startX;
        public double endX;
        public double width;
        public CanvasContext context;
        public double x;
        public int numLines;
        public double y;
        public int measure;
        public double height;
        public IList<Glyph> glyphs;
        public IList<Glyph> endGlyphs;
        public IList<object> modifiers;//可以保存staveModifier和modifier。。。
        public double glyphStartX;
        public double glyphEndX;
        public string clef;//keySignatrue用到
        public Font font;
        StaveOpts options;
        public BoundingBox bounds;
        #endregion




    }
}
