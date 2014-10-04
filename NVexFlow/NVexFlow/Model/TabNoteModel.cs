using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NVexFlow.Model
{
    public class TabNoteStruct:NoteStruct
    {
        public IList<TabNotePos> positions;
    }

    public class TabNotePos
    {
        public double str;
        public double fret;
    }

    public class TabNoteRenderOpts:NoteRenderOpts
    {
        public int glyph_font_scale;
        public bool draw_stem;
        public bool draw_dots;
        public bool draw_stem_through_stave;
    }

    public class Glyph4TabNote : Glyph4Note
    {
        //          return {
        //  text: fret,
        //  code: glyph,
        //  width: width,
        //  shift_y: shift_y
        //};
        public string text;
        public string code;
        public double width;
        public double shift_y;
        public object code_flag_down_stem;
        public object code_flag_up_stem;
    }

    public class TabNoteModifierStartXY
    {
        public double x;
        public double y;
    }
}
