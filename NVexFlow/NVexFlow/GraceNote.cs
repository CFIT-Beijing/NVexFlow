//gracenote
using NVexFlow.Model;
namespace NVexFlow
{
    public class GraceNote:StaveNote
    {
        #region js直译部分
        public GraceNote(GraceNoteStruct note_struct)
            : base(note_struct)
        {
            Init(note_struct);
        }
        private void Init(GraceNoteStruct note_struct)
        {
            //GraceNote.superclass.init.call(this, note_struct);
            (this.render_options as GraceNoteRenderOpts).glyph_font_scale = 22;
            (this.render_options as GraceNoteRenderOpts).stem_height = 20;
            (this.render_options as GraceNoteRenderOpts).stroke_px = 2;
            this.glyph.head_width = 6;

            this.slash = note_struct.slash;
            this.slur = true;

            this.BuildNoteHeads();
            this.SetWidth(3);
        }

        public override double GetStemExtension()
        {
            Glyph4Note glyph= this.GetGlyph();
            if (this.stem_extension_override != null)
            {
                return this.stem_extension_override.Value;
            }

            if (glyph != null)
            {
                return this.GetStemExtension() == 1 ? glyph.gracenote_stem_up_extension : glyph.gracenote_stem_down_extension;
            }

            return 0;
        }
        public override string GetCategory()
        {
            return "gracenotes";
        }
        public override void Draw()
        {
            //          GraceNote.superclass.draw.call(this);
            //var ctx = this.context;
            //var stem_direction = this.getStemDirection();

            //if (this.slash) {
            //  ctx.beginPath();

            //  var x = this.getAbsoluteX();
            //  var y = this.getYs()[0] - (this.stem.getHeight() / 2.8);
            //  if (stem_direction === 1) {
            //    x += 1;
            //    ctx.lineTo(x, y);
            //    ctx.lineTo(x + 13, y - 9);
            //  } else if (stem_direction === -1) {
            //    x -= 4;
            //    y += 1;
            //    ctx.lineTo(x, y);
            //    ctx.lineTo(x + 13, y + 9);
            //  }

            //  ctx.closePath();
            //  ctx.stroke();
            //}
        }
        #endregion

        #region 隐含字段
        public bool slash;
        public bool slur;
        #endregion



    }
}
