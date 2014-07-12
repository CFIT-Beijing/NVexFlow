//对应 bend.js
//框架：    已完成
//类型定义：存在改进空间
//原js：    存在改进空间
using System;
using System.Collections.Generic;
using System.Linq;
using NVexFlow.Model;

namespace NVexFlow
{
    public partial class Vex
    {
        public partial class Flow
        {
            /// <summary>
            ///  This class implements bends.
            /**
               @constructor

               @param text Text for bend ("Full", "Half", etc.) (DEPRECATED)
               @param release If true, render a release. (DEPRECATED)
               @param phrase If set, ignore "text" and "release", and use the more
                             sophisticated phrase specified.

               Example of a phrase:

                 [{
                   type: UP,
                   text: "whole"
                   width: 8;
                 },
                 {
                   type: DOWN,
                   text: "whole"
                   width: 8;
                 },
                 {
                   type: UP,
                   text: "half"
                   width: 8;
                 },
                 {
                   type: UP,
                   text: "whole"
                   width: 8;
                 },
                 {
                   type: DOWN,
                   text: "1 1/2"
                   width: 8;
                 }]
             */
            /// </summary>
            public class Bend:Modifier
            {
                #region js直译部分
                public Bend(string text,bool release,IList<PhraseModel> phrase)
                {
                    Init(text,release,phrase);
                }
                public enum BendType
                {
                    UP = 0,
                    DOWN = 1
                }
                public void Init(string text,bool release,IList<PhraseModel> phrase)
                {
                    this.text=text;
                    this.xShift=0;
                    this.release=release||false;
                    //字体类型不兼容父类
                    //this.font="10pt Arial";
                    this.font=new Font() {
                        family="Arial",
                        size=10,
                        weight=string.Empty
                    };
                    this.renderOptions=new BendRenderOpts() {
                        lineWidth=1.5,
                        lineStyle="#777777",
                        bendWidth=8,
                        releaseWidth=8
                    };
                    if(phrase!=null)
                    {
                        this.phrase=phrase;
                    }
                    else
                    {
                        // Backward compatibility
                        this.phrase=new List<PhraseModel>();
                        this.phrase.Add(
                            new PhraseModel() {
                                type=BendType.UP,
                                text=this.text
                            });
                        if(this.release)
                        {
                            this.phrase.Add(
                                new PhraseModel() {
                                    type=BendType.DOWN,
                                    text=string.Empty
                                });
                        }
                    }
                    this.UpdateWidth();
                }
                public override double XShift
                {
                    set
                    {
                        this.xShift=value;
                        UpdateWidth();
                    }
                }
                public Font Font
                {
                    set
                    {
                        font=value;
                    }
                }
                public override string Category
                {
                    get
                    {
                        return "bends";
                    }
                }
                public string Text
                {
                    get
                    {
                        return text;
                    }
                }
                public Bend UpdateWidth()
                {
                    double totalWidth = 0;
                    for(int i = 0;
                    i<this.phrase.Count();
                    i++)
                    {
                        var bend = this.phrase[i];
                        if(bend.width.HasValue)
                        {
                            totalWidth+=bend.width.Value;
                        }
                        else
                        {
                            double additionalWidth = (bend.type==BendType.UP) ?
                              this.renderOptions.bendWidth : this.renderOptions.releaseWidth;
                            bend.width=Math.Max(additionalWidth,MeasureText(bend.text))+3;
                            bend.drawWidth=bend.width.Value/2;
                            bend.drawWidth=bend.width.Value/2;
                            totalWidth+=bend.width.Value;
                        }
                    }
                    this.Width=totalWidth+this.xShift;
                    return this;
                }
                private double MeasureText(string text)
                {
                    double textWidth;
                    if(this.Context!=null)
                    {
                        textWidth=this.context.MeasureText(text).width;
                    }
                    else
                    {
                        textWidth=Vex.Flow.TextWidth(text);
                    }
                    return textWidth;
                }

                public override void Draw()
                {
                    throw new NotImplementedException();
                }
                #endregion

                #region 隐含的字段
                protected string text;
                protected BendRenderOpts renderOptions;
                protected IList<PhraseModel> phrase;
                protected bool release;
                #endregion
            }
        }
    }
}
