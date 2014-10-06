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
        /// <param name="time_spec"></param>
        /// <param name="custom_padding"></param>
        public TimeSignature(string time_spec,double? custom_padding)
        {
            Init(time_spec,custom_padding);
        }
        public static IDictionary<string,GlyphsModel> glyphs = new Dictionary<string,GlyphsModel>() {
                 {"C",new GlyphsModel(){code="v41",point=40,line=2}},
                 {"C|",new GlyphsModel(){code="vb6",point=40,line=2}}
                };
        private void Init(string time_spec,double? custom_padding)
        {
            double padding = custom_padding ?? 15;
            this.SetPadding(padding);
            this.point = 40;
            this.top_line = 2;
            this.bottom_line = 4;
            this.time_sig = this.ParseTimeSpec(time_spec);
        }
        public TimeSig ParseTimeSpec(string time_spec)
        {
            if(time_spec == "C" || time_spec == "C|")
            {
                GlyphsModel glyph_info = TimeSignature.glyphs[time_spec];
                return new TimeSig() { num = false,line = glyph_info.line,glyph = new Glyph(glyph_info.code,glyph_info.point) };
            }
            IList<char> top_nums = new List<char>();
            int i;
            char c;
            for(i = 0;
            i < time_spec.Length;
            i++)
            {
                c = time_spec.ToCharArray()[i];
                if(c == '/')
                {
                    break;
                }
                else if(Regex.IsMatch(c.ToString(),"[0-9]"))
                {
                    top_nums.Add(c);
                }
                else
                {
                    throw new Exception("BadTimeSignature,Invalid time spec: " + time_spec);
                }
            }
            if(i == 0)
            {
                throw new Exception("BadTimeSignature,Invalid time spec: " + time_spec);
            }


            //skip the "/"
            ++i;
            if(i == time_spec.Length)
            {
                throw new Exception("BadTimeSignature,Invalid time spec: " + time_spec);
            }
            IList<char> bot_nums = new List<char>();
            for(;
            i < time_spec.Length;
            i++)
            {
                c = time_spec.ToCharArray()[i];
                if(Regex.IsMatch(c.ToString(),"[0-9]"))
                {
                    bot_nums.Add(c);
                }
                else
                {
                    throw new Exception("BadTimeSignature,Invalid time spec: " + time_spec);
                }
            }

            return new TimeSig() { num = true,glyph = this.MakeTimeSignatureGlyph(top_nums,bot_nums) };
        }
        //这个方法写的时候脑子有点儿乱，可以仔细查一下。有关他对glyph对象方法的重新赋值在方法内部忽略了，直接写在了TimeSignatureModel里。即：方法内部的glyph对象已经是子类对象。
        public Glyph4TimeSignature MakeTimeSignatureGlyph(IList<char> top_nums,IList<char> bot_nums)
        {
            Glyph4TimeSignature glyph = new Glyph4TimeSignature("v0",this.point);
            glyph.top_glyphs = new List<Glyph>();
            glyph.bot_glyphs = new List<Glyph>();
            double top_width = 0;
            int i;
            char num;
            for(i = 0;
            i < top_nums.Count();
            ++i)
            {
                num = top_nums[i];
                Glyph top_glyph = new Glyph("v" + num,this.point);

                glyph.top_glyphs.Add(top_glyph);
                top_width += top_glyph.GetMetrics().width;
            }

            double bot_width = 0;
            for(i = 0;
            i < bot_nums.Count();
            ++i)
            {
                num = bot_nums[i];
                Glyph bot_glyph = new Glyph("v" + num,this.point);

                glyph.bot_glyphs.Add(bot_glyph);
                bot_width += bot_glyph.GetMetrics().width;
            }

            double width = (top_width > bot_width ? top_width : bot_width);
            double x_min = (glyph as Glyph).GetMetrics().x_min;

            double top_start_x = (width - top_width) / 2.0;
            double bot_start_x = (width - bot_width) / 2.0;


            return glyph;
        }
        public TimeSig GetTimeSig()
        {
            return this.time_sig;
        }
        public override void AddModifier(Stave stave)
        {
            if(!this.time_sig.num)
            {
                this.PlaceGlyphOnLine(this.time_sig.glyph,stave,this.time_sig.line);
            }
            stave.AddGlyph(this.time_sig.glyph);
        }
        public override void AddEndModifier(Stave stave)
        {
            if(!this.time_sig.num)
            {
                this.PlaceGlyphOnLine(this.time_sig.glyph,stave,this.time_sig.line);
            }
            stave.AddEndGlyph(this.time_sig.glyph);
        }
        #endregion


        #region 隐含字段
        public double point;
        public double top_line;
        public double bottom_line;
        public TimeSig time_sig;
        #endregion



    }
}
