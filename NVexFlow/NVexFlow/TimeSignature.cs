//timesignature.js
using System;
using System.Collections.Generic;
using NVexFlow.Model;
using System.Linq;
using System.Text.RegularExpressions;
namespace NVexFlow
{
    /// <summary>
    /// Vex Flow Notation
    // Implements time signatures glyphs for staffs
    // See tables.js for the internal time signatures
    // representation
    //
    /// </summary>
    public class TimeSignature:StaveModifier
    {
        #region js直译部分
        /// <summary>
        ///  * @param {string} timeSpec time signature, i.e. "4/4"
        ///* @param {number} [customPadding] custom padding when using multi-stave/multi-instrument setting
        ///* to align key/time signature (in pixels), optional
        ///* @constructor
        /// </summary>
        /// <param name="timeSpec"></param>
        /// <param name="customPadding"></param>
        public TimeSignature(string timeSpec,double? customPadding)
        {
            Init(timeSpec,customPadding);
        }
        public static IDictionary<string,GlyphsModel> glyphs = new Dictionary<string,GlyphsModel>() {
                 {"C",new GlyphsModel(){code="v41",point=40,line=2}},
                 {"C|",new GlyphsModel(){code="vb6",point=40,line=2}}
                };
        private void Init(string timeSpec,double? customPadding)
        {
            double padding = customPadding ?? 15;
            this.SetPadding(padding);
            this.point = 40;
            this.topLine = 2;
            this.bottomLine = 4;
            this.timeSig = this.ParseTimeSpec(timeSpec);
        }
        public TimeSig ParseTimeSpec(string timeSpec)
        {
            if(timeSpec == "C" || timeSpec == "C|")
            {
                GlyphsModel glyphInfo = TimeSignature.glyphs[timeSpec];
                return new TimeSig() { num = false,line = glyphInfo.line,glyph = new Glyph(glyphInfo.code,glyphInfo.point) };
            }
            IList<char> topNums = new List<char>();
            int i;
            char c;
            for(i = 0;
            i < timeSpec.Length;
            i++)
            {
                c = timeSpec.ToCharArray()[i];
                if(c == '/')
                {
                    break;
                }
                else if(Regex.IsMatch(c.ToString(),"[0-9]"))
                {
                    topNums.Add(c);
                }
                else
                {
                    throw new Exception("BadTimeSignature,Invalid time spec: " + timeSpec);
                }
            }
            if(i == 0)
            {
                throw new Exception("BadTimeSignature,Invalid time spec: " + timeSpec);
            }


            //skip the "/"
            ++i;
            if(i == timeSpec.Length)
            {
                throw new Exception("BadTimeSignature,Invalid time spec: " + timeSpec);
            }
            IList<char> botNums = new List<char>();
            for(;
            i < timeSpec.Length;
            i++)
            {
                c = timeSpec.ToCharArray()[i];
                if(Regex.IsMatch(c.ToString(),"[0-9]"))
                {
                    botNums.Add(c);
                }
                else
                {
                    throw new Exception("BadTimeSignature,Invalid time spec: " + timeSpec);
                }
            }

            return new TimeSig() { num = true,glyph = this.MakeTimeSignatureGlyph(topNums,botNums) };
        }
        //这个方法写的时候脑子有点儿乱，可以仔细查一下。有关他对glyph对象方法的重新赋值在方法内部忽略了，直接写在了TimeSignatureModel里。即：方法内部的glyph对象已经是子类对象。
        public Glyph4TimeSignature MakeTimeSignatureGlyph(IList<char> topNums,IList<char> botNums)
        {
            Glyph4TimeSignature glyph = new Glyph4TimeSignature("v0",this.point);
            glyph.topGlyphs = new List<Glyph>();
            glyph.botGlyphs = new List<Glyph>();
            double topWidth = 0;
            int i;
            char num;
            for(i = 0;
            i < topNums.Count();
            ++i)
            {
                num = topNums[i];
                Glyph topGlyph = new Glyph("v" + num,this.point);

                glyph.topGlyphs.Add(topGlyph);
                topWidth += topGlyph.GetMetrics().width;
            }

            double botWidth = 0;
            for(i = 0;
            i < botNums.Count();
            ++i)
            {
                num = botNums[i];
                Glyph botGlyph = new Glyph("v" + num,this.point);

                glyph.botGlyphs.Add(botGlyph);
                botWidth += botGlyph.GetMetrics().width;
            }

            double width = (topWidth > botWidth ? topWidth : botWidth);
            double xMin = (glyph as Glyph).GetMetrics().xMin;

            double topStartX = (width - topWidth) / 2.0;
            double botStartX = (width - botWidth) / 2.0;


            return glyph;
        }
        public TimeSig GetTimeSig()
        {
            return this.timeSig;
        }
        public override void AddModifier(Stave stave)
        {
            if(!this.timeSig.num)
            {
                this.PlaceGlyphOnLine(this.timeSig.glyph,stave,this.timeSig.line);
            }
            stave.AddGlyph(this.timeSig.glyph);
        }
        public override void AddEndModifier(Stave stave)
        {
            if(!this.timeSig.num)
            {
                this.PlaceGlyphOnLine(this.timeSig.glyph,stave,this.timeSig.line);
            }
            stave.AddEndGlyph(this.timeSig.glyph);
        }
        #endregion


        #region 隐含字段
        public double point;
        public double topLine;
        public double bottomLine;
        public TimeSig timeSig;
        #endregion



    }
}
