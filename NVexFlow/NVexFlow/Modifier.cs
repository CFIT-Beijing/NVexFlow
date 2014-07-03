//对应modifier.js
//框架：    已完成
//类型定义：存在改进空间
//原js：    存在改进空间
namespace NVexFlow
{
    public partial class Vex
    {
        public partial class Flow
        {
            /// <summary>
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
                //严格按照JS文件顺序翻译
                //现在先保持JS分开构造函数Modifier()和初始化函数Init()的形式
                //下一阶段合并构造函数，不再出现单独的Init()
                public Modifier() { Init(); }
                //// To enable logging for this class. Set `Vex.Flow.Modifier.DEBUG` to `true`.
                //function L() { if (Modifier.DEBUG) Vex.L("Vex.Flow.Modifier", arguments); }
                public enum ModifierPosition
                {
                    LEFT = 1,
                    RIGHT = 2,
                    ABOVE = 3,
                    BELOW = 4
                }
                /// <summary>
                /// The constructor sets initial widhts and constants.
                /// </summary>
                public virtual void Init()
                {
                    //暂时不理会初始化函数顺序和属性get/set顺序不同问题
                    //以后再完善这些细节一致性，进一步增加代码可读性
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
                    //L("Created new modifier");
                }
                //现在先保留返回string的情况，以后看情况是否须有建立相应enum
                // Every modifier has a category. The `ModifierContext` uses this to determine
                // the type and order of the modifiers.
                public virtual string Category { get { return "none"; } }
                //把私有字段放在属性后面方便和JS文件对照
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

                private double width;

                /// <summary>
                /// Get and set attached note (`StaveNote`, `TabNote`, etc.)
                /// </summary>
                public virtual Note Note
                {
                    get { return note; }
                    set { note = value; }
                }
                private Note note;
                /// <summary>
                /// Get and set note index, which is a specific note in a chord.
                /// </summary>
                public virtual object Index
                {
                    get { return index; }
                    set { index = value; }
                }
                private object index;

                /// <summary>
                /// Every modifier must be part of a `ModifierContext`.
                /// </summary>
                public virtual object ModifierContext
                {
                    get { return modifierContext; }
                    set { modifierContext = value; }
                }
                private object modifierContext;
                /// <summary>
                /// Get and set articulation position.
                /// </summary>
                public virtual ModifierPosition Position
                {
                    get { return position; }
                    set { position = value; }
                }
                private ModifierPosition position;
                /// <summary>
                /// Set the `text_line` for the modifier.
                /// </summary>
                public virtual int TextLine
                {
                    set { textLine = value; }
                }
                private int textLine;
                /// <summary>
                /// Shift modifier down `y` pixels. Negative values shift up.
                /// </summary>
                public virtual double YShift
                {
                    set { yShift = value; }
                }
                private double yShift;
                /// <summary>
                /// Shift modifier `x` pixels in the direction of the modifier. Negative values shift reverse.
                /// </summary>
                public virtual double XShift
                {
                    set
                    {
                        //现在先保留这种先赋值为0在+=或-=的奇怪方式
                        //以后可以改成直接=value或=-value的正常方式
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
                private double xShift;
                /// <summary>
                /// Render the modifier onto the canvas.
                /// </summary>
                public abstract void Draw();
            }
        }
    }
}
