namespace NVexFlow.Model
{
    public class PhraseModel
    {
        public Bend.BendType type;
        public string text;
        public double? width;
        public double draw_width;
    }
    public class BendRenderOpts:RenderOptions
    {
        public double line_width;
        public string line_style;
        public double bend_width;
        public double release_width;
    }
}
