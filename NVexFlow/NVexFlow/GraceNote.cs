﻿//gracenote
using NVexFlow.Model;
namespace NVexFlow
{
    public class GraceNote:StaveNote
    {
        #region js直译部分
        public GraceNote(GraceNoteStruct noteStruct)
            : base(noteStruct)
        {
            Init(noteStruct);
        }
        private void Init(GraceNoteStruct noteStruct)
        {
            //GraceNote.superclass.init.call(this, note_struct);
            (this.renderOptions as GraceNoteRenderOpts).glyphFontScale = 22;
            (this.renderOptions as GraceNoteRenderOpts).stemHeight = 20;
            (this.renderOptions as GraceNoteRenderOpts).strokePx = 2;
            this.glyph.headWidth = 6;

            this.slash = noteStruct.slash;
            this.slur = true;

            this.BuildNoteHeads();
            this.SetWidth(3);
        }

        public override double GetStemExtension()
        {
            Glyph4Note glyph= this.GetGlyph();
            if (this.stemExtensionOverride != null)
            {
                return this.stemExtensionOverride.Value;
            }

            if (glyph != null)
            {
                return this.GetStemExtension() == 1 ? glyph.gracenoteStemUpExtension : glyph.gracenoteStemDownExtension;
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
