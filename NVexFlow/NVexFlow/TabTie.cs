using System.Collections.Generic;

namespace NVexFlow
{
    public class TabTie:StaveTie
    {

        #region 隐含字段
        object renderOptions;
        #endregion


        #region js直译部分
        public TabTie(IList<object> notes,string text)
            : base(notes,text)
        {
            Init(notes,text);
        }

        public override void Init(IList<object> notes,string text)
        { }

        public void Draw()
        { }


        public static TabTie CreateHammeron(IList<object> notes)
        {
            return new TabTie(notes,"H");
        }


        public static TabTie CreatePulloff(IList<object> notes)
        {
            return new TabTie(notes,"P");
        }
        #endregion
    }
}
