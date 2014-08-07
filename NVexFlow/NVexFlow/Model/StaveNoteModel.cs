using System.Collections.Generic;

namespace NVexFlow.Model
{
    public class StaveNoteStruct:NoteStruct
    {
        public IList<string> keys;
        public string clef;
        public int stemDirection;
        public int? autoStem;
    }
    public class StaveNoteRenderOpts:NoteRenderOpts
    {
        public int glyphFontScale;
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
        public double yTop;
        public double yBottom;
        public double highestLine;
        public double lowestLine;
    }
    public class ModifierStartXY
    {
        //return { x: this.getAbsoluteX() + x, y: this.ys[index] };
        public double x;
        public double y;
    }
}
