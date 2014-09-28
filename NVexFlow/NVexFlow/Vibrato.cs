//对应 vibrato.js
using System;
using NVexFlow.Model;
namespace NVexFlow
{
    /// <summary>
    /// This class implements vibratos.
    /// </summary>
    public class Vibrato:Modifier
    {
        #region js直译部分
        public Vibrato()
        {
            Init();
        }
        private void Init()
        {
            this.harsh = false;
            this.position = ModifierPosition.RIGHT;
            this.renderOptions = new RenderOptions() {
                vibratoWidth = 20,
                waveHeight = 6,
                waveWidth = 4,
                waveGirth = 2
            };
            this.SetVibratoWidth(this.renderOptions.vibratoWidth);
        }
        public override string GetCategory()
        {
            return "vibratos";
        }
        public Vibrato SetHarsh(bool harsh)
        {
            this.harsh = harsh;
            return this;
        }
        public Vibrato SetVibratoWidth(double width)
        {
            this.vibratoWidth = width;
            this.SetWidth(this.vibratoWidth);
            return this;
        }
        public override void Draw()
        {
            throw new NotImplementedException();
        }
        #endregion
        #region 隐含的字段
        public RenderOptions renderOptions;
        public bool harsh;
        public double vibratoWidth;
        #endregion
    }
}
