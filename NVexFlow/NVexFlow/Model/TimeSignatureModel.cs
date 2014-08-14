using System.Collections.Generic;
namespace NVexFlow.Model
{
    public class TimeSig
    {
        public bool num;
        public int line;
        public Glyph glyph;
    }
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
        //这里还有闭包。。。暂时卡住了
        public void RenderToStave(double x,TimeSignature that)
        {
            //  glyph.renderToStave = function(x) {
            //    var start_x = x + topStartX;
            //    var i, g;
            //    for (i = 0; i < this.topGlyphs.length; ++i) {
            //      g = this.topGlyphs[i];
            //      Vex.Flow.Glyph.renderOutline(this.context, g.metrics.outline,
            //          g.scale, start_x + g.x_shift, this.stave.getYForLine(that.topLine) + 1);
            //      start_x += g.getMetrics().width;
            //    }

            //    start_x = x + botStartX;
            //    for (i = 0; i < this.botGlyphs.length; ++i) {
            //      g = this.botGlyphs[i];
            //      that.placeGlyphOnLine(g, this.stave, g.line);
            //      Vex.Flow.Glyph.renderOutline(this.context, g.metrics.outline,
            //          g.scale, start_x + g.x_shift, this.stave.getYForLine(that.bottomLine) + 1);
            //      start_x += g.getMetrics().width;
            //    }
            //  };
        }
    }
}
