using System.Linq;
using System.Collections.Generic;
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
            public class Bend : Modifier
            {

                #region 枚举
                public enum BendType
                {
                    UP, DOWN
                }
                #endregion


                #region 属性字段

                public override double XShift
                {
                    set
                    {
                        this.xShift = value;
                        UpdateWidth();
                    }
                }
                private double xShift;

                bool release;


                public string Font
                {
                    set { font = value; }
                }
                string font;

                RenderOptions renderOptions;

                IList<PhraseModel> phrase;



                public string Text
                {
                    get { return text; }
                }
                private string text;
                #endregion


                #region 方法
                public Bend(string text, bool release, IList<PhraseModel> phrase)
                {
                    Init(text, release, phrase);
                }

                public void Init(string text, bool release, IList<PhraseModel> phrase)
                {
                    this.text = text;
                    this.xShift = 0;
                    this.release = release || false;
                    this.font = "10pt Arial";
                    this.renderOptions = new RenderOptions() { LineWidth = 1.5, LineStyle = "#777777", BendWidth = 8, ReleaseWidth = 8 };
                    if (phrase != null)
                    {
                        this.phrase = phrase;
                    }
                    else
                    {
                        // Backward compatibility
                        this.phrase = new List<PhraseModel>() {
                         new PhraseModel(){Type=BendType.UP,Text=this.text}
                     };
                        if (this.release)
                        {
                            this.phrase.Add(
                                new PhraseModel() { Type = BendType.DOWN, Text = string.Empty }
                                );
                        }
                    }

                    this.UpdateWidth();
                }

                public Bend UpdateWidth()
                {
                    double totalWidth = 0;
                    for (int i = 0; i < this.phrase.Count(); i++)
                    {
                        PhraseModel bend = this.phrase[i];
                        if (bend.Width.HasValue)
                        {
                            totalWidth += bend.Width.Value;
                        }
                        else
                        {
                            double additionalWidth = (bend.Type == BendType.UP) ?
                              this.renderOptions.BendWidth : this.renderOptions.ReleaseWidth;
                            bend.Width = Vex.Max(additionalWidth, MeasureText(bend.Text)) + 3;
                            bend.DrawWidth = bend.Width.Value/ 2;
                            totalWidth += bend.Width.Value;
                        }
                    }
                    this.Width = totalWidth + this.xShift;
                    return this;
                }

                private double MeasureText(string text)
                {
                    double textWidth;
                    if (this.Context != null)
                    {
                        //textWidth= that.context.measureText(text).width;
                        //此处还不知道context.measureText(text)返回什么，除了width属性还有什么等等，暂且赋值为零。
                        textWidth = 0;
                    }
                    else
                    {
                        textWidth = Vex.Flow.TextWidth(text);
                    }

                    return textWidth; ;
                }


                public override void Draw()
                { }
                #endregion
            }
        }
    }
}
