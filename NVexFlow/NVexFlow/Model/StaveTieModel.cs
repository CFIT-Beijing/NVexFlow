using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NVexFlow.Model
{
    public class Notes4StaveTie
    {
        public Note first_note;
        public Note last_note;
        public IList<int> first_indices;
        public IList<int> last_indices;
    }
    public class StaveTieRenderOpts:RenderOptions
    {
        public double cp1;
        public double cp2;
        public double text_shift_x;
        public double first_x_shift;
        public double last_x_shift;
        public double y_shift;
        public double tie_spacing;
        public Font font;
    }
}
