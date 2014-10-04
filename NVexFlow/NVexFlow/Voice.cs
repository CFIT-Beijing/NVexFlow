//voice.js
using System;
using System.Collections.Generic;
using NVexFlow.Model;
using System.Linq;

namespace NVexFlow
{
    // [VexFlow](http://vexflow.com) - Copyright (c) Mohit Muthanna 2010.
    //
    // ## Description
    // 
    // This file implements the main Voice class. It's mainly a container 
    // object to group `Tickables` for formatting.
    public class Voice
    {
        #region js直译部分

        public Voice(VoiceTime time)
        { Init(time); }

        // Modes allow the addition of ticks in three different ways:
        //
        // STRICT: This is the default. Ticks must fill the voice.
        // SOFT:   Ticks can be added without restrictions.
        // FULL:   Ticks do not need to fill the voice, but can't exceed the maximum
        //         tick length.
        public enum VoiceMode
        {
            STRICT,
            SOFT,
            FULL
        }
        private void Init(VoiceTime time)
        {
            this.time = new VoiceTime()
            {
                num_beats = 4,
                beat_value = 4,
                resolution = Flow.RESOLUTION
            };
            if (time.beat_value.HasValue)
            {
                this.time.beat_value = time.beat_value;
            }
            if (time.num_beats.HasValue)
            {
                this.time.num_beats = time.num_beats;
            }
            if (time.resolution.HasValue)
            {
                this.time.resolution = time.resolution;
            }

            // Recalculate total ticks.
            this.total_ticks = new Fraction(this.time.num_beats.Value * this.time.resolution.Value / this.time.beat_value.Value, 1);
            this.resolution_multiplier = 1;

            // Set defaults
            this.tickables = new List<StemmableNote>();
            this.ticks_used = new Fraction(0, 1);
            this.smallest_tick_count = this.total_ticks;
            this.largest_tick_width = 0;
            this.stave = null;
            this.boundingBox = null;
            // Do we care about strictly timed notes
            this.mode = VoiceMode.STRICT;

            // This must belong to a VoiceGroup
            this.voice_group = null;
        }

        // Get the total ticks in the voice
        public Fraction GetTotalTicks()
        {
            return this.total_ticks;
        }

        // Get the total ticks used in the voice by all the tickables
        public Fraction GetTicksUsed()
        {
            return this.ticks_used;
        }

        //// Get the largest width of all the tickables
        public double GetLargestTickWidth()
        {
            return this.largest_tick_width;
        }
        //// Get the tick count for the shortest tickable
        public Fraction GetSmallestTickCount()
        {
            return this.smallest_tick_count;
        }
        //// Get the tickables in the voice
        public IList<StemmableNote> GetTickables()
        {
            return this.tickables;
        }
        //// Get/set the voice mode, use a value from `Voice.Mode`
        public VoiceMode GetMode()
        {
            return this.mode;
        }
        public Voice SetMode(VoiceMode mode)
        {
            this.mode = mode; return this;
        }
        //// Get the resolution multiplier for the voice
        public int GetResolutionMultiplier()
        {
            return this.resolution_multiplier;
        }
        //// Get the actual tick resolution for the voice
        public int GetActualResolution()
        {
            return this.resolution_multiplier * this.time.resolution.Value;
        }
        //// Set the voice's stave
        public Voice SetStave(Stave stave)
        {
            this.stave = stave;
            this.boundingBox = null; // Reset bounding box so we can reformat
            return this;
        }
        //// Get the bounding box for the voice
        public BoundingBox GetBoundingBox()
        {
            if (this.boundingBox == null)
            {
                if (this.stave == null)
                {
                    throw new Exception("NoStave,Can't get bounding box without stave.");
                }
                Stave stave = this.stave;

                BoundingBox boundingBox = null;
                if (this.tickables[0] != null)
                {
                    this.tickables[0].SetStave(stave);
                    boundingBox = this.tickables[0].GetBoundingBox();
                }
                for (int i = 0; i < this.tickables.Count(); i++)
                {
                    this.tickables[i].SetStave(stave);
                    if (i > 0 && boundingBox != null)
                    {
                        BoundingBox bb = this.tickables[i].GetBoundingBox();
                        if (bb != null)
                        {
                            boundingBox.MergeWith(bb);
                        }
                    }
                }
                this.boundingBox = boundingBox;
            }
            return this.boundingBox;
        }


        //// Every tickable must be associated with a voiceGroup. This allows formatters
        //// and preformatters to associate them with the right modifierContexts.
        public object GetVoiceGroup()
        {
            if (this.voice_group == null)
            {
                throw new Exception("NoVoiceGroup,No voice group for voice.");
            }
            return this.voice_group;
        }
        //// Set the voice group
        public Voice SetVoiceGroup(VoiceGroup g)
        {
            this.voice_group = g; return this; 
        }
        //// Set the voice mode to strict or soft 
        public Voice SetStrict(bool strict)
        {
            this.mode = strict ? VoiceMode.STRICT : VoiceMode.SOFT;
            return this;
        }
        // Determine if the voice is complete according to the voice mode
        public bool IsComplete()
        {
            if (this.mode == VoiceMode.STRICT || this.mode == VoiceMode.FULL)
            {
                return this.ticks_used == this.total_ticks;
            }
            else
            {
                return true;
            }
        }

        // Add a tickable to the voice
        public Voice AddTickable(StemmableNote tickable)
        {
            //            // Add a tickable to the voice
            //addTickable: function(tickable) {
            //  if (!tickable.shouldIgnoreTicks()) {
            //    var ticks = tickable.getTicks();
            if (tickable.ShouldIgnoreTicks())
            {
                Fraction ticks= tickable.GetTicks();
                // Update the total ticks for this line
                this.ticks_used += ticks;

                if ((this.mode == VoiceMode.STRICT || this.mode == VoiceMode.FULL) &&
                this.ticks_used > this.total_ticks)
                {
                    this.total_ticks -= ticks;
                    throw new Exception("BadArgument,Too many ticks.");
                }

                // Track the smallest tickable for formatting
                if (ticks < this.smallest_tick_count)
                {
                    this.smallest_tick_count = ticks;
                }

                this.resolution_multiplier = ticks_used.Denominator;
                // Expand total ticks using denominator from ticks used
                // this.totalTicks.add(0, this.ticksUsed.denominator);
            }

             // Add the tickable to the line
            this.tickables.Add(tickable);
            tickable.SetVoice(this);
            return this;
        }

        // Add an array of tickables to the voice
        public Voice AddTickables(IList<StemmableNote> tickables)
        {
            for (int i = 0; i < tickables.Count(); ++i)
            {
                this.AddTickable(tickables[i]);
            }
            return this;
        }

        //     // Preformats the voice by applying the voice's stave to each note
        public Voice PreFormat()
        {
            if (this.preFormatted)
            {
                return null;
            }
            foreach (var tickable in this.tickables)
            {
                if (tickable.GetStave() == null)
                {
                    tickable.SetStave(this.stave);
                }
            }

            this.preFormatted = true;
            return this;
        }
        // Render the voice onto the canvas `context` and an optional `stave`.
        // If `stave` is omitted, it is expected that the notes have staves
        // already set.
        public void Draw(object context, object stave)
        {

            //draw: function(context, stave) {
            //  var boundingBox = null;
            //  for (var i = 0; i < this.tickables.length; ++i) {
            //    var tickable = this.tickables[i];

            //    // Set the stave if provided
            //    if (stave) tickable.setStave(stave);

            //    if (!tickable.getStave()) {
            //      throw new Vex.RuntimeError("MissingStave",
            //        "The voice cannot draw tickables without staves.");
            //    }

            //    if (i === 0) boundingBox = tickable.getBoundingBox();

            //    if (i > 0 && boundingBox) {
            //      var tickable_bb = tickable.getBoundingBox();
            //      if (tickable_bb) boundingBox.mergeWith(tickable_bb);
            //    }

            //   tickable.setContext(context);
            //   tickable.draw();
            //  }

            //  this.boundingBox = boundingBox;
            //}
        }
        #endregion


        #region 隐含字段
        public VoiceTime time;
        public Fraction total_ticks;
        public Fraction ticks_used;
        public double largest_tick_width;
        public Fraction smallest_tick_count;
        public IList<StemmableNote> tickables;
        public VoiceMode mode;
        public int resolution_multiplier;
        public object actual_resolution;
        public Stave stave;
        public BoundingBox boundingBox;
        public VoiceGroup voice_group;
        public VoiceMode strict;
        public bool preFormatted;
        #endregion
    }
}
