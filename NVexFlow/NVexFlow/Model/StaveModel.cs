using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NVexFlow.Model
{
    public class StaveOpts
    {
        //  this.options = {
        //    vertical_bar_width: 10,       // Width around vertical bar end-marker
        //    glyph_spacing_px: 10,
        //    num_lines: 5,
        //    fill_style: "#999999",
        //    spacing_between_lines_px: 10, // in pixels
        //    space_above_staff_ln: 4,      // in staff lines
        //    space_below_staff_ln: 4,      // in staff lines
        //    top_text_position: 1          // in staff lines
        //  };
        public double? verticalBarWidth;
        public double? glyphSpacingPx;
        public int? numLines;
        public string fillStyle;
        public double? spacingBetweenLinesPx;
        public double? spaceAboveStaffIn;
        public double? spaceBelowStaffIn;
        public int? topTextPosition;
        public IList<LineConfig> lineConfig;
        public double? bottomTextPosition;
    }

    public class LineConfig
    {
        public bool visible;
    }
}
