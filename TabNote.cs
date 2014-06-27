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
            public class TabNote:StemmableNote
            {
                #region 属性字段
                bool ghost;

                public bool Ghost
                {
                    set
                    {
                        ghost = value;
                        UpdateWidth();
                    }
                }

                IList<object> positions;

                public override Stave Stave
                {
                    set
                    {
                        base.Stave = value;
                    }
                }


                public IList<object> Positions
                {
                    get { return positions; }
                }
                object glyph;
                #endregion


                #region 方法

                public TabNote(object tab_struct, object draw_stem)
                    : base(tab_struct)
                { Init(tab_struct, draw_stem); }

                public void Init(object tab_struct, object draw_stem)
                { }

                public void UpdateWidth()
                { }



                public object HasStem()
                {
                    return null;
                }

                public int GetStemExtension()
                {
                    return 0;
                }

                public object AddDot()
                {
                    return null;
                }



                public override void AddToModifierContext(object mc)
                {
                    base.AddToModifierContext(mc);
                }

                public double GetTieRightX()
                { return 0; }

                public double GetTieLeftX()
                { return 0; }

                public object GetModifierStartXY(object position, object index)
                { return null; }

                public string GetLineForRest()
                {
                    return "";
                }

                public override void PreFormat()
                {
                    base.PreFormat();
                }

                public double GetStemX()
                { return 0; }

                public double GetStemY()
                {
                    return 0;
                }

                public object GetStemExtents()
                {
                    return null;
                }

                public void DrawFlag()
                { }

                public void DrawModifiers()
                { }

                public void DrawStemThrough()
                { }

                public void DrawPositions()
                { }

                public void Draw()
                { }

                public static object GetUnusedStringGroups(int num_lines, object strings_used)
                {
                    return null;
                }

                public static object GetPartialStemLines(double stem_y, object unused_strings, object stave, object stem_direction)
                {
                    return null;
                } 
                #endregion
            }
        }
    }
}
