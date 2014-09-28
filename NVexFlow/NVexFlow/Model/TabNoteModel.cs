﻿using System;
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
        public int glyphFontScale;
        public bool drawStem;
        public bool drawDots;
        public bool drawStemThroughStave;
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
        public object codeFlagDownStem;
        public object codeFlagUpStem;
    }

    public class TabNoteModifierStartXY
    {
        public double x;
        public double y;
    }
}
