using System.Collections.Generic;
using NVexFlow.Model;

namespace NVexFlow
{
    public partial class Vex
    {
        public partial class Flow
        {
            public class TextNote : Note
            {
                #region 静态
                public enum TextNoteJustification
                {
                    LEFT,
                    CENTER,
                    RIGHT
                }

                public static IDictionary<string, object> GLYPHS;

                #endregion


                #region 属性字段

                object text;
                object superscript;
                object subscript;
                object glyphType;
                object glyph;
                Font font;
                double width;
                bool smooth;
                bool ignoreTicks;
                TextNoteJustification justification;
                public TextNoteJustification Justification
                {
                    set { justification = value; }
                }

                object line;

                public object Line
                {
                    set { line = value; }
                }
                #endregion


                #region 方法

                public TextNote(NoteStruct text_struct)
                    : base(text_struct)
                {
                    Init(text_struct);
                }

                private void Init(NoteStruct text_struct)
                { }





                public void PreFormat()
                { }

                public void Draw() { }
                #endregion

                public override string Category
                {
                    get { throw new System.NotImplementedException(); }
                }
            }
        }
    }
}
