
namespace NVexFlow
{
    public partial class Vex
    {
        public partial class Flow
        {
            public class Annotation : Modifier
            {
                #region 属性字段
                object note;
                object index;
                object text;
                int text_line = 0;
                object font;
                double width;
                public object Font
                {
                    set
                    {
                        //
                        font = value;
                    }
                }

                object verticalJustification;

                public object VerticalJustification
                {
                    set { verticalJustification = value; }
                }

                object justification;

                public object Justification
                {
                    get { return justification; }
                    set { justification = value; }
                }

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


                #region 方法
                public Annotation(string text)
                {
                    Init(text);
                }

                public void Init(string text)
                { }




                public override void Draw()
                { }
                #endregion
            }
        }
    }
}
