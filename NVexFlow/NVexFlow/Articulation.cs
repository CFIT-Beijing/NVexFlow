﻿
namespace NVexFlow
{
    public partial class Vex
    {
        public partial class Flow
        {
            public class Articulation : Modifier
            {

                #region 属性字段
                object note;
                object index;
                object type;
                Modifier.ModifierPosition position;
                object renderOptions;
                object articulation;
                double width;
                public override double Width
                {
                    set { this.width = value; }
                }
                #endregion


                #region 方法
                public Articulation(object type)
                {
                    Init(type);
                }

                public void Init(object type)
                { }


                public override void Draw()
                { }
                #endregion
            }
        }
    }
}
