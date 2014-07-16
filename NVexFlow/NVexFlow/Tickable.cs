//对应 Tickable.js

using System.Collections.Generic;

namespace NVexFlow
{
    public partial class Vex
    {
        public partial class Flow
        {
            public class Tickable
            {

                #region 属性字段
                private CanvasContext context;
                private object boundingBox;
                private Fraction ticks;
                private bool ignoreTicks;
                private double width;
                private double xShift;
                private object voice;
                private object tuplet;
                private object modifierContext;
                private bool preFormatted;
                private IList<object> modifiers;
                private object tickContext;
                private bool postFormatted;
                private double intrinsicTicks;
                private Fraction tickMultiplier;

                public virtual bool ShouldIgnoreTicks()
                {
                    return this.ignoreTicks;
                }
                public virtual double Width
                {
                    get { return width; }
                }
                public virtual double XShift
                {
                    set { xShift = value; }
                }

                public virtual object Voice
                {
                    get { return voice; }
                    set { voice = value; }
                }

                public virtual object Tuplet
                {
                    get { return tuplet; }
                    set
                    {
                        //需要重写
                        tuplet = value;
                    }
                }

                public virtual bool PreFormatted
                {
                    set { this.preFormatted = value; }
                }
                public virtual object TickContext
                {
                    set
                    {
                        tickContext = value;
                        this.preFormatted = false;
                    }
                }
                public virtual Tickable PostFormat()
                {
                    if (this.postFormatted == true)
                    {
                        return null;
                    }
                    this.postFormatted = true;
                    return this;
                }
                public virtual double IntrinsicTicks
                {
                    get { return intrinsicTicks; }
                    set
                    {
                        //需要重写
                        intrinsicTicks = value;
                    }
                }
                public virtual Fraction TickMultiplier
                {
                    get { return tickMultiplier; }
                }
                #endregion


                #region 方法
                public Tickable()
                {
                    Init();
                }
                private void Init()
                {
                    this.intrinsicTicks = 0;
                    this.tickMultiplier = new Fraction(1, 1);
                    this.ticks = new Fraction(0, 1);
                    this.width = 0;
                    this.xShift = 0; // Shift from tick context
                    this.voice = null;
                    this.tickContext = null;
                    this.modifierContext = null;
                    this.modifiers = new List<object>();
                    this.preFormatted = false;
                    this.postFormatted = false;
                    this.tuplet = null;
                    this.ignoreTicks = false;
                    this.context = null;
                }
                public virtual CanvasContext Context
                {
                    set { context = value; }
                }
                public virtual object BoundingBox
                {
                    get { return null; }
                }
                public virtual Fraction Ticks
                {
                    get { return ticks; }
                }
                public virtual void AddToModifierContext(object mc)
                {
                    this.modifierContext = mc;
                    this.preFormatted = false;
                }


                public virtual Tickable AddModifier(object mod)
                {
                    this.modifiers.Add(mod);
                    this.preFormatted = false;
                    return this;
                }



                public virtual void PreFormat()
                { }

                public virtual string Category
                {
                    get {
                        return "";
                    }
                }

                public virtual void ApplyTickMultiplier(object numerator, object denominator)
                { }
                #endregion
            }
        }

    }
}
