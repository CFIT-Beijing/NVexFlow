using System.Collections.Generic;
namespace NVexFlow.Model
{
    public class BeamRenderOpts:RenderOptions
    {
        public double beamWidth;
        public double maxSlope;
        public double minSlope;
        public double slopeIterations;
        public double slopeCost;
        public bool showStemlets;
        public double stemletExtension;
        public double partialBeamLength;
    }
    public class BeamLine
    { 
    //var new_line = {start: stem_x, end: null};
        public double? start;
        public double? end;
    }
    public class DeterminePartialSideRes
    {
        //      var left_partial = duration !== "8" && unshared_beams > 0;
        //      var right_partial = duration !== "8" && unshared_beams < 0;

        //      return {
        //        left: left_partial,
        //        right: right_partial
        //      };
        public bool left;
        public bool right;
    }
    public class Config
    {
        // config = {
        //   groups: [new Vex.Flow.Fraction(2, 8)],
        //   stem_direction: -1,
        //   beam_rests: true,
        //   beam_middle_only: true,
        //   show_stemlets: false
        // };
        public IList<object> groups;
        public int stem_direction;
    }
}
