using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NVexFlow;


namespace NVexFlow.MODEL
{
    public class TimeSig
    {
        private bool num;

        public bool Num
        {
            get { return num; }
            set { num = value; }
        }
        private int line;

        public int Line
        {
            get { return line; }
            set { line = value; }
        }
        private Vex.Flow.Glyph glyph;

        public Vex.Flow.Glyph Glyph
        {
            get { return glyph; }
            set { glyph = value; }
        }
    }
}
