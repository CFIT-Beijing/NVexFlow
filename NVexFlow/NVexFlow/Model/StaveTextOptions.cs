using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NVexFlow.Model
{
    public class StaveTextOptions
    {
        double shiftX;

        public double ShiftX
        {
            get { return shiftX; }
            set { shiftX = value; }
        }
        double shiftY;

        public double ShiftY
        {
            get { return shiftY; }
            set { shiftY = value; }
        }
        Vex.Flow.TextNote.TextNoteJustification justification;

        public Vex.Flow.TextNote.TextNoteJustification Justification
        {
            get { return justification; }
            set { justification = value; }
        }
    }
}
