﻿//对应 textNote.js
using System;
using System.Collections.Generic;
using NVexFlow.Model;

namespace NVexFlow
{
    /// <summary>
    /// ## Description
    //
    // `TextNote` is a notation element that is positioned in time. Generally 
    // meant for objects that sit above/below the staff and inline with each other.
    // Examples of this would be such as dynamics, lyrics, chord changes, etc.
    /// </summary>
    public class TextNote:Note
    {
        #region js直译部分
        public enum TextNoteJustification
        {
            LEFT = 1,
            CENTER = 2,
            RIGHT = 3
        }
        public static IDictionary<string,Glyph4TextNote> GLYPHS = new Dictionary<string,Glyph4TextNote>()
                {
                    {"segno",new Glyph4TextNote(){code="v8c",point=40,x_shift=0,y_shift=-10}},
                    {"tr",new Glyph4TextNote(){code="v1f",point=40,x_shift=0,y_shift=0}},
                    { "mordent_upper",new Glyph4TextNote(){code="v1e",point=40,x_shift=0,y_shift=0}},
                    {"mordent_lower",new Glyph4TextNote(){code="v45",point=40,x_shift=0,y_shift=0}},
                    { "f",new Glyph4TextNote(){code="vba",point=40,x_shift=0,y_shift=0}},
                    { "p",new Glyph4TextNote(){code="vbf",point=40,x_shift=0,y_shift=0}},
                    {"m",new Glyph4TextNote(){code="v62",point=40,x_shift=0,y_shift=0}},
                    { "s",new Glyph4TextNote(){code="v4a",point=40,x_shift=0,y_shift=0}},
                    { "z",new Glyph4TextNote(){code="v80",point=40,x_shift=0,y_shift=0}},
                    { "coda",new Glyph4TextNote(){code="v4d",point=40,x_shift=0,y_shift=-8}},
                    { "pedal_open",new Glyph4TextNote(){code="v36",point=40,x_shift=0,y_shift=0}},
                    { "pedal_close",new Glyph4TextNote(){code="v5d",point=40,x_shift=0,y_shift=3}},
                    { "caesura_straight",new Glyph4TextNote(){code="v34",point=40,x_shift=0,y_shift=2}},
                    { "caesura_curved",new Glyph4TextNote(){code="v4b",point=40,x_shift=0,y_shift=2}},
                    { "breath",new Glyph4TextNote(){code="v6c",point=40,x_shift=0,y_shift=0}},
                    {"tick",new Glyph4TextNote(){code="v6f",point=50,x_shift=0,y_shift=0}},
                    {"turn",new Glyph4TextNote(){code="v72",point=40,x_shift=0,y_shift=0}},
                    {"turn_inverted",new Glyph4TextNote(){code="v33",point=40,x_shift=0,y_shift=0}},
            // DEPRECATED - please use "mordent_upper" or "mordent_lower"
            {"mordent",new Glyph4TextNote(){code="v1e",point=40,x_shift=0,y_shift=0}}
                };
        public TextNote(TextStruct text_struct)
            : base(text_struct)
        {
            Init(text_struct);
        }
        private void Init(TextStruct text_struct)
        {
            // Note properties

            this.text = text_struct.text;
            this.superscript = text_struct.superscript;
            this.subscript = text_struct.subscript;
            this.glyph_type = text_struct.glyph;
            this.glyph = null;
            this.font = new Font() { family = "Arial",size = 12,weight = "" };
            // Set font
            if(text_struct.font != null)
            {
                this.font = text_struct.font;
            }

            //// Determine and set initial note width. Note that the text width is an approximation and isn't very accurate. The only way to accurately measure the length of text is with `canvasContext.measureText()`
            if(!string.IsNullOrEmpty(this.glyph_type))
            {
                Glyph4TextNote @struct;
                if(!GLYPHS.TryGetValue(this.glyph_type,out @struct))
                {
                    throw new Exception("Invalid glyph type:" + this.glyph_type);
                }
                this.glyph = new Glyph(@struct.code,@struct.point,new GlyphsOpts() { cache = false });
                if(@struct.width.HasValue)
                {
                    this.SetWidth(@struct.width.Value);
                }
                else
                {
                    this.SetWidth(this.glyph.Metrics.width);
                }
                this.glyph_struct = @struct;
            }
            else
            {
                this.SetWidth(Flow.TextWidth(this.text));
            }
            this.line = text_struct.line ?? 0;
            this.smooth = text_struct.smooth ?? false;
            this.ignore_ticks = text_struct.ignore_ticks ?? false;
            this.justification = TextNote.TextNoteJustification.LEFT;
        }
        /// <summary>
        /// Set the horizontal justification of the TextNote
        /// </summary>
        public TextNote SetJustification(TextNoteJustification justification)
        {
            this.justification = justification;
            return this;
        }
        /// <summary>
        ///  Set the Stave line on which the note should be placed
        /// </summary>
        public TextNote SetLine(int line)
        {
            this.line = line;
            return this;
        }
        /// <summary>
        /// Pre-render formatting
        /// </summary>
        public new void PreFormat()
        {
            if(this.context == null)
            {
                throw new Exception("NoRenderContext,Can't measure text without rendering context.");
            }
            if(this.preFormatted)
            {
                return;
            }
            if(this.smooth)
            {
                this.SetWidth(0);
            }
            else
            {
                if(this.glyph != null)
                {
                    // Width already set.
                }
                else
                {
                    this.SetWidth(this.context.MeasureText(this.text).width);
                }
            }
            if(this.justification == TextNote.TextNoteJustification.CENTER)
            {
                this.extra_left_px = this.width / 2;
            }
            else if(this.justification == TextNote.TextNoteJustification.RIGHT)
            {
                this.extra_left_px = this.width;
            }
            this.SetPreFormatted(true);
        }
        /// <summary>
        /// Renders the TextNote
        /// </summary>
        public override void Draw()
        {
            throw new NotImplementedException();
        }

        #endregion


        #region 隐含字段
        public string text;
        public string subscript;
        public string glyph_type;
        public new Glyph glyph;
        public bool smooth;
        public TextNoteJustification justification;
        public Glyph4TextNote glyph_struct;
        public int line;
        public string superscript;
        public override string GetCategory()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
