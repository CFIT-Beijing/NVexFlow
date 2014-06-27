using System.Collections.Generic;

namespace NVexFlow
{
    public partial class Vex
    {
        public partial class Flow
        {
            public class Bend : Modifier
            {
                #region 属性字段
                private double xShift;
                public override double XShift
                {
                    set
                    {
                        base.XShift = value;
                        UpdateWidth();
                    }
                }

                bool release;
                Font font;

                public Font Font
                {
                    set { font = value; }
                }
                object renderOptions;

                IList<object> phrase;

                private string text;

                public string Text
                {
                    get { return text; }
                }
                #endregion


                #region 方法
                public Bend(string text, object release, object phrase)
                {
                    Init(text, release, phrase);
                }

                public void Init(string text, object release, object phrase)
                { }

                public Bend UpdateWidth()
                {
                    return this;
                }



                public void Draw()
                { }
                #endregion
            }
        }
    }
}
