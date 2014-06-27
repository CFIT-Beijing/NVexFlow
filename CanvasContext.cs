using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZhCJB.VexFlow.CS
{//CanvasContext
    public partial class Vex
    {
        public partial class Flow
        {//这个类暂时不细化。将来直接做成和WPF接轨的。
            public class CanvasContext
            {
                public CanvasContext(object context)
                {
                    Init(context);
                }

                public static double Width = 600;
                public static double Height = 400;

                object vexFlowCanvasContext;
                public void Init(object context)
                { }

                public void Clear()
                { }

                public CanvasContext SerFont(object family, object size, object weight)
                {
                    return null;
                }

                private Font font;

                public Font RawFont
                {
                    set { font = value; }
                }

                private object fillStyle;

                public object FillStyle
                {
                    set { fillStyle = value; }
                }

                private object background_fillStyle;

                public object BackgroundFillStyle
                {
                    set { background_fillStyle = value; }
                }

                private object strokeStyle;

                public object StrokeStyle
                {
                    set { strokeStyle = value; }
                }

                private object shadowColor;

                public object ShadowColor
                {
                    set { shadowColor = value; }
                }

                private object shadowBlur;

                public object ShadowBlur
                {
                    set { shadowBlur = value; }
                }

                private double lineWidth;

                public double LineWidth
                {
                    set { lineWidth = value; }
                }

                private object cap_type;

                public object LineCap
                {
                    set { cap_type = value; }
                }

                private object dash;

                public object LineDash
                {
                    set { dash = value; }
                }

                public object Scale(string x, string y)
                {
                    return Scale(Convert.ToDouble(x), Convert.ToDouble(y));
                }

                public object Scale(double x, double y)
                {
                    return null;
                }

                public object Resize(string width, string height)
                { return Resize(Convert.ToInt32(width), Convert.ToInt32(height)); }

                public object Resize(int width, int height)
                { return null; }

                public object Rect(object x, object y, object width, object height)
                {
                    return null;
                }


                public object FillRect(object x, object y, object width, object height)
                {
                    return null;
                }

                public object ClearRect(object x, object y, object width, object height)
                {
                    return null;
                }


                public object BeginPath()
                {
                    return null;
                }

                public object MoveTo(double x,double y)
                {
                    return null;
                }

                public object LineTo(double x, double y)
                {
                    return null;
                }

                public object BezierCurveTo(double x1, double y1, double x2, double y2, double x3, double y3)
                {
                    return null;
                }

                public object QuadraticCurveTo(double x1, double y1, double x2, double y2)
                {
                    return null;
                } 



                public object Arc(double x, double y, object radius, object startAngle, object endAngle, object antiClockwise)
                {
                    return null;
                }

                public object Glow()
                {
                    return null;
                }


                public object Fill()
                {
                    return null;
                }

                public object Stroke()
                {
                    return null;
                }

                public object ClosePath()
                {
                    return null;
                }



                public object MeasureText(string text)
                {
                    return null;
                }
 
                public object FillText(string text,double x,double y)
                {
                    return null;
                }

                public object Save()
                {
                    return null;
                }

                public object Restore()
                {
                    return null;
                }
            }
        }
    }
}
