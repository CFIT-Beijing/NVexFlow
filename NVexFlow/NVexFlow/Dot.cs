﻿
namespace NVexFlow
{
    public partial class Vex
    {
        public partial class Flow
        {
            /// <summary>
            ///  This class implements dot modifiers for notes.
            /// </summary>
            public class Dot : Modifier
            {
                #region js直译部分
                public Dot()
                {
                    Init();
                }


                public override void Init()
                {
                    this.note = null;
                    this.index = null;
                    this.position = Modifier.ModifierPosition.RIGHT;

                    this.radius = 2;
                    this.Width = 5;
                    this.dotShiftY = 0;
                }


                public override Note Note
                {
                    set
                    {
                        this.note = value;
                        if (this.note is GraceNote)
                        {
                            this.radius *= 0.50;
                            this.Width = 3;
                        }
                    }
                }


                public override string Category
                {
                    get
                    {
                        return "dots";
                    }
                }


                public double DotShiftY
                {
                    set { dotShiftY = value; }
                }


                public override void Draw()
                { }
                #endregion


                #region 隐含的字段
                protected double dotShiftY;
                protected double radius;
                #endregion
            }
        }

    }
}
