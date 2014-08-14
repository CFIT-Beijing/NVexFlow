using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NVexFlow.Model
{
    public class MakeSpacerRes:Glyph
    {
        //返回一个Glyph对象，但是重写了Glyph的这几个方法。这样翻译不合适（小写代表重写后的方法，但是大写的Glyph本身的方法依然可以调用。或者把Glyph中的这几个方法改成委托类型变量？暂时没想到更好的办法），以后再说。
        //      return {
        //  getContext: function() {return true;},
        //  setStave: function() {},
        //  renderToStave: function() {},
        //  getMetrics: function() {
        //    return {width: padding};
        //  }
        //};
        public MakeSpacerRes():base(null,0,null)
        { }
        public Func<bool> getContext;
        public Action setStave;
        public Action renderToStave;
        public Func<GetMetrics> getMetrics;
    }

    public class GetMetrics
    {
        public double width;
    }
}
