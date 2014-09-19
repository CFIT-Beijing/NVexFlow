//对应 note.js
using System;
using System.Collections.Generic;
using NVexFlow.Model;
namespace NVexFlow
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
    public abstract class Note:Tickable
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
        public Note(NoteStruct note_struct)
        {
            Init(note_struct);
        }
        // See constructor above for how to create a note.
        private void Init(NoteStruct noteStruct)
        {
            if(noteStruct == null)
            {
                throw new Exception("BadArguments,Note must have valid initialization data to identifyduration and type.");
            }
            // Parse `note_struct` and get note properties.
            NoteInitData initData = Flow.ParseNoteData(noteStruct);
            if(initData == null)
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
            this.glyph = Flow.DurationToGlyph(this.duration,this.noteType);
            /*
            if (this.positions != null)
            {
                if (!(this.positions is IEnumerable<object>) || this.positions.Count <= 0)
                {
                    throw new Exception("BadArguments,Note keys must be array type.");
                }
            }
            *///C#无需类型检查。但如果!this.positions.length等价于this.positions.Count <= 0
              //需要保留this.positions.Count <= 0检验。
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
            this.renderOptions = new NoteRenderOpts() {
                annotationSpacing = 5,
                stavePadding = 12
            };
        }
        /// <summary>
        /// Get and set the play note, which is arbitrary data that can be used by an audio player.
        /// </summary>
        public virtual object PlayNote
        {
            get
            {
                return this.playNote;
            }
            set
            {
                this.playNote = value;
            }
        }
        /// <summary>
        /// Don't play notes by default, call them rests. This is also used by things like beams and dots for positioning.
        /// </summary>
        public virtual bool IsRest()
        {
            return false;
        }
        /// <summary>
        /// TODO(0xfe): Why is this method here?
        /// </summary>
        public Note AddStroke(int index,Stroke stroke)
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
            get
            {
                return this.stave;
            }
            set
            {
                this.stave = value;
                this.Ys = new List<double>() { value.GetYForLine(0) };// Update Y values if the stave is changed.
                this.context = this.stave.context;
            }
        }
        public virtual Stave GetStave()
        { return this.stave; }
        public virtual Note SetStave(Stave stave)
        {
            this.stave = stave;
            this.Ys = new List<double>() { stave.GetYForLine(0) };// Update Y values if the stave is changed.
            this.context = this.stave.context;
            return this;
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
            get
            {
                return this.extraLeftPx;
            }
            set
            {
                this.extraLeftPx = value;
            }
        }
        public double ExtraRightPx
        {
            get
            {
                return this.extraRightPx;
            }
            set
            {
                this.extraRightPx = value;
            }
        }
        /// <summary>
        /// Returns true if this note has no duration (e.g., bar notes, spacers, etc.)
        /// </summary>
        /// <returns></returns>
        public bool ShouldIgnoreTicks()
        {//不增加override或new关键词以提示潜在重复implement
                return this.ignoreTicks;
        }
        /// <summary>
        /// Get the stave line number for the note.
        /// </summary>
        public object LineNumber
        {
            get
            {
                return 0;
            }
        }
        /// <summary>
        /// Get the stave line number for rest.
        /// </summary>
        public object LineForRest
        {
            get
            {
                return 0;
            }
        }
        /// <summary>
        /// Get the glyph associated with this note.
        /// </summary>
        public virtual Glyph4Note Glyph
        {
            get
            {
                return this.glyph;
            }
        }
        public virtual Glyph4Note GetGlyph()
        {
            return this.glyph;
        }
        /// <summary>
        /// Set and get Y positions for this note. Each Y value is associated with an individual pitch/key within the note/chord.
        /// </summary>
        public IList<double> Ys
        {
            get
            {
                if(this.ys.Count <= 0)
                {
                    throw new Exception("NoYValues,No Y-values calculated for this note.");
                }
                return ys;
            }
            set
            {
                this.ys = value;
            }
        }
        /// <summary>
        /// Get the Y position of the space above the stave onto which text can be rendered.
        /// </summary>
        public virtual double GetYForTopText(double textLine)
        {
            if(this.stave == null)
            {
                throw new Exception("NoStave,No stave attached to this note.");
            }
            return this.stave.GetYForTopText(textLine);
        }
        /// <summary>
        /// Get a `BoundingBox` for this note.
        /// </summary>
        public virtual BoundingBox BoundingBox
        {
            get
            {
                return null;
            }
        }
        public virtual BoundingBox GetBoundingBox()
        {
                return null;
        }
        /// <summary>
        /// Returns the voice that this note belongs in.
        /// Attach this note to `voice`.
        /// </summary>
        public override Voice Voice
        {
            get
            {
                if(this.voice == null)
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
        public override Voice GetVoice()
        {
            if (this.voice == null)
            {
                throw new Exception("NoVoice,Note has no voice.");
            }
            return this.voice;
        }
        public new Note SetVoice(Voice voice)
        {
            this.voice = voice;
            this.preFormatted = false;
            return this;
        }
        #region GetTickContext无法被getter替代比较麻烦需要以后优化
        /// <summary>
        /// Get and set the `TickContext` for this note.
        /// </summary>
        public object GetTickContext()
        {
            return this.tickContext;
        }
        public override TickContext TickContext
        {
            set
            {
                this.tickContext = value;
                this.preFormatted = false;
            }
        }
        #endregion
        /// <summary>
        /// Accessors for the note type.
        /// </summary>
        public object Duration
        {
            get
            {
                return this.duration;
            }
        }
        public bool IsDotted()
        {
            return (this.dots > 0);
        }
        public virtual bool HasStem()
        {
            return false;
        }
        public int Dots
        {
            get
            {
                return this.dots;
            }
        }
        public object NoteType
        {
            get
            {
                return this.noteType;
            }
        }
        public Note SetBeam()
        {
            return this;
        }// ignore parameters
         //非常奇怪的函数。多半没有用。
         /// <summary>
         /// Attach this note to a modifier context.
         /// </summary>
        public ModifierContext ModifierContext
        {
            set
            {
                this.modifierContext = value;
            }
        }
        /// <summary>
        /// Attach a modifier to this note.
        /// </summary>
        public Note AddModifier(Modifier modifier,int? index)
        {
            modifier.Note = this;
            modifier.Index = index ?? 0;
            this.modifiers.Add(modifier);
            this.PreFormatted = false;
            return this;
        }
        /// <summary>
        /// Get the coordinates for where modifiers begin.
        /// </summary>
        public object ModifierStartXY
        {
            get
            {
                if(!this.preFormatted)
                {
                    throw new Exception("UnformattedNote,Can't call GetModifierStartXY on an unformatted note");
                }
                return new NoteModifierStartXY() {
                    x = this.AbsoluteX,
                    y = this.ys[0]
                };//匿名对象类型不安全需要根据ModifierStartXY的使用情况优化。
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
        public NoteMetrics Metrics
        {
            get
            {
                if(!this.preFormatted)
                {
                    throw new Exception("UnformattedNote,Can't call getMetrics on an unformatted note.");
                }
                double modLeftPx = 0;
                double modRightPx = 0;
                if(this.modifierContext != null)
                {
                    modLeftPx = this.modifierContext.state.leftShift;
                    modRightPx = this.modifierContext.state.rightShift;
                }
                double width = this.Width;
                return new NoteMetrics() {
                    width = width,
                    noteWidth = width -
                                modLeftPx - modRightPx - // used by accidentals and modifiers
                                        this.extraLeftPx - this.extraRightPx,
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
                if(!this.preFormatted)
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
                if(this.tickContext == null)
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
                if(this.tickContext == null)
                {
                    throw new Exception("NoTickContext,Note needs a TickContext assigned for an X-Value");
                }
                double x = this.tickContext.X;
                if(this.stave != null)
                {
                    x += this.stave.GetNoteStartX() + this.renderOptions.stavePadding;
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
                if(this.preFormatted)
                {
                    TickContextExtraPx extra = this.tickContext.ExtraPx;
                    this.leftModPx = Math.Max(this.leftModPx,extra.left);
                    this.rightModPx = Math.Max(this.rightModPx,extra.right);
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
        protected Glyph4Note glyph;
        protected IList<double> ys;
        protected IList<object> positions;
        protected string duration;//里程碑2阶段duration改用Fraction类型。
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
        public abstract string GetCategory();
        #endregion
    }
}
