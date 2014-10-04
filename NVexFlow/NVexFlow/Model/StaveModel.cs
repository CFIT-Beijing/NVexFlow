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
        public double? vertical_bar_width;
        public double? glyph_spacing_px;
        public int? num_lines;
        public string fill_style;
        public double? spacing_between_lines_px;
        public double? space_above_staff_ln;
        public double? space_below_staff_ln;
        public int? top_text_position;
        public IList<LineConfig> line_config;
        public double? bottom_text_position;
    }

    public class LineConfig
    {
        public bool visible;
    }
}
