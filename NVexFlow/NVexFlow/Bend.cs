//对应 bend.js
using System;
using System.Collections.Generic;
using System.Linq;
using NVexFlow.Model;

namespace NVexFlow
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
        private void Init(string text,bool release,IList<PhraseModel> phrase)
        {
            this.text = text;
            this.xShift = 0;
            this.release = release || false;
            //字体类型不兼容父类
            //this.font="10pt Arial";
            this.font = new Font() {
                family = "Arial",
                size = 10,
                weight = string.Empty
            };
            this.renderOptions = new BendRenderOpts() {
                lineWidth = 1.5,
                lineStyle = "#777777",
                bendWidth = 8,
                releaseWidth = 8
            };
            if(phrase != null)
            {
                this.phrase = phrase;
            }
            else
            {
                // Backward compatibility
                this.phrase = new List<PhraseModel>();
                this.phrase.Add(
                    new PhraseModel() {
                        type = BendType.UP,
                        text = this.text
                    });
                if(this.release)
                {
                    this.phrase.Add(
                        new PhraseModel() {
                            type = BendType.DOWN,
                            text = string.Empty
                        });
                }
            }
            this.UpdateWidth();
        }
        public new Bend SetXShift(int xShift)
        {
            this.xShift = xShift;
            UpdateWidth();
            return this;
        }
        public Bend SetFont(Font font)
        {
            this.font = font;
            return this;
        }
        public override string GetCategory()
        {
            return "bends";
        }
        public string GetText()
        { 
        return text;
        }
        public Bend UpdateWidth()
        {
            double totalWidth = 0;
            for(int i = 0;
            i < this.phrase.Count();
            i++)
            {
                var bend = this.phrase[i];
                if(bend.width.HasValue)
                {
                    totalWidth += bend.width.Value;
                }
                else
                {
                    double additionalWidth = (bend.type == BendType.UP) ?
                      this.renderOptions.bendWidth : this.renderOptions.releaseWidth;
                    bend.width = Math.Max(additionalWidth,MeasureText(bend.text)) + 3;
                    bend.drawWidth = bend.width.Value / 2;
                    bend.drawWidth = bend.width.Value / 2;
                    totalWidth += bend.width.Value;
                }
            }
            this.SetWidth(totalWidth + this.xShift);
            return this;
        }
        private double MeasureText(string text)
        {
            double textWidth;
            if(this.GetContext() != null)
            {
                textWidth = this.context.MeasureText(text).width;
            }
            else
            {
                textWidth = Flow.TextWidth(text);
            }
            return textWidth;
        }

        public override void Draw()
        {
            throw new NotImplementedException();
        }
        #endregion

        #region 隐含的字段
        public string text;
        public BendRenderOpts renderOptions;
        public IList<PhraseModel> phrase;
        public bool release;
        #endregion
    }
}
