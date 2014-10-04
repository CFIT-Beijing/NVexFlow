using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NVexFlow.Model
{
    public class MakeSpacerRes:Glyph
    {
        //返回一个Glyph对象，但是重写了Glyph的这几个方法。
        //一种办法是：直接将这些方法翻译成C#写死在这个类里。
        //另一种方法是：把这些方法定义成这个类的委托字段，将来可以比较灵活的赋值。
        //暂时采用了委托字段的方式。
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
