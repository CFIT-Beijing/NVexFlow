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
            this.note_type = initData.type;
            this.SetIntrinsicTicks(initData.ticks); 
            this.modifiers = new List<Modifier>();
            // Get the glyph code for this note from the font.
            this.glyph = Flow.DurationToGlyph(this.duration,this.note_type);
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
            this.play_note = null;
            // Positioning contexts used by the Formatter.
            this.tick_context = null;    // The current tick context.
            this.modifier_context = null;
            this.ignore_ticks = false;
            // Positioning variables
            this.width = 0;             // Width in pixels calculated after preFormat
            this.extra_left_px = 0;       // Extra room on left for offset note head
            this.extra_right_px = 0;      // Extra room on right for offset note head
            this.x_shift = 0;           // X shift from tick context X
            this.left_mod_px = 0;        // Max width of left modifiers
            this.right_mod_px = 0;       // Max width of right modifiers
            this.voice = null;          // The voice that this note is in
            this.preFormatted = false;  // Is this note preFormatted?
            this.ys = new List<double>();               // list of y coordinates for each note
                                                        // we need to hold on to these for ties and beams.
                                                        // The render surface.
            this.context = null;
            this.stave = null;
            this.render_options = new NoteRenderOpts() {
                annotation_spacing = 5,
                stave_padding = 12
            };
        }
        /// <summary>
        /// Get and set the play note, which is arbitrary data that can be used by an audio player.
        /// </summary>
        public virtual object GetPlayNote()
        {
            return this.play_note;
        }
        public Note SetPlayNote(object playNote)
        {
            this.play_note = playNote;
            return this;
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
            stroke.SetNote(this);
            stroke.SetIndex(index);
            this.modifiers.Add(stroke);
            this.SetPreFormatted(false);
            return this;
        }
        /// <summary>
        /// Get and set the target stave.
        /// </summary>
        public virtual Stave GetStave()
        { return this.stave; }
        public virtual Note SetStave(Stave stave)
        {
            this.stave = stave;
            this.SetYs(new List<double>() { stave.GetYForLine(0) });// Update Y values if the stave is changed.
            this.context = this.stave.context;
            return this;
        }
        /// <summary>
        /// Set the rendering context for the note.
        /// </summary>
        public new Note SetContext(CanvasContext context)
        {
            this.context = context;
            return this;
        }
        /// <summary>
        /// Get and set spacing to the left and right of the notes.
        /// </summary>
        public virtual double GetExtraLeftPx()
        {
            return this.extra_left_px; 
        }
        public Note SetExtraLeftPx(double extraLeftPx)
        {
            this.extra_left_px = extraLeftPx;
            return this;
        }
        public virtual double GetExtraRightPx()
        {
            return this.extra_right_px;
        }
        public Note SetExtraRightPx(double extraRightPx)
        {
            this.extra_right_px = extraRightPx;
            return this;
        }
        /// <summary>
        /// Returns true if this note has no duration (e.g., bar notes, spacers, etc.)
        /// </summary>
        /// <returns></returns>
        public bool ShouldIgnoreTicks()
        {//不增加override或new关键词以提示潜在重复implement
                return this.ignore_ticks;
        }
        /// <summary>
        /// Get the stave line number for the note.
        /// </summary>
        public int GetLineNumber()
        {
            return 0;
        }
        /// <summary>
        /// Get the stave line number for rest.
        /// </summary>
        public virtual double GetLineForRest()
        {
            return 0;
        }
        /// <summary>
        /// Get the glyph associated with this note.
        /// </summary>
        public virtual Glyph4Note GetGlyph()
        {
            return this.glyph;
        }
        /// <summary>
        /// Set and get Y positions for this note. Each Y value is associated with an individual pitch/key within the note/chord.
        /// </summary>
        public IList<double> GetYs()
        {
            if (this.ys.Count <= 0)
            {
                throw new Exception("NoYValues,No Y-values calculated for this note.");
            }
            return ys;
        }
        public Note SetYs(IList<double> ys)
        {
            this.ys = ys;
            return this;
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
        public override BoundingBox GetBoundingBox()
        {
                return null;
        }
        /// <summary>
        /// Returns the voice that this note belongs in.
        /// Attach this note to `voice`.
        /// </summary>
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
        public TickContext GetTickContext()
        {
            return this.tick_context;
        }
        public new Note SetTickContext(TickContext tickContext)
        {
            this.tick_context = tickContext;
            this.preFormatted = false;
            return this;
        }
        #endregion
        /// <summary>
        /// Accessors for the note type.
        /// </summary>
        public string GetDuration()
        {
            return this.duration;
        }
        public bool IsDotted()
        {
            return (this.dots > 0);
        }
        public virtual bool HasStem()
        {
            return false;
        }
        public int GetDots()
        {
            return this.dots;
        }
        public string GetNoteType()
        {
            return this.note_type;
        }
        public Note SetBeam()
        {
            return this;
        }// ignore parameters
         //非常奇怪的函数。多半没有用。
         /// <summary>
         /// Attach this note to a modifier context.
         /// </summary>
        public new Note SetModifierContext(ModifierContext modifierContext)
        {
            this.modifier_context = modifierContext;
            return this;
        }
        /// <summary>
        /// Attach a modifier to this note.
        /// </summary>
        public Note AddModifier(Modifier modifier,int? index)
        {
            modifier.SetNote(this);
            modifier.SetIndex(index ?? 0);
            this.modifiers.Add(modifier);
            this.SetPreFormatted(false);
            return this;
        }
        /// <summary>
        /// Get the coordinates for where modifiers begin.
        /// </summary>
        public NoteModifierStartXY GetModifierStartXY()
        {
            if (!this.preFormatted)
            {
                throw new Exception("UnformattedNote,Can't call GetModifierStartXY on an unformatted note");
            }
            return new NoteModifierStartXY()
            {
                x = this.GetAbsoluteX(),
                y = this.ys[0]
            };//匿名对象类型不安全需要根据ModifierStartXY的使用情况优化。
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
        public NoteMetrics GetMetrics()
        {
            if (!this.preFormatted)
            {
                throw new Exception("UnformattedNote,Can't call getMetrics on an unformatted note.");
            }
            double modLeftPx = 0;
            double modRightPx = 0;
            if (this.modifier_context != null)
            {
                modLeftPx = this.modifier_context.state.left_shift;
                modRightPx = this.modifier_context.state.right_shift;
            }
            double width = this.GetWidth();
            return new NoteMetrics()
            {
                width = width,
                note_width = width -
                            modLeftPx - modRightPx - // used by accidentals and modifiers
                                    this.extra_left_px - this.extra_right_px,
                left_shift = this.x_shift,// TODO(0xfe): Make style consistent
                mod_left_px = modLeftPx,
                mod_right_px = modRightPx,
                extra_left_px = this.extra_left_px,
                extra_right_px = this.extra_right_px
            };
        }
        /// <summary>
        /// Get and set width of note. Used by the formatter for positioning.
        /// </summary>
        public override double GetWidth()
        {
            if (!this.preFormatted)
            {
                throw new Exception("UnformattedNote,Can't call GetWidth on an unformatted note.");
            }
            return this.width + (this.modifier_context != null ? this.modifier_context.Width : 0);
        } 
        public new Note SetWidth(double width)
        {
            this.width = width;
            return this;
        }
        /// <summary>
        /// Displace note by `x` pixels.
        /// </summary>
        public new Note SetXShift(double x)
        {
            this.x_shift = x;
            return this;
        }
        /// <summary>
        /// Get `X` position of this tick context.
        /// </summary>
        public virtual double GetX()
        {
            if (this.tick_context == null)
            {
                throw new Exception("NoTickContext,Note needs a TickContext assigned for an X-Value");
            }
            return this.tick_context.X + this.x_shift;
        }
        /// <summary>
        /// Get the absolute `X` position of this note relative to the stave.
        /// </summary>
        public virtual double GetAbsoluteX()
        {
            if (this.tick_context == null)
            {
                throw new Exception("NoTickContext,Note needs a TickContext assigned for an X-Value");
            }
            double x = this.tick_context.X;
            if (this.stave != null)
            {
                x += this.stave.GetNoteStartX() + this.render_options.stave_padding;
            }
            return x;
        }
        public Note SetPreFormatted(bool preFormatted)
        {
            this.preFormatted = preFormatted;
            // Maintain the width of left and right modifiers in pixels.
            if (this.preFormatted)
            {
                TickContextExtraPx extra = this.tick_context.ExtraPx;
                this.left_mod_px = Math.Max(this.left_mod_px, extra.left);
                this.right_mod_px = Math.Max(this.right_mod_px, extra.right);
            }
            return this;
        }
        #endregion

        #region 隐含字段
        public double x;
        public double left_mod_px;
        public double right_mod_px;
        public object play_note;
        public Stave stave;
        public double extra_left_px;
        public double extra_right_px;
        public object line_number;
        public object line_for_rest;
        public Glyph4Note glyph;
        public IList<double> ys;
        public IList<object> positions;
        public string duration;//里程碑2阶段duration改用Fraction类型。
        public int dots;
        public string note_type;
        public NoteRenderOpts render_options;
        #endregion
    }
}
