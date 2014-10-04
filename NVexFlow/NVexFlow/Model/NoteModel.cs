using System.Collections.Generic;

namespace NVexFlow.Model
{
    public class NoteStruct
    {
        public string duration;
        public bool? ignore_ticks;
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
    public class NoteRenderOpts:RenderOptions
    {
        public double annotation_spacing;
        public double stave_padding;
    }
    public class NoteModifierStartXY
    {
        public double x;
        public double y;
    }
    public class NoteMetrics
    {
        public Dictionary<Barline.BarlineType,int> widths;
        public double width;
        public double note_width;
        public double left_shift;
        public double mod_left_px;
        public double mod_right_px;
        public double extra_left_px;
        public double extra_right_px;
    }
    public class Glyph4Note
    {
        public double stem_up_extension = -Flow.STEM_HEIGHT;
        public double stem_down_extension = -Flow.STEM_HEIGHT;
        public string code_head;
        public bool rest;
        public string position;
        public double line_above;
        public double line_below;
        public bool stem;
        public double head_width;
        public double dot_shiftY;
        public bool flag;
        public double gracenote_stem_up_extension;
        public double gracenote_stem_down_extension;
        public double tabnote_stem_up_extension;
        public double tabnote_stem_down_extension;
        public double stem_offset;
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
    public class NoteProps
    {
        public double line;
        public string code;
        public double shift_right;
        public bool displaced;
        public int int_value;
        //  Vex.Flow.keyProperties = function(key, clef) {
        //  return {
        //  key: k,
        //  octave: o,
        //  line: line,
        //  int_value: int_value,
        //  accidental: value.accidental,
        //  code: code,
        //  stroke: stroke,
        //  shift_right: shift_right,
        //  displaced: false
        //};
        //  }
    }
    public class KeyProperties
    {
    }
}
