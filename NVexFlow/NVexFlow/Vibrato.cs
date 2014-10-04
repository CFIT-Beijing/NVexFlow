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
            this.render_options = new RenderOptions() {
                vibrato_width = 20,
                wave_height = 6,
                wave_width = 4,
                wave_girth = 2
            };
            this.SetVibratoWidth(this.render_options.vibrato_width);
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
            this.vibrato_width = width;
            this.SetWidth(this.vibrato_width);
            return this;
        }
        public override void Draw()
        {
            throw new NotImplementedException();
        }
        #endregion
        #region 隐含的字段
        public RenderOptions render_options;
        public bool harsh;
        public double vibrato_width;
        #endregion
    }
}
