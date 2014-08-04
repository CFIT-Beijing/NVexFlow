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
        public bool? ignoreTicks;
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
    {
        public double stemUpExtension = - Vex.Flow.STEM_HEIGHT;
        public double stemDownExtension = - Vex.Flow.STEM_HEIGHT;
        //common
        //  head_width: 16,
        //stem: false,
        //stem_offset: 0,
        //flag: false,
        //stem_up_extension: -Vex.Flow.STEM_HEIGHT,
        //stem_down_extension: -Vex.Flow.STEM_HEIGHT,
        //gracenote_stem_up_extension: -Vex.Flow.STEM_HEIGHT,
        //gracenote_stem_down_extension: -Vex.Flow.STEM_HEIGHT,
        //tabnote_stem_up_extension: -Vex.Flow.STEM_HEIGHT,
        //tabnote_stem_down_extension: -Vex.Flow.STEM_HEIGHT,
        //dot_shiftY: 0,
        //line_above: 0,
        //line_below: 0
        //type
        //        "m": { // Whole note muted
        //  code_head: "v92",
        //  stem_offset: -3
        //},
        //"r": { // Whole rest
        //  code_head: "v5c",
        //  head_width: 12,
        //  rest: true,
        //  position: "D/5",
        //  dot_shiftY: 0.5
        //}
    }










}
