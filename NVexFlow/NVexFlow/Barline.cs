//stavebarline.js
namespace NVexFlow
{
    /// <summary>
    /// Vex Flow Notation
    // Author Larry Kuhns 2011
    // Implements barlines (single, double, repeat, end)
    //
    // Requires vex.js.
    /// </summary>
    public class Barline : StaveModifier
    {
        #region js直译部分
        public Barline(BarlineType type, double x)
        {
            Init(type, x);
        }
        public enum BarlineType
        {
            SINGLE = 1,
            DOUBLE = 2,
            END = 3,
            REPEAT_BEGIN = 4,
            REPEAT_END = 5,
            REPEAT_BOTH = 6,
            NONE = 7
        }

        private void Init(BarlineType type, double x)
        {
            this.barLine = type;
            this.x = x;// Left most x for the stave
        }

        public override string GetCategory()
        {
            return "barlines"; 
        }
        public Barline SetX(double x)
        {
            this.x = x; 
            return this; 
        }
        //////////
        //draw: function(stave, xShift)
        //drawVerticalBar: function(stave, x, double_bar)
        // drawVerticalEndBar: function(stave, x)
        //drawRepeatBar: function(stave, x, begin)

        public void Draw(object stave, double x_shift)
        {
            //  x_shift = typeof x_shift !== 'number' ? 0 : x_shift;

            //switch (this.barline) {
            //  case Barline.type.SINGLE:
            //    this.drawVerticalBar(stave, this.x, false);
            //    break;
            //  case Barline.type.DOUBLE:
            //    this.drawVerticalBar(stave, this.x, true);
            //    break;
            //  case Barline.type.END:
            //    this.drawVerticalEndBar(stave, this.x);
            //    break;
            //  case Barline.type.REPEAT_BEGIN:
            //    // If the barline is shifted over (in front of clef/time/key)
            //    // Draw vertical bar at the beginning.
            //    if (x_shift > 0) {
            //      this.drawVerticalBar(stave, this.x);
            //    }
            //    this.drawRepeatBar(stave, this.x + x_shift, true);
            //    break;
            //  case Barline.type.REPEAT_END:
            //    this.drawRepeatBar(stave, this.x, false);
            //    break;
            //  case Barline.type.REPEAT_BOTH:
            //    this.drawRepeatBar(stave, this.x, false);
            //    this.drawRepeatBar(stave, this.x, true);
            //    break;
            //  default:
            //    // Default is NONE, so nothing to draw
            //    break;
            //}
        }

        public void DrawVerticalBar(object stave, double x, object double_bar)
        {
            //if (!stave.context) throw new Vex.RERR("NoCanvasContext",
            //  "Can't draw stave without canvas context.");
            //var top_line = stave.getYForLine(0);
            //var bottom_line = stave.getYForLine(stave.options.num_lines - 1) + (THICKNESS / 2);
            //if (double_bar)
            //    stave.context.fillRect(x - 3, top_line, 1, bottom_line - top_line + 1);
            //stave.context.fillRect(x, top_line, 1, bottom_line - top_line + 1);
        }

        public void DrawVerticalEndBar(object stave, double x)
        {
            //if (!stave.context) throw new Vex.RERR("NoCanvasContext",
            //  "Can't draw stave without canvas context.");

            //var top_line = stave.getYForLine(0);
            //var bottom_line = stave.getYForLine(stave.options.num_lines - 1) + (THICKNESS / 2);
            //stave.context.fillRect(x - 5, top_line, 1, bottom_line - top_line + 1);
            //stave.context.fillRect(x - 2, top_line, 3, bottom_line - top_line + 1);
        }

        public void DrawRepeatBar(object stave, double x, object begin)
        {
            //    if (!stave.context) throw new Vex.RERR("NoCanvasContext",
            //      "Can't draw stave without canvas context.");

            //  var top_line = stave.getYForLine(0);
            //  var bottom_line = stave.getYForLine(stave.options.num_lines - 1) + (THICKNESS / 2);
            //  var x_shift = 3;

            //  if (!begin) {
            //    x_shift = -5;
            //  }

            //  stave.context.fillRect(x + x_shift, top_line, 1, bottom_line - top_line + 1);
            //  stave.context.fillRect(x - 2, top_line, 3, bottom_line - top_line + 1);

            //  var dot_radius = 2;

            //  // Shift dots left or right
            //  if (begin) {
            //    x_shift += 4;
            //  } else {
            //    x_shift -= 4;
            //  }

            //  var dot_x = (x + x_shift) + (dot_radius / 2);

            //  // calculate the y offset based on number of stave lines
            //  var y_offset = (stave.options.num_lines -1) *
            //    stave.options.spacing_between_lines_px;
            //  y_offset = (y_offset / 2) -
            //             (stave.options.spacing_between_lines_px / 2);
            //  var dot_y = top_line + y_offset + (dot_radius / 2);

            //  // draw the top repeat dot
            //  stave.context.beginPath();
            //  stave.context.arc(dot_x, dot_y, dot_radius, 0, Math.PI * 2, false);
            //  stave.context.fill();

            //  //draw the bottom repeat dot
            //  dot_y += stave.options.spacing_between_lines_px;
            //  stave.context.beginPath();
            //  stave.context.arc(dot_x, dot_y, dot_radius, 0, Math.PI * 2, false);
            //  stave.context.fill();
            //}
        }
        #endregion
        #region 隐含字段
        public double x;
        public BarlineType barLine;
        #endregion



    }
}
