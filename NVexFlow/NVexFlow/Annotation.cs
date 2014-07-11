﻿
namespace NVexFlow
{
    public partial class Vex
    {
        public partial class Flow
        {
            public class Annotation : Modifier
            {
                //Annotations inherit from `Modifier` and is positioned correctly when in a `ModifierContext`.
                #region js直译部分                
                /// <summary>
                /// Create a new `Annotation` with the string `text`.
                /// </summary>
                /// <param name="text"></param>
                public Annotation(string text)
                {
                    Init(text);
                }


                /// <summary>
                /// Text annotations can be positioned and justified relative to the note.
                /// </summary>
                public enum AnnotationJustify
                {
                    LEFT,
                    CENTER,
                    RIGHT,
                    CENTER_STEM
                }
                public enum AnnotationVerticalJustify
                {
                    TOP,
                    CENTER,
                    BOTTOM,
                    CENTER_STEM
                } 


                /// <summary>
                /// Create a new `Annotation` with the string `text`.
                /// </summary>
                /// <param name="text"></param>
                public void Init(string text)
                {
                    this.note = null;
                    this.index = null;
                    this.textLine = 0;
                    this.text = text;
                    this.justification = Annotation.AnnotationJustify.CENTER;
                    this.verticalJustification = Annotation.AnnotationVerticalJustify.TOP;
                    this.font = new Font() { Family = "Arial", Size = 10, Weight = "" };

                    //// The default width is calculated from the text.
                    Width = Vex.Flow.TextWidth(text);
                }


                /// <summary>
                /// Return the modifier type. Used by the `ModifierContext` to calculate layout.
                /// </summary>
                public override string Category
                {
                    get
                    {
                        return "annotations"; 
                    }
                }

                /// <summary>
                /// Set the vertical position of the text relative to the stave.
                /// </summary>
                public override int TextLine
                {
                    set
                    {
                        TextLine = value;
                    }
                }


                /// <summary>
                /// Set font family, size, and weight. E.g., `Arial`, `10pt`, `Bold`.
                /// </summary>
                public Font Font
                {
                    set
                    {
                        font = value;
                    }
                }


                /// <summary>
                /// Set vertical position of text (above or below stave). `just` must be  a value in `Annotation.VerticalJustify`.
                /// </summary>
                public Annotation.AnnotationVerticalJustify VerticalJustification
                {
                    set { verticalJustification = value; }
                }


                /// <summary>
                /// Get and set horizontal justification. `justification` is a value in  `Annotation.Justify`.
                /// </summary>
                public Annotation.AnnotationJustify Justification
                {
                    get { return justification; }
                    set { justification = value; }
                }


                /// <summary>
                /// Render text beside the note.
                /// </summary>
                public override void Draw()
                { }
                #endregion


                #region 属性字段            
                protected Annotation.AnnotationVerticalJustify verticalJustification;
                protected Annotation.AnnotationJustify justification;
                protected string text;
                #endregion             
            }
        }
    }
}
