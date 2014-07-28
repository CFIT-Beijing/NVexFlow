using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NVexFlow.Model
{
    public class NoteHeadStruct : NoteStruct
    {
        public int line;
        public object index;
        public double? x;
        public double? y;
        public string noteType;
        public bool? displaced;
        public int? stemDirection;
        public double xShift;
        public string customGlyphCode;
        public NoteHeadStyle style;
        public object slashed;
        public int? glyphFontScale;
    }

    /// <summary>
    /// `style` is an `object` with the following properties: `shadowColor`, `shadowBlur`, `fillStyle`, `strokeStyle`
    /// </summary>
    public class NoteHeadStyle
    {
        public object shadowColor;
        public object shadowBlur;
        public object fillStyle;
        public object strokeStyle;
    }
    /// <summary>
    ///table.js  Vex.Flow.durationToGlyph.duration_codes
    /// </summary>
    public class Glyph4NoteHead :Glyph4Note
    {
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
        public string codeHead;
        public double headWidth;
    }

    public class NoteHeadRenderOpts : NoteRenderOpts
    {       
        public int glyphFontScale;// font size for note heads
        public int strokePx;// number of stroke px to the left and right of head
    }
}
