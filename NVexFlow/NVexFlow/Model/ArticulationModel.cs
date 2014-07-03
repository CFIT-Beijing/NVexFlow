using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NVexFlow.Model
{
    public class ArticulationModel
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
        double shiftRight;

        public double ShiftRight
        {
            get { return shiftRight; }
            set { shiftRight = value; }
        }
        double shiftUp;

        public double ShiftUp
        {
            get { return shiftUp; }
            set { shiftUp = value; }
        }
        double shiftDown;

        public double ShiftDown
        {
            get { return shiftDown; }
            set { shiftDown = value; }
        }
        bool betweenLines;

        public bool BetweenLines
        {
            get { return betweenLines; }
            set { betweenLines = value; }
        }

    }
}
