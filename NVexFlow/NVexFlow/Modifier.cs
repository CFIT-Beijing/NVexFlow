//对应 modifier.js
using System;

namespace NVexFlow
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
        #region js直译部分
        //严格按照JS文件顺序翻译
        //现在先保持JS分开构造函数Modifier()和初始化函数Init()的形式
        //下一阶段合并构造函数，不再出现单独的Init()
        public Modifier()
        {
            Init();
        }
        //// To enable logging for this class. Set `Vex.Flow.Modifier.DEBUG` to `true`.
        //function L() { if (Modifier.DEBUG) Vex.L("Vex.Flow.Modifier", arguments); }
        public enum ModifierPosition
        {
            CENTER = 0,//Tremolo用到
            LEFT = 1,
            RIGHT = 2,
            ABOVE = 3,
            BELOW = 4
        }
        /// <summary>
        /// The constructor sets initial widhts and constants.
        /// </summary>
        private void Init()
        {//C#缺省初始化可以替代这个初始化，里程碑2阶段省去这个初始化
            //暂时不理会初始化函数顺序和属性get/set顺序不同问题
            //以后再完善这些细节一致性，进一步增加代码可读性
            this.width = 0;
            this.context = null;

            // Modifiers are attached to a note and an index. An index is a
            // specific head in a chord.
            this.note = null;
            this.index = null;

            // The `textLine` is reserved space above or below a stave.
            this.text_line = 0;
            this.position = Modifier.ModifierPosition.LEFT;
            this.modifier_context = null;
            this.x_shift = 0;
            this.y_shift = 0;
            //L("Created new modifier");
        }
        //现在先保留返回string的情况，以后看情况是否须有建立相应enum
        // Every modifier has a category. The `ModifierContext` uses this to determine the type and order of the modifiers.
        public virtual string GetCategory()
        {
            return "none";
        }
        //把私有字段放在属性后面方便和JS文件对照
        /// <summary>
        /// Get and set modifier widths.
        /// </summary>
        public virtual double GetWidth()
        {
            return width;
        }
        public Modifier SetWidth(double width)
        {
            this.width = width;
            return this;
        }
        /// <summary>
        /// Get and set attached note (`StaveNote`, `TabNote`, etc.)
        /// </summary>    
        public virtual Note GetNote()
        {
            return note;
        }
        public Modifier SetNote(Note note)
        {
            this.note = note;
            return this;
        }
        /// <summary>
        /// Get and set note index, which is a specific note in a chord.
        /// </summary>
        public virtual int GetIndex()
        {
            return index.Value;
        }
        public Modifier SetIndex(int index)
        {
            this.index = index;
            return this;
        }
        /// <summary>
        /// Get and set rendering context.
        /// </summary>
        public virtual CanvasContext GetContext()
        {
            return context;
        }
        public Modifier SetContext(CanvasContext context)
        {
            this.context = context;
            return this;
        }
        /// <summary>
        /// Every modifier must be part of a `ModifierContext`.
        /// </summary>
        public virtual ModifierContext GetModifierContext()
        {
            return modifier_context;
        }
        public Modifier SetModifierContext(ModifierContext modifier_context)
        {
            this.modifier_context = modifier_context;
            return this;
        }
        /// <summary>
        /// Get and set articulation position.
        /// </summary>
        public virtual ModifierPosition GetPosition()
        {
            return position;
        }
        public Modifier SetPosition(ModifierPosition position)
        {
            this.position = position;
            return this;
        }
        /// <summary>
        /// Set the `text_line` for the modifier.
        /// </summary>
        public Modifier SetTextLine(int text_line)
        {
            this.text_line = text_line;
            return this;
        }
        /// <summary>
        /// Shift modifier down `y` pixels. Negative values shift up.
        /// </summary>
        public Modifier SetYShift(int y)
        {
            this.y_shift = y;
            return this;
        }
        /// <summary>
        /// Shift modifier `x` pixels in the direction of the modifier. Negative values shift reverse.
        /// </summary>
        public Modifier SetXShift(int x)
        {
            //现在先保留这种先赋值为0在+=或-=的奇怪方式
            //以后可以改成直接=value或=-value的正常方式
            this.x_shift = 0;
            if (this.position == Modifier.ModifierPosition.LEFT)
            {
                this.x_shift -= x;
            }
            else
            {
                this.x_shift += x;
            }
            return this;
        }
        /// <summary>
        /// Render the modifier onto the canvas.
        /// </summary>
        public virtual void Draw()
        {//曾在StaveSection这样不适用无参数draw的子类
            throw new NotImplementedException();
        }
        #endregion

        #region 隐含的字段
        public double width;
        public CanvasContext context;
        public Note note;
        public int? index;
        public int text_line;
        public ModifierPosition position;
        public ModifierContext modifier_context;
        public double x_shift;
        public double y_shift;
        //每个子类都有font字段，是不是放到抽象类里？还是按照js的放到每个类里？
        //放这里可以，不过这个是里程碑2的工作任务了。
        public Font font;
        #endregion
    }
}
