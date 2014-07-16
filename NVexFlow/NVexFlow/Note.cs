//对应 note.js
using System.Collections.Generic;
using NVexFlow.Model;

namespace NVexFlow
{
    public partial class Vex
    {
        public partial class Flow
        {
            public class Note : Tickable
            {
                #region 属性字段
                protected double width;

                public virtual double Width
                {
                    get
                    {
                        //
                        return width;
                    }
                    set { width = value; }
                }

                public bool preFormatted { get; set; }

                protected double xShift;

                public virtual double X_shift
                {
                    set { xShift = value; }
                }

                protected double x;
                
                public virtual double X
                {
                    get
                    {
                        return x;
                        //
                    }
                    set
                    {
                        this.x = value;
                    }
                }

                protected double leftModPx;
                protected double rightModPx;

                protected object playNote;

                public object PlayNote
                {
                    get { return playNote; }
                    set { playNote = value; }
                }


                protected Stave stave;

                public override bool PreFormatted
                {
                    set
                    {
                        //
                        preFormatted = value;
                    }
                }
                public virtual Stave Stave
                {
                    get { return stave; }
                    set
                    {
                        //
                        stave = value;
                    }
                }

                protected double extraLeftPx;

                public double ExtraLeftPx
                {
                    get { return extraLeftPx; }
                    set { extraLeftPx = value; }
                }

                protected double extraRightPx;

                public double ExtraRightPx
                {
                    get { return extraRightPx; }
                    set { extraRightPx = value; }
                }

                protected bool ignoreTicks;

                public bool ShouldIgnore_ticks
                {
                    get { return ignoreTicks; }
                }

                protected object lineNumber;

                public object LineNumber
                {
                    get { return 0; }
                }

                protected object lineForRest;

                public object LineForRest
                {
                    get { return 0; }
                }



                protected object glyph;

                public virtual object Glyph
                {
                    get { return glyph; }
                }


                protected IList<object> ys;

                public IList<object> Ys
                {
                    get
                    {
                        //
                        return ys;
                    }
                    set { ys = value; }
                }

                protected object voice;
                public override object Voice
                {
                    get
                    {
                        if (this.voice == null)
                        { }
                        return this.Voice;
                    }
                    set
                    {
                        this.Voice = value;
                        this.preFormatted = false;
                    }
                }

                protected IList<object> positions;

                protected object duration;

                public object Duration
                {
                    get { return duration; }
                }

                protected int dots;

                public int Dots
                {
                    get { return dots; }
                }


                protected object noteType;

                public object NoteType
                {
                    get { return noteType; }
                }

                object modifierContext;

                public object ModifierContext
                {
                    set { modifierContext = value; }
                }

                protected CanvasContext context;

                protected object renderOptions;

                #endregion


                #region 方法
                public Note(NoteStruct note_struct)
                {
                    Init(note_struct);
                }


                private void Init(NoteStruct noteStruct)
                {


                }



                public bool IsRest()
                {
                    return false;
                }


                public Note AddStroke(object index, object stroke)
                {
                    return this;
                }


                public bool IsDotted()
                {
                    return (this.dots > 0);
                }


                public bool HasStem()
                {
                    return false;
                }


                public Note SetBeam()
                {
                    return this;
                }


                public Note AddModifier(object modifier, object index)
                {
                    return null;
                }


                public object GetModifierStartXY()
                {
                    return null;
                }

                public object GetMetrics()
                {
                    return null;
                }


                public virtual double GetYForTopText(object text_line)
                {
                    return 0;
                }

                public virtual double AbsoluteX
                {
                    get
                    {
                        return 0;
                    }
                }

                #endregion








            }
        }

    }

}
