using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NVexFlow.Model
{
    public class CrescendoStruct : NoteStruct
    {
        public int? line;
    }
    public class RenderHairpinParams
    {
        public double beginX;
        public double endX;
        public double y;
        public double height;
        public bool reverse;
    }

    public class CrescendoRenderOpts : NoteRenderOpts
    { 
        public double extendLeft;
        public double extendRight;
        public double yShift;
        public static void Merge(NoteRenderOpts renderOptions, CrescendoRenderOpts crescendoRenderOpts)
        {
            CrescendoRenderOpts result =(CrescendoRenderOpts) renderOptions;
            //下面只做差额复制
            result.extendLeft = crescendoRenderOpts.extendLeft;
            result.extendRight = crescendoRenderOpts.extendRight;
            result.yShift = crescendoRenderOpts.yShift;
        }
    }
}
