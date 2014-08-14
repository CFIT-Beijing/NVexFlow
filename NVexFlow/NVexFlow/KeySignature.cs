using System.Collections;
using System.Collections.Generic;
using System.Linq;
//keysignature.js
using NVexFlow.Model;
namespace NVexFlow
{
    /// <summary>
    ///Vex Flow Notation
    // Implements key signatures
    //
    // Requires vex.js.
    /// </summary>
    public class KeySignature : StaveModifier
    {
        #region js直译部分
        public KeySignature(string keySpec)
        {
            Init(keySpec);
        }
        private void Init(string keySpec)
        {
            this.glyphFontScale = 38;// TODO(0xFE): Should this match StaveNote?
            this.accList = Flow.keySignature(keySpec);
        }
        public void AddAccToStave(Stave stave, Acc acc)
        {
            Glyph glyph = new Glyph(acc.glyphCode, this.glyphFontScale);
            this.PlaceGlyphOnLine(glyph, stave, acc.line);
            stave.AddGlyph(glyph);
        }
        public override void AddModifier(Stave stave)
        {
            this.ConvertAccLines(stave.clef, this.accList[0].glyphCode);
            for (int i = 0; i < this.accList.Count(); ++i)
            {
                this.AddAccToStave(stave, this.accList[i]);
            }
        }
        public KeySignature AddToStave(Stave stave, bool firstGlyph)
        {
            if (this.accList.Count <= 0)
            {
                return this;
            }
            if (!firstGlyph)
            {
                stave.AddGlyph(this.MakeSpacer(this.padding));
            }
            this.AddModifier(stave);
            return this;
        }
        public void ConvertAccLines(string clef, string code)
        {
            double offset = 0.0; // if clef === "treble"
            IList<double> tenorSharps;
            bool isTenorSharps = ((clef == "tenor") && (code == "v18")) ? true : false;
            switch (clef)
            {
                case "bass":
                    offset = 1;
                    break;
                case "alto":
                    offset = 0.5;
                    break;
                case "tenor":
                    if (!isTenorSharps)
                    {
                        offset = -0.5;
                    }
                    break;
            }

            // Special-case for TenorSharps
            int i;
            if (isTenorSharps)
            {
                tenorSharps = new List<double>() { 3, 1, 2.5, 0.5, 2, 0, 1.5 };
                for (i = 0; i < this.accList.Count(); ++i)
                {
                    this.accList[i].line = tenorSharps[i];
                }
            }
            else
            {
                if (clef != "treble")
                {
                    for (i = 0; i < this.accList.Count(); ++i)
                    {
                        this.accList[i].line += offset;
                    }
                }
            }
        }
        #endregion


        #region 隐含字段
        protected IList<Acc> accList;
        protected int glyphFontScale;
        #endregion
    }
}
