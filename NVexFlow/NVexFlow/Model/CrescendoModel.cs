using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NVexFlow.Model
{
    public class CrescendoStruct : NoteStruct
    {
        public int? line;
    }
    public class RenderHairpinParams
    {
        public double beginX;
        public double endX;
        public double y;
        public double height;
        public bool reverse;
    }

    public class CrescendoRenderOpts
    { 
        public double extendLeft;
        public double extendRight;
        public double yShift;
    }
}
