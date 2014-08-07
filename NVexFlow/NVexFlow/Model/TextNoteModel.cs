namespace NVexFlow.Model
{
    public class Glyph4TextNote
    {
        public string code;
        public int point;
        public double xShift;
        public double yShift;
        public double? width;
    }
    public class TextStruct:NoteStruct
    {
        public string text;
        public string superscript;
        public string subscript;
        public string glyph;
        public Font font;
        public int? line;
        public bool? smooth;
    }
}
