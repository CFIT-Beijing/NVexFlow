using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NVexFlow.Model
{
    public class Notes4StaveTie
    {
        public Note firstNote;
        public Note lastNote;
        public IList<int> firstIndices;
        public IList<int> lastIndices;
    }
    public class StaveTieRenderOpts:RenderOptions
    {
        public double cp1;
        public double cp2;
        public double textShiftX;
        public double firstXShift;
        public double lastXShift;
        public double yShift;
        public double tieSpacing;
        public Font font;
    }
}
