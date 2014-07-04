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

        double lineWidth;

        public double LineWidth
        {
            get { return lineWidth; }
            set { lineWidth = value; }
        }
        string lineStyle;

        public string LineStyle
        {
            get { return lineStyle; }
            set { lineStyle = value; }
        }
        double bendWidth;

        public double BendWidth
        {
            get { return bendWidth; }
            set { bendWidth = value; }
        }
        double releaseWidth;

        public double ReleaseWidth
        {
            get { return releaseWidth; }
            set { releaseWidth = value; }
        }

        double vibratoWidth;

        public double VibratoWidth
        {
            get { return vibratoWidth; }
            set { vibratoWidth = value; }
        }
        double waveHeight;

        public double WaveHeight
        {
            get { return waveHeight; }
            set { waveHeight = value; }
        }
        double waveWidth;

        public double WaveWidth
        {
            get { return waveWidth; }
            set { waveWidth = value; }
        }
        double waveGirth;

        public double WaveGirth
        {
            get { return waveGirth; }
            set { waveGirth = value; }
        }

        double strokeSpacing;

        public double StrokeSpacing
        {
            get { return strokeSpacing; }
            set { strokeSpacing = value; }
        }

    }
}
