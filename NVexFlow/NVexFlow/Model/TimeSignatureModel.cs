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
    //他对这个glyph对象进行了改造，不再遵守Glyph的方法。这里暂时采用子类继承改写父类的方式。
    public class Glyph4TimeSignature : Glyph
    {
        public Glyph4TimeSignature(string code, double point):base(code,point)
        { }
        public IList<Glyph> topGlyphs;
        public IList<Glyph> botGlyphs;
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
            return new Metrics() { xMin=xMin,xMax=xMin+width,width=width};
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
            for ( i = 0; i < this.topGlyphs.Count(); ++i)
            {
                g = this.topGlyphs[i];
                Glyph.RenderOutline(this.Context, g.metrics.outline, g.scale, startX + g.xShift, this.stave.GetYForLine(that.topLine) + 1);
                startX += g.GetMetrics().width;
            }
            startX = x + botStartX; for (i = 0; i < this.botGlyphs.Count(); ++i)
            {
                g = this.botGlyphs[i];
                //      that.placeGlyphOnLine(g, this.stave, g.line); 这句不会写，怀疑他写错了。。。可能是that.line吧？
                Glyph.RenderOutline(this.Context,g.metrics.outline,g.scale,startX+g.xShift,this.stave.GetYForLine(that.bottomLine)+1);
                startX += g.GetMetrics().width;
            }
        }
    }
}
