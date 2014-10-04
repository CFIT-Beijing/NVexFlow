//对应 stavetext.js
using System;
using NVexFlow.Model;
namespace NVexFlow
{
    public class StaveText:Modifier
    {
        #region js直译部分
        public StaveText(string text,ModifierPosition position,StaveTextOpts options)
        {
            Init(text,position,options);
        }
        private void Init(string text,ModifierPosition position,StaveTextOpts options)
        {
            this.SetWidth(16);
            this.text = text;
            this.position = position;
            this.options = new StaveTextOpts() {
                shift_x = 0,
                shift_y = 0,
                justification = TextNote.TextNoteJustification.CENTER
            };

            Vex.Merge(this.options,options);
            this.font = new Font() {
                family = "times",
                size = 16,
                weight = "normal"
            };
        }
        public override string GetCategory()
        {
            return "stavetext";
        }
        public StaveText SetStaveText(string text)
        {
            this.text = text;
            return this;
        }
        public StaveText SetShiftX(double shiftX)
        {
            this.shift_x = shiftX;
            return this;
        }
        public StaveText SetShiftY(double shiftY)
        {
            this.shift_y = shiftY;
            return this;
        }
        public StaveText SetFont(Font font)
        {
            if (!string.IsNullOrEmpty(font.family))
            {
                this.font.family = font.family;
            }
            if (font.size.HasValue)
            {
                this.font.size = font.size;
            }
            if (!string.IsNullOrEmpty(font.weight))
            {
                this.font.weight = font.weight;
            }
            if (!string.IsNullOrEmpty(font.style))
            {
                this.font.style = font.style;
            }
            if (!string.IsNullOrEmpty(font.font))
            {
                this.font.font = font.font;
            }
            return this;
        }
        public StaveText SetText(string text)
        {
            this.text = text;
            return this;
        }
        public void Draw(Stave stave)
        {
            throw new NotImplementedException();
        }
        #endregion


        #region 隐含的字段
        public string text;
        public double shift_x;
        public double shift_y;
        public StaveTextOpts options;
        #endregion
    }
}
