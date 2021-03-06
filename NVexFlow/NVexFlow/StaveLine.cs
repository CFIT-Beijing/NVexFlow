﻿using System;
//staveline.js
using System.Collections.Generic;
using NVexFlow.Model;
using System.Linq;

namespace NVexFlow
{
    // [VexFlow](http://vexflow.com) - Copyright (c) Mohit Muthanna 2010.
    //
    // ## Description
    //
    // This file implements `StaveLine` which are simply lines that connect
    // two notes. This object is highly configurable, see the `render_options`.
    // A simple line is often used for notating glissando articulations, but you
    // can format a `StaveLine` with arrows or colors for more pedagogical
    // purposes, such as diagrams.
    public class StaveLine
    {
        #region js直译部分
        public StaveLine(StaveLineNotes notes)
        {
            Init(notes);
        }
        // Text Positioning
        public enum StaveLineTextVerticalPosition
        {
            TOP,
            BOTTOM
        }

        public enum StaveLineTextJustification
        {
            LEFT,
            CENTER,
            RIGHT
        }

        // Initialize the StaveLine with the given `notes`.
        //
        // `notes` is a struct that has:
        //
        //  ```
        //  {
        //    first_note: Note,
        //    last_note: Note,
        //    first_indices: [n1, n2, n3],
        //    last_indices: [n1, n2, n3]
        //  }
        //  ```

        private void Init(StaveLineNotes notes)
        {
            this.notes = notes;
            this.context = null;

            this.text = "";

            this.font = new Font()
            {
                family = "Arial",
                size = 10,
                weight = ""
            };

            this.render_options = new StaveLineRenderOpts()
            {
                // space to add to the left or the right
                padding_left = 4,
                padding_right = 3,

                // the width of the line in pixels
                line_width = 1,
                // an array of line/space lengths. unsupported with raphael (svg)
                line_dash = null,
                // can draw rounded line end, instead of a square. unsupported with raphael (svg)
                rounded_end = true,
                // the color of the line and arrowheads
                color = null,

                // flags to draw arrows on each end of the line
                draw_start_arrow = false,
                draw_end_arrow = false,

                // the length of the arrowhead sides
                arrowhead_length = 10,
                // the angle of the arrowhead
                arrowhead_angle = Math.PI / 8,

                // the position of the text
                text_position_vertical = StaveLine.StaveLineTextVerticalPosition.TOP,
                text_justification = StaveLine.StaveLineTextJustification.CENTER
            };

            this.SetNotes(notes);
        }


        // Set the rendering context
        public StaveLine SetContext(CanvasContext context)
        {
            this.context = context; return this;
        }
        // Set the font for the `StaveLine` text
        public StaveLine SetFont(Font font)
        {
            this.font = font; return this;
        }
        // The the annotation for the `StaveLine`
        public StaveLine SetText(string text)
        {
            this.text = text; return this;
        }

        // Set the notes for the `StaveLine`
        public StaveLine SetNotes(StaveLineNotes notes)
        {
            if (notes.first_note == null && notes.last_note == null)
            {
                throw new Exception("BadArguments,Notes needs to have either first_note or last_note set.");
            }
            if (notes.first_indices == null)
            {
                notes.first_indices = new List<int>() { 0 };
            }
            if (notes.last_indices == null)
            {
                notes.last_indices = new List<int>() { 0 };
            }
            if (notes.first_indices.Count() != notes.last_indices.Count())
            {
                throw new Exception("BadArguments,Connected notes must have similar" + " index sizes");
            }

            // Success. Lets grab 'em notes.
            this.first_note = notes.first_note;
            this.first_indices = notes.first_indices;
            this.last_note = notes.last_note;
            this.last_indices = notes.last_indices;
            return this;
        }
        // Apply the style of the `StaveLine` to the context
        public void ApplyLineStyle()
        {

            //applyLineStyle: function() {
            //  if (!this.context) {
            //    throw new Vex.RERR("NoContext","No context to apply the styling to");
            //  }

            //  var render_options = this.render_options;
            //  var ctx = this.context;

            //  if (render_options.line_dash) {
            //    ctx.setLineDash(render_options.line_dash);
            //  }

            //  if (render_options.line_width) {
            //    ctx.setLineWidth(render_options.line_width);
            //  }

            //  if (render_options.rounded_end) {
            //    ctx.setLineCap("round");
            //  } else {
            //    ctx.setLineCap("square");
            //  }
            //},
        }
        // Apply the text styling to the context
        public void ApplyFontStyle()
        {

            //applyFontStyle: function() {
            //  if (!this.context) {
            //    throw new Vex.RERR("NoContext","No context to apply the styling to");
            //  }

            //  var ctx = this.context;

            //  if (this.font) {
            //    ctx.setFont(this.font.family, this.font.size, this.font.weight);
            //  }

            //  if (this.render_options.color) {
            //    ctx.setStrokeStyle(this.render_options.color);
            //    ctx.setFillStyle(this.render_options.color);
            //  }
            //},
        }
        // Renders the `StaveLine` on the context
        public void Draw()
        {

            //draw: function() {
            //  if (!this.context) {
            //    throw new Vex.RERR("NoContext", "No context to render StaveLine.");
            //  }

            //  var ctx = this.context;
            //  var first_note = this.first_note;
            //  var last_note = this.last_note;
            //  var render_options = this.render_options;

            //  ctx.save();
            //  this.applyLineStyle();

            //  // Cycle through each set of indices and draw lines
            //  var start_position;
            //  var end_position;
            //  this.first_indices.forEach(function(first_index, i) {
            //    var last_index = this.last_indices[i];

            //    // Get initial coordinates for the start/end of the line
            //    start_position = first_note.getModifierStartXY(2, first_index);
            //    end_position = last_note.getModifierStartXY(1, last_index);
            //    var upwards_slope = start_position.y > end_position.y;

            //    // Adjust `x` coordinates for modifiers
            //    start_position.x += first_note.getMetrics().modRightPx +
            //                        render_options.padding_left;
            //    end_position.x -= last_note.getMetrics().modLeftPx +
            //                      render_options.padding_right;


            //    // Adjust first `x` coordinates for displacements
            //    var notehead_width = first_note.getGlyph().head_width;
            //    var first_displaced = first_note.getKeyProps()[first_index].displaced;
            //    if (first_displaced && first_note.getStemDirection() === 1) {
            //      start_position.x += notehead_width + render_options.padding_left;
            //    }

            //    // Adjust last `x` coordinates for displacements
            //    var last_displaced = last_note.getKeyProps()[last_index].displaced;
            //    if (last_displaced && last_note.getStemDirection() === -1) {
            //      end_position.x -= notehead_width + render_options.padding_right;
            //    }

            //    // Adjust y position better if it's not coming from the center of the note
            //    start_position.y += upwards_slope ? -3 : 1;
            //    end_position.y += upwards_slope ? 2 : 0;

            //    drawArrowLine(ctx, start_position, end_position, this.render_options);

            //  }, this);

            //  ctx.restore();

            //  // Determine the x coordinate where to start the text
            //  var text_width = ctx.measureText(this.text).width;
            //  var justification = render_options.text_justification;
            //  var x = 0;
            //  if (justification === StaveLine.TextJustification.LEFT) {
            //    x = start_position.x;
            //  } else if (justification === StaveLine.TextJustification.CENTER) {
            //    var delta_x = (end_position.x - start_position.x);
            //    var center_x = (delta_x / 2 ) + start_position.x;
            //    x = center_x - (text_width / 2);
            //  } else if (justification === StaveLine.TextJustification.RIGHT) {
            //    x = end_position.x  -  text_width;
            //  }

            //  // Determine the y value to start the text
            //  var y;
            //  var vertical_position = render_options.text_position_vertical;
            //  if (vertical_position === StaveLine.TextVerticalPosition.TOP) {
            //    y = first_note.getStave().getYForTopText();
            //  } else if (vertical_position === StaveLine.TextVerticalPosition.BOTTOM) {
            //    y = first_note.getStave().getYForBottomText();
            //  }

            //  // Draw the text
            //  ctx.save();
            //  this.applyFontStyle();
            //  ctx.fillText(this.text, x, y);
            //  ctx.restore();

            //  return this;
            //}
        }
        // ## Private Helpers
        // 
        // Attribution: Arrow rendering implementations based off of
        // Patrick Horgan's article, "Drawing lines and arcs with 
        // arrow heads on  HTML5 Canvas"
        // 
        // Draw an arrow head that connects between 3 coordinates
        public static void DrawArrowHead(object ctx, double x0, double y0, double x1, double y1, double x2, double y2)
        {

            //function drawArrowHead(ctx, x0, y0, x1, y1, x2, y2) {
            //  // all cases do this.
            //  ctx.beginPath();
            //  ctx.moveTo(x0,y0);
            //  ctx.lineTo(x1,y1);
            //  ctx.lineTo(x2,y2);
            //  ctx.lineTo(x0, y0);
            //  ctx.closePath();

            //  ctx.fill();
            //}
        }
        // Helper function to draw a line with arrow heads
        public static void DrawArrowLine(object ctx, object point1, object point2, object config)
        {

            //function drawArrowLine(ctx, point1, point2, config) {
            //  var both_arrows = config.draw_start_arrow && config.draw_end_arrow;

            //  var x1 = point1.x;
            //  var y1 = point1.y;
            //  var x2 = point2.x;
            //  var y2 = point2.y;

            //  // For ends with arrow we actually want to stop before we get to the arrow
            //  // so that wide lines won't put a flat end on the arrow.
            //  var distance = Math.sqrt((x2-x1)*(x2-x1)+(y2-y1)*(y2-y1));
            //  var ratio = (distance - config.arrowhead_length/3) / distance;
            //  var end_x, end_y, start_x, start_y;
            //  if (config.draw_end_arrow || both_arrows) {
            //    end_x = Math.round(x1 + (x2 - x1) * ratio);
            //    end_y = Math.round(y1 + (y2 - y1) * ratio);
            //  } else {
            //    end_x = x2;
            //    end_y = y2;
            //  }

            //  if (config.draw_start_arrow || both_arrows) {
            //    start_x = x1 + (x2 - x1) * (1 - ratio);
            //    start_y = y1 + (y2 - y1) * (1 - ratio);
            //  } else {
            //    start_x = x1;
            //    start_y = y1;
            //  }

            //  if (config.color) {
            //    ctx.setStrokeStyle(config.color);
            //    ctx.setFillStyle(config.color);
            //  }

            //  // Draw the shaft of the arrow
            //  ctx.beginPath();
            //  ctx.moveTo(start_x, start_y);
            //  ctx.lineTo(end_x,end_y);
            //  ctx.stroke();
            //  ctx.closePath();

            //  // calculate the angle of the line
            //  var line_angle = Math.atan2(y2 - y1, x2 - x1);
            //  // h is the line length of a side of the arrow head
            //  var h = Math.abs(config.arrowhead_length / Math.cos(config.arrowhead_angle));

            //  var angle1, angle2;
            //  var top_x, top_y;
            //  var bottom_x, bottom_y;

            //  if (config.draw_end_arrow || both_arrows) {
            //    angle1 = line_angle + Math.PI + config.arrowhead_angle;
            //    top_x = x2 + Math.cos(angle1) * h;
            //    top_y = y2 + Math.sin(angle1) * h;

            //    angle2 = line_angle + Math.PI - config.arrowhead_angle;
            //    bottom_x = x2 + Math.cos(angle2) * h;
            //    bottom_y = y2 + Math.sin(angle2) * h;

            //    drawArrowHead(ctx, top_x, top_y, x2, y2, bottom_x, bottom_y);
            //  }

            //  if (config.draw_start_arrow || both_arrows) {
            //    angle1 = line_angle + config.arrowhead_angle;
            //    top_x = x1 + Math.cos(angle1) * h;
            //    top_y = y1 + Math.sin(angle1) * h;

            //    angle2 = line_angle - config.arrowhead_angle;
            //    bottom_x = x1 + Math.cos(angle2) * h;
            //    bottom_y = y1 + Math.sin(angle2) * h;

            //    drawArrowHead(ctx, top_x, top_y, x1, y1, bottom_x, bottom_y);
            //  }
            //}
        } 
        #endregion



        #region 隐含字段
        public StaveLineNotes notes;
        public CanvasContext context;
        public StaveLineRenderOpts render_options;
        public Font font;
        public string text;

        public StaveNote first_note;
        public IList<int> first_indices;
        public StaveNote last_note;
        public IList<int> last_indices;
        #endregion
    }
}
