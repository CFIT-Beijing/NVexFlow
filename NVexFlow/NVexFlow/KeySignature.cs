
namespace NVexFlow
{//KeySignature
    public partial class Vex
    {
        public partial class Flow
        {
            public class KeySignature : StaveModifier
            {
                #region 静态
                public static void AccidentalList(string acc)
                { }
                #endregion


                #region 属性字段
                object accList;
                int glyphFontScale;
                #endregion


                #region 方法
                public KeySignature(object keySpec)
                {
                    Init(keySpec);
                }

                public void Init(object keySpec)
                {

                }

                public void AddAccToStave(Stave stave, object acc)
                { }

                public void AddModifier(Stave stave)
                { }

                public KeySignature AddToStave(Stave stave, object firstGlyph)
                {
                    return this;
                }

                public void ConvertAccLines(string clef, string code)
                { }
                #endregion
            }
        }

    }
}
