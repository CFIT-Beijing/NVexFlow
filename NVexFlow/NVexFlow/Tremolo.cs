//对应 tremolo.js
//框架：    已完成
//类型定义：存在改进空间
//原js：    存在改进空间
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
                private void Init(int num)
                {
                    this.num=num;
                    //里程碑2阶段去掉这类重复初始化
                    this.note=null;
                    this.index=null;
                    //JS原文是Modifier.ModifierPosition.CENTER;可是枚举里没有Center选项
                    this.position=Modifier.ModifierPosition.CENTER;
                    this.code="v74";
                    this.shiftRight=-2;
                    this.ySpacing=4;
                    this.renderOptions=new RenderOptions() {
                        fontScale=35,
                        strokePx=3,
                        strokeSpacing=10
                    };
                    this.font=new Font() {
                        family="Arial",
                        size=16,
                        weight=string.Empty
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
                protected int num;
                protected string code;
                protected int shiftRight;
                protected int ySpacing;
                protected RenderOptions renderOptions;
                //搬到modifier中统一定义过了
                //protected Font font;
                #endregion
            }
        }
    }
}
