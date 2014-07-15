
using NVexFlow.Model;
namespace NVexFlow
{
    //GraceNote
    public partial class Vex
    {
        public partial class Flow
        {
            public class GraceNote : StaveNote
            {

                #region 属性字段
                object renderOptions;
                object glyph;
                object slash;
                bool slur;
                double width;
                #endregion


                #region 方法
                public GraceNote(NoteStruct note_struct)
                    : base(note_struct)
                {
                    //this.renderOptions.glyph_font_scale = 22;
                    //this.renderOptions.stem_height = 20;
                    //this.renderOptions.stroke_px = 2;
                    //this.glyph.head_width = 6;

                    //this.slash = noteStruct.slash;
                    //this.slur = true;

                    //this.buildNoteHeads();

                    //this.width = 3;
                }


                public object GetStemExtension()
                {
                    return null;
                }

                public void Draw()
                { }
                #endregion
            }
        }
    }
}
