using System;
//stavemodifier.js
using System.Collections.Generic;
using NVexFlow.Model;

namespace NVexFlow
{
    /// <summary>
    // A base class for stave modifiers (e.g. clefs, key signatures)
    /// </summary>
    public class StaveModifier
    {
        #region js直译部分
        public StaveModifier()
        {
            Init();
        }
        private void Init()
        {
            this.padding = 10;
        }
        public virtual string GetCategory()
        {
            return "";
        }
        public Glyph MakeSpacer(double padding)
        {
            return new MakeSpacerRes()
            {
                getContext = () => { return true; },
                setStave = () => { },
                renderToStave = () => { },
                getMetrics = () => { return new GetMetrics() { width = this.padding }; }
            };
        }
        public void PlaceGlyphOnLine(Glyph glyph, Stave stave, double line)
        {
            glyph.SetYShift(stave.GetYForLine(line) - stave.GetYForGlyphs());
        }
        public virtual void SetPadding(double padding)
        {
            this.padding = padding;
        }
        public StaveModifier AddToStave(Stave stave, bool? firstGlyph=null)
        {
            if (!firstGlyph.HasValue||firstGlyph.Value==false)
            {
                stave.AddGlyph(this.MakeSpacer(this.padding));
            }

            this.AddModifier(stave);
            return this;
        }
        public StaveModifier AddToStaveEnd(Stave stave, bool firstGlyph)
        {
            if (!firstGlyph)
            {
                stave.AddEndGlyph(this.MakeSpacer(this.padding));
            }
            else
            {
                stave.AddEndGlyph(this.MakeSpacer(2));
            }
            this.AddModifier(stave);
            return this;
        }
        public virtual void AddModifier(Stave stave)
        {
            throw new Exception("MethodNotImplemented,addModifier() not implemented for this stave modifier.");
        }
        public virtual void AddEndModifier(Stave stave)
        {
            throw new Exception("MethodNotImplemented,addEndModifier() not implemented for this stave modifier.");
        }
        #endregion


        #region 隐含字段
        protected double padding;
        #endregion




    }
}
