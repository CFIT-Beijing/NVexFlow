﻿////对应 crescendo.js
using System.Collections.Generic;
using NVexFlow.Model;
using System;

namespace NVexFlow
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
    public class Crescendo:Note
    {
        #region js直译部分
        public Crescendo(CrescendoStruct noteStruct)
            : base(noteStruct)
        {
            Init(noteStruct);
        }
        /// <summary>
        /// // Private helper to draw the hairpin
        /// </summary>
        /// <param name="ctx"></param>
        /// <param name="params"></param>
        private void RenderHairpin(CanvasContext ctx,RenderHairpinParams @params)
        {
            double begin_x = @params.begin_x;
            double end_x = @params.end_x;
            double y = @params.y;
            double half_height = @params.height / 2;

            ctx.BeginPath();

            if(@params.reverse)
            {
                ctx.MoveTo(begin_x,y - half_height);
                ctx.LineTo(end_x,y);
                ctx.LineTo(begin_x,y + half_height);
            }
            else
            {
                ctx.MoveTo(end_x,y - half_height);
                ctx.LineTo(begin_x,y);
                ctx.LineTo(end_x,y + half_height);
            }

            ctx.Stroke();
            ctx.ClosePath();
        }
        // Initialize the crescendo's properties
        private void Init(CrescendoStruct note_struct)
        {
            //// Whether the object is a decrescendo
            this.decrescendo = false;
            //// The staff line to be placed on
            this.line = note_struct.line ?? 0;

            //// The height at the open end of the cresc/decresc
            this.height = 15;
            //以后是用这种模式为需要Merge的选项类型实现并取代无强类型的Vex.Merge
            CrescendoRenderOpts.Merge(this.render_options,new CrescendoRenderOpts() {
                // Extensions to the length of the crescendo on either side
                extend_left = 0,
                extend_right = 0,
                // Vertical shift
                y_shift = 0
            });
        }
        /// <summary>
        /// Set the line to center the element on
        /// </summary>
        public Crescendo SetLine(int line)
        {
            this.line = line;
            return this;
        }
        /// <summary>
        /// Set the full height at the open end
        /// </summary>
        public Crescendo SetHeight(int height)
        {
            this.height = height;
            return this;
        }
        /// <summary>
        /// Set whether the sign should be a descresendo by passing a bool to `decresc`
        /// </summary>
        public Crescendo SetDecrescendo(bool decrescendo)
        {
            this.decrescendo = decrescendo;
            return this;
        }
        // Preformat the note
        public new Crescendo PreFormat()
        {
            this.SetPreFormatted(true);
            return this;
        }
        /// <summary>
        /// Render the Crescendo object onto the canvas
        /// </summary>
        public override void Draw()
        {
            throw new NotImplementedException();
        }
        #endregion


        #region 隐含字段
        public bool decrescendo;
        public int line;
        public double height;
        #endregion

        public override string GetCategory()
        {
            throw new System.NotImplementedException();
        }
    }
}
