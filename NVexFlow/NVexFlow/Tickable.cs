﻿//对应 tickable.js
using System;
using System.Collections.Generic;
namespace NVexFlow
{
    // The tickable interface. Tickables are things that sit on a score and
    // have a duration, i.e., they occupy space in the musical rendering dimension.
    public class Tickable : Modifier
    {
        #region js直译部分
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
            this.modifiers = new List<Modifier>();
            this.preFormatted = false;
            this.postFormatted = false;
            this.tuplet = null;
            // This flag tells the formatter to ignore this tickable during formatting and justification. It is set by tickables such as BarNote.
            this.ignoreTicks = false;
            this.context = null;
        }
        public virtual CanvasContext Context
        {
            set
            {
                this.context = value;
            }
        }
        public new Tickable SetContext(CanvasContext context)
        {
            this.context = context;
            return this;
        }
        public virtual BoundingBox BoundingBox
        {
            get
            {
                return null;
            }
        }
        public virtual BoundingBox GetBoundingBox()
        {
            return null;
        }
        public virtual Fraction Ticks
        {
            get
            {
                return this.ticks;
            }
        }
        public virtual Fraction GetTicks()
        {
            return this.ticks;
        }
        public virtual bool ShouldIgnoreTicks
        {
            get
            {
                return this.ignoreTicks;
            }
        }
        public virtual bool GetShouldIgnoreTicks()
        {
            return this.ignoreTicks;
        }
        public virtual double Width
        {
            get
            {
                return this.width;
            }
        }
        public override double GetWidth()
        {
            return this.width;
        }
        public virtual double XShift
        {
            set
            {
                xShift = value;
            }
        }
        public Tickable SetXShift(double xShift)
        {
            this.xShift = xShift;
            return this;
        }
        // Every tickable must be associated with a voice. This allows formatters
        // and preFormatter to associate them with the right modifierContexts.
        public virtual Voice Voice
        {
            get
            {
                if (this.voice == null)
                {
                    throw new Exception("NoVoice, Tickable has no voice.");//抛出异常是否需要封装？new Vex.RERR（“XXXXXXXXXXXX”）？
                    //改完后看看是否有null值出现的可能。getter不抛异常为好。
                }
                return this.voice;
            }
            set
            {
                this.voice = value;
            }
        }
        public virtual Voice GetVoice()
        {
            if (this.voice == null)
            {
                throw new Exception("NoVoice, Tickable has no voice.");//抛出异常是否需要封装？new Vex.RERR（“XXXXXXXXXXXX”）？
                //改完后看看是否有null值出现的可能。getter不抛异常为好。
            }
            return this.voice;
        }
        public virtual Tickable SetVoice(Voice voice)
        {
            this.voice = voice;
            return this;
        }
        public virtual Tuplet Tuplet
        {
            get
            {
                return this.tuplet;
            }
            set
            {
                // Detach from previous tuplet
                int noteCount;
                int beatsOccupied;
                if (this.tuplet != null)
                {
                    noteCount = this.tuplet.GetNoteCount();
                    beatsOccupied = this.tuplet.GetBeatsOccupied();
                    // Revert old multiplier
                    this.ApplyTickMultiplier(noteCount, beatsOccupied);
                }

                // Attach to new tuplet
                if (value != null)
                {
                    noteCount = value.GetNoteCount();
                    beatsOccupied = value.GetBeatsOccupied();
                    this.ApplyTickMultiplier(beatsOccupied, noteCount);
                }

                this.tuplet = value;
            }
        }
        public virtual Tuplet GetTuplet()
        {
            return this.tuplet;
        }
        public virtual Tickable SetTuplet(Tuplet tuplet)
        {
            // Detach from previous tuplet
            int noteCount;
            int beatsOccupied;
            if (this.tuplet != null)
            {
                noteCount = this.tuplet.GetNoteCount();
                beatsOccupied = this.tuplet.GetBeatsOccupied();
                // Revert old multiplier
                this.ApplyTickMultiplier(noteCount, beatsOccupied);
            }

            // Attach to new tuplet
            if (tuplet != null)
            {
                noteCount = tuplet.GetNoteCount();
                beatsOccupied = tuplet.GetBeatsOccupied();
                this.ApplyTickMultiplier(beatsOccupied, noteCount);
            }

            this.tuplet = tuplet;
            return this;
        }
        /** optional, if tickable has modifiers **/
        public virtual void AddToModifierContext(ModifierContext mc)
        {
            this.modifierContext = mc;
            // Add modifiers to modifier context (if any)
            this.preFormatted = false;
        }
        /** optional, if tickable has modifiers **/
        public virtual Tickable AddModifier(Modifier mod)
        {
            this.modifiers.Add(mod);
            this.preFormatted = false;
            return this;
        }
        public virtual TickContext TickContext
        {
            set
            {
                this.tickContext = value;
                this.preFormatted = false;
            }
        }
        public Tickable SetTickContext(TickContext tickContext)
        {
            this.tickContext = tickContext;
            this.preFormatted = false;
            return this;
        }
        public virtual void PreFormat()
        {
            if (this.preFormatted)
                return;
            this.width = 0;
            if (this.modifierContext != null)
            {
                this.modifierContext.PreFormat();
                this.width += this.modifierContext.Width;
            }
        }
        public virtual Tickable PostFormat()
        {
            if (this.postFormatted)
                return this;//发现js中的一个错误
            this.postFormatted = true;
            return this;
        }
        public virtual Fraction GetIntrinsicTicks()
        {
            return this.intrinsicTicks;
        }
        public virtual void SetIntrinsicTicks(Fraction intrinsicTicks)
        {
            this.intrinsicTicks = intrinsicTicks;
            this.ticks = this.tickMultiplier * this.intrinsicTicks;
        }
        public virtual Fraction IntrinsicTicks
        {
            get
            {
                return intrinsicTicks;
            }
            set
            {
                this.intrinsicTicks = value;
                this.ticks = this.tickMultiplier * this.intrinsicTicks;
            }
        }
        public virtual Fraction TickMultiplier
        {
            get
            {
                return tickMultiplier;
            }
        }
        public virtual Fraction GetTickMultiplier()
        {
            return tickMultiplier;
        }
        public virtual void ApplyTickMultiplier(int numerator, int denominator)
        {
            this.tickMultiplier *= new Fraction(numerator, denominator);
            this.ticks = this.tickMultiplier * this.intrinsicTicks;
        }
        #endregion

        #region 隐含字段
        public Fraction ticks;
        public bool ignoreTicks;
        public Voice voice;
        public Tuplet tuplet;
        public bool preFormatted;
        public IList<Modifier> modifiers;
        public TickContext tickContext;
        public bool postFormatted;
        public Fraction intrinsicTicks;
        public Fraction tickMultiplier;
        #endregion
    }
}
