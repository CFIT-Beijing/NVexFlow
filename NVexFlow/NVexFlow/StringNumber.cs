//对应 stringnumber.js
using System;

namespace NVexFlow
{
    /// <summary>
    /// Class to draws string numbers into the notation.
    /// </summary>
    public class StringNumber:Modifier
    {
        #region js直译部分
        public StringNumber(string number)
        {
            Init(number);
        }

        private void Init(string number)
        {
            this.note = null;
            this.lastNote = null;
            this.index = null;
            this.stringNumber = number;
            this.SetWidth(20);
            this.position = ModifierPosition.ABOVE;  // Default position above stem or note head
            this.xShift = 0;
            this.yShift = 0;
            this.xOffset = 0;                               // Horizontal offset from default
            this.yOffset = 0;                               // Vertical offset from default
            this.dashed = true;                              // true - draw dashed extension  false - no extension
            this.leg = Renderer.RendererLineEndType.NONE;   // draw upward/downward leg at the of extension line
            this.radius = 8;
            this.font = new Font() {
                family = "sans-serif",
                size = 10,
                weight = "bold"
            };
        }
        public override string GetCategory()
        {
            return "stringnumber";
        }
        public override Note GetNote()
        {
            return this.note;
        }
        public new StringNumber SetNote(Note note)
        {
            this.note = note;
            return this;
        }
        public override int GetIndex()
        {
            return this.index.Value;
        }
        public new StringNumber SetIndex(int Index)
        {
            this.index = Index;
            return this;
        }
        public StringNumber SetLineEndType(NVexFlow.Renderer.RendererLineEndType leg)
        {
            if (leg >= Renderer.RendererLineEndType.NONE && leg <= Renderer.RendererLineEndType.DOWN)
            {
                this.leg = leg;
            }
            return this;
        }
        public override Modifier.ModifierPosition GetPosition()
        {
            return this.position;
        }
        public new StringNumber SetPosition(ModifierPosition position )
        {
            if (position >= ModifierPosition.LEFT && position <= ModifierPosition.BELOW)
            {
                this.position = position;
            }
            return this;
        }
        public StringNumber SetStringNumber(string number)
        {
            this.stringNumber = number;
            return this;
        }
        public StringNumber SetXOffset(double x)
        {
            this.xOffset = x;
            return this;
        }
        public StringNumber SetYOffset(double y)
        {
            this.yOffset = y;
            return this;
        } 
        public StringNumber SetLastNote(object note)
        {
            this.lastNote = note;
            return this;
        }
        public StringNumber SetDashed(bool dashed)
        {
            this.dashed = dashed;
            return this;
        }
        public override void Draw()
        {
            throw new NotImplementedException();
        }
        #endregion
        #region 隐含的字段
        public double xOffset;
        public double yOffset;
        public object lastNote;
        public bool dashed;
        public Renderer.RendererLineEndType leg;
        public string stringNumber;
        public int radius;
        #endregion
    }
}
