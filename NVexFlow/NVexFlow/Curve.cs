﻿using System;
//curve.js
using System.Collections.Generic;
using NVexFlow.Model;

namespace NVexFlow
{
    /// <summary>
    /// VexFlow - Music Engraving for HTML5
    // Copyright Mohit Muthanna 2010
    //
    // This class implements curves (for slurs)
    /// </summary>
    public class Curve
    {
        #region js直译部分
        // from: Start note
        // to: End note
        // options:
        //    cps: List of control points
        //    x_shift: pixels to shift
        //    y_shift: pixels to shift
        public Curve(StaveNote from, StaveNote to, CurveOpts options)
        {
            Init(from, to, options);
        }
        public enum CurvePosition
        {
            NEAR_HEAD,
            NEAR_TOP
        }
        private void Init(StaveNote from, StaveNote to, CurveOpts options)
        {
            this.renderoptions = new CurveRenderOpts()
            {
                spacing = 2,
                thickness = 2,
                xShift = 0,
                yShift = 10,
                position = Curve.CurvePosition.NEAR_HEAD,
                invert = false,
                cps = new List<Cps>() { new Cps() { x = 0, y = 10 }, new Cps() { x = 0, y = 10 } }
            };
            this.renderoptions.cps = options.cps;
            this.SetNotes(from, to);
        }

        public Curve SetContext(CanvasContext context)
        {
            this.context = context;
            return this;
        }
        public Curve SetNotes(StaveNote from, StaveNote to)
        {
            if (from == null && to == null)
            {
                throw new Exception("BadArguments,Curve needs to have either first_note or last_note set.");
            }
            this.from = from;
            this.to = to;
            return this;
        }
        /**
    * @return {boolean} Returns true if this is a partial bar.
    */
        public bool IsPartial()
        {
            return this.from == null || this.to == null;
        }

        public void RenderCurve(IList<object> @params)
        {
    //    renderCurve: function(params) {
    //  var ctx = this.context;
    //  var cps = this.render_options.cps;

    //  var x_shift = this.render_options.x_shift;
    //  var y_shift = this.render_options.y_shift * params.direction;

    //  var first_x = params.first_x + x_shift;
    //  var first_y = params.first_y + y_shift;
    //  var last_x = params.last_x - x_shift;
    //  var last_y = params.last_y + y_shift;
    //  var thickness = this.render_options.thickness;

    //  var cp_spacing = (last_x - first_x) / (cps.length + 2);

    //  ctx.beginPath();
    //  ctx.moveTo(first_x, first_y);
    //  ctx.bezierCurveTo(first_x + cp_spacing + cps[0].x,
    //                    first_y + (cps[0].y * params.direction),
    //                    last_x - cp_spacing + cps[1].x,
    //                    last_y + (cps[1].y * params.direction),
    //                    last_x, last_y);
    //  ctx.bezierCurveTo(last_x - cp_spacing + cps[1].x,
    //                    last_y + ((cps[1].y + thickness) * params.direction),
    //                    first_x + cp_spacing + cps[0].x,
    //                    first_y + ((cps[0].y + thickness) * params.direction),
    //                    first_x, first_y);
    //  ctx.stroke();
    //  ctx.closePath();
    //  ctx.fill();
    //},
        }

        public bool Draw()
        {
    //    draw: function() {
    //  if (!this.context)
    //    throw new Vex.RERR("NoContext", "No context to render tie.");
    //  var first_note = this.from;
    //  var last_note = this.to;
    //  var first_x, last_x, first_y, last_y, stem_direction;

    //  var metric = "baseY";
    //  var end_metric = "baseY";
    //  var position = this.render_options.position;
    //  var position_end = this.render_options.position_end;

    //  if (position === Curve.Position.NEAR_TOP) {
    //    metric = "topY";
    //    end_metric = "topY";
    //  }

    //  if (position_end == Curve.Position.NEAR_HEAD) {
    //    end_metric = "baseY";
    //  } else if (position_end == Curve.Position.NEAR_TOP) {
    //    end_metric = "topY";
    //  }

    //  if (first_note) {
    //    first_x = first_note.getTieRightX();
    //    stem_direction = first_note.getStemDirection();
    //    first_y = first_note.getStemExtents()[metric];
    //  } else {
    //    first_x = last_note.getStave().getTieStartX();
    //    first_y = last_note.getStemExtents()[metric];
    //  }

    //  if (last_note) {
    //    last_x = last_note.getTieLeftX();
    //    stem_direction = last_note.getStemDirection();
    //    last_y = last_note.getStemExtents()[end_metric];
    //  } else {
    //    last_x = first_note.getStave().getTieEndX();
    //    last_y = first_note.getStemExtents()[end_metric];
    //  }

    //  this.renderCurve({
    //    first_x: first_x,
    //    last_x: last_x,
    //    first_y: first_y,
    //    last_y: last_y,
    //    direction: stem_direction *
    //      (this.render_options.invert === true ? -1 : 1)
    //  });
    //  return true;
    //}
            return true;
        } 
        #endregion


        #region 隐含字段
        public CanvasContext context;
        public StaveNote from;
        public StaveNote to;
        public CurveRenderOpts renderoptions;
        #endregion
    }
}
