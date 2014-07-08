using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NVexFlow.Model
{
    public class BeamRenderOptions
    {
        double beamWidth;

        public double BeamWidth
        {
            get { return beamWidth; }
            set { beamWidth = value; }
        }
        double maxSlope;

        public double MaxSlope
        {
            get { return maxSlope; }
            set { maxSlope = value; }
        }
        double minSlope;

        public double MinSlope
        {
            get { return minSlope; }
            set { minSlope = value; }
        }
        double slopeIterations;

        public double SlopeIterations
        {
            get { return slopeIterations; }
            set { slopeIterations = value; }
        }
        double slopeCost;

        public double SlopeCost
        {
            get { return slopeCost; }
            set { slopeCost = value; }
        }
        bool showStemlets;

        public bool ShowStemlets
        {
            get { return showStemlets; }
            set { showStemlets = value; }
        }
        double stemletExtension;

        public double StemletExtension
        {
            get { return stemletExtension; }
            set { stemletExtension = value; }
        }
        double partialBeamLength;

        public double PartialBeamLength
        {
            get { return partialBeamLength; }
            set { partialBeamLength = value; }
        }
    }
}
