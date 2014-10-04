namespace NVexFlow.Model
{
    public class NoteHeadStruct:NoteStruct
    {
        public double line;
        public int index;
        public double? x;
        public double? y;
        public string note_type;
        public bool? displaced;
        public int? stem_direction;
        public double x_shift;
        public string custom_glyph_code;
        public NoteHeadStyle style;
        public object slashed;
        public int? glyph_font_scale;
    }
    /// <summary>
    /// `style` is an `object` with the following properties: `shadowColor`, `shadowBlur`, `fillStyle`, `strokeStyle`
    /// </summary>
    public class NoteHeadStyle
    {
        public object shadow_color;
        public object shadow_blur;
        public object fill_style;
        public object stroke_style;
    }
    /// <summary>
    ///table.js  Vex.Flow.durationToGlyph.duration_codes
    /// </summary>
    public class Glyph4NoteHead:Glyph4Note
    {
    }
    public class NoteHeadRenderOpts:NoteRenderOpts
    {
        public int glyph_font_scale;// font size for note heads
    }
}
