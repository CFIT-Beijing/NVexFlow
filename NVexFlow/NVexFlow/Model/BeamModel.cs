namespace NVexFlow.Model
{
    public class BeamRenderOpts:RenderOptions
    {
        public double BeamWidth;
        public double MaxSlope;
        public double MinSlope;
        public double SlopeIterations;
        public double SlopeCost;
        public bool ShowStemlets;
        public double StemletExtension;
        public double PartialBeamLength;
    }
}
