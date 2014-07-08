using System;
using NVexFlow.Model;

namespace NVexFlow
{
    public partial class Vex
    {
        public partial class Flow
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
                public void Init(int num)
                {
                    base.Init();
                    this.num=num;
                    this.note=null;
                    this.index=null;
                    //JS原文是Modifier.ModifierPosition.CENTER;可是枚举里没有Center选项
                    this.position=Modifier.ModifierPosition.CENTER;
                    this.code="v74";
                    this.shiftRight=-2;
                    this.ySpacing=4;
                    this.renderOptions=new RenderOptions() {
                        FontScale=35,
                        StrokePx=3,
                        StrokeSpacing=10
                    };
                    this.font=new Font() {
                        Family="Arial",
                        Size=16,
                        Weight=string.Empty
                    };
                }
                public override string Category
                {
                    get
                    {
                        return "tremolo";
                    }
                }
                public override void Draw()
                {
                    throw new NotImplementedException();
                }
                #endregion
                #region 隐含的字段
                int num;
                Note note;
                object index;
                ModifierPosition position;
                string code;
                int shiftRight;
                int ySpacing;
                RenderOptions renderOptions;
                Font font;
                #endregion
            }
        }
    }
}
