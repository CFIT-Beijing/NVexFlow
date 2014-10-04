//对应 accidental.js
using System;
using NVexFlow.Model;
namespace NVexFlow
{
    /// <summary>
    /// This file implements accidentals as modifiers that can be attached to
    /// notes. Support is included for both western and microtonal accidentals.
    //
    /// See `tests/accidental_tests.js` for usage examples.
    /// </summary>
    public class Accidental:Modifier
    {
        #region js直译部分
        //An `Accidental` inherits from `Modifier`, and is formatted within a ModifierContext`.
        public Accidental(string type)
        {
            Init(type);
        }
        /// <summary>
        /// Create accidental. `type` can be a value from the  `Vex.Flow.accidentalCodes.accidentals` table in `tables.js`. For  example: `#`, `##`, `b`, `n`, etc.
        /// </summary>
        private void Init(string type)
        {
            this.note = null;
            // The `index` points to a specific note in a chord.
            this.index = null;
            this.type = type;
            this.position = Modifier.ModifierPosition.LEFT;
            this.render_options = new RenderOptions() {
                // Font size for glyphs
                font_scale = 38,
                // Length of stroke across heads above or below the stave.
                stroke_px = 3
            };
            this.accidental = Flow.AccidentalCodes(this.type);
            if(this.accidental == null)
            {
                throw new ArgumentException("ArgumentError,Unknown accidental type: " + this.type);
            }
            // Cautionary accidentals have parentheses around them
            this.cautionary = false;
            this.paren_left = null;
            this.paren_right = null;
            // Initial width is set from table.
            this.SetWidth(this.accidental.width);
        }
        // Return the modifier type. Used by the `ModifierContext` to calculate
        // layout.
        public override string GetCategory()
        {
            return "accidentals";
        }
        /// <summary>
        /// Attach this accidental to `note`, which must be a `StaveNote`.
        /// </summary>
        public new Modifier SetNote(Note note)
        {
            if (note == null)
            {
                throw new ArgumentException("ArgumentError,Bad note value: " + this.note);
            }
            this.note = note;
            // Accidentals attached to grace notes are rendered smaller.
            if (this.note.GetCategory() == "gracenotes")
            {
                this.render_options.font_scale = 25;
                this.SetWidth(this.accidental.gracenote_width);
            }
            return this;
        }
        /// <summary>
        /// If called, draws parenthesis around accidental.
        /// </summary>
        public Accidental SetAsCautionary()
        {
            this.cautionary = true;
            this.render_options.font_scale = 28;
            this.paren_left = Flow.AccidentalCodes("{");
            this.paren_right = Flow.AccidentalCodes("}");
            double width_adjust = (this.type == "##" || this.type == "bb") ? 6 : 4;
            // Make sure `width` accomodates for parentheses.
            this.SetWidth(this.paren_left.width + this.accidental.width + this.paren_right.width - width_adjust);
            return this;
        }
        /// <summary>
        /// Render accidental onto canvas.
        /// </summary>
        public override void Draw()
        {
            throw new NotImplementedException();
        }
        #endregion

        #region 隐含的字段
        public string type;
        public RenderOptions render_options;
        public AccidentalOpts accidental;
        public bool cautionary;
        public AccidentalOpts paren_left;
        public AccidentalOpts paren_right;
        #endregion
    }
}
