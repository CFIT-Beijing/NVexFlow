
namespace NVexFlow
{
    public partial class Vex
    {
        public partial class Flow
        {
            public class BoundingBox
            {
                public BoundingBox(double x, double y, double w, double h)
                { }
                public void Init(double x, double y, double w, double h)
                {
                    this.x = x;
                    this.y = y;
                    this.w = w;
                    this.h = h;
                }

                public void Move(double x, double y)
                {
                    this.x += x;
                    this.y += y;
                }

                public BoundingBox Clone()
                {
                    return Copy(this);
                }

                public BoundingBox Copy(BoundingBox that)
                {
                    return new BoundingBox(that.X, that.Y, that.W, that.H);
                }

                public void Draw(object ctx, double x, double y)
                { }

                public BoundingBox MergeWith(BoundingBox boundingBox, object ctx)
                {
                    return null;
                }

                double x;

                public double X
                {
                    get { return x; }
                    set { x = value; }
                }
                double y;

                public double Y
                {
                    get { return y; }
                    set { y = value; }
                }
                double w;

                public double W
                {
                    get { return w; }
                    set { w = value; }
                }
                double h;

                public double H
                {
                    get { return h; }
                    set { h = value; }
                }
            }
        }
    }
}
