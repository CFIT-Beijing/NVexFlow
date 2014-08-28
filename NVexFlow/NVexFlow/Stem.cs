using System;
using System.Collections;
using System.Collections.Generic;
using NVexFlow.Model;
using System.Linq;
namespace NVexFlow
{
    /// <summary>
    /// ## Description
    // 
    // This file implements the `Stem` object. Generally this object is handled 
    // by its parent `StemmableNote`.
    // 
    /// </summary>
    public class Stem
    {
        #region js直译部分
        public Stem(StemOpts options = null)
        {
            Init(options);
        }
        // Stem directions
        public static int UP = 1;
        public static int DOWN = -1;
        // Theme
        public static double WIDTH = Flow.STEM_WIDTH;
        public static double HEIGHT = Flow.STEM_HEIGHT;
        private void Init(StemOpts options)
        {
            // Default notehead x bounds
            this.xBegin = options.xBegin ?? 0;
            this.xEnd = options.xEnd ?? 0;
            // Y bounds for top/bottom most notehead
            this.yTop = options.yTop ?? 0;
            this.yBottom = options.yBottom ?? 0;

            // Stem base extension
            this.yExtend = options.yExtend ?? 0;
            // Stem top extension
            this.stemExtension = options.stemExtension ?? 0;
            // Direction of the stem
            this.stemDirection = options.stemDirection ?? 0;
            // Flag to override all draw calls
            this.hide = false;
        }
        // Set the x bounds for the default notehead
        public Stem SetNoteHeadXBounds(double xBegin, double xEnd)
        {
            this.xBegin = xBegin;
            this.xEnd = xEnd;
            return this;
        }
        // Set the direction of the stem in relation to the noteheads
        public void SetDirection(double direction)
        {
            this.stemDirection = direction;
        }
        // Set the extension for the stem, generally for flags or beams
        public void SetExtension(double ext)
        {
            this.stemExtension = ext;
        }
        // The the y bounds for the top and bottom noteheads
        public Stem SetYBounds(double yTop, double yBottom)
        {
            this.yTop = yTop;
            this.yBottom = yBottom;
            return this;
        }
        // The category of the object
        public string GetCategory()
        {
            return "stem";
        }
        // Set the canvas context to render on
        public Stem SetContext(CanvasContext context)
        {
            this.context = context;
            return this;
        }
        // Gets the entire height for the stem
        public double GetHeight()
        {
            return (this.yBottom - this.yTop) * this.stemDirection + (Stem.HEIGHT + this.stemExtension) * this.stemDirection;
        }
        public BoundingBox GetBoundingBox()
        {
            throw new Exception("NotImplemented,getBoundingBox() not implemented.");
        }
        // Get the y coordinates for the very base of the stem to the top of the extension
        public StemExtents GetExtents()
        {
            IList<double> ys = new List<double>() { this.yTop, this.yBottom };
            double topPixel = this.yTop;
            double basePixel = this.yBottom;
            double stemHeight = Stem.HEIGHT + this.stemExtension;
            for (int i = 0; i < ys.Count(); i++)
            {
                double stemTop = ys[i] + (stemHeight * -this.stemDirection);

                if (this.stemDirection == Stem.DOWN)
                {
                    topPixel = topPixel > stemTop ? topPixel : stemTop;
                    basePixel = basePixel < ys[i] ? basePixel : ys[i];
                }
                else
                {
                    topPixel = topPixel < stemTop ? topPixel : stemTop;
                    basePixel = basePixel > ys[i] ? basePixel : ys[i];
                }
            }
            return new StemExtents() {topY=topPixel,baseY=basePixel };
        }
        // Render the stem onto the canvas
        public void Draw()
        {

            //draw: function() {
            //  if (!this.context) throw new Vex.RERR("NoCanvasContext",
            //      "Can't draw without a canvas context.");

            //  if (this.hide) return;

            //  var ctx = this.context;
            //  var stem_x, stem_y;
            //  var stem_direction = this.stem_direction;

            //  if (stem_direction == Stem.DOWN) {
            //    // Down stems are rendered to the left of the head.
            //    stem_x = this.x_begin + (Stem.WIDTH / 2);
            //    stem_y = this.y_top + 2;
            //  } else {
            //    // Up stems are rendered to the right of the head.
            //    stem_x = this.x_end + (Stem.WIDTH / 2);
            //    stem_y = this.y_bottom - 2;
            //  }

            //  stem_y += this.y_extend * stem_direction;

            //  L("Rendering stem - ", "Top Y: ", this.y_top, "Bottom Y: ", this.y_bottom);

            //  // Draw the stem
            //  ctx.beginPath();
            //  ctx.setLineWidth(Stem.WIDTH);
            //  ctx.moveTo(stem_x, stem_y);
            //  ctx.lineTo(stem_x, stem_y - this.getHeight());
            //  ctx.stroke();
            //  ctx.setLineWidth(1);
            //}
        }
        #endregion


        #region 隐含字段
        public bool hide;
        public double xBegin;
        public double xEnd;
        public double yExtend;
        public double stemDirection;
        public double stemExtension;
        public string category;
        public CanvasContext context;
        public double yTop;
        public double yBottom;
        #endregion
    }
}
