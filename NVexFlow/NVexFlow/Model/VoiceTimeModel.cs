using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NVexFlow.Model
{
    public class VoiceTimeModel
    {
      //  this.voice = new Vex.Flow.Voice({
      //  num_beats: 4,
      //  beat_value: 4,
      //  resolution: Vex.Flow.RESOLUTION
      //})
        double numBeats;

        public double NumBeats
        {
            get { return numBeats; }
            set { numBeats = value; }
        }
        double numValue;

        public double NumValue
        {
            get { return numValue; }
            set { numValue = value; }
        }
        int resolution;

        public int Resolution
        {
            get { return resolution; }
            set { resolution = value; }
        }

    }
}
