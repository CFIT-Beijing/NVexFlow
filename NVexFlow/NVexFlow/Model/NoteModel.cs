using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NVexFlow.Model
{
    public class NoteStruct
    {
        public string duration;
        //{ keys: ["a/3"], duration: "q", stem_direction: 1 }
        //public IList<string> keys;

        //public int stemDirection;
        //public string glyph;
        //public int? line;
    }

    public class NoteInitData
    {
        public string duration;
        public int dots;
        public string type;
        public int ticks;
    }

    public class NoteRenderOpts
    {
        public double annotationSpacing;
        public double stavePadding;
    }

    public class NoteModifierStartXY
    {
        public double x;
        public double y;
    }

    public class NoteMetrics
    { 
        public double width;
        public double noteWidth;
        public double leftShift;
        public double modLeftPx;
        public double modRightPx;
        public double extraLeftPx;
        public double extraRightPx;
    }

    public class Glyph4Note
    { }










}
