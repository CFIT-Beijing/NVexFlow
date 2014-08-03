using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NVexFlow.Model
{
    public class Glyph4StemmableNote:Glyph4Note
    {
        public double headWidth;
        public double beamCount;
    }

    public class StemExtents
    {
        public double topY;
        public double baseY;
    }
}
