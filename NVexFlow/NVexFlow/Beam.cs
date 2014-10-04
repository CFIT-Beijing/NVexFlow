//beam.js
using System.Collections.Generic;
using NVexFlow.Model;
using System.Linq;
using System;
namespace NVexFlow
{
    /// <summary>
    ///  [VexFlow](http://vexflow.com) - Copyright (c) Mohit Muthanna 2010.
    //
    // ## Description
    // 
    // This file implements `Beams` that span over a set of `StemmableNotes`.
    // 
    // Requires: vex.js, vexmusic.js, note.js
    /// </summary>
    public class Beam
    {

        #region js直译部分
        public Beam(IList<StemmableNote> notes, bool? autoStem = null)
        {
            Init(notes, autoStem);
        }

        private void Init(IList<StemmableNote> notes, bool? autoStem)
        {
            if (notes == null || notes.Count() == 0)
            {
                throw new Exception("BadArguments No notes provided for beam.");
            }
            if (notes.Count() == 1)
            {
                throw new Exception("BadArguments,Too few notes for beam.");
            }
            this.ticks = notes[0].GetIntrinsicTicks();
            if (this.ticks != null)
            {
                if (this.ticks.Value >= Flow.DurationToTicks("4"))
                {
                    throw new Exception("BadArguments,Beams can only be applied to notes shorter than a quarter note.");
                }
            }

            int i;// shared iterator
            StemmableNote note;
            this.stem_direction = 1;
            for (i = 0; i < notes.Count(); ++i)
            {
                note = notes[i];
                if (note.HasStem())
                {
                    this.stem_direction = note.GetStemDirection().Value;
                    break;
                }
            }
            int stemDirection = -1;
            // Figure out optimal stem direction based on given notes
            if (autoStem != null && notes[0].GetCategory() == "stavenotes")
            {
                // Auto Stem StaveNotes
                this.min_line = 1000;

                for (i = 0; i < notes.Count(); ++i)
                {
                    note = notes[i];
                    if ((note as StaveNote).GetKeyProps() != null)
                    {
                        IList<NoteProps> props = (note as StaveNote).GetKeyProps();
                        double centerLine = (props[0].line + props[props.Count() - 1].line) / 2;
                        this.min_line = Math.Min(centerLine, this.min_line);
                    }
                }
                if (this.min_line < 3)
                {
                    stemDirection = 1;
                }
            }
            else if (autoStem != null && notes[0].GetCategory() == "tabnotes")
            {
                // Auto Stem TabNotes
                int stemWeight = 0;
                foreach (var noteCurrent in notes)
                {
                    stemWeight += noteCurrent.stem_direction.Value;
                }
                stemDirection = stemWeight > -1 ? 1 : -1;
            }

            // Apply stem directions and attach beam to notes
            for (i = 0; i < notes.Count(); i++)
            {
                note = notes[i];
                if (autoStem != null)
                {
                    note.SetStemDirection(stemDirection);
                    this.stem_direction = stemDirection;
                }
                note.SetBeam(this);
            }
            this.post_formatted = false;
            this.notes = notes;
            this.beam_count = this.GetBeamCount();
            this.break_on_indices = new List<int>();
            this.render_options = new BeamRenderOpts()
            {
                //    beam_width: 5,
                beam_width = 5,
                max_slope = 0.25,
                min_slope = -0.25,
                slope_iterations = 20,
                slope_cost = 25,
                show_stemlets = false,
                stemlet_extension = 7,
                partial_beamLength = 10
            };
        }
        //        // The the rendering `context`
        public Beam SetContext(CanvasContext context)
        {
            this.context = context; return this;
        }
        // Get the notes in this beam
        public IList<StemmableNote> GetNotes()
        {
            return this.notes;
        }


        // Get the max number of beams in the set of notes
        public int GetBeamCount()
        {
            IList<int> beamCounts = new List<int>();
            foreach (var note in this.notes)
            {
                //因为note是StemmableNote，所以note的Glyph里面实际存的是Glyph4StemmableNote
                Glyph4StemmableNote glyph4StemmableNote = note.GetGlyph() as Glyph4StemmableNote;
                if (glyph4StemmableNote == null)
                {
                    //throw new Exception("?"); 
                }
                else
                { beamCounts.Add(glyph4StemmableNote.beam_count); }
            }

            int maxBeamCount = beamCounts[0];
            for (int i = 1; i < beamCounts.Count(); i++)
            {
                maxBeamCount += beamCounts[i] > maxBeamCount ? beamCounts[i] : maxBeamCount;
            }
            return maxBeamCount;
        }
        // Set which note `indices` to break the secondary beam at
        public Beam BreakSecondaryAt(IList<int> indices)
        {
            this.break_on_indices = indices;
            return this;
        }
        // Return the y coordinate for linear function
        public double GetSlopeY(double x, double firstXPx, double firstYPx, double slope)
        {
            return firstYPx + (x - firstXPx) * slope;
        }
        // Calculate the best possible slope for the provided notes
        public void CalculateSlope()
        {
            StemmableNote firstNote = this.notes[0];
            double firstYPx = firstNote.GetStemExtents().top_y;
            double firstXPx = firstNote.GetStemX();
            double inc = (this.render_options.max_slope - this.render_options.min_slope) / this.render_options.slope_iterations;

            double min_cost = double.MaxValue;//先这么写着
            double best_slope = 0;
            double y_shift = 0;
            // iterate through slope values to find best weighted fit
            for (double slope = this.render_options.min_slope; slope <= this.render_options.max_slope; slope += inc)
            {
                double total_stem_extension = 0;
                double y_shift_tmp = 0;
                // iterate through notes, calculating y shift and stem extension
                for (int i = 0; i < this.notes.Count(); ++i)
                {
                    StemmableNote note = notes[i];

                    double x_px = note.GetStemX();
                    double y_px = note.GetStemExtents().top_y;
                    double slope_y_px = this.GetSlopeY(x_px, firstXPx, firstYPx, slope) + y_shift_tmp;

                    // beam needs to be shifted up to accommodate note
                    if (y_px * this.stem_direction < slope_y_px * this.stem_direction)
                    {
                        double diff = Math.Abs(y_px - slope_y_px);
                        y_shift_tmp += diff * -this.stem_direction;
                        total_stem_extension += (y_px - slope_y_px) * this.stem_direction;
                    }
                    else
                    { // beam overshoots note, account for the difference
                        total_stem_extension += (y_px - slope_y_px) * this.stem_direction;
                    }
                }

                //    /*
                //      // This causes too many zero-slope beams.

                //      var cost = this.render_options.slope_cost * Math.abs(slope) +
                //        Math.abs(total_stem_extension);
                //    */

                //    // Pick a beam that minimizes stem extension.
                double cost = Math.Abs(total_stem_extension);
                // update state when a more ideal slope is found
                if (cost < min_cost)
                {
                    min_cost = cost;
                    best_slope = slope;
                    y_shift = y_shift_tmp;
                }
            }

            this.slope = best_slope;
            this.y_shift = y_shift;
        }

        // Create new stems for the notes in the beam, so that each stem extends into the beams.
        public void ApplyStemExtensions()
        {
            StemmableNote first_note = this.notes[0];
            double first_y_px = first_note.GetStemExtents().top_y;
            double first_x_px = first_note.GetStemX();

            for (int i = 0; i < this.notes.Count(); ++i)
            {
                StemmableNote note = this.notes[i];
                double x_px = note.GetStemX();
                StemExtents y_extents = note.GetStemExtents();
                double base_y_px = y_extents.base_y;
                double top_y_px = y_extents.top_y;

                // For harmonic note heads, shorten stem length by 3 pixels
                base_y_px += this.stem_direction * note.GetGlyph().stem_offset;
                // Don't go all the way to the top (for thicker stems)
                double y_displacement = Flow.STEM_WIDTH;
                if (!note.HasStem())
                {
                    if (note.IsRest() && this.render_options.show_stemlets)
                    {
                        double centerGlyphX = note.GetCenterGlyphX();

                        double width = this.render_options.beam_width;
                        double total_width = (this.beam_count - 1) * width * 1.5 + width;

                        double stemlet_height = total_width - y_displacement + this.render_options.stemlet_extension;
                        double beam_y = this.GetSlopeY(centerGlyphX, first_x_px, first_y_px, this.slope) + this.y_shift;
                        double start_y = beam_y + Stem.HEIGHT * this.stem_direction;
                        double end_y = beam_y + stemlet_height * this.stem_direction;

                        // Draw Stemlet
                        note.SetStem(new Stem(
                            new StemOpts()
                            {
                                x_begin = centerGlyphX,
                                x_end = centerGlyphX,
                                y_bottom = this.stem_direction == 1 ? end_y : start_y,
                                y_top = this.stem_direction == 1 ? start_y : end_y,
                                y_extend = y_displacement,
                                stem_extension = -1,// To avoid protruding through the beam
                                stem_direction = this.stem_direction
                            }
                            ));

                        continue;
                    }
                }

                double slope_y = this.GetSlopeY(x_px, first_x_px, first_y_px, this.slope) + this.y_shift;

                note.SetStem(new Stem(
                    new StemOpts()
                    {
                        x_begin = x_px - Flow.STEM_WIDTH / 2,
                        x_end = x_px,
                        y_bottom = this.stem_direction == 1 ? top_y_px : base_y_px,
                        y_top = this.stem_direction == 1 ? base_y_px : top_y_px,
                        y_extend = y_displacement,
                        stem_extension = Math.Abs(top_y_px - slope_y) - Stem.HEIGHT - 1,
                        stem_direction = this.stem_direction
                    }
                    ));
            }
        }

        // Get the x coordinates for the beam lines of specific `duration`
        //  function determinePartialSide (prev_note, next_note){
        public IList<BeamLine> GetBeamLines(string duration)
        {
            IList<BeamLine> beam_lines = new List<BeamLine>();
            bool beam_started = false;
            BeamLine current_beam;
            double partial_beam_length = this.render_options.partial_beamLength;

            //for (var i = 0; i < this.notes.length; ++i)  原文js数组超出索引返回undefind，c#报错所以做了修改，不知道该没改业务涵义你再查查。
            for (int i = 1; i < this.notes.Count() - 1; ++i)
            {
                StemmableNote note = this.notes[i];
                StemmableNote prev_note = this.notes[i - 1];
                StemmableNote next_note = this.notes[i + 1];
                Fraction ticks = note.GetIntrinsicTicks();
                DeterminePartialSideRes partial = DeterminePartialSide(prev_note, next_note, duration);
                double stem_x = note.IsRest() ? note.GetCenterGlyphX() : note.GetStemX();

                // Check whether to apply beam(s)
                if (ticks < Flow.DurationToTicks(duration))
                {
                    if (!beam_started)
                    {
                        BeamLine new_line = new BeamLine() { start = stem_x, end = null };

                        if (partial.left)
                        {
                            new_line.end = stem_x - partial_beam_length;
                        }

                        beam_lines.Add(new_line);
                        beam_started = true;
                    }
                    else
                    {
                        current_beam = beam_lines[beam_lines.Count() - 1];//有可能超出索引？
                        current_beam.end = stem_x;
                        // Should break secondary beams on note
                        bool should_break = this.break_on_indices.IndexOf(i) != -1;
                        // Shorter than or eq an 8th note duration
                        bool can_break = int.Parse(duration) >= 8;//严谨一点可以用TryParse
                        if (should_break && can_break)
                        {
                            beam_started = false;
                        }
                    }
                }
                else
                {
                    if (!beam_started)
                    {
                        // we don't care
                    }
                    else
                    {
                        current_beam = beam_lines[beam_lines.Count() - 1];//有可能超出索引？
                        if (current_beam.end == null)
                        {
                            // single note
                            current_beam.end = current_beam.start + partial_beam_length;
                        }
                        else
                        {
                            // we don't care
                        }
                    }
                    beam_started = false;
                }
            }

            if (beam_started)
            {
                current_beam = beam_lines[beam_lines.Count() - 1];////有可能超出索引？
                if (current_beam.end == null)
                {
                    // single note
                    current_beam.end = current_beam.start - partial_beam_length;
                }
            }

            return beam_lines;
        }
        private DeterminePartialSideRes DeterminePartialSide(StemmableNote prev_note, StemmableNote next_note, string duration)
        {
            // Compare beam counts and store differences
            double unshared_beams = 0;
            //上个方法中修改了循环，此处note参数不会是undefind。你看看怎么写合适吧
            if (next_note != null && prev_note != null)
            {
                unshared_beams = prev_note.GetBeamCount() - next_note.GetBeamCount();
            }
            bool left_partial = duration != "8" && unshared_beams > 0;
            bool right_partial = duration != "8" && unshared_beams < 0;

            return new DeterminePartialSideRes()
            {
                left = left_partial,
                right = right_partial
            };
        }

        // Render the stems for each notes
        public void DrawStems()
        {
            //drawStems: function() {
            //  this.notes.forEach(function(note) {
            //    if (note.getStem()) {
            //      note.getStem().setContext(this.context).draw();
            //    }
            //  }, this);
            //},
        }

        // Render the beam lines
        public void DrawBeamLines()
        {

            //drawBeamLines: function() {
            //  if (!this.context) throw new Vex.RERR("NoCanvasContext",
            //      "Can't draw without a canvas context.");

            //  var valid_beam_durations = ["4", "8", "16", "32", "64"];

            //  var first_note = this.notes[0];
            //  var last_note = this.notes[this.notes.length - 1];

            //  var first_y_px = first_note.getStemExtents().topY;
            //  var last_y_px = last_note.getStemExtents().topY;

            //  var first_x_px = first_note.getStemX();

            //  var beam_width = this.render_options.beam_width * this.stem_direction;

            //  // Draw the beams.
            //  for (var i = 0; i < valid_beam_durations.length; ++i) {
            //    var duration = valid_beam_durations[i];
            //    var beam_lines = this.getBeamLines(duration);

            //    for (var j = 0; j < beam_lines.length; ++j) {
            //      var beam_line = beam_lines[j];
            //      var first_x = beam_line.start - (this.stem_direction == -1 ? Vex.Flow.STEM_WIDTH/2:0);
            //      var first_y = this.getSlopeY(first_x, first_x_px, first_y_px, this.slope);

            //      var last_x = beam_line.end +
            //        (this.stem_direction == 1 ? (Vex.Flow.STEM_WIDTH/3):(-Vex.Flow.STEM_WIDTH/3));
            //      var last_y = this.getSlopeY(last_x, first_x_px, first_y_px, this.slope);

            //      this.context.beginPath();
            //      this.context.moveTo(first_x, first_y + this.y_shift);
            //      this.context.lineTo(first_x, first_y + beam_width + this.y_shift);
            //      this.context.lineTo(last_x + 1, last_y + beam_width + this.y_shift);
            //      this.context.lineTo(last_x + 1, last_y + this.y_shift);
            //      this.context.closePath();
            //      this.context.fill();
            //    }

            //    first_y_px += beam_width * 1.5;
            //    last_y_px += beam_width * 1.5;
            //  }
            //},
        }
        // Pre-format the beam
        public Beam PreFormat()
        {
            return this;
        }
        // Post-format the beam. This can only be called after the notes in the beam have both `x` and `y` values. ie: they've been formatted and have staves
        public void PostFormat()
        {
            if (this.post_formatted)
            {
                return;
            }

            this.CalculateSlope();
            this.ApplyStemExtensions();

            this.post_formatted = true;
        }
        // Render the beam to the canvas context
        public void Draw()
        {
            //draw: function() {
            //  if (!this.context) throw new Vex.RERR("NoCanvasContext",
            //      "Can't draw without a canvas context.");

            //  if (this.unbeamable) return;

            //  if (!this.postFormatted) {
            //    this.postFormat();
            //  }

            //  this.drawStems();
            //  this.drawBeamLines();

            //  return true;
            //}
        }
        // ## Static Methods
        // 
        // Gets the default beam groups for a provided time signature.
        // Attempts to guess if the time signature is not found in table.
        // Currently this is fairly naive.
        public static IList<Fraction> GetDefaultBeamGroups(string timeSig)
        {
            //没太具体看Fraction，这段你仔细查查吧
            if (timeSig == null || timeSig == "c")
            {
                timeSig = "4/4";
            }
            IDictionary<string, IList<string>> defaults = new Dictionary<string, IList<string>>() {
                
                {    "1/2" , new List<string>{"1/2"}},
                {    "2/2" ,  new List<string>{"1/2"}},
                {    "3/2" ,  new List<string>{"1/2"}},
                {    "4/2" ,  new List<string>{"1/2"}},

                {    "1/4" ,  new List<string>{"1/4"}},
                {    "2/4" ,  new List<string>{"1/4"}},
                {    "3/4" ,  new List<string>{"1/4"}},
                {    "4/4" ,  new List<string>{"1/4"}},

                {    "1/8" ,  new List<string>{"1/8"}},
                {    "2/8" ,  new List<string>{"2/8"}},
                {    "3/8" ,  new List<string>{"3/8"}},
                {    "4/8" ,  new List<string>{"2/8"}},

                {    "1/16" , new List<string>{"1/16"}},
                {    "2/16" , new List<string>{"2/16"}},
                {    "3/16" , new List<string>{"3/16"}},
                {    "4/16" , new List<string>{"2/16"}}
            };

            IList<string> groups = defaults[timeSig];
            if (groups == null)
            {
                // If no beam groups found, naively determine the beam groupings from the time signature
                int beatTotal = int.Parse(timeSig.Split('/')[0]);
                int beatValue = int.Parse(timeSig.Split('/')[1]);

                bool tripleMeter = beatTotal % 3 == 0;
                if (tripleMeter)
                {
                    return new List<Fraction>() { new Fraction(3, beatValue) };
                }
                else
                {
                    if (beatValue > 4)
                    {
                        return new List<Fraction>() { new Fraction(2, beatValue) };
                    }
                    else
                    {
                        return new List<Fraction>() { new Fraction(1, beatValue) };
                    }
                }
            }
            else
            {
                IList<Fraction> res = new List<Fraction>();
                foreach (string group in groups)
                {
                    res.Add(new Fraction(int.Parse(group.Split('/')[0]), int.Parse(group.Split('/')[1])));
                }
                return res;
            }
        }

        // A helper function to automatically build basic beams for a voice. For more
        // complex auto-beaming use `Beam.generateBeams()`.
        // 
        // Parameters:
        // * `voice` - The voice to generate the beams for
        // * `stem_direction` - A stem direction to apply to the entire voice
        // * `groups` - An array of `Fraction` representing beat groupings for the beam
        public static object ApplyAndGetBeams(Voice voice, int stem_direction, IList<Fraction> groups)
        {
            return Beam.GenerateBeams(voice.GetTickables(), new Config()
            {
                groups = groups,
                stem_direction = stem_direction
            });
        }
        // A helper function to autimatically build beams for a voice with 
        // configuration options.
        // 
        // Example configuration object:
        //
        // ```
        // config = {
        //   groups: [new Vex.Flow.Fraction(2, 8)],
        //   stem_direction: -1,
        //   beam_rests: true,
        //   beam_middle_only: true,
        //   show_stemlets: false
        // };
        // ```
        // 
        // Parameters:
        // * `notes` - An array of notes to create the beams for
        // * `config` - The configuration object
        //    * `groups` - Array of `Fractions` that represent the beat structure to beam the notes
        //    * `stem_direction` - Set to apply the same direction to all notes
        //    * `beam_rests` - Set to `true` to include rests in the beams
        //    * `beam_middle_only` - Set to `true` to only beam rests in the middle of the beat
        //    * `show_stemlets` - Set to `true` to draw stemlets for rests 
        // 
        public static IList<Beam> GenerateBeams(IList<StemmableNote> notes, Config config)
        {
            if (config == null)
            {
                config = new Config();
            }
            if (config.groups == null || config.groups.Count() <= 0)
            {
                config.groups = new List<Fraction>() { new Fraction(2, 8) };
            }

            // Convert beam groups to tick amounts
            //  var tickGroups = config.groups.map(function(group) {
            //    if (!group.multiply) {
            //      throw new Vex.RuntimeError("InvalidBeamGroups",
            //        "The beam groups must be an array of Vex.Flow.Fractions");
            //    }
            //    return group.clone().multiply(Vex.Flow.RESOLUTION, 1);
            //  });

            //  var unprocessedNotes = notes;
            //  var currentTickGroup = 0;
            //  var noteGroups       = [];
            //  var currentGroup     = [];
            
            // Convert beam groups to tick amounts
            IList<Fraction> tickGroups = new List<Fraction>();
            //Fraction写成类就可以直接用object的浅拷贝方法了，考虑？
            foreach (Fraction group in config.groups)
            {
                //    return group.clone().multiply(Vex.Flow.RESOLUTION, 1);
            }

            


            //  // Using closures to store the variables throughout the various functions
            //  // IMO Keeps it this process lot cleaner - but not super consistent with
            //  // the rest of the API's style - Silverwolf90 (Cyril)
            //  createGroups();
            //  sanitizeGroups();
            //  formatStems();

            //  // Get the notes to be beamed
            //  var beamedNoteGroups = getBeamGroups();

            //  // Get the tuplets in order to format them accurately
            //  var tupletGroups = getTupletGroups();

            //  // Create a Vex.Flow.Beam from each group of notes to be beamed
            //  var beams = [];
            //  beamedNoteGroups.forEach(function(group){
            //    var beam = new Vex.Flow.Beam(group);

            //    if (config.show_stemlets) {
            //      beam.render_options.show_stemlets = true;
            //    }

            //    beams.push(beam);
            //  });

            //  // Reformat tuplets
            //  tupletGroups.forEach(function(group){
            //    var firstNote = group[0];
            //    for (var i=0; i<group.length; ++i) {
            //      if (group[i].hasStem()) {
            //        firstNote = group[i];
            //        break;
            //      }
            //    }

            //    var tuplet = firstNote.tuplet;

            //    if (firstNote.beam) tuplet.setBracketed(false);
            //    if (firstNote.stem_direction == -1) {
            //      tuplet.setTupletLocation(Vex.Flow.Tuplet.LOCATION_BOTTOM);
            //    }
            //  });

            //  return beams;
            //};
            return null;
        }

        //***************************辅助方法
        //  function getTotalTicks(vf_notes){
        //    return vf_notes.reduce(function(memo,note){
        //      return note.getTicks().clone().add(memo);
        //    }, new Vex.Flow.Fraction(0, 1));
        //  }

        //  function nextTickGroup() {
        //    if (tickGroups.length - 1 > currentTickGroup) {
        //      currentTickGroup += 1;
        //    } else {
        //      currentTickGroup = 0;
        //    }
        //  }

        //  function createGroups(){
        //    var nextGroup = [];

        //    unprocessedNotes.forEach(function(unprocessedNote){
        //      nextGroup    = [];
        //      if (unprocessedNote.shouldIgnoreTicks()) {
        //        noteGroups.push(currentGroup);
        //        currentGroup = nextGroup;
        //        return; // Ignore untickables (like bar notes)
        //      }

        //      currentGroup.push(unprocessedNote);
        //      var ticksPerGroup = tickGroups[currentTickGroup].value();
        //      var totalTicks = getTotalTicks(currentGroup).value();

        //      // Double the amount of ticks in a group, if it's an unbeamable tuplet
        //      if (parseInt(unprocessedNote.duration, 10) < 8 && unprocessedNote.tuplet) {
        //        ticksPerGroup *= 2;
        //      }

        //      // If the note that was just added overflows the group tick total
        //      if (totalTicks > ticksPerGroup) {
        //        nextGroup.push(currentGroup.pop());
        //        noteGroups.push(currentGroup);
        //        currentGroup = nextGroup;
        //        nextTickGroup();
        //      } else if (totalTicks == ticksPerGroup) {
        //        noteGroups.push(currentGroup);
        //        currentGroup = nextGroup;
        //        nextTickGroup();
        //      }
        //    });

        //    // Adds any remainder notes
        //    if (currentGroup.length > 0)
        //      noteGroups.push(currentGroup);
        //  }

        //  function getBeamGroups() {
        //    return noteGroups.filter(function(group){
        //        if (group.length > 1) {
        //          var beamable = true;
        //          group.forEach(function(note) {
        //            if (note.getIntrinsicTicks() >= Vex.Flow.durationToTicks("4")) {
        //              beamable = false;
        //            }
        //          });
        //          return beamable;
        //        }
        //        return false;
        //    });
        //  }

        //  // Splits up groups by Rest
        //  function sanitizeGroups() {
        //    var sanitizedGroups = [];
        //    noteGroups.forEach(function(group) {
        //      var tempGroup = [];
        //      group.forEach(function(note, index, group) {
        //        var isFirstOrLast = index === 0 || index === group.length - 1;

        //        var breaksOnEachRest = !config.beam_rests && note.isRest();
        //        var breaksOnFirstOrLastRest = (config.beam_rests &&
        //          config.beam_middle_only && note.isRest() && isFirstOrLast);

        //        var shouldBreak = breaksOnEachRest || breaksOnFirstOrLastRest;

        //        if (shouldBreak) {
        //          if (tempGroup.length > 0) {
        //            sanitizedGroups.push(tempGroup);
        //          }
        //          tempGroup = [];
        //        } else {
        //          tempGroup.push(note);
        //        }
        //      });

        //      if (tempGroup.length > 0) {
        //        sanitizedGroups.push(tempGroup);
        //      }
        //    });

        //    noteGroups = sanitizedGroups;
        //  }

        //  function formatStems() {
        //    noteGroups.forEach(function(group){
        //      var stemDirection = determineStemDirection(group);
        //      applyStemDirection(group, stemDirection);
        //    });
        //  }

        //  function determineStemDirection(group) {
        //    if (config.stem_direction) return config.stem_direction;

        //    var lineSum = 0;
        //    group.forEach(function(note) {
        //      if (note.keyProps) {
        //        note.keyProps.forEach(function(keyProp){
        //          lineSum += (keyProp.line - 2.5);
        //        });
        //      }
        //    });

        //    if (lineSum > 0)
        //      return -1;
        //    return 1;
        //  }

        //  function applyStemDirection(group, direction) {
        //    group.forEach(function(note){
        //      if (note.hasStem()) note.setStemDirection(direction);
        //    });
        //  }

        //  function getTupletGroups() {
        //    return noteGroups.filter(function(group){
        //      if (group[0]) return group[0].tuplet;
        //    });
        //  }
        //***************************
        #endregion



        #region 隐含字段
        public BeamRenderOpts render_options;
        public object context;
        public IList<StemmableNote> notes;
        public IList<int> break_on_indices;
        public int beam_count;
        public Fraction? ticks;
        public int stem_direction;
        public double min_line;
        public bool post_formatted;
        public double slope;
        public double y_shift;
        #endregion
    }
}
