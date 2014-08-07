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
        public new void Init()
        {
            this.harsh = false;
            this.position = ModifierPosition.RIGHT;
            this.renderOptions = new RenderOptions() {
                vibratoWidth = 20,
                waveHeight = 6,
                waveWidth = 4,
                waveGirth = 2
            };
            this.VibratoWidth = this.renderOptions.vibratoWidth;
        }
        public override string Category
        {
            get
            {
                return "vibratos";
            }
        }
        public bool Harsh
        {
            set
            {
                harsh = value;
            }
        }
        public double VibratoWidth
        {
            set
            {
                this.vibratoWidth = value;
                this.Width = this.vibratoWidth;
            }
        }
        public override void Draw()
        {
            throw new NotImplementedException();
        }
        #endregion
        #region 隐含的字段
        protected RenderOptions renderOptions;
        protected bool harsh;
        protected double vibratoWidth;
        #endregion
    }
}
