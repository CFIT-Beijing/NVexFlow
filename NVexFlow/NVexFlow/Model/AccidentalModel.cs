using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NVexFlow.Model
{
    public class AccidentalModel
    {
        string code;

        public string Code
        {
            get { return code; }
            set { code = value; }
        }

        double width;

        public double Width
        {
            get { return width; }
            set { width = value; }
        }
        double gracenoteWidth;

        public double GracenoteWidth
        {
            get { return gracenoteWidth; }
            set { gracenoteWidth = value; }
        }
        double shiftRight;

        public double ShiftRight
        {
            get { return shiftRight; }
            set { shiftRight = value; }
        }
        double shiftDown;

        public double ShiftDown
        {
            get { return shiftDown; }
            set { shiftDown = value; }
        }
    }
}
