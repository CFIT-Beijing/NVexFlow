//tuplet.js
using System.Collections.Generic;
using NVexFlow.Model;
using System.Linq;
using System;
namespace NVexFlow
{
    /**
 * Create a new tuplet from the specified notes. The notes must
 * be part of the same line, and have the same duration (in ticks).
 *
 * @constructor
 * @param {Array.<Vex.Flow.StaveNote>} A set of notes.
 */
    public class Tuplet
    {

        #region js直译部分
        public static int LOCATION_TOP = 1;
        public static int LOCATION_BOTTOM = -1;
        public Tuplet(IList<StaveNote> notes, TupletOpts options)
        {
            Init(notes, options);
        }
        private void Init(IList<StaveNote> notes, TupletOpts options)
        {
            if (notes == null || notes.Count() == 0)
            {
                throw new Exception("BadArguments,No notes provided for tuplet.");
            }
            if (notes.Count() == 1)
            {
                throw new Exception("BadArguments,Too few notes for tuplet.");
            }

            //  this.options = Vex.Merge({}, options);之后看到什么属性再赋值什么属性
            this.options = new TupletOpts() { beats_occupied = options.beats_occupied, num_notes = options.num_notes };

            this.notes = notes;
            this.num_notes = this.options.num_notes.HasValue ? this.options.num_notes.Value : notes.Count();
            this.beats_occupied = this.options.beats_occupied.HasValue ? this.options.beats_occupied.Value : 2;
            this.bracketed = notes[0].beam == null;
            this.ratioed = false;
            this.point = 28;
            this.y_pos = 16;
            this.x_pos = 100;
            this.width = 200;
            this.location = Tuplet.LOCATION_TOP;

            Formatter.AlignRestsToNotes(notes, true, true);
            this.ResolveGlyphs();
            this.Attach();
        }
        public void Attach()
        {
            for (int i = 0; i < this.notes.Count(); i++)
            {
                StaveNote note = this.notes[i];
                note.SetTuplet(this);
            }
        }
        public void Detach()
        {
            for (int i = 0; i < this.notes.Count(); i++)
            {
                StaveNote note = this.notes[i];
                note.SetTuplet(null);
            }
        }
        public Tuplet SetContext(CanvasContext context)
        {
            this.context = context;
            return this;
        }
        /**
     * Set whether or not the bracket is drawn.
     */
        public Tuplet SetBracketed(bool bracketed)
        {
            this.bracketed = bracketed ? true : false;//this.bracketed = bracketed;直接这么写。。
            return this;
        }
        /**
     * Set whether or not the ratio is shown.
     */
        public Tuplet SetRatioed(bool ratioed)
        {
            this.ratioed = ratioed ? true : false;
            return this;
        }
        /**
    * Set the tuplet to be displayed either on the top or bottom of the stave
    */
        public Tuplet TupletLocation(int? location)
        {
            if (!location.HasValue)
            {
                location = Tuplet.LOCATION_TOP;
            }
            else if (location.Value != Tuplet.LOCATION_TOP && location.Value != Tuplet.LOCATION_BOTTOM)
            {
                throw new Exception("BadArgument,Invalid tuplet location: " + location);
            }

            this.location = location.Value;
            return this;
        }
        public IList<StaveNote> GetNotes()
        {
            return this.notes;
        }
        public int GetNoteCount()
        {
            return this.num_notes;
        }
        public int GetBeatsOccupied()
        {
            return this.beats_occupied;
        }
        public void SetBeatsOccupied(int beats)
        {
            this.Detach();
            this.beats_occupied = beats;
            this.ResolveGlyphs();
            this.Attach();
        }
        public void ResolveGlyphs()
        {
            this.num_glyphs = new List<Glyph>();
            int n = this.num_notes;
            while (n >= 1)
            {
                this.num_glyphs.Add(new Glyph("v" + n % 10, this.point));
                n = n / 10;
            }

            this.denom_glyphs = new List<Glyph>();
            n = this.beats_occupied;
            while (n >= 1)
            {
                this.denom_glyphs.Add(new Glyph("v" + n % 10, this.point));
                n = n / 10;
            }
        }
        public void Draw()
        {
            //    draw: function() {
            //  if (!this.context) throw new Vex.RERR("NoCanvasContext",
            //      "Can't draw without a canvas context.");

            //  // determine x value of left bound of tuplet
            //  var first_note = this.notes[0];
            //  var last_note = this.notes[this.notes.length - 1];

            //  if (!this.bracketed) {
            //    this.x_pos = first_note.getStemX();
            //    this.width = last_note.getStemX() - this.x_pos;
            //  }
            //  else {
            //    this.x_pos = first_note.getTieLeftX() - 5;
            //    this.width = last_note.getTieRightX() - this.x_pos + 5;
            //  }

            //  // determine y value for tuplet
            //  var i;
            //  if (this.location == Tuplet.LOCATION_TOP) {
            //    this.y_pos = first_note.getStave().getYForLine(0) - 15;
            //    //this.y_pos = first_note.getStemExtents().topY - 10;

            //    for (i=0; i<this.notes.length; ++i) {
            //      var top_y = this.notes[i].getStemExtents().topY - 10;
            //      if (top_y < this.y_pos)
            //        this.y_pos = top_y;
            //    }
            //  }
            //  else {
            //    this.y_pos = first_note.getStave().getYForLine(4) + 20;

            //    for (i=0; i<this.notes.length; ++i) {
            //      var bottom_y = this.notes[i].getStemExtents().topY + 10;
            //      if (bottom_y > this.y_pos)
            //        this.y_pos = bottom_y;
            //    }
            //  }

            //  // calculate total width of tuplet notation
            //  var width = 0;
            //  var glyph;
            //  for (glyph in this.num_glyphs) {
            //    width += this.num_glyphs[glyph].getMetrics().width;
            //  }
            //  if (this.ratioed) {
            //    for (glyph in this.denom_glyphs) {
            //      width += this.denom_glyphs[glyph].getMetrics().width;
            //    }
            //    width += this.point * 0.32;
            //  }

            //  var notation_center_x = this.x_pos + (this.width/2);
            //  var notation_start_x = notation_center_x - (width/2);

            //  // draw bracket if the tuplet is not beamed
            //  if (this.bracketed) {
            //    var line_width = this.width/2 - width/2 - 5;

            //    // only draw the bracket if it has positive length
            //    if (line_width > 0) {
            //      this.context.fillRect(this.x_pos, this.y_pos,line_width, 1);
            //      this.context.fillRect(this.x_pos + this.width / 2 + width / 2 + 5,
            //                            this.y_pos,line_width, 1);
            //      this.context.fillRect(this.x_pos,
            //          this.y_pos + (this.location == Tuplet.LOCATION_BOTTOM),
            //          1, this.location * 10);
            //      this.context.fillRect(this.x_pos + this.width,
            //          this.y_pos + (this.location == Tuplet.LOCATION_BOTTOM),
            //          1, this.location * 10);
            //    }
            //  }

            //  // draw numerator glyphs
            //  var x_offset = 0;
            //  var size = this.num_glyphs.length;
            //  for (glyph in this.num_glyphs) {
            //    this.num_glyphs[size-glyph-1].render(
            //        this.context, notation_start_x + x_offset,
            //        this.y_pos + (this.point/3) - 2);
            //    x_offset += this.num_glyphs[size-glyph-1].getMetrics().width;
            //  }

            //  // display colon and denominator if the ratio is to be shown
            //  if (this.ratioed) {
            //    var colon_x = notation_start_x + x_offset + this.point*0.16;
            //    var colon_radius = this.point * 0.06;
            //    this.context.beginPath();
            //    this.context.arc(colon_x, this.y_pos - this.point*0.08,
            //                     colon_radius, 0, Math.PI*2, true);
            //    this.context.closePath();
            //    this.context.fill();
            //    this.context.beginPath();
            //    this.context.arc(colon_x, this.y_pos + this.point*0.12,
            //                     colon_radius, 0, Math.PI*2, true);
            //    this.context.closePath();
            //    this.context.fill();
            //    x_offset += this.point*0.32;
            //    size = this.denom_glyphs.length;
            //    for (glyph in this.denom_glyphs) {
            //      this.denom_glyphs[size-glyph-1].render(
            //          this.context, notation_start_x + x_offset,
            //          this.y_pos + (this.point/3) - 2);
            //      x_offset += this.denom_glyphs[size-glyph-1].getMetrics().width;
            //    }
            //  }
            //}
        }
        #endregion



        #region 隐含字段
        public TupletOpts options;
        public int num_notes;
        public CanvasContext context;
        public bool bracketed;
        public bool ratioed;
        public int location;
        public IList<StaveNote> notes;
        public int beats_occupied;
        public double point;
        public double y_pos;
        public double x_pos;
        public double width;
        public IList<Glyph> num_glyphs;
        public IList<Glyph> denom_glyphs;
        #endregion
    }
}
