using System;
//对应 note.js
using System.Collections.Generic;
using NVexFlow.Model;

namespace NVexFlow
{
    public partial class Vex
    {
        public partial class Flow
        {
            // [VexFlow](http://vexflow.com) - Copyright (c) Mohit Muthanna 2010.
            //
            // ## Description
            //
            // This file implements an abstract interface for notes and chords that
            // are rendered on a stave. Notes have some common properties: All of them
            // have a value (e.g., pitch, fret, etc.) and a duration (quarter, half, etc.)
            //
            // Some notes have stems, heads, dots, etc. Most notational elements that
            // surround a note are called *modifiers*, and every note has an associated
            // array of them. All notes also have a rendering context and belong to a stave.
            public abstract class Note : Tickable
            {
                #region js直译部分
                // To create a new note you need to provide a `note_struct`, which consists
                // of the following fields:
                //
                // `type`: The note type (e.g., `r` for rest, `s` for slash notes, etc.)
                // `dots`: The number of dots, which affects the duration.
                // `duration`: The time length (e.g., `q` for quarter, `h` for half, `8` for eighth etc.)
                //
                // The range of values for these parameters are available in `src/tables.js`.

                /// <summary>
                /// Every note is a tickable, i.e., it can be mutated by the `Formatter` class for positioning and layout.
                /// </summary>
                /// <param name="note_struct"></param>
                public Note(NoteStruct note_struct)
                {
                    Init(note_struct);
                }

                /// <summary>
                /// See constructor above for how to create a note.
                /// </summary>
                /// <param name="noteStruct"></param>
                private void Init(NoteStruct noteStruct)
                {
                    if (noteStruct == null)
                    {
                        throw new Exception("BadArguments,Note must have valid initialization data to identifyduration and type.");
                    }
                    // Parse `note_struct` and get note properties.

                    NoteInitData initData = Vex.Flow.ParseNoteData(noteStruct);
                    if (initData == null)
                    {
                        throw new Exception("BadArguments,Invalid note initialization object: ");
                        //  throw new Vex.RuntimeError("BadArguments",
                        //      "Invalid note initialization object: " + JSON.stringify(note_struct));
                    }
                    // Set note properties from parameters.
                    this.duration = initData.duration;
                    this.dots = initData.dots;
                    this.noteType = initData.type;
                    this.IntrinsicTicks = initData.ticks;
                    this.modifiers = new List<object>();
                    // Get the glyph code for this note from the font.
                    this.glyph = Vex.Flow.DurationToGlyph(this.duration, this.noteType);
                    if (this.positions != null)
                    {
                        if (!(this.positions is IEnumerable<object>) || this.positions.Count <= 0)
                        {
                            throw new Exception("BadArguments,Note keys must be array type.");
                        }
                    }
                    // Note to play for audio players.
                    this.playNote = null;
                    // Positioning contexts used by the Formatter.
                    this.tickContext = null;    // The current tick context.
                    this.modifierContext = null;
                    this.ignoreTicks = false;

                    // Positioning variables
                    this.width = 0;             // Width in pixels calculated after preFormat
                    this.extraLeftPx = 0;       // Extra room on left for offset note head
                    this.extraRightPx = 0;      // Extra room on right for offset note head
                    this.xShift = 0;           // X shift from tick context X
                    this.leftModPx = 0;        // Max width of left modifiers
                    this.rightModPx = 0;       // Max width of right modifiers
                    this.voice = null;          // The voice that this note is in
                    this.preFormatted = false;  // Is this note preFormatted?
                    this.ys = new List<object>();               // list of y coordinates for each note
                                                // we need to hold on to these for ties and beams.

                    // The render surface.
                    this.context = null;
                    this.stave = null;
                    this.renderOptions = new NoteRenderOpts() { annotationSpacing=5,stavePadding=12};
                }
                public object PlayNote
                {
                    get { return playNote; }
                    set { playNote = value; }
                }


                public bool IsRest()
                {
                    return false;
                }


                public Note AddStroke(object index, object stroke)
                {
                    return this;
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
                public override CanvasContext Context
                {
                    set
                    {
                        base.Context = value;
                    }
                }
                public double ExtraLeftPx
                {
                    get { return extraLeftPx; }
                    set { extraLeftPx = value; }
                }
                public double ExtraRightPx
                {
                    get { return extraRightPx; }
                    set { extraRightPx = value; }
                }
                public bool ShouldIgnore_ticks
                {
                    get { return ignoreTicks; }
                }
                public object LineNumber
                {
                    get { return 0; }
                }
                public object LineForRest
                {
                    get { return 0; }
                }
                public virtual object Glyph
                {
                    get { return glyph; }
                }
                public IList<object> Ys
                {
                    get
                    {
                        //
                        return ys;
                    }
                    set { ys = value; }
                }
                public virtual double GetYForTopText(object text_line)
                {
                    return 0;
                }
                public override object BoundingBox
                {
                    get
                    {
                        return base.BoundingBox;
                    }
                }
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
                public override object TickContext
                {
                    set
                    {
                        base.TickContext = value;
                    }
                }

                public object GetTickContext()
                {
                    return null;
                }
                public object Duration
                {
                    get { return duration; }
                }
                public bool IsDotted()
                {
                    return (this.dots > 0);
                }


                public bool HasStem()
                {
                    return false;
                }
                public int Dots
                {
                    get { return dots; }
                }
                public object NoteType
                {
                    get { return noteType; }
                }

                public Note SetBeam()
                {
                    return this;
                }
                public ModifierContext ModifierContext
                {
                    set { modifierContext = value; }
                }

                public Note AddModifier(object modifier, object index)
                {
                    return null;
                }


                public object ModifierStartXY
                {
                    get { return null; }
                }

                public object Metrics
                {
                    get
                    {
                        return null;
                    }
                }

                public override double Width
                {
                    get
                    {
                        //
                        return width;
                    }
                }
                public Note SetWidth()
                {
                    return this;
                }

                public override double XShift
                {
                    set
                    {
                        base.XShift = value;
                    }
                }
                public virtual double X
                {
                    get
                    {
                        return x;
                        //
                    }
                }

                public virtual double AbsoluteX
                {
                    get
                    {
                        return 0;
                    }
                }
                public override bool PreFormatted
                {
                    set
                    {
                        //
                        preFormatted = value;
                    }
                }
                #endregion


                #region 隐含字段
                protected double x;
                protected double leftModPx;
                protected double rightModPx;
                protected object playNote;
                protected Stave stave;
                protected double extraLeftPx;
                protected double extraRightPx;
                protected object lineNumber;
                protected object lineForRest;
                protected object glyph;
                protected IList<object> ys;
                protected IList<object> positions;
                protected string duration;
                protected int dots;
                protected string noteType;
                protected NoteRenderOpts renderOptions;
                /// <summary>
                /// js文件没有这个属性。在Modifier分支里有一个属性叫Note，暂时写成了Note类型。为了让不同的Note都能点儿出Category，先在父类里加入了Category
                /// </summary>
                public abstract string Category
                {
                    get;
                }

                #endregion
            }
        }

    }

}
