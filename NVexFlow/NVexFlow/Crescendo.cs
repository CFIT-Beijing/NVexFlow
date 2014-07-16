////对应 crescendo.js
using System.Collections.Generic;
using NVexFlow.Model;

namespace NVexFlow
{
    public partial class Vex
    {
        public partial class Flow
        {
            /// <summary>
            /// ## Description
            //
            // This file implements the `Crescendo` object which draws crescendos and
            // decrescendo dynamics markings. A `Crescendo` is initialized with a
            // duration and formatted as part of a `Voice` like any other `Note`
            // type in VexFlow. This object would most likely be formatted in a Voice
            // with `TextNotes` - which are used to represent other dynamics markings.
            /// </summary>
            public class Crescendo : Note
            {
                #region js直译部分
                public Crescendo(NoteStruct noteStruct)
                    : base(noteStruct)
                {
                    Init(noteStruct);
                }
                /// <summary>
                /// // Private helper to draw the hairpin
                /// </summary>
                /// <param name="ctx"></param>
                /// <param name="params"></param>
                private void RenderHairpin(CanvasContext ctx, RenderHairpinParams @params)
                {
                    double beginX = @params.beginX;
                    double endX = @params.endX;
                    double y = @params.y;
                    double halfHeight = @params.height / 2;

                    ctx.BeginPath();

                    if (@params.reverse)
                    {
                        ctx.MoveTo(beginX, y - halfHeight);
                        ctx.LineTo(endX, y);
                        ctx.LineTo(beginX, y + halfHeight);
                    } else {
                        ctx.MoveTo(endX, y - halfHeight);
                        ctx.LineTo(beginX, y);
                        ctx.LineTo(endX, y + halfHeight);
                    }

                    ctx.Stroke();
                    ctx.ClosePath();
                }
                private void Init(NoteStruct noteStruct)
                {
                    //// Whether the object is a decrescendo
                    this.decrescendo = false;
                    //// The staff line to be placed on
                    this.line = noteStruct.line == null ? 0 : noteStruct.line.Value;

                    //// The height at the open end of the cresc/decresc
                    this.height = 15;
                    Vex.Merge(this.renderOptions, new CrescendoRenderOpts() { extendLeft = 0, extendRight = 0, yShift = 0 });
                }
                /// <summary>
                /// Set the line to center the element on
                /// </summary>
                public int Line
                {
                    set { line = value; }
                }
                /// <summary>
                /// Set the full height at the open end
                /// </summary>
                public double Height
                {
                    set { height = value; }
                }
                /// <summary>
                /// Set whether the sign should be a descresendo by passing a bool to `decresc`
                /// </summary>
                public bool Decrescendo
                {
                    set { decrescendo = value; }
                }
                /// <summary>
                /// Preformat the note
                /// </summary>
                /// <returns></returns>
                public Crescendo PreFormat()
                {
                    this.PreFormatted = true;
                    return this;
                }
                /// <summary>
                /// Render the Crescendo object onto the canvas
                /// </summary>
                public void Draw()
                {
                
                }
                #endregion


                #region 隐含字段
                protected bool decrescendo;
                protected int line;
                protected double height;
                protected CrescendoRenderOpts renderOptions;
                #endregion
            }
        }
    }
}
