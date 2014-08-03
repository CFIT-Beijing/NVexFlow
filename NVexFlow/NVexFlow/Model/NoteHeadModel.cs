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
        public string codeHead;
        public double headWidth;
    }

    public class NoteHeadRenderOpts : NoteRenderOpts
    {       
        public int glyphFontScale;// font size for note heads
        public int strokePx;// number of stroke px to the left and right of head
    }
}
