using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZhCJB.VexFlow.CS
{//Renderer
    public partial class Vex
    {
        public partial class Flow
        {
            public class Renderer
            {
                public Renderer(object sel,object backend)
                {
                    Init(sel, backend);
                }

                public enum RendererBackends
                {
                    CANVAS,
                    RAPHAEL,
                    SVG,
                    VML
                }

                public enum RendererLineEndType
                {
                    NONE,
                    UP,
                    DOWN
                }

                public static bool USE_CANVAS_PROXY = false;

                public static object BuildContext(object sel,
      object backend,double width,double height,object background)
                {
                    return null;
                }

                public static object GetCanvasContext(object sel,
       double width, double height, object background)
                {
                    return null;
                //return Renderer.buildContext(sel, Renderer.Backends.CANVAS, width, height, background);
                }


                public static object getRaphaelContext(object sel,
       double width, double height, object background)
                {
                    return null;
                    //return Renderer.buildContext(sel, Renderer.Backends.RAPHAEL,width, height, background);
                }

                public static object BolsterCanvasContext(object ctx)
                {
                    return ctx;
                }

                public static void DrawDashedLine(object context,double fromX,double fromY,double toX,double toY,object dashPattern)
                { }

                public void Init(object sel, object backend)
                { }

                public Renderer Resize(double width,double height)
                {
                    return this;
                }

                private object ctx;

                public object Ctx
                {
                    get { return ctx; }
                }
            }
        }
    }
}
