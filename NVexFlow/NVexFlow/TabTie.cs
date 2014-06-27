using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NVexFlow
{
    public partial class Vex
    {
        public partial class Flow
        {
            public class TabTie:StaveTie
            {

                #region 属性字段
                object renderOptions; 
                #endregion


                #region 方法
                public TabTie(IList<object> notes, string text)
                    : base(notes, text)
                {
                    Init(notes, text);
                }

                public override void Init(IList<object> notes, string text)
                { }

                public void Draw()
                { }


                public static TabTie CreateHammeron(IList<object> notes)
                {
                    return new TabTie(notes, "H");
                }


                public static TabTie CreatePulloff(IList<object> notes)
                {
                    return new TabTie(notes, "P");
                } 
                #endregion
            }
        }

    }
}
