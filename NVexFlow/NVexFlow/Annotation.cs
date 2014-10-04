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
            this.text_line = 0;
            this.text = text;
            this.justification = Annotation.AnnotationJustify.CENTER;
            this.verticalJustification = Annotation.AnnotationVerticalJustify.TOP;
            this.font = new Font() {
                family = "Arial",
                size = 10,
                weight = ""
            };
            //// The default width is calculated from the text.
            this.SetWidth(Flow.TextWidth(text));
        }
        /// <summary>
        /// Return the modifier type. Used by the `ModifierContext` to calculate layout.
        /// </summary>
        public override string GetCategory()
        {
            return "annotations";
        }
        /// <summary>
        /// Set the vertical position of the text relative to the stave.
        /// </summary>
        public new Annotation SetTextLine(int textLine)
        {
            this.text_line = textLine;
            return this;
        }
        /// <summary>
        /// Set font family, size, and weight. E.g., `Arial`, `10pt`, `Bold`.
        /// </summary>
        public Annotation SetFont(Font font)
        {
            this.font = font;
            return this;
        }
        /// <summary>
        /// Set vertical position of text (above or below stave). `just` must be  a value in `Annotation.VerticalJustify`.
        /// </summary>
        public Annotation SetVerticalJustification(AnnotationVerticalJustify verticalJustification)
        {
            this.verticalJustification = verticalJustification;
            return this;
        }
        /// <summary>
        /// Get and set horizontal justification. `justification` is a value in  `Annotation.Justify`.
        /// </summary>
        public AnnotationJustify GetJustification()
        {
            return justification;
        }
        public Annotation SetJustification(AnnotationJustify Justification)
        {
            this.justification = Justification;
            return this;
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
        public Annotation.AnnotationVerticalJustify verticalJustification;
        public Annotation.AnnotationJustify justification;
        public string text;
        #endregion
    }
}
