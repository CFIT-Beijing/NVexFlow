//对应 gracenotegroup.js
using System;
using System.Collections.Generic;
using NVexFlow.Model;
using System.Linq;
namespace NVexFlow
{
    public class GraceNoteGroup:Modifier
    {
        #region js直译部分
        public GraceNoteGroup(IList<StemmableNote> graceNotes, bool config)
        {
            Init(graceNotes,config);
        }
        private void Init(IList<StemmableNote> graceNotes, bool showSlur)
        {
            this.note = null;
            this.index = null;
            this.position = ModifierPosition.LEFT;
            this.grace_notes = graceNotes;
            this.width = 0;

            this.preFormatted = false;

            this.show_slur = showSlur;
            this.slur = null;

            this.formatter = new Formatter();
            this.voice = new Voice(new VoiceTime() {
                num_beats = 4,
                beat_value = 4,
                resolution = Flow.RESOLUTION
            });
            this.voice.SetStrict(false);
            this.voice.AddTickables(graceNotes);
        }
        public void PreFormat()
        {
            if(this.preFormatted)
            {
                return;
            }
            this.formatter.JoinVoices(new List<Voice>() { this.voice })
                .Format(new List<Voice>() { this.voice },0);
            this.SetWidth(this.formatter.MinTotalWidth);
            this.preFormatted = true;
        }
        public GraceNoteGroup BeamNotes()
        {
            if(this.grace_notes.Count > 1)
            {
                Beam beam = new Beam(this.grace_notes);
                beam.render_options = new BeamRenderOpts() {
                    beam_width = 3,
                    partial_beamLength = 4
                };
                this.beam = beam;
            }
            return this;
        }
        public new GraceNoteGroup SetNote(Note note)
        {
            this.note = note;
            return this;
        }
        public override string GetCategory()
        {
            return "gracenotegroups";
        }
        public override double GetWidth()
        {
            return this.width;
        }
        public new GraceNoteGroup SetWidth(double width)
        {
            this.width = width;
            return this;
        }
        public new GraceNoteGroup SetXShift(int xShift)
        {
            this.x_shift = xShift;
            return this;
        }
        public override void Draw()
        {
            throw new NotImplementedException();
        }
        #endregion

        #region 隐含的字段
        public bool preFormatted;
        public Beam beam;
        public IList<StemmableNote> grace_notes;
        public bool show_slur;
        public object slur;
        public Formatter formatter;
        public Voice voice;
        #endregion
    }
}
