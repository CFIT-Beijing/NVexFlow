using System.Collections.Generic;

namespace NVexFlow
{//TabSlide
    public class TabSlide:TabTie
    {
        #region 静态
        public static TabSlide CreateSlideUp(IList<object> notes)
        {
            return new TabSlide(notes,TabSlide.SLIDE_UP);
        }


        public static TabSlide CreateSlideDown(IList<object> notes)
        {
            return new TabSlide(notes,TabSlide.SLIDE_DOWN);
        }

        public static int SLIDE_UP = 1;
        public static int SLIDE_DOWN = -1;
        #endregion


        #region 隐含字段
        int slideDirection;
        object renderOptions;
        #endregion


        #region js直译部分

        public TabSlide(IList<object> notes,object direction)
            : base(notes,"sl.")
        {
            Init(notes,direction);
        }



        private void Init(IList<object> notes,object direction)
        { }

        public void RenderTie(IList<object> @params)
        { }


        #endregion
    }
}
