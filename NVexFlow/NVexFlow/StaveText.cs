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
            this.Width = 16;
            this.text = text;
            this.position = position;
            this.options = new StaveTextOpts() {
                shiftX = 0,
                shiftY = 0,
                justification = TextNote.TextNoteJustification.CENTER
            };

            Vex.Merge(this.options,options);
            this.font = new Font() {
                family = "times",
                size = 16,
                weight = "normal"
            };
        }
        public override string Category
        {
            get
            {
                return "stavetext";
            }
        }
        public string StaveTxt
        {
            set
            {
                this.text = value;
            }
        }
        public double ShiftX
        {
            set
            {
                shiftX = value;
            }
        }
        public double ShiftY
        {
            set
            {
                shiftY = value;
            }
        }
        public Font Font
        {
            set
            {
                Vex.Merge(this.font,value);
            }
        }
        public string Text
        {
            set
            {
                this.text = value;
            }
        }
        public void Draw(Stave stave)
        {
            throw new NotImplementedException();
        }
        #endregion


        #region 隐含的字段
        protected string text;
        protected double shiftX;
        protected double shiftY;
        protected StaveTextOpts options;
        #endregion
    }
}
