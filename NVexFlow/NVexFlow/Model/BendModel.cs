using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NVexFlow.Model
{
    public class PhraseModel
    {
        public NVexFlow.Vex.Flow.Bend.BendType type;
        public string text;
        public double? width;
        public double drawWidth;
    }

    public class BendRenderOpts : RenderOptions
    {
        public double LineWidth
        {
            get;
            set;
        }
        public string LineStyle
        {
            get;
            set;
        }
        public double BendWidth
        {
            get;
            set;
        }
        public double ReleaseWidth
        {
            get;
            set;
        }
    }
}
