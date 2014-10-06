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
            this.x_shift = 0;
            this.release = release || false;
            //字体类型不兼容父类
            //this.font="10pt Arial";
            this.font = new Font() {
                family = "Arial",
                size = 10,
                weight = string.Empty
            };
            this.render_options = new BendRenderOpts() {
                line_width = 1.5,
                line_style = "#777777",
                bend_width = 8,
                release_width = 8
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
        public new Bend SetXShift(int x_shift)
        {
            this.x_shift = x_shift;
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
            double total_width = 0;
            for(int i = 0;
            i < this.phrase.Count();
            i++)
            {
                var bend = this.phrase[i];
                if(bend.width.HasValue)
                {
                    total_width += bend.width.Value;
                }
                else
                {
                    double additional_width = (bend.type == BendType.UP) ?
                      this.render_options.bend_width : this.render_options.release_width;
                    bend.width = Math.Max(additional_width,MeasureText(bend.text)) + 3;
                    bend.draw_width = bend.width.Value / 2;
                    bend.draw_width = bend.width.Value / 2;
                    total_width += bend.width.Value;
                }
            }
            this.SetWidth(total_width + this.x_shift);
            return this;
        }
        private double MeasureText(string text)
        {
            double text_width;
            if(this.GetContext() != null)
            {
                text_width = this.context.MeasureText(text).width;
            }
            else
            {
                text_width = Flow.TextWidth(text);
            }
            return text_width;
        }

        public override void Draw()
        {
            throw new NotImplementedException();
        }
        #endregion

        #region 隐含的字段
        public string text;
        public BendRenderOpts render_options;
        public IList<PhraseModel> phrase;
        public bool release;
        #endregion
    }
}
