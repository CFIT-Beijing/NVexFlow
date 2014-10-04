using System;
using System.Collections.Generic;
namespace NVexFlow.Model
{
    public class BeamRenderOpts:RenderOptions
    {
        public double beam_width;
        public double max_slope;
        public double min_slope;
        public double slope_iterations;
        public double slope_cost;
        public bool show_stemlets;
        public double stemlet_extension;
        public double partial_beamLength;
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
        public IList<Fraction> groups;
        public int stem_direction;
    }
}
