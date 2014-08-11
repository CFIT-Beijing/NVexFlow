//对应 annotation.js
using System;
namespace NVexFlow
{
    /// <summary>
    /// This file implements text annotations as modifiers that can be attached to
    /// notes.
    /// See `tests/annotation_tests.js` for usage examples.
    /// </summary>
    public class Annotation:Modifier
    {
        //Annotations inherit from `Modifier` and is positioned correctly when in a `ModifierContext`.
        #region js直译部分                
        public Annotation(string text)
        {
            Init(text);
        }
        /// <summary>
        /// Text annotations can be positioned and justified relative to the note.
        /// </summary>
        public enum AnnotationJustify
        {
            LEFT = 1,
            CENTER = 2,
            RIGHT = 3,
            CENTER_STEM = 4
        }
        public enum AnnotationVerticalJustify
        {
            TOP = 1,
            CENTER = 2,
            BOTTOM = 3,
            CENTER_STEM = 4
        }
        /// <summary>
        /// Create a new `Annotation` with the string `text`.
        /// </summary>
        private void Init(string text)
        {
            this.note = null;
            this.index = null;
            this.textLine = 0;
            this.text = text;
            this.justification = Annotation.AnnotationJustify.CENTER;
            this.verticalJustification = Annotation.AnnotationVerticalJustify.TOP;
            this.font = new Font() {
                family = "Arial",
                size = 10,
                weight = ""
            };
            //// The default width is calculated from the text.
            Width = Flow.TextWidth(text);
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
            set
            {
                verticalJustification = value;
            }
        }
        /// <summary>
        /// Get and set horizontal justification. `justification` is a value in  `Annotation.Justify`.
        /// </summary>
        public Annotation.AnnotationJustify Justification
        {
            get
            {
                return justification;
            }
            set
            {
                justification = value;
            }
        }
        /// <summary>
        /// Render text beside the note.
        /// </summary>
        public override void Draw()
        {
            throw new NotImplementedException();
        }
        #endregion

        #region 隐含字段            
        protected Annotation.AnnotationVerticalJustify verticalJustification;
        protected Annotation.AnnotationJustify justification;
        protected string text;
        #endregion
    }
}
