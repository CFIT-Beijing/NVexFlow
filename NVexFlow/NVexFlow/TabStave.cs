﻿using System.Collections.Generic;

namespace NVexFlow
{
    public class TabStave:Stave
    {
        #region 隐含字段

        IList<object> tabOptions;

        private double yForGlyphs;

        public double YForGlyphs
        {
            get
            { return GetYForLine(2.5); }
        }



        private double spacing_between_lines_px;
        private int num_lines;
        private int top_text_position;
        private IList<object> options;
        #endregion


        #region js直译部分
        public TabStave(double x,double y,double width,IList<object> options)
            : base(x,y,width,options)
        {
            Init(x,y,width,this.options);
        }

        public override void Init(double x,double y,double width,IList<object> options)
        {
            //var tab_options = new List<object>() { spacing_between_lines_px, num_lines, top_text_position };
            //this.options = new Vex().Merge(tab_options, options);
            spacing_between_lines_px = 13;
            num_lines = 6;
            top_text_position = 1;

        }

        public TabStave AddTabGlyph()
        {
            return null;
        }
        #endregion


    }
}
