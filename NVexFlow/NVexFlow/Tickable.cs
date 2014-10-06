//对应 tickable.js
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
            this.intrinsic_ticks = 0;
            this.tick_multiplier = new Fraction(1, 1);
            this.ticks = new Fraction(0, 1);
            this.width = 0;
            this.x_shift = 0; // Shift from tick context
            this.voice = null;
            this.tick_context = null;
            this.modifier_context = null;
            this.modifiers = new List<Modifier>();
            this.preFormatted = false;
            this.postFormatted = false;
            this.tuplet = null;
            // This flag tells the formatter to ignore this tickable during formatting and justification. It is set by tickables such as BarNote.
            this.ignore_ticks = false;
            this.context = null;
        }
        public new Tickable SetContext(CanvasContext context)
        {
            this.context = context;
            return this;
        }
        public virtual BoundingBox GetBoundingBox()
        {
            return null;
        }
        public virtual Fraction GetTicks()
        {
            return this.ticks;
        }
        public virtual bool GetShouldIgnoreTicks()
        {
            return this.ignore_ticks;
        }
        public override double GetWidth()
        {
            return this.width;
        }
        public Tickable SetXShift(double x_shift)
        {
            this.x_shift = x_shift;
            return this;
        }
        // Every tickable must be associated with a voice. This allows formatters
        // and preFormatter to associate them with the right modifierContexts.
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
        public virtual Tuplet GetTuplet()
        {
            return this.tuplet;
        }
        public virtual Tickable SetTuplet(Tuplet tuplet)
        {
            // Detach from previous tuplet
            int note_count;
            int beats_occupied;
            if (this.tuplet != null)
            {
                note_count = this.tuplet.GetNoteCount();
                beats_occupied = this.tuplet.GetBeatsOccupied();
                // Revert old multiplier
                this.ApplyTickMultiplier(note_count, beats_occupied);
            }

            // Attach to new tuplet
            if (tuplet != null)
            {
                note_count = tuplet.GetNoteCount();
                beats_occupied = tuplet.GetBeatsOccupied();
                this.ApplyTickMultiplier(beats_occupied, note_count);
            }

            this.tuplet = tuplet;
            return this;
        }
        /** optional, if tickable has modifiers **/
        public virtual void AddToModifierContext(ModifierContext mc)
        {
            this.modifier_context = mc;
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
        public Tickable SetTickContext(TickContext tick_context)
        {
            this.tick_context = tick_context;
            this.preFormatted = false;
            return this;
        }
        public virtual void PreFormat()
        {
            if (this.preFormatted)
                return;
            this.width = 0;
            if (this.modifier_context != null)
            {
                this.modifier_context.PreFormat();
                this.width += this.modifier_context.Width;
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
            return this.intrinsic_ticks;
        }
        public virtual void SetIntrinsicTicks(Fraction intrinsic_ticks)
        {
            this.intrinsic_ticks = intrinsic_ticks;
            this.ticks = this.tick_multiplier * this.intrinsic_ticks;
        }
        public virtual Fraction GetTickMultiplier()
        {
            return tick_multiplier;
        }
        public virtual void ApplyTickMultiplier(int numerator, int denominator)
        {
            this.tick_multiplier *= new Fraction(numerator, denominator);
            this.ticks = this.tick_multiplier * this.intrinsic_ticks;
        }
        #endregion

        #region 隐含字段
        public Fraction ticks;
        public bool ignore_ticks;
        public Voice voice;
        public Tuplet tuplet;
        public bool preFormatted;
        public IList<Modifier> modifiers;
        public TickContext tick_context;
        public bool postFormatted;
        public Fraction intrinsic_ticks;
        public Fraction tick_multiplier;
        #endregion
    }
}
