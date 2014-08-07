using System.Collections.Generic;
using NVexFlow.Model;

namespace NVexFlow
{
    public class Clef:StaveModifier
    {
        #region 静态
        private static IDictionary<string,ClefType> types = new Dictionary<string,ClefType>()
                {
                    {"treble",new ClefType(){code="v83",point=40,line=3}},
                    {"bass",new ClefType(){code="v79",point=40,line=1}}
            //...
        };

        public static IDictionary<string,ClefType> Types
        {
            get
            { return Clef.types; }
            set
            { Clef.types = value; }
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

        private void Init(string clef)
        { }

        public void AddModifier(Stave stave)
        { }

        public void AddEndModifier(Stave stave)
        { }
        #endregion
    }
}
