//tabstave.js
using System.Collections.Generic;
using NVexFlow.Model;
namespace NVexFlow
{
    /// <summary>
    /// Vex Flow
    // Mohit Muthanna <mohit@muthanna.com>
    //
    // Copyright Mohit Cheppudira 2010
    /// </summary>
    public class TabStave : Stave
    {
        #region js直译部分
        public TabStave(double x, double y, double width, StaveOpts options = null)
            : base(x, y, width, options)
        {
            Init(x, y, width, options);
        }

        private void Init(double x, double y, double width, StaveOpts options)
        {
            StaveOpts tabOpts = new StaveOpts()
            {
                spacing_between_lines_px = 13,
                num_lines = 6,
                top_text_position = 1
            };
            if (options != null)
            {
                #region 只发现options传入了num_lines。（var stave = new Vex.Flow.TabStave(10, 10, 550,{num_lines:8});）+Vex.Merge(tab_options, options);
                if (options.num_lines.HasValue)
                {
                    tabOpts.num_lines = options.num_lines;
                }
                #endregion
            }
        }
        public override double GetYForGlyphs()
        {
            return this.GetYForLine(2.5);
        }
        public TabStave AddTabGlyph()
        {
            //         addTabGlyph: function() {
            double glyph_scale=0;
            double glyph_offset=0;

            switch (this.options.num_lines)
            {
                case 8:
                    glyph_scale = 55;
                    glyph_offset = 14;
                    break;
                case 7:
                    glyph_scale = 47;
                    glyph_offset = 8;
                    break;
                case 6:
                    glyph_scale = 40;
                    glyph_offset = 1;
                    break;
                case 5:
                    glyph_scale = 30;
                    glyph_offset = -6;
                    break;
                case 4:
                    glyph_scale = 23;
                    glyph_offset = -12;
                    break;
            }
            Glyph tab_glyph = new Glyph("v2f", glyph_scale);
            tab_glyph.yShift = glyph_offset;
            this.AddGlyph(tab_glyph);
            return this;
        }
        #endregion


        #region 隐含字段
        public StaveOpts options;
        #endregion





    }
}
