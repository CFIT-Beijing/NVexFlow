using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZhCJB.VexFlow.CS
{
    public partial class Vex
    {
        public partial class Flow
        {
            public class Tremolo:Modifier
            {
                #region 属性字段
                private double num;
                private object index;
                private object note;
                private string code;
                private int shiftRight;
                private int ySpacing;
                private Modifier.ModifierPosition position;
                private IList<object> renderOptions;
                private Font font; 
                #endregion


                #region 方法
                public Tremolo(int num)
                {
                    Init(num);
                }

                public void Init(int num)
                {

                }

                public override void Draw()
                { } 
                #endregion
            }
        }
    }
}
