using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NVexFlow
{
    public partial class Vex
    {
        public partial class Flow
        {
            public class Note : Tickable
            {
                #region 属性字段
                private double width;

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

                double xShift;

                public virtual double X_shift
                {
                    set { xShift = value; }
                }

                double x;

                public virtual double X
                {
                    get
                    {
                        return x;
                        //
                    }
                }

                double leftModPx;
                double rightModPx;

                object playNote;

                public object PlayNote
                {
                    get { return playNote; }
                    set { playNote = value; }
                }


                private Stave stave;

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

                double extraLeftPx;

                public double ExtraLeftPx
                {
                    get { return extraLeftPx; }
                    set { extraLeftPx = value; }
                }

                double extraRightPx;

                public double ExtraRightPx
                {
                    get { return extraRightPx; }
                    set { extraRightPx = value; }
                }

                bool ignoreTicks;

                public bool ShouldIgnore_ticks
                {
                    get { return ignoreTicks; }
                }

                object lineNumber;

                public object LineNumber
                {
                    get { return 0; }
                }

                object lineForRest;

                public object LineForRest
                {
                    get { return 0; }
                }



                object glyph;

                public virtual object Glyph
                {
                    get { return glyph; }
                }


                IList<object> ys;

                public IList<object> Ys
                {
                    get
                    {
                        //
                        return ys;
                    }
                    set { ys = value; }
                }

                object voice;
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

                IList<object> positions;

                object duration;

                public object Duration
                {
                    get { return duration; }
                }

                int dots;

                public int Dots
                {
                    get { return dots; }
                }


                object noteType;

                public object NoteType
                {
                    get { return noteType; }
                }

                object modifierContext;

                public object ModifierContext
                {
                    set { modifierContext = value; }
                }

                object context;

                object renderOptions;

                #endregion


                #region 方法
                public Note(object note_struct)
                {
                    Init(note_struct);
                }
                

                public virtual void Init(object noteStruct)
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

                public virtual double GetAbsoluteX()
                {
                    return 0;
                }

                #endregion








            }
        }

    }

}
