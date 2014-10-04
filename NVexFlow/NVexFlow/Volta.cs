//stavevolta.js
namespace NVexFlow
{
    /// <summary>
    /// Vex Flow Notation
    // Author Larry Kuhns 2011
    // Implements voltas (repeat brackets)
    //
    // Requires vex.js.
    /// </summary>
    public class Volta : StaveModifier
    {
        #region js直译部分
        public Volta(VoltaType type, int number, double x, double y_shift)
        {
            Init(type, number, x, y_shift);
        }
        public enum VoltaType
        {
            NONE,
            BEGIN,
            MID,
            END,
            BEGIN_END
        }
        private void Init(VoltaType type, int number, double x, double yShift)
        {
            this.volta = type;

            this.x = x;
            this.y_shift = yShift;
            this.number = number;
            this.font = new Font()
            {
                family = "sans-serif",
                size = 9,
                weight = "bold"
            };
        }
        public override string GetCategory()
        {
            return "voltas";
        }
        public Volta SetShiftY(double y)
        {
            this.y_shift = y;
            return this;
        }
        public Volta Draw(Stave stave, double x)
        {
            //        draw: function(stave, x) {
            //  if (!stave.context) throw new Vex.RERR("NoCanvasContext",
            //    "Can't draw stave without canvas context.");
            //  var ctx = stave.context;
            //  var width = stave.width;
            //  var top_y = stave.getYForTopText(stave.options.num_lines) + this.y_shift;
            //  var vert_height = 1.5 * stave.options.spacing_between_lines_px;
            //  switch(this.volta) {
            //    case Vex.Flow.Volta.type.BEGIN:
            //      ctx.fillRect(this.x + x, top_y, 1, vert_height);
            //      break;
            //    case Vex.Flow.Volta.type.END:
            //      width -= 5;
            //      ctx.fillRect(this.x + x + width, top_y, 1, vert_height);
            //      break;
            //    case Vex.Flow.Volta.type.BEGIN_END:
            //      width -= 3;
            //      ctx.fillRect(this.x + x, top_y, 1, vert_height);
            //      ctx.fillRect(this.x + x + width, top_y, 1, vert_height);
            //      break;
            //  }
            //    // If the beginning of a volta, draw measure number
            //  if (this.volta == Volta.type.BEGIN ||
            //      this.volta == Volta.type.BEGIN_END) {
            //    ctx.save();
            //    ctx.setFont(this.font.family, this.font.size, this.font.weight);
            //    ctx.fillText(this.number, this.x + x + 5, top_y + 15);
            //    ctx.restore();
            //  }
            //  ctx.fillRect(this.x + x, top_y, width, 1);
            //  return this;
            //}
            return null;
        }

        #endregion


        #region 隐含字段
        protected VoltaType volta;
        protected VoltaType type;
        protected double x;
        protected double y_shift;
        protected int number;
        protected Font font;
        #endregion



    }
}
