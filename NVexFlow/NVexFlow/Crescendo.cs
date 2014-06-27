using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NVexFlow
{//Crescendo
    public partial class Vex
    {
        public partial class Flow
        {
            public class Crescendo:Note
            {

                #region 静态
                public static void RenderHairpin(object ctx, IList<object> @params)
                { } 
                #endregion


                #region 属性字段

                private bool decrescendo;

                public bool Decrescendo
                {
                    set { decrescendo = value; }
                }
                private int line;

                public int Line
                {
                    set { line = value; }
                }
                private double height;

                public double Height
                {
                    set { height = value; }
                } 
                #endregion


                #region 方法
                public Crescendo(object note_struct)
                    : base(note_struct)
                {
                    Init(note_struct);
                }



                public void Init(object note_struct)
                { }



                public Crescendo PreFormat()
                {
                    this.PreFormatted = true;
                    return this;
                }

                public void Draw()
                { } 
                #endregion
            }
        }
    }
}
