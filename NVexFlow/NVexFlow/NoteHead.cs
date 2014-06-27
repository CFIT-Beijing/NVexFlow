
namespace NVexFlow
{
    public partial class Vex
    {
        public partial class Flow
        {
            public class NoteHead : Note
            {
                #region 静态
                public static void DrawSlashNoteHead(object ctx, object duration, double x, double y, int stemDirection)
                { }
                #endregion


                #region 属性字段

                public override object Context
                {
                    set
                    {
                        base.Context = value;
                    }
                }



                public override double Width
                {
                    get
                    {
                        return base.Width;
                    }
                    set
                    {
                        base.Width = value;
                    }
                }

                object index;

                double x;
                double y;

                object noteType;
                object duration;

                object displaced;
                int stemDirection;

                object line;

                public object Line
                {
                    get { return line; }
                }

                public override object Glyph
                {
                    get
                    {
                        return base.Glyph;
                    }
                }

                double xShift;

                object glyphCode;

                object context;

                object style;

                public object Style
                {
                    get { return style; }
                    set { style = value; }
                }

                object slashed;

                public override double X
                {
                    get
                    {
                        return base.X;
                    }
                }

                public double Y
                {
                    get { return y; }
                    set { y = value; }
                }



                public override Stave Stave
                {
                    get
                    {
                        return base.Stave;
                    }
                    set
                    {
                        base.Stave = value;
                    }
                }

                #endregion


                #region 方法
                public NoteHead(object head_options)
                    : base(head_options)
                {

                    Init(head_options);
                }

                public override void Init(object head_options)
                { }


                public override double GetAbsoluteX()
                {
                    return base.GetAbsoluteX();
                }

                public BoundingBox GetBoundingBox()
                {
                    return null;
                }

                public object IsDisplaced
                {
                    get { return object.ReferenceEquals(this.displaced, true); }
                }

                public NoteHead ApplyStyle()
                {
                    return null;
                }

                public NoteHead PreFormat()
                {
                    return null;
                }

                public void Draw()
                { }
                #endregion
            }
        }
    }
}
