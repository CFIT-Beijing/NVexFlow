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
                spacingBetweenLinesPx = 13,
                numLines = 6,
                topTextPosition = 1
            };
            if (options != null)
            {
                #region 只发现options传入了num_lines。（var stave = new Vex.Flow.TabStave(10, 10, 550,{num_lines:8});）+Vex.Merge(tab_options, options);
                if (options.numLines.HasValue)
                {
                    tabOpts.numLines = options.numLines;
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
            double glyphScale=0;
            double glyphOffset=0;

            switch (this.options.numLines)
            {
                case 8:
                    glyphScale = 55;
                    glyphOffset = 14;
                    break;
                case 7:
                    glyphScale = 47;
                    glyphOffset = 8;
                    break;
                case 6:
                    glyphScale = 40;
                    glyphOffset = 1;
                    break;
                case 5:
                    glyphScale = 30;
                    glyphOffset = -6;
                    break;
                case 4:
                    glyphScale = 23;
                    glyphOffset = -12;
                    break;
            }
            Glyph tabGlyph = new Glyph("v2f", glyphScale);
            tabGlyph.yShift = glyphOffset;
            this.AddGlyph(tabGlyph);
            return this;
        }
        #endregion


        #region 隐含字段
        public StaveOpts options;
        #endregion





    }
}
