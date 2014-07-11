
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
                #region js直译部分
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
                    this.Width = this.accidental.width;
                }


                public override string Category
                {
                    get
                    {
                        return "accidentals";
                    }
                }


                /// <summary>
                /// Attach this accidental to `note`, which must be a `StaveNote`.
                /// </summary>
                public override Note Note
                {
                    set
                    {
                        if (value == null)
                        {
                            throw new Exception("ArgumentError,Bad note value: " + this.note);
                        }
                        this.note = value;

                        // Accidentals attached to grace notes are rendered smaller.
                        if (this.note.Category == "gracenotes")
                        {
                            this.renderOptions.FontScale = 25;
                            this.Width = this.accidental.gracenoteWidth;
                        }
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
                    this.Width = this.parenLeft.width + this.accidental.width + this.parenRight.width - widthAdjust;
                    return this;
                }


                /// <summary>
                /// Render accidental onto canvas.
                /// </summary>
                public override void Draw()
                { }
                #endregion


                #region 隐含的字段
                string type;
                RenderOptions renderOptions;
                AccidentalOpts accidental;
                bool cautionary;
                AccidentalOpts parenLeft;
                AccidentalOpts parenRight;
                #endregion
            }
        }
    }
}
