﻿//对应 dot.js
using System;
namespace NVexFlow
{
    /// <summary>
    ///  This class implements dot modifiers for notes.
    /// </summary>
    public class Dot:Modifier
    {
        #region js直译部分
        public Dot()
        {
            Init();
        }
       private void Init()
        {
            this.note = null;
            this.index = null;
            this.position = Modifier.ModifierPosition.RIGHT;

            this.radius = 2;
            this.SetWidth(5); 
            this.dot_shift_y = 0;
        }
        public new Dot SetNote(Note note)
        {
            this.note = note;
            if (this.note.GetCategory() == "gracenotes")
            {
                this.radius *= 0.50;
                this.SetWidth(3);
            }
            return this;
        }
        public override string GetCategory()
        {
            return "dots";
        }
        public Dot SetDotShiftY(double dot_shift_y )
        {
            this.dot_shift_y=dot_shift_y;
            return this;
        }
        public override void Draw()
        {
            throw new NotImplementedException();
        }
        #endregion

        #region 隐含的字段
        public double dot_shift_y;
        public double radius;
        #endregion
    }
}
