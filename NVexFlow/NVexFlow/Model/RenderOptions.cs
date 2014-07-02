using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NVexFlow.Model
{
    public class RenderOptions
    {
        int fontScale;

        public int FontScale
        {
            get { return fontScale; }
            set { fontScale = value; }
        }

        int strokePx;

        public int StrokePx
        {
            get { return strokePx; }
            set { strokePx = value; }
        }
    }
}
