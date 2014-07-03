
namespace NVexFlow
{
    public partial class Vex
    {
        public partial class Flow
        {
            /// <summary>
            /// ## Description
            //
            // `Modifier` is an abstract interface for notational elements that modify
            // a `Note`. Examples of modifiers are `Accidental`, `Annotation`, `Stroke`, etc.
            //
            // For a `Modifier` instance to be positioned correctly, it must be part of
            // a `ModifierContext`. All modifiers in the same context are rendered relative to
            // one another.
            //
            // Typically, all modifiers to a note are part of the same `ModifierContext` instance. Also,
            // in multi-voice staves, all modifiers to notes on the same `tick` are part of the same
            // `ModifierContext`. This ensures that multiple voices don't trample all over each other.
            /// </summary>
            public abstract class Modifier
            {

                #region 枚举
                public enum ModifierPosition
                {
                    LEFT,
                    RIGHT,
                    ABOVE,
                    BELOW
                } 
                #endregion


                #region 属性字段
                private double width;
                /// <summary>
                /// Get and set modifier widths.
                /// </summary>
                public virtual double Width
                {
                    get { return width; }
                    set { width = value; }
                }
                private CanvasContext context;
                /// <summary>
                /// Get and set rendering context.
                /// </summary>
                public virtual CanvasContext Context
                {
                    get { return context; }
                    set { context = value; }
                }
                private Note note;
                /// <summary>
                /// Get and set attached note (`StaveNote`, `TabNote`, etc.)
                /// </summary>
                public virtual Note Note
                {
                    get { return note; }
                    set { note = value; }
                }
                private object index;
                /// <summary>
                /// Get and set note index, which is a specific note in a chord.
                /// </summary>
                public virtual object Index
                {
                    get { return index; }
                    set { index = value; }
                }
                private int textLine;
                /// <summary>
                /// Set the `text_line` for the modifier.
                /// </summary>
                public virtual int TextLine
                {
                    get { return textLine; }
                    set { textLine = value; }
                }
                private ModifierPosition position;
                /// <summary>
                /// Get and set articulation position.
                /// </summary>
                public virtual ModifierPosition Position
                {
                    get { return position; }
                    set { position = value; }
                }
                private object modifierContext;
                /// <summary>
                /// Every modifier must be part of a `ModifierContext`.
                /// </summary>
                public virtual object ModifierContext
                {
                    get { return modifierContext; }
                    set { modifierContext = value; }
                }
                private double xShift;
                /// <summary>
                /// Shift modifier `x` pixels in the direction of the modifier. Negative values shift reverse.
                /// </summary>
                public virtual double XShift
                {
                    get { return xShift; }
                    set {
                        this.xShift = 0;
                        if (this.position == Modifier.ModifierPosition.LEFT)
                        {
                            this.xShift -= value;
                        }
                        else
                        {
                            this.xShift += value;
                        }
                    }
                }
                private double yShift;
                /// <summary>
                /// Shift modifier down `y` pixels. Negative values shift up.
                /// </summary>
                public virtual double YShift
                {
                    get { return yShift; }
                    set { yShift = value; }
                }

                
                #endregion


                #region 方法
                public Modifier()
                {
                    Init();
                }

                public virtual void Init()
                {
                    this.width = 0;
                    this.context = null;

                    // Modifiers are attached to a note and an index. An index is a
                    // specific head in a chord.
                    this.note = null;
                    this.index = null;

                    // The `textLine` is reserved space above or below a stave.
                    this.textLine = 0;
                    this.position = Modifier.ModifierPosition.LEFT;
                    this.modifierContext = null;
                    this.xShift = 0;
                    this.yShift = 0;
                }



                public abstract void Draw();


                #endregion


            }
        }
    }
}
