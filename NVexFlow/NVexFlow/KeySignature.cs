﻿namespace NVexFlow
{//KeySignature
    public class KeySignature:StaveModifier
    {
        #region 静态
        public static void AccidentalList(string acc)
        { }
        #endregion


        #region 隐含字段
        object accList;
        int glyphFontScale;
        #endregion


        #region js直译部分
        public KeySignature(object keySpec)
        {
            Init(keySpec);
        }

        private void Init(object keySpec)
        {

        }

        public void AddAccToStave(Stave stave,object acc)
        { }

        public void AddModifier(Stave stave)
        { }

        public KeySignature AddToStave(Stave stave,object firstGlyph)
        {
            return this;
        }

        public void ConvertAccLines(string clef,string code)
        { }
        #endregion
    }
}
