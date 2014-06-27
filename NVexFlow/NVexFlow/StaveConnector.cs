using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NVexFlow
{
    public partial class Vex
    {
        public partial class Flow
        {
            public class StaveConnector
            {

                public static class StaveConnectorType 
                {
                    public static int SINGLE_RIGHT = 0;
                    public static int SINGLE_LEFT = 1;
                    public static int SINGLE = 1;
                    public static int DOUBLE = 2;
                    public static int BRACE = 3;
                    public static int BRACKET = 4;
                    public static int BOLD_DOUBLE_LEFT = 5;
                    public static int BOLD_DOUBLE_RIGHT = 6;
                    public static int THIN_DOUBLE = 7;
                }

                public StaveConnector(object top_stave,object  bottom_stave)
                { Init(top_stave,bottom_stave); }

                public void Init(object top_stave, object bottom_stave)
                { }

                object ctx;

                public object Context
                {
                    set { ctx = value; }
                }

                int type;

                public int Type
                {
                    set {
                        if (type >= StaveConnectorType.SINGLE_RIGHT &&
    type <= StaveConnectorType.THIN_DOUBLE)
                        {
                            type = value;
                        }
                    }
                }


                string text;
                IList<object> text_options;
                public StaveConnector SetText(string text,IList<object> text_options)
                {
                    return this;
                }

                object font;

                public object Font
                {
                    set {
                        //
                        font = value; }
                }

                double x_shift;

                public double X_shift
                {
                    set {
                        double x_shift;
                        if (double.TryParse(value.ToString(),out x_shift) == false)
                        { }
                        else
                        {
                            this.x_shift = value;
                        }
                    }
                }

                public void Draw()
                { }

                public static void DrawBoldDoubleLine(object ctx, object type, double topX, double topY, double botY)
                { }
            }
        }
    }
}
