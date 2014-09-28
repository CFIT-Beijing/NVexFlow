//stavetempo.js
using NVexFlow.Model;
namespace NVexFlow
{
    /// <summary>
    ///VexFlow - Music Engraving for HTML5
    // Copyright Mohit Muthanna 2010
    // Author Radosaw Eichler 2012
    // Implements tempo marker.
    /// </summary>
    public class StaveTempo : StaveModifier
    {
        #region js直译部分
        /// <summary>
        /// @constructor
        /// @param {Object} tempo Tempo parameters: { name, duration, dots, bpm }
        /// </summary>
        /// <param name="tempo"></param>
        /// <param name="x"></param>
        /// <param name="shift_y"></param>
        public StaveTempo(Tempo tempo, double x, double shift_y)
        {
            Init(tempo, x, shiftY);
        }
        private void Init(Tempo tempo, double x, double shiftY)
        {
              this.tempo = tempo;
              this.position =Modifier.ModifierPosition.ABOVE;
              this.x = x;
              this.shiftX = 10;
              this.shiftY = shiftY;
              this.font = new Font()
              {
                  family = "times",
                  size = 14,
                  weight = "bold"
              };
              this.renderOptions = new StaveTempoRenderOpts() { glyphFontScale = 30 };// font size for note
        }
        public override string GetCategory()
        {
            return "stavetempo";
        }
        public StaveTempo SetTempo(Tempo tempo)
        { 
            this.tempo = tempo;
            return this;
        }
        public StaveTempo SetShiftX(double x)
        {
            this.x = x;
            return this;
        }
        public StaveTempo SetShiftY(double y)
        {
            this.shiftY= y;
            return this;
        }
        public StaveTempo Draw(Stave stave, double shift_x)
        {
            //    draw: function(stave, shift_x) {
            //  if (!stave.context) throw new Vex.RERR("NoContext",
            //    "Can't draw stave tempo without a context.");

            //  var options = this.render_options;
            //  var scale = options.glyph_font_scale / 38;
            //  var name = this.tempo.name;
            //  var duration = this.tempo.duration;
            //  var dots = this.tempo.dots;
            //  var bpm = this.tempo.bpm;
            //  var font = this.font;
            //  var ctx = stave.context;
            //  var x = this.x + this.shift_x + shift_x;
            //  var y = stave.getYForTopText(1) + this.shift_y;

            //  ctx.save();

            //  if (name) {
            //    ctx.setFont(font.family, font.size, font.weight);
            //    ctx.fillText(name, x, y);
            //    x += ctx.measureText(name).width;
            //  }

            //  if (duration && bpm) {
            //    ctx.setFont(font.family, font.size, 'normal');

            //    if (name) {
            //      x += ctx.measureText(" ").width;
            //      ctx.fillText("(", x, y);
            //      x += ctx.measureText("(").width;
            //    }

            //    var code = Vex.Flow.durationToGlyph(duration);

            //    x += 3 * scale;
            //    Vex.Flow.renderGlyph(ctx, x, y, options.glyph_font_scale, code.code_head);
            //    x += code.head_width * scale;

            //    // Draw stem and flags
            //    if (code.stem) {
            //      var stem_height = 30;

            //      if (code.beam_count) stem_height += 3 * (code.beam_count - 1);

            //      stem_height *= scale;

            //      var y_top = y - stem_height;
            //      ctx.fillRect(x, y_top, scale, stem_height);

            //      if (code.flag) {
            //        Vex.Flow.renderGlyph(ctx, x + scale, y_top, options.glyph_font_scale,
            //                             code.code_flag_upstem);

            //        if (!dots) x += 6 * scale;
            //      }
            //    }

            //    // Draw dot
            //    for (var i = 0; i < dots; i++) {
            //      x += 6 * scale;
            //      ctx.beginPath();
            //      ctx.arc(x, y + 2 * scale, 2 * scale, 0, Math.PI * 2, false);
            //      ctx.fill();
            //    }

            //    ctx.fillText(" = " + bpm + (name ? ")" : ""), x + 3 * scale, y);
            //  }

            //  ctx.restore();
            //  return this;
            //}
            return null;
        }
        #endregion


        #region 隐含字段
        public double x;
        public Modifier.ModifierPosition position;
        public Font font;
        public RenderOptions renderOptions;
        public Tempo tempo;
        public double shiftX;
        public double shiftY;
        #endregion



    }
}
