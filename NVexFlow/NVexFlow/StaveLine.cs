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
            public class StaveLine
            {
                public enum StaveLineTextVerticalPosition
                {TOP,
    BOTTOM }

                public enum StaveLineTextJustification
                {
                LEFT,
    CENTER,
    RIGHT
                }

                public StaveLine(IList<object> notes)
                {
                    Init(notes);
                }

                public void Init(IList<object> notes)
                { }

                object context;

                public object Context
                {
                    set { context = value; }
                }

                object font;

                public object Font
                {
                    set { font = value; }
                }

                string text;

                public string Text
                {
                    set { text = value; }
                }

                object first_note;
                object first_indices;
                object last_note;
                object last_indices;

                public StaveLine SetNotes(IList<object> notes)
                {
                    return this;
                }

                public void ApplyLineStyle()
                { }

                public void ApplyFontStyle()
                { }

                public void Draw()
                { }

                public static void DrawArrowHead(object ctx,double x0,double y0,double x1,double y1,double x2,double y2)
                { }

                public static void DrawArrowLine(object ctx, object point1, object point2, object config)
                { }
            }
        }
    }
}
