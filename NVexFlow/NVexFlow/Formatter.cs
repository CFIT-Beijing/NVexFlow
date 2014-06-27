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
            public class Formatter
            {
                double minTotalWidth;

                public double MinTotalWidth
                {
                    get { return minTotalWidth; }
                }
                bool hasMinTotalWidth;
                double pixelsPerTick;
                Fraction totalTicks;
                object tContexts;
                object mContexts;

                




                public Formatter()
                {
                    // Minimum width required to render all the notes in the voices.
                    this.minTotalWidth = 0;

                    // This is set to `true` after `minTotalWidth` is calculated.
                    this.hasMinTotalWidth = false;

                    // The suggested amount of space for each tick.
                    this.pixelsPerTick = 0;

                    // Total number of ticks in the voice.
                    this.totalTicks = new Vex.Flow.Fraction(0, 1);

                    // Arrays of tick and modifier contexts.
                    this.tContexts = null;
                    this.mContexts = null;
                }


                public object LookAhead(IList<object> notes, object rest_line, object i, object compare)
                {
                    return null;
                }


                public object CreateContexts(IList<object> voices, object context_type, object add_fn)
                {  
                    return null;
                }

                public static object FormatAndDraw(object ctx,object stave,IList<object> notes,IList<object> @params)
                {
                    return null;
                }

                public static void FormatAndDrawTab(object ctx, object tabstave, object stave, IList<object> tabnotes, IList<object> notes, object autobeam, IList<object> @params)
                { }

                public static void AlignRestsToNotes(IList<object> notes, IList<object> align_all_notes, IList<object> align_tuplets)
                { }

                public void AlignRests(IList<object> voices, IList<object> align_all_notes)
                { }

                public double PreCalculateMinTotalWidth(object voices)
                {
                    return 0;
                }

                public object CreateModifierContexts(IList<object> voices)
                {
                    return null;
                }

                public object CreateTickContexts(IList<object> voices)
                {
                    return null;
                }

                public void PreFormat(double justifyWidth, object rendering_context, IList<object> voices, object stave)
                { }

                public Formatter PostFormat()
                {
                    return null;
                }

                public Formatter JoinVoices(IList<object> voices)
                { return null; }

                public Formatter Format(IList<object> voices,double justifyWidth,IList<object> options)
                {
                    return null;
                }

                public Formatter FormatToStave(IList<object> voices,object stave,IList<object> options)
                {
                    return null;
                }
            }
        }
    }
}
