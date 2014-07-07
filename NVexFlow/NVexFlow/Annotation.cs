
namespace NVexFlow
{
    public partial class Vex
    {
        public partial class Flow
        {
            public class Annotation : Modifier
            {
                #region 方法
                //Annotations inherit from `Modifier` and is positioned correctly when in a `ModifierContext`.

                public Annotation(string text)
                {
                    Init(text);
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
                    base.Width = Vex.Flow.TextWidth(text);
                }

                /// <summary>
                /// Render text beside the note.
                /// </summary>
                public override void Draw()
                { }
                #endregion


                #region 枚举
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
                #endregion


                #region 属性字段
                
                /// <summary>
                /// Set the vertical position of the text relative to the stave.
                /// </summary>
                public override int TextLine
                {
                    set
                    {
                        base.TextLine = value;
                    }
                }
                int textLine;


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
                Font font;

                
                /// <summary>
                /// Set vertical position of text (above or below stave). `just` must be  a value in `Annotation.VerticalJustify`.
                /// </summary>
                public Annotation.AnnotationVerticalJustify VerticalJustification
                {
                    set { verticalJustification = value; }
                }
                Annotation.AnnotationVerticalJustify verticalJustification;


                
                /// <summary>
                /// Get and set horizontal justification. `justification` is a value in  `Annotation.Justify`.
                /// </summary>
                public Annotation.AnnotationJustify Justification
                {
                    get { return justification; }
                    set { justification = value; }
                }
                Annotation.AnnotationJustify justification;



                Note note;
                object index;
                string text;
                #endregion             
            }
        }
    }
}
