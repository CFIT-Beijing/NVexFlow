
using System;
using NVexFlow.Model;
namespace NVexFlow
{//Accidental
    public partial class Vex
    {
        public partial class Flow
        {
            /// <summary>
            /// ## Description
            //
            // This file implements accidentals as modifiers that can be attached to
            // notes. Support is included for both western and microtonal accidentals.
            //
            // See `tests/accidental_tests.js` for usage examples.
            /// </summary>
            public class Accidental : Modifier
            {
                #region 属性字段
                Note note;
                string type;
                object index;
                Modifier.ModifierPosition position;
                RenderOptions renderOptions;
                AccidentalModel accidental;
                bool cautionary;
                AccidentalModel parenLeft;
                AccidentalModel parenRight;
                double width;

                #endregion

                
                #region 方法
                //An `Accidental` inherits from `Modifier`, and is formatted within a ModifierContext`.

                /// <summary>
                /// Create accidental. `type` can be a value from the  `Vex.Flow.accidentalCodes.accidentals` table in `tables.js`. For  example: `#`, `##`, `b`, `n`, etc.
                /// </summary>
                /// <param name="type"></param>
                public Accidental(string type)
                {
                    Init(type);
                }

                /// <summary>
                ///Create accidental. `type` can be a value from the `Vex.Flow.accidentalCodes.accidentals` table in `tables.js`. For  example: `#`, `##`, `b`, `n`, etc.
                /// </summary>
                /// <param name="type"></param>
                public void Init(string type)
                {
                    this.note = null;
                    // The `index` points to a specific note in a chord.
                    this.index = null;
                    this.type = type;
                    this.position = Modifier.ModifierPosition.LEFT;
                    this.renderOptions = new RenderOptions() { FontScale = 38, StrokePx = 3 };


                    this.accidental = Vex.Flow.AccidentalCodes(this.type);
                    if (this.accidental == null)
                    {
                        throw new Exception("ArgumentError,Unknown accidental type: " + this.type);
                    }

                    // Cautionary accidentals have parentheses around them
                    this.cautionary = false;
                    this.parenLeft = null;
                    this.parenRight = null;

                    // Initial width is set from table.
                    this.Width = this.accidental.Width;
                }

                /// <summary>
                /// Attach this accidental to `note`, which must be a `StaveNote`.
                /// </summary>
                /// <param name="note"></param>
                public void SerNote(Note note)
                {
                    if (note == null)
                    {
                        throw new Exception("ArgumentError,Bad note value: " + this.note);
                    }
                    this.note = note;

                    // Accidentals attached to grace notes are rendered smaller.
                    if (this.note is GraceNote)
                    {
                        this.renderOptions.FontScale = 25;
                        this.Width = this.accidental.GracenoteWidth;
                    }
                }

                /// <summary>
                /// If called, draws parenthesis around accidental.
                /// </summary>
                /// <returns></returns>
                public Accidental SetAsCautionary()
                {
                    this.cautionary = true;
                    this.renderOptions.FontScale = 28;
                    this.parenLeft = Vex.Flow.AccidentalCodes("{");
                    this.parenRight = Vex.Flow.AccidentalCodes("}");
                    double widthAdjust = (this.type == "##" || this.type == "bb") ? 6 : 4;

                    // Make sure `width` accomodates for parentheses.
                    this.Width = this.parenLeft.Width + this.accidental.Width + this.parenRight.Width - widthAdjust;
                    return this;
                }

                /// <summary>
                /// Render accidental onto canvas.
                /// </summary>
                public override void Draw()
                { }
                #endregion
            }
        }
    }
}
