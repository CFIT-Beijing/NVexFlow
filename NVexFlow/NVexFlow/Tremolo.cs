//对应 tremolo.js
using System;
using NVexFlow.Model;
namespace NVexFlow
{
    /// <summary>
    /// 原js文件作者: Mike Corrigan <corrigan@gmail.com>
    /// 更多关于Tremolo在音乐中的信息
    /// http://en.wikipedia.org/wiki/Tremolo
    /// </summary>
    public class Tremolo:Modifier
    {
        #region js直译部分
        public Tremolo(int num)
        {
            Init(num);
        }
        private void Init(int num)
        {
            this.num = num;
            //里程碑2阶段去掉这类重复初始化
            this.note = null;
            this.index = null;
            //JS原文是Modifier.ModifierPosition.CENTER;可是枚举里没有Center选项
            this.position = Modifier.ModifierPosition.CENTER;
            this.code = "v74";
            this.shift_right = -2;
            this.y_spacing = 4;
            this.render_options = new RenderOptions() {
                font_scale = 35,
                stroke_px = 3,
                stroke_spacing = 10
            };
            this.font = new Font() {
                family = "Arial",
                size = 16,
                weight = string.Empty
            };
        }
        public override string GetCategory()
        {
            return "tremolo";
        }
        public override void Draw()
        {
            throw new NotImplementedException();
        }
        #endregion
        #region 隐含的字段
        public int num;
        public string code;
        public int shift_right;
        public int y_spacing;
        public RenderOptions render_options;
        #endregion
    }
}
