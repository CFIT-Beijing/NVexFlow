using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NVexFlow.MODEL
{
    public class ClefType
    {
        private string code;

        public string Code
        {
            get { return code; }
            set { code = value; }
        }

        private int point;

        public int Point
        {
            get { return point; }
            set { point = value; }
        }

        private int line;

        public int Line
        {
            get { return line; }
            set { line = value; }
        }
    }
}
