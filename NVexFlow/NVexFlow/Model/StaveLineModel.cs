using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NVexFlow.Model
{
    public class StaveLineNotes
    {
        // `notes` is a struct that has:
        //
        //  ```
        //  {
        //    first_note: Note,
        //    last_note: Note,
        //    first_indices: [n1, n2, n3],
        //    last_indices: [n1, n2, n3]
        //  }
        //  ```
        public StaveNote first_note;
        public StaveNote last_note;
        public IList<int> first_indices;
        public IList<int> last_indices;
    }
    public class StaveLineRenderOpts
    {
        // Space to add to the left or the right
        public double? padding_left;
        public double? padding_right;
        // The width of the line in pixels
        public double? line_width;
        // An array of line/space lengths. Unsupported with Raphael (SVG)
        public IList<double> line_dash;
        // Can draw rounded line end, instead of a square. Unsupported with Raphael (SVG)
        public bool? rounded_end;
        // The color of the line and arrowheads
        public object color;

        // Flags to draw arrows on each end of the line
        public bool? draw_start_arrow;
        public bool? draw_end_arrow;

        // The length of the arrowhead sides
        public double? arrowhead_length;
        // The angle of the arrowhead
        public double? arrowhead_angle;

        // The position of the text
        public StaveLine.StaveLineTextVerticalPosition text_position_vertical;
        public StaveLine.StaveLineTextJustification text_justification;
    }
}
