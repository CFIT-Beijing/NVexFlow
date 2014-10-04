using System.Collections.Generic;
using System.Linq;
namespace NVexFlow.Model
{
    public class TimeSig
    {
        public bool num;
        public int line;
        public Glyph glyph;
    }
    //返回一个Glyph对象，但是重写了Glyph的这几个方法。
    //一种办法是：直接将这些方法翻译成C#写死在这个类里。
    //另一种方法是：把这些方法定义成这个类的委托字段，将来可以比较灵活的赋值。
    //暂时采用了写死的方式。
    public class Glyph4TimeSignature : Glyph
    {
        public Glyph4TimeSignature(string code, double point):base(code,point)
        { }
        public IList<Glyph> top_glyphs;
        public IList<Glyph> bot_glyphs;
        public NVexFlow.Metrics GetMetrics(double xMin,double xMax,double width)
        {
            //你看是这样写死的好，还是把Glyph的GetMetrics写成委托好
            //  glyph.getMetrics = function() {
            //    return {
            //      x_min: xMin,
            //      x_max: xMin + width,
            //      width: width
            //    };
            //  };
            return new Metrics() { x_min=xMin,x_max=xMin+width,width=width};
        }

        //*****************下面这个你看看怎么改吧************************
        //  var topStartX = (width - topWidth) / 2.0;
        //var botStartX = (width - botWidth) / 2.0;

        //var that = this;
        //glyph.renderToStave = function(x) {
        //  var start_x = x + topStartX;
        //  var i, g;
        //  for (i = 0; i < this.topGlyphs.length; ++i) {
        //    g = this.topGlyphs[i];
        //    Vex.Flow.Glyph.renderOutline(this.context, g.metrics.outline,
        //        g.scale, start_x + g.x_shift, this.stave.getYForLine(that.topLine) + 1);
        //    start_x += g.getMetrics().width;
        //  }

        //  start_x = x + botStartX;
        //  for (i = 0; i < this.botGlyphs.length; ++i) {
        //    g = this.botGlyphs[i];
        //    that.placeGlyphOnLine(g, this.stave, g.line);
        //    Vex.Flow.Glyph.renderOutline(this.context, g.metrics.outline,
        //        g.scale, start_x + g.x_shift, this.stave.getYForLine(that.bottomLine) + 1);
        //    start_x += g.getMetrics().width;
        //  }
        //};
        public void RenderToStave(double x, TimeSignature that, double topStartX, double botStartX)
        {
            double startX = x + topStartX;
            int i;
            Glyph g;
            for ( i = 0; i < this.top_glyphs.Count(); ++i)
            {
                g = this.top_glyphs[i];
                Glyph.RenderOutline(this.Context, g.metrics.outline, g.scale, startX + g.xShift, this.stave.GetYForLine(that.top_line) + 1);
                startX += g.GetMetrics().width;
            }
            startX = x + botStartX; for (i = 0; i < this.bot_glyphs.Count(); ++i)
            {
                g = this.bot_glyphs[i];
                //      that.placeGlyphOnLine(g, this.stave, g.line); 这句不会写，怀疑他写错了。。。可能是that.line吧？
                Glyph.RenderOutline(this.Context,g.metrics.outline,g.scale,startX+g.xShift,this.stave.GetYForLine(that.bottom_line)+1);
                startX += g.GetMetrics().width;
            }
        }
    }
}
