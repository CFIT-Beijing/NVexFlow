//对应 stavesection.js
using System;
namespace NVexFlow
{
    public class StaveSection:Modifier
    {
        #region js直译部分
        public StaveSection(object section,double x,double shift_y)
        {
            Init(section,x,shift_y);
        }
        private void Init(object section,double x,double shift_y)
        {
            this.width = 16;
            this.section = section;
            this.position = ModifierPosition.ABOVE;
            this.x = x;
            this.shiftX = 0;
            this.shiftY = shift_y;
            this.font = new Font() {
                family = "sans-serif",
                size = 12,
                weight = "bold"
            };
        }
        public override string GetCategory()
        {
            return "stavesection";
        }
        public StaveSection SetSection(object section)
        {
            this.section = section;
            return this;
        }
        public StaveSection SetShiftX(double shiftX)
        {
            this.shiftX = shiftX;
            return this;
        }
        public StaveSection SetShiftY(double shiftY)
        {
            this.shiftY = shiftY;
            return this;
        }
        public void Draw(object stave,double shift_x)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region 隐含的字段
        public object section;
        public double shiftX;
        public double shiftY;
        public double x;
        #endregion
    }
}
