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
            this.last_note = null;
            this.index = null;
            this.string_number = number;
            this.SetWidth(20);
            this.position = ModifierPosition.ABOVE;  // Default position above stem or note head
            this.x_shift = 0;
            this.y_shift = 0;
            this.x_offset = 0;                               // Horizontal offset from default
            this.y_offset = 0;                               // Vertical offset from default
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
            this.string_number = number;
            return this;
        }
        public StringNumber SetXOffset(double x)
        {
            this.x_offset = x;
            return this;
        }
        public StringNumber SetYOffset(double y)
        {
            this.y_offset = y;
            return this;
        } 
        public StringNumber SetLastNote(object note)
        {
            this.last_note = note;
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
        public double x_offset;
        public double y_offset;
        public object last_note;
        public bool dashed;
        public Renderer.RendererLineEndType leg;
        public string string_number;
        public int radius;
        #endregion
    }
}
