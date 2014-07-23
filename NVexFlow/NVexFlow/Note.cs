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
                    this.modifiers = new List<Modifier>();
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
                    this.ys = new List<double>();               // list of y coordinates for each note
                    // we need to hold on to these for ties and beams.

                    // The render surface.
                    this.context = null;
                    this.stave = null;
                    this.renderOptions = new NoteRenderOpts() { annotationSpacing = 5, stavePadding = 12 };
                }
                /// <summary>
                /// Get and set the play note, which is arbitrary data that can be used by an audio player.
                /// </summary>
                public object PlayNote
                {
                    get { return this.playNote; }
                    set { this.playNote = value; }
                }
                /// <summary>
                /// Don't play notes by default, call them rests. This is also used by things like beams and dots for positioning.
                /// </summary>
                /// <returns></returns>
                public bool IsRest()
                {
                    return false;
                }
                /// <summary>
                /// TODO(0xfe): Why is this method here?
                /// </summary>
                /// <param name="index"></param>
                /// <param name="stroke"></param>
                /// <returns></returns>
                public Note AddStroke(object index, Stroke stroke)
                {
                    stroke.Note = this;
                    stroke.Index = index;
                    this.modifiers.Add(stroke);
                    this.PreFormatted = false;
                    return this;
                }
                /// <summary>
                /// Get and set the target stave.
                /// </summary>
                public virtual Stave Stave
                {
                    get { return this.stave; }
                    set
                    {
                        this.stave = value;
                        this.Ys = new List<double>() { value.GetYForLine(0) };
                        this.context = this.stave.context;
                    }
                }
                /// <summary>
                /// Set the rendering context for the note.
                /// </summary>
                public override CanvasContext Context
                {
                    set
                    {
                        this.context = value;
                    }
                }
                /// <summary>
                /// Get and set spacing to the left and right of the notes.
                /// </summary>
                public double ExtraLeftPx
                {
                    get { return this.extraLeftPx; }
                    set { this.extraLeftPx = value; }
                }
                public double ExtraRightPx
                {
                    get { return this.extraRightPx; }
                    set { this.extraRightPx = value; }
                }
                /// <summary>
                /// Returns true if this note has no duration (e.g., bar notes, spacers, etc.)
                /// </summary>
                public bool ShouldIgnore_ticks
                {
                    get { return this.ignoreTicks; }
                }
                /// <summary>
                /// Get the stave line number for the note.
                /// </summary>
                public object LineNumber
                {
                    get { return 0; }
                }
                /// <summary>
                /// Get the stave line number for rest.
                /// </summary>
                public object LineForRest
                {
                    get { return 0; }
                }
                /// <summary>
                /// Get the glyph associated with this note.
                /// </summary>
                public virtual object Glyph
                {
                    get { return this.glyph; }
                }
                /// <summary>
                /// Set and get Y positions for this note. Each Y value is associated with an individual pitch/key within the note/chord.
                /// </summary>
                public IList<double> Ys
                {
                    get
                    {
                        if (this.ys.Count <= 0)
                        {
                            throw new Exception("NoYValues,No Y-values calculated for this note.");
                        }
                        return ys;
                    }
                    set { this.ys = value; }
                }
                /// <summary>
                /// Get the Y position of the space above the stave onto which text can be rendered.
                /// </summary>
                /// <param name="textLine"></param>
                /// <returns></returns>
                public virtual double GetYForTopText(object textLine)
                {
                    if (this.stave == null)
                    {
                        throw new Exception("NoStave,No stave attached to this note.");
                    }
                    return this.stave.GetYForTopText(textLine);
                }
                /// <summary>
                /// Get a `BoundingBox` for this note.
                /// </summary>
                public override object BoundingBox
                {
                    get
                    {
                        return null;
                    }
                }
                /// <summary>
                /// Returns the voice that this note belongs in.
                /// </summary>
                public override object Voice
                {
                    get
                    {
                        if (this.voice == null)
                        {
                            throw new Exception("NoVoice,Note has no voice.");
                        }
                        return this.voice;
                    }
                    set
                    {
                        this.voice = value;
                        this.preFormatted = false;
                    }
                }
                /// <summary>
                /// Attach this note to `voice`.
                /// </summary>
                public override TickContext TickContext
                {
                    set
                    {
                        this.tickContext = value;
                        this.preFormatted = false;
                    }
                }
                public object GetTickContext()
                {
                    return this.tickContext;
                }
                /// <summary>
                /// Accessors for the note type.
                /// </summary>
                public object Duration
                {
                    get { return this.duration; }
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
                    get { return this.dots; }
                }
                public object NoteType
                {
                    get { return this.noteType; }
                }
                public Note SetBeam()
                {
                    return this;
                }
                /// <summary>
                /// Attach this note to a modifier context.
                /// </summary>
                public ModifierContext ModifierContext
                {
                    set { this.modifierContext = value; }
                }
                /// <summary>
                /// Attach a modifier to this note.
                /// </summary>
                /// <param name="modifier"></param>
                /// <param name="index"></param>
                /// <returns></returns>
                public Note AddModifier(Modifier modifier, int? index)
                {
                    modifier.Note = this;
                    if (index.HasValue)
                    {
                        modifier.Index = index.Value;
                    }
                    else
                    {
                        modifier.Index = 0;//此处确定Modifier的index是int或者int？
                    }
                    return this;
                }
                /// <summary>
                /// Get the coordinates for where modifiers begin.
                /// </summary>
                public object ModifierStartXY
                {
                    get
                    {
                        if (!this.preFormatted)
                        {
                            throw new Exception("UnformattedNote,Can't call GetModifierStartXY on an unformatted note");
                        }
                        return new NoteModifierStartXY()
                        {
                            x = this.AbsoluteX,
                            y = this.ys[0]
                        };
                    }
                }
                // Get bounds and metrics for this note.
                //
                // Returns a struct with fields:
                // `width`: The total width of the note (including modifiers.)
                // `noteWidth`: The width of the note head only.
                // `left_shift`: The horizontal displacement of the note.
                // `modLeftPx`: Start `X` for left modifiers.
                // `modRightPx`: Start `X` for right modifiers.
                // `extraLeftPx`: Extra space on left of note.
                // `extraRightPx`: Extra space on right of note.
                public object Metrics
                {
                    get
                    {
                        if (!this.preFormatted)
                        {
                            throw new Exception("UnformattedNote,Can't call getMetrics on an unformatted note.");
                        }
                        double modLeftPx = 0;
                        double modRightPx = 0;
                        if (this.modifierContext != null)
                        {
                            modLeftPx = this.modifierContext.state.leftShift;
                            modRightPx = this.modifierContext.state.rightShift;
                        }
                        double width = this.Width;
                        return new NoteMetrics()
                        {
                            width = width,
                            noteWidth = modLeftPx - modRightPx - this.extraLeftPx - this.extraRightPx,// used by accidentals and modifiers
                            leftShift = this.xShift,// TODO(0xfe): Make style consistent
                            modLeftPx = modLeftPx,
                            modRightPx = modRightPx,
                            extraLeftPx = this.extraLeftPx,
                            extraRightPx = this.extraRightPx
                        };
                    }
                }
                /// <summary>
                /// Get and set width of note. Used by the formatter for positioning.
                /// </summary>
                public override double Width
                {
                    get
                    {
                        if (!this.preFormatted)
                        {
                            throw new Exception("UnformattedNote,Can't call GetWidth on an unformatted note.");
                        }
                        return this.width + (this.modifierContext != null ? this.modifierContext.Width : 0);
                    }
                }
                public Note SetWidth(double width)
                {
                    this.width = width;
                    return this;
                }
                /// <summary>
                /// Displace note by `x` pixels.
                /// </summary>
                public override double XShift
                {
                    set
                    {
                        this.xShift = value;
                    }
                }
                /// <summary>
                /// Get `X` position of this tick context.
                /// </summary>
                public virtual double X
                {
                    get
                    {
                        if (this.tickContext == null)
                        {
                            throw new Exception("NoTickContext,Note needs a TickContext assigned for an X-Value");
                        }
                        return this.tickContext.X + this.xShift;
                    }
                }
                /// <summary>
                /// Get the absolute `X` position of this note relative to the stave.
                /// </summary>
                public virtual double AbsoluteX
                {
                    get
                    {
                        if (this.tickContext == null)
                        {
                            throw new Exception("NoTickContext,Note needs a TickContext assigned for an X-Value");
                        }
                        double x = this.tickContext.X;
                        if (this.stave != null)
                        {
                            x += this.stave.NoteStartX + this.renderOptions.stavePadding;
                        }
                        return x;
                    }
                }
                public override bool PreFormatted
                {
                    set
                    {
                        this.preFormatted = value;
                        // Maintain the width of left and right modifiers in pixels.
                        if (this.preFormatted)
                        {
                            TickContextExtraPx extra = this.tickContext.ExtraPx;
                            this.leftModPx = Math.Max(this.leftModPx, extra.left);
                            this.rightModPx = Math.Max(this.rightModPx, extra.right);
                        }
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
                protected IList<double> ys;
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



