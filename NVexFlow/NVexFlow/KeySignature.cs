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
        public KeySignature(string key_spec)
        {
            Init(key_spec);
        }
        private void Init(string key_spec)
        {
            this.glyph_font_scale = 38;// TODO(0xFE): Should this match StaveNote?
            this.acc_list = Flow.keySignature(key_spec);
        }
        public void AddAccToStave(Stave stave, Acc acc)
        {
            Glyph glyph = new Glyph(acc.glyph_code, this.glyph_font_scale);
            this.PlaceGlyphOnLine(glyph, stave, acc.line);
            stave.AddGlyph(glyph);
        }
        public override void AddModifier(Stave stave)
        {
            this.ConvertAccLines(stave.clef, this.acc_list[0].glyph_code);
            for (int i = 0; i < this.acc_list.Count(); ++i)
            {
                this.AddAccToStave(stave, this.acc_list[i]);
            }
        }
        public KeySignature AddToStave(Stave stave, bool first_glyph)
        {
            if (this.acc_list.Count <= 0)
            {
                return this;
            }
            if (!first_glyph)
            {
                stave.AddGlyph(this.MakeSpacer(this.padding));
            }
            this.AddModifier(stave);
            return this;
        }
        public void ConvertAccLines(string clef, string code)
        {
            double offset = 0.0; // if clef === "treble"
            IList<double> tenor_sharps;
            bool is_tenor_sharps = ((clef == "tenor") && (code == "v18")) ? true : false;
            switch (clef)
            {
                case "bass":
                    offset = 1;
                    break;
                case "alto":
                    offset = 0.5;
                    break;
                case "tenor":
                    if (!is_tenor_sharps)
                    {
                        offset = -0.5;
                    }
                    break;
            }

            // Special-case for TenorSharps
            int i;
            if (is_tenor_sharps)
            {
                tenor_sharps = new List<double>() { 3, 1, 2.5, 0.5, 2, 0, 1.5 };
                for (i = 0; i < this.acc_list.Count(); ++i)
                {
                    this.acc_list[i].line = tenor_sharps[i];
                }
            }
            else
            {
                if (clef != "treble")
                {
                    for (i = 0; i < this.acc_list.Count(); ++i)
                    {
                        this.acc_list[i].line += offset;
                    }
                }
            }
        }
        #endregion


        #region 隐含字段
        public IList<Acc> acc_list;
        public int glyph_font_scale;
        #endregion
    }
}
