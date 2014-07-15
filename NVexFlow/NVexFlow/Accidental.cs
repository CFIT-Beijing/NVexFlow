//对应 accidental.js
//框架：    已完成
//类型定义：存在改进空间
//原js：    存在改进空间
using System;
using NVexFlow.Model;
namespace NVexFlow
{
    public partial class Vex
    {
        public partial class Flow
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
                    this.note=null;
                    // The `index` points to a specific note in a chord.
                    this.index=null;
                    this.type=type;
                    this.position=Modifier.ModifierPosition.LEFT;
                    this.renderOptions=new RenderOptions() {
                        // Font size for glyphs
                        fontScale=38,
                        // Length of stroke across heads above or below the stave.
                        strokePx=3
                    };
                    this.accidental=Vex.Flow.AccidentalCodes(this.type);
                    if(this.accidental==null)
                    {
                        throw new ArgumentException("ArgumentError,Unknown accidental type: "+this.type);
                    }
                    // Cautionary accidentals have parentheses around them
                    this.cautionary=false;
                    this.parenLeft=null;
                    this.parenRight=null;
                    // Initial width is set from table.
                    this.Width=this.accidental.width;
                }
                // Return the modifier type. Used by the `ModifierContext` to calculate
                // layout.
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
                        if(value==null)
                        {
                            throw new ArgumentException("ArgumentError,Bad note value: "+this.note);
                        }
                        this.note=value;
                        // Accidentals attached to grace notes are rendered smaller.
                        if(this.note.Category=="gracenotes")
                        {
                            this.renderOptions.fontScale=25;
                            this.Width=this.accidental.gracenoteWidth;
                        }
                    }
                }
                /// <summary>
                /// If called, draws parenthesis around accidental.
                /// </summary>
                public Accidental SetAsCautionary()
                {
                    this.cautionary=true;
                    this.renderOptions.fontScale=28;
                    this.parenLeft=Vex.Flow.AccidentalCodes("{");
                    this.parenRight=Vex.Flow.AccidentalCodes("}");
                    double widthAdjust = (this.type=="##"||this.type=="bb") ? 6 : 4;
                    // Make sure `width` accomodates for parentheses.
                    this.Width=this.parenLeft.width+this.accidental.width+this.parenRight.width-widthAdjust;
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
