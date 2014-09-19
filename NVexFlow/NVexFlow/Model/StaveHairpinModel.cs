using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NVexFlow.Model
{
    public class StaveHairpinNotes
    {
        public StaveNote first_note;
        public StaveNote last_note;
    }
    public class StaveHairpinOpts
    { 
        public double height;
        public double y_shift;//vertical offset
        public double left_shift_ticks;//left horizontal offset expressed in ticks
        public double right_shift_ticks;// right horizontal offset expressed in ticks
    }
    public class StaveHairpinRenderOpts
    {
        public double? height;
        public double? y_shift;
        public double? left_shift_px;
        public double? right_shift_px;
    }
}
