using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NVexFlow.Model
{
    public class CurveOpts
    {
        public IList<Cps> cps;
    }
    public class Cps
    {
        public double x;
        public double y;
    }
    public class CurveRenderOpts
    {
        //  this.render_options = {
        //    spacing: 2,
        //    thickness: 2,
        //    x_shift: 0,
        //    y_shift: 10,
        //    position: Curve.Position.NEAR_HEAD,
        //    invert: false,
        //    cps: [{x: 0, y: 10}, {x: 0, y: 10}]
        //  };
        public double spacing;
        public double thickness;
        public double x_shift;
        public double y_shift;
        public Curve.CurvePosition position;
        public bool invert;
        public IList<Cps> cps;
    }
}
