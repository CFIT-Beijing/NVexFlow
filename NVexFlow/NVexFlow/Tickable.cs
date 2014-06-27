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
                private object context;

                public virtual object Context
                {
                    set { context = value; }
                }

                private object boundingBox;

                public virtual object BoundingBox
                {
                    get { return null; }
                }

                private Fraction ticks;

                public virtual Fraction Ticks
                {
                    get { return ticks; }
                }

                private bool ignoreTicks;

                public virtual bool ShouldIgnoreTicks()
                {
                    return this.ignoreTicks;
                }

                private double width;

                public virtual double Width
                {
                    get { return width; }
                }
                private double xShift;

                public virtual double XShift
                {
                    set { xShift = value; }
                }

                private object voice;

                public virtual object Voice
                {
                    get { return voice; }
                    set { voice = value; }
                }

                private object tuplet;

                public virtual object Tuplet
                {
                    get { return tuplet; }
                    set
                    {
                        //需要重写
                        tuplet = value;
                    }
                }

                private object modifierContext;

                private bool preFormatted;

                public virtual bool PreFormatted
                {
                    set { this.preFormatted = value; }
                }

                private IList<object> modifiers;

                private object tickContext;

                public virtual object TickContext
                {
                    set
                    {
                        tickContext = value;
                        this.preFormatted = false;
                    }
                }

                private bool postFormatted;
                public virtual Tickable PostFormat()
                {
                    if (this.postFormatted == true)
                    {
                        return null;
                    }
                    this.postFormatted = true;
                    return this;
                }

                private double intrinsicTicks;

                public virtual double IntrinsicTicks
                {
                    get { return intrinsicTicks; }
                    set
                    {
                        //需要重写
                        intrinsicTicks = value;
                    }
                }

                private Fraction tickMultiplier;

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

                public virtual void Init()
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



                public virtual void ApplyTickMultiplier(object numerator, object denominator)
                { }
                #endregion
            }
        }

    }
}
