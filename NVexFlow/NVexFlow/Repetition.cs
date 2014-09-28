//staverepetition.js
namespace NVexFlow
{
    /// <summary>
    /// Vex Flow Notation
    // Author Larry Kuhns 2011
    // Implements Repetitions (Coda, signo, D.C., etc.)
    //
    // Requires vex.js.
    /// </summary>
    public class Repetition : StaveModifier
    {
        #region js直译部分

        public Repetition(RepetitionType type, double x, double y_shift)
        {
            Init(type, x, y_shift);
        }
        public enum RepetitionType
        {
            NONE,// no coda or segno
            CODA_LEFT,// coda at beginning of stave
            CODA_RIGHT,// coda at end of stave
            SEGNO_LEFT,// segno at beginning of stave
            SEGNO_RIGHT,// segno at end of stave
            DC,// D.C. at end of stave
            DC_AL_CODA,// D.C. al coda at end of stave
            DC_AL_FINE,// D.C. al Fine end of stave
            DS,// D.S. at end of stave
            DS_AL_CODA,// D.S. al coda at end of stave
            DS_AL_FINE,// D.S. al Fine at end of stave
            FINE// Fine at end of stave
        }
        private void Init(RepetitionType type, double x, double yShift)
        {
            //        init: function(type, x, y_shift) {
            //  Repetition.superclass.init.call(this);
            this.symbolType = type;
            this.x = x;
            this.xShift = 0;
            this.yShift = yShift;
            this.font = new Font() {
                family = "times",
                size=12,
                weight = "bold italic"
            };
        }

        public override string GetCategory()
        {
            return "repetitions"; 
        }
        public Repetition SetShiftX(double x)
        {
            this.xShift = x;
            return this;
        }
        public Repetition SetShiftY(double y)
        {
            this.yShift = y;
            return this;
        }


        public Repetition Draw(Stave stave, double x)
        {
            //        draw: function(stave, x) {
            //  switch (this.symbol_type) {
            //    case Repetition.type.CODA_RIGHT:
            //      this.drawCodaFixed(stave, x + stave.width);
            //      break;
            //    case Repetition.type.CODA_LEFT:
            //      this.drawSymbolText(stave, x, "Coda", true);
            //      break;
            //    case Repetition.type.SEGNO_LEFT:
            //      this.drawSignoFixed(stave, x);
            //      break;
            //    case Repetition.type.SEGNO_RIGHT:
            //      this.drawSignoFixed(stave, x + stave.width);
            //      break;
            //    case Repetition.type.DC:
            //      this.drawSymbolText(stave, x, "D.C.", false);
            //      break;
            //    case Repetition.type.DC_AL_CODA:
            //      this.drawSymbolText(stave, x, "D.C. al", true);
            //      break;
            //    case Repetition.type.DC_AL_FINE:
            //      this.drawSymbolText(stave, x, "D.C. al Fine", false);
            //      break;
            //    case Repetition.type.DS:
            //      this.drawSymbolText(stave, x, "D.S.", false);
            //      break;
            //    case Repetition.type.DS_AL_CODA:
            //      this.drawSymbolText(stave, x, "D.S. al", true);
            //      break;
            //    case Repetition.type.DS_AL_FINE:
            //      this.drawSymbolText(stave, x, "D.S. al Fine", false);
            //      break;
            //    case Repetition.type.FINE:
            //      this.drawSymbolText(stave, x, "Fine", false);
            //      break;
            //    default:
            //      break;
            //  }

            //  return this;
            //},
            return null;
        }

        public Repetition DrawCodaFixed(Stave stave, double x)
        {
            //        drawCodaFixed: function(stave, x) {
            //  if (!stave.context) throw new Vex.RERR("NoCanvasContext",
            //      "Can't draw stave without canvas context.");

            //  var y = stave.getYForTopText(stave.options.num_lines) + this.y_shift;
            //  Vex.Flow.renderGlyph(stave.context, this.x + x + this.x_shift,
            //                       y + 25, 40, "v4d", true);
            //  return this;
            //},


            return null;
        }

        public Repetition DrawSignoFixed(Stave stave, double x)
        {
            //drawSignoFixed: function(stave, x) {
            //  if (!stave.context) throw new Vex.RERR("NoCanvasContext",
            //      "Can't draw stave without canvas context.");
            //  var y = stave.getYForTopText(stave.options.num_lines) + this.y_shift;
            //  Vex.Flow.renderGlyph(stave.context, this.x + x + this.x_shift,
            //                       y + 25, 30, "v8c", true);
            //  return this;
            //},
            return null;
        }

        public Repetition DrawSymbolText(Stave stave, double x)
        {
            //         drawSymbolText: function(stave, x, text, draw_coda) {
            //  if (!stave.context) throw new Vex.RERR("NoCanvasContext",
            //      "Can't draw stave without canvas context.");

            //  var ctx = stave.context;
            //  ctx.save();
            //  ctx.setFont(this.font.family, this.font.size, this.font.weight);
            //    // Default to right symbol
            //  var text_x = 0 + this.x_shift;
            //  var symbol_x = x + this.x_shift;
            //  if (this.symbol_type == Vex.Flow.Repetition.type.CODA_LEFT) {
            //      // Offset Coda text to right of stave beginning
            //    text_x = this.x + stave.options.vertical_bar_width;
            //    symbol_x = text_x + ctx.measureText(text).width + 12;
            //  } else {
            //      // Offset Signo text to left stave end
            //    symbol_x = this.x + x + stave.width - 5 + this.x_shift;
            //    text_x = symbol_x - + ctx.measureText(text).width - 12;
            //  }
            //  var y = stave.getYForTopText(stave.options.num_lines) + this.y_shift;
            //  if (draw_coda) {
            //    Vex.Flow.renderGlyph(ctx, symbol_x, y, 40, "v4d", true);
            //  }

            //  ctx.fillText(text, text_x, y + 5);
            //  ctx.restore();

            //  return this;
            //}
            return null;
        }
        #endregion


        #region 隐含字段
        public RepetitionType symbolType;
        public double x;
        public double y;
        public double xShift;
        public double yShift;
        public Font font;
        #endregion
    }
}
