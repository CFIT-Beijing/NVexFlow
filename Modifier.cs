using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZhCJB.VexFlow.CS
{
    public partial class Vex
    {
        public partial class Flow
        {
            public class Modifier
            {
                #region 属性字段
                private double width;

                public virtual double Width
                {
                    get { return width; }
                    set { width = value; }
                }
                private object context;

                public object Context
                {
                    get { return context; }
                    set { context = value; }
                }
                private object note;

                public virtual object Note
                {
                    get { return note; }
                    set { note = value; }
                }
                private object index;

                public object Index
                {
                    get { return index; }
                    set { index = value; }
                }
                private int textLine;

                public int Text_line
                {
                    get { return textLine; }
                    set { textLine = value; }
                }
                private ModifierPosition position;

                public virtual ModifierPosition Position
                {
                    get { return position; }
                    set { position = value; }
                }
                private object modifierContext;

                public object ModifierContext
                {
                    get { return modifierContext; }
                    set { modifierContext = value; }
                }
                private double xShift;

                public virtual double XShift
                {
                    get { return xShift; }
                    set { xShift = value; }
                }
                private double yShift;

                public double YShift
                {
                    get { return yShift; }
                    set { yShift = value; }
                }

                public enum ModifierPosition
                {
                    LEFT,
                    RIGHT,
                    ABOVE,
                    BELOW
                }
                #endregion


                #region 方法
                public Modifier()
                {

                }

                public virtual void Init()
                {
                    //                this.width = 0;
                    //this.context = null;

                    //// Modifiers are attached to a note and an index. An index is a
                    //// specific head in a chord.
                    //this.note = null;
                    //this.index = null;

                    //// The `textLine` is reserved space above or below a stave.
                    //this.textLine = 0;
                    //this.position = Modifier.Position.LEFT;
                    //this.modifierContext = null;
                    //this.xShift = 0;
                    //this.yShift = 0;
                    //L("Created new modifier");
                }



                public virtual void Draw()
                { }

                
                #endregion


            }
        }
    }
}
