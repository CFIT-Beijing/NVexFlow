//对应 frethandfinger.js
using System;

namespace NVexFlow
{
    /// <summary>
    /// Class to draws string numbers into the notation.
    /// </summary>
    public class FretHandFinger : Modifier
    {
        #region js直译部分
        public FretHandFinger(string number)
        {
            Init(number);
        }
        private void Init(string number)
        {
            this.note = null;
            this.index = null;
            this.finger = number;
            this.width = 7;
            this.position = Modifier.ModifierPosition.LEFT;  // Default position above stem or note head
            this.xShift = 0;
            this.yShift = 0;
            this.xOffset = 0;       // Horizontal offset from default
            this.yOffset = 0;       // Vertical offset from default
            this.font = new Font()
            {
                family = "sans-serif",
                size = 9,
                weight = "bold"
            };
        }
        public override string GetCategory()
        {
            return "frethandfinger";
        }
        public override Note GetNote()
        {
            return this.note;
        }
        public new FretHandFinger SetNote(Note note)
        {
            this.note = note;
            return this;
        }
        public override int GetIndex()
        {
            return this.index.Value;
        }
        public new FretHandFinger SetIndex(int index)
        {
            this.index = index;
            return this;
        }
        public override Modifier.ModifierPosition GetPosition()
        {
            return this.position;
        }
        public new FretHandFinger SetPosition(Modifier.ModifierPosition position)
        {
            if (position >= ModifierPosition.LEFT && position <= ModifierPosition.BELOW)
            {
                this.position = position;
            }
            return this;
        }
        public FretHandFinger SetFretHandFinger(string finger)
        {
            this.finger = finger;
            return this;
        }
        public FretHandFinger SetOffsetX(double x)
        {
            this.xOffset = x;
            return this;
        }
        public FretHandFinger SetOffsetY(double y)
        {
            this.xOffset = y;
            return this;
        }

        public override void Draw()
        {
            throw new NotImplementedException();
        }
        #endregion
        #region 隐含的字段
        public string finger;
        public double xOffset;
        public double yOffset;
        #endregion
    }
}
