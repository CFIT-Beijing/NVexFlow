using System;
//对应 textNote.js
using System.Collections.Generic;
using NVexFlow.Model;

namespace NVexFlow
{
    public partial class Vex
    {
        public partial class Flow
        {
            /// <summary>
            /// ## Description
            //
            // `TextNote` is a notation element that is positioned in time. Generally 
            // meant for objects that sit above/below the staff and inline with each other.
            // Examples of this would be such as dynamics, lyrics, chord changes, etc.
            /// </summary>
            public class TextNote : Note
            {
                #region js直译部分
                public enum TextNoteJustification
                {
                    LEFT,
                    CENTER,
                    RIGHT
                }
                public static IDictionary<string, Glyph4TextNote> GLYPHS = new Dictionary<string, Glyph4TextNote>() 
                {              
                    {"segno",new Glyph4TextNote(){code="v8c",point=40,xShift=0,yShift=-10}},
                    {"tr",new Glyph4TextNote(){code="v1f",point=40,xShift=0,yShift=0}},
                    { "mordent_upper",new Glyph4TextNote(){code="v1e",point=40,xShift=0,yShift=0}},
                    {"mordent_lower",new Glyph4TextNote(){code="v45",point=40,xShift=0,yShift=0}},
                    { "f",new Glyph4TextNote(){code="vba",point=40,xShift=0,yShift=0}},
                    { "p",new Glyph4TextNote(){code="vbf",point=40,xShift=0,yShift=0}},
                    {"m",new Glyph4TextNote(){code="v62",point=40,xShift=0,yShift=0}},
                    { "s",new Glyph4TextNote(){code="v4a",point=40,xShift=0,yShift=0}},
                    { "z",new Glyph4TextNote(){code="v80",point=40,xShift=0,yShift=0}},
                    { "coda",new Glyph4TextNote(){code="v4d",point=40,xShift=0,yShift=-8}},
                    { "pedal_open",new Glyph4TextNote(){code="v36",point=40,xShift=0,yShift=0}},
                    { "pedal_close",new Glyph4TextNote(){code="v5d",point=40,xShift=0,yShift=3}},
                    { "caesura_straight",new Glyph4TextNote(){code="v34",point=40,xShift=0,yShift=2}},
                    { "caesura_curved",new Glyph4TextNote(){code="v4b",point=40,xShift=0,yShift=2}},
                    { "breath",new Glyph4TextNote(){code="v6c",point=40,xShift=0,yShift=0}},
                    {"tick",new Glyph4TextNote(){code="v6f",point=50,xShift=0,yShift=0}},
                    {"turn",new Glyph4TextNote(){code="v72",point=40,xShift=0,yShift=0}},
                    {"turn_inverted",new Glyph4TextNote(){code="v33",point=40,xShift=0,yShift=0}},
                    // DEPRECATED - please use "mordent_upper" or "mordent_lower"
                    {"mordent",new Glyph4TextNote(){code="v1e",point=40,xShift=0,yShift=0}}
                };
                public TextNote(TextStruct textStruct)
                    : base(textStruct)
                {
                    Init(textStruct);
                }
                private void Init(TextStruct textStruct)
                {
                    // Note properties

                    this.text = textStruct.text;
                    this.superscript = textStruct.superscript;
                    this.subscript = textStruct.subscript;
                    this.glyphType = textStruct.glyph;
                    this.glyph = null;
                    this.font = new Font() { family = "Arial",size=12,weight="" };
                    // Set font
                    if (textStruct.font != null)
                    {
                        this.font = textStruct.font;
                    }

                    //// Determine and set initial note width. Note that the text width is an approximation and isn't very accurate. The only way to accurately measure the length of text is with `canvasContext.measureText()`
                    if (!string.IsNullOrEmpty(this.glyphType))
                    {
                        if (!GLYPHS.ContainsKey(this.glyphType))
                        {
                            throw new Exception("Invalid glyph type:" + this.glyphType);
                        }
                        Glyph4TextNote @struct = GLYPHS[this.glyphType];
                        this.glyph = new Glyph(@struct.code, @struct.point, new MODEL.GlyphsOpts() { cache = false });
                        if (@struct.width.HasValue)
                        {
                            this.SetWidth(@struct.width.Value);
                        }
                        else
                        {
                            this.SetWidth(this.glyph.GetMetrics().width);
                        }
                        this.glyphStruct = @struct;
                    }
                    else
                    {
                        this.SetWidth(Vex.Flow.TextWidth(this.text));
                    }
                    this.line = textStruct.line.HasValue ? textStruct.line.Value : 0;
                    this.smooth = textStruct.smooth.HasValue ? textStruct.smooth.Value : false;
                    this.justification = TextNote.TextNoteJustification.LEFT;
                }
                /// <summary>
                /// Set the horizontal justification of the TextNote
                /// </summary>
                public TextNoteJustification Justification
                {
                    set
                    {
                        this.justification = value;
                    }
                }
                /// <summary>
                ///  Set the Stave line on which the note should be placed
                /// </summary>
                public int Line
                {
                    set
                    {
                        this.line = value;
                    }
                }
                /// <summary>
                /// Pre-render formatting
                /// </summary>
                public new void PreFormat()
                {
                    if (this.context == null)
                    {
                        throw new Exception("NoRenderContext,Can't measure text without rendering context.");
                    }
                    if (this.preFormatted)
                    {
                        return;
                    }
                    if (this.smooth)
                    {
                        this.SetWidth(0);
                    }
                    else
                    {
                        if (this.glyph != null)
                        {
                            // Width already set.
                        }
                        else
                        {
                            this.SetWidth(this.context.MeasureText(this.text).width);
                        }
                    }
                    if (this.justification == TextNote.TextNoteJustification.CENTER)
                    {
                        this.extraLeftPx = this.width / 2;
                    }
                    else if (this.justification == TextNote.TextNoteJustification.RIGHT)
                    {
                        this.extraLeftPx = this.width;
                    }
                    this.PreFormatted = true;
                }
                /// <summary>
                /// Renders the TextNote
                /// </summary>
                public void Draw() { }

                #endregion


                #region 隐含字段
                protected string text;
                protected string subscript;
                protected string glyphType;
                protected new Glyph glyph;
                protected Font font;
                protected bool smooth;
                protected TextNoteJustification justification;
                protected Glyph4TextNote glyphStruct;
                protected int line;
                protected string superscript;
                public override string Category
                {
                    get { throw new System.NotImplementedException(); }
                }
                #endregion





            }
        }
    }
}
