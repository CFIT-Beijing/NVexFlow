using System;
namespace NVexFlow
{
    /// <summary>
    /// Vex Music Notation
    // Mohit Muthanna <mohit@muthanna.com>
    //
    // Copyright Mohit Muthanna 2010

    // Bounding boxes for interactive notation
    /// </summary>
    public class BoundingBox
    {
        #region js直译部分
        public BoundingBox(double x, double y, double w, double h)
        { }
        public static BoundingBox Copy(BoundingBox that)
        {
            return new BoundingBox(that.x, that.y, that.w, that.h);
        }
        private void Init(double x, double y, double w, double h)
        {
            this.x = x;
            this.y = y;
            this.w = w;
            this.h = h;
        }
        public double GetX()
        { return this.x; }
        public double GetY()
        { return this.y; }
        public double GetW()
        { return this.w; }
        public double GetH()
        { return this.h; }
        public BoundingBox SetX(double x)
        { this.x = x; return this; }
        public BoundingBox SetY(double y)
        { this.y = y; return this; }
        public BoundingBox SetW(double w)
        { this.w = w; return this; }
        public BoundingBox SetH(double h)
        { this.h = h; return this; }
        public void Move(double x, double y)
        {
            this.x += x;
            this.y += y;
        }
        public BoundingBox Clone()
        {
            return BoundingBox.Copy(this);
        }
        public BoundingBox MergeWith(BoundingBox boundingBox, CanvasContext ctx=null)
        {
            //         // Merge my box with given box. Creates a bigger bounding box unless the given box is contained in this one.
            //mergeWith: function(boundingBox, ctx) {
            //  var that = boundingBox;
            BoundingBox that = boundingBox;
            double newX = this.x < that.x ? this.x : that.x;
            double newY = this.y < that.y ? this.y : that.y;
            double newW = this.x + this.w < that.x + that.w ? that.x + that.w - this.x : this.x + this.w - Math.Min(this.x, that.x);
            double newH = this.y + this.h < that.y + that.h ? that.y + that.h - this.y : this.y + this.h - Math.Min(this.y, that.y);

            this.x = newX;
            this.y = newY;
            this.w = newW;
            this.h = newH;

            if (ctx != null)
            {
                this.Draw(ctx);
            }
            return this;
        }
        public void Draw(object ctx, double? x = null, double? y = null)
        {
            //    draw: function(ctx, x, y) {
            //  if (!x) x = 0;
            //  if (!y) y = 0;
            //  ctx.rect(this.x + x, this.y + y, this.w, this.h);
            //  ctx.stroke();
            //}
        }
        #endregion



        #region 隐含字段
        public double x;
        public double y;
        public double w;
        public double h;
        #endregion
    }
}
