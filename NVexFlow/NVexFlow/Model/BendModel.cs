namespace NVexFlow.Model
{
    public class PhraseModel
    {
        public Bend.BendType type;
        public string text;
        public double? width;
        public double drawWidth;
    }
    public class BendRenderOpts:RenderOptions
    {
        public double lineWidth;
        public string lineStyle;
        public double bendWidth;
        public double releaseWidth;
    }
}
