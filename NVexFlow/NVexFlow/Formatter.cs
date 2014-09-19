using System;
using System.Collections.Generic;

namespace NVexFlow
{
    public class Formatter
    {
        double minTotalWidth;

        public double MinTotalWidth
        {
            get
            { return minTotalWidth; }
        }
        bool hasMinTotalWidth;
        public double? pixelsPerTick;
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
            this.totalTicks = new Fraction(0,1);

            // Arrays of tick and modifier contexts.
            this.tContexts = null;
            this.mContexts = null;
        }


        public object LookAhead(IList<object> notes,object rest_line,object i,object compare)
        {
            return null;
        }


        public object CreateContexts(IList<object> voices,object context_type,object add_fn)
        {
            return null;
        }

        public static object FormatAndDraw(object ctx,object stave,IList<object> notes,IList<object> @params)
        {
            return null;
        }

        public static void FormatAndDrawTab(object ctx,object tabstave,object stave,IList<object> tabnotes,IList<object> notes,object autobeam,IList<object> @params)
        { }

        public static void AlignRestsToNotes(IList<StaveNote> notes, bool align_all_notes, bool align_tuplets)
        { }

        public void AlignRests(IList<object> voices,IList<object> align_all_notes)
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

        public void PreFormat(double justifyWidth,object rendering_context,IList<object> voices,object stave)
        { }

        public Formatter PostFormat()
        {
            return null;
        }

        public Formatter JoinVoices(IList<Voice> voices)
        { return null; }

        public Formatter Format(IList<Voice> voices,double justifyWidth,IList<object> options = null)
        {
            return null;
        }

        public Formatter FormatToStave(IList<object> voices,object stave,IList<object> options)
        {
            return null;
        }
    }
}
