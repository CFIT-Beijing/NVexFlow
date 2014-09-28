namespace NVexFlow.Model
{
    public class NoteHeadStruct:NoteStruct
    {
        public double line;
        public int index;
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
    public class Glyph4NoteHead:Glyph4Note
    {
    }
    public class NoteHeadRenderOpts:NoteRenderOpts
    {
        public int glyphFontScale;// font size for note heads
    }
}
