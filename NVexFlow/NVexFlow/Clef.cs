using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NVexFlow.MODEL;

namespace NVexFlow
{
    public partial class Vex
    {
        public partial class Flow
        {

            public class Clef:StaveModifier
            {
                #region 静态
                private static IDictionary<string, MODEL.ClefType> types = new Dictionary<string, MODEL.ClefType>() 
                {
                    {"treble",new MODEL.ClefType(){Code="v83",Point=40,Line=3}},
                    {"bass",new MODEL.ClefType(){Code="v79",Point=40,Line=1}}
                    //...
                };

                public static IDictionary<string, MODEL.ClefType> Types
                {
                    get { return Clef.types; }
                    set { Clef.types = value; }
                }
                #endregion


                #region 属性字段
                ClefType clef; 
                #endregion


                #region 方法
                public Clef(string clef)
                {
                    Init(clef);
                }

                public void Init(string clef)
                { }

                public void AddModifier(Stave stave)
                { }

                public void AddEndModifier(Stave stave)
                { } 
                #endregion
            }
        }
    }
}
