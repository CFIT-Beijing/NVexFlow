using System.Collections.Generic;

namespace NVexFlow.Model
{
    public class StaveNoteStruct:NoteStruct
    {
        public IList<string> keys;
        public string clef;
        public int stem_direction;
        public int? auto_stem;
    }
    public class StaveNoteRenderOpts:NoteRenderOpts
    {
        public int glyph_font_scale;
    }
    public class Glyph4StaveNote:Glyph4Note
    {
    }
    public class NoteHeadBounds
    {
        //return {
        //  y_top: y_top,
        //  y_bottom: y_bottom,
        //  highest_line: highest_line,
        //  lowest_line: lowest_line
        //};
        public double y_top;
        public double y_bottom;
        public double highest_line;
        public double lowest_line;
    }
    public class ModifierStartXY
    {
        //return { x: this.getAbsoluteX() + x, y: this.ys[index] };
        public double x;
        public double y;
    }
}
