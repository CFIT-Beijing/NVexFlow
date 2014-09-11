//voice.js
using System.Collections.Generic;
using NVexFlow.Model;

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
          
        public Voice(VoiceTimeModel time)
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
        private void Init(VoiceTimeModel time)
        {
    //       init: function(time) {
    //  this.time = Vex.Merge({
    //    num_beats: 4,
    //    beat_value: 4,
    //    resolution: Vex.Flow.RESOLUTION
    //  }, time);

    //  // Recalculate total ticks.
    //  this.totalTicks = new Vex.Flow.Fraction(
    //    this.time.num_beats * (this.time.resolution / this.time.beat_value), 1);

    //  this.resolutionMultiplier = 1;

    //  // Set defaults
    //  this.tickables = [];
    //  this.ticksUsed = new Vex.Flow.Fraction(0, 1);
    //  this.smallestTickCount = this.totalTicks.clone();
    //  this.largestTickWidth = 0;
    //  this.stave = null;
    //  this.boundingBox = null;
    //  // Do we care about strictly timed notes
    //  this.mode = Vex.Flow.Voice.Mode.STRICT;

    //  // This must belong to a VoiceGroup
    //  this.voiceGroup = null;
    //},
        }

    // Get the total ticks in the voice
        public object GetTotalTicks()
        {
            //getTotalTicks: function() { return this.totalTicks; },
            return null;
        }

    // Get the total ticks used in the voice by all the tickables
        public object GetTicksUsed()
        {
            //getTicksUsed: function() { return this.ticksUsed; },
            return null;
        }

    //// Get the largest width of all the tickables
        public object GetLargestTickWidth()
        {
            //getLargestTickWidth: function() { return this.largestTickWidth; },
            return null;
        }
    //// Get the tick count for the shortest tickable
        public object GetSmallestTickCount()
        {
            //getSmallestTickCount: function() { return this.smallestTickCount; },
            return null;
        }
    //// Get the tickables in the voice
        public IList<object> GetTickables()
        {
            //getTickables: function() { return this.tickables; },
            return null;
        }
    //// Get/set the voice mode, use a value from `Voice.Mode`
        public object GetMode()
        {
            //getMode: function() { return this.mode; },
            return null;
        }
        public Voice SetMode(object mode)
        {
            //setMode: function(mode) { this.mode = mode; return this; },
            return null;
        }
    //// Get the resolution multiplier for the voice
        public object GetResolutionMultiplier()
        {

            //getResolutionMultiplier: function() { return this.resolutionMultiplier; },
            return null;
        }
    //// Get the actual tick resolution for the voice
        public object GetActualResolution()
        {

            //getActualResolution: function() { return this.resolutionMultiplier * this.time.resolution; },
            return null;
        }
    //// Set the voice's stave
        public Voice SetStave(object stave)
        {

            //setStave: function(stave) {
            //  this.stave = stave;
            //  this.boundingBox = null; // Reset bounding box so we can reformat
            //  return this;
            //},
            return null;
        }
    //// Get the bounding box for the voice
        public BoundingBox GetBoundingBox()
        {
            //getBoundingBox: function() {
            //  if (!this.boundingBox) {
            //    if (!this.stave) throw Vex.RERR("NoStave", "Can't get bounding box without stave.");
            //    var stave = this.stave;

            //    var boundingBox = null;
            //    if (this.tickables[0]) {
            //      this.tickables[0].setStave(stave);
            //      boundingBox = this.tickables[0].getBoundingBox();
            //    }

            //    for (var i = 0; i < this.tickables.length; ++i) {
            //      this.tickables[i].setStave(stave);
            //      if (i > 0 && boundingBox) {
            //        var bb = this.tickables[i].getBoundingBox();
            //        if (bb) boundingBox.mergeWith(bb);
            //      }
            //    }

            //    this.boundingBox = boundingBox;
            //  }
            //  return this.boundingBox;
            //},
            return null;
        }
    

    //// Every tickable must be associated with a voiceGroup. This allows formatters
    //// and preformatters to associate them with the right modifierContexts.
        public object GetVoiceGroup()
        {

            //getVoiceGroup: function() {
            //  if (!this.voiceGroup)
            //    throw new Vex.RERR("NoVoiceGroup", "No voice group for voice.");
            //  return this.voiceGroup;
            //},
            return null;
        }
    //// Set the voice group
        public Voice SetVoiceGroup(object g)
        {
            //setVoiceGroup: function(g) { this.voiceGroup = g; return this; },
            return null;
        }
    //// Set the voice mode to strict or soft 
        public Voice SetStrict(bool strict)
        {
            //setStrict: function(strict) {
            //  this.mode = strict ? Vex.Flow.Voice.Mode.STRICT : Vex.Flow.Voice.Mode.SOFT;
            //  return this;
            //},
            return null;
        }
        // Determine if the voice is complete according to the voice mode
        public bool IsComplete()
        {
    //            // Determine if the voice is complete according to the voice mode
    //isComplete: function() {
    //  if (this.mode == Vex.Flow.Voice.Mode.STRICT ||
    //      this.mode == Vex.Flow.Voice.Mode.FULL) {
    //    return this.ticksUsed.equals(this.totalTicks);
    //  } else {
    //    return true;
    //  }
    //},
            return false;
        }

        // Add a tickable to the voice
        public Voice AddTickable(object tickable)
        {
    //            // Add a tickable to the voice
    //addTickable: function(tickable) {
    //  if (!tickable.shouldIgnoreTicks()) {
    //    var ticks = tickable.getTicks();

    //    // Update the total ticks for this line
    //    this.ticksUsed.add(ticks);

    //    if ((this.mode == Vex.Flow.Voice.Mode.STRICT ||
    //         this.mode == Vex.Flow.Voice.Mode.FULL) &&
    //         this.ticksUsed.value() > this.totalTicks.value()) {
    //      this.totalTicks.subtract(ticks);
    //      throw new Vex.RERR("BadArgument", "Too many ticks.");
    //    }

    //    // Track the smallest tickable for formatting
    //    if (ticks.value() < this.smallestTickCount.value()) {
    //      this.smallestTickCount = ticks.clone();
    //    }

    //    this.resolutionMultiplier = this.ticksUsed.denominator;

    //    // Expand total ticks using denominator from ticks used
    //    this.totalTicks.add(0, this.ticksUsed.denominator);
    //  }

    //  // Add the tickable to the line
    //  this.tickables.push(tickable);
    //  tickable.setVoice(this);
    //  return this;
    //},
            return this;
        }

        // Add an array of tickables to the voice
        public Voice AddTickables(IList<StemmableNote> tickables)
        {
    //            // Add an array of tickables to the voice
    //addTickables: function(tickables) {
    //  for (var i = 0; i < tickables.length; ++i) {
    //    this.addTickable(tickables[i]);
    //  }

    //  return this;
    //},
            return this;
        }

    //     // Preformats the voice by applying the voice's stave to each note
        public Voice PreFormat()
        {
            //preFormat: function(){
            //  if (this.preFormatted) return;

            //  this.tickables.forEach(function(tickable) {
            //    if (!tickable.getStave()) {
            //      tickable.setStave(this.stave);
            //    }
            //  }, this);

            //  this.preFormatted = true;
            //  return this;
            //},
            return null;
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
        IList<object> totalTicks;
        object ticksUsed;
        double largestTickWidth;
        object smallestTickCount;
        IList<object> tickables;
        VoiceMode mode;
        object resolutionMultiplier;
        object actualResolution;
        object stave;
        object boundingBox;
        object voiceGroup;
        VoiceMode strict;
        #endregion
    }
}
