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
            this.graceNotes = graceNotes;
            this.width = 0;

            this.preFormatted = false;

            this.showSlur = showSlur;
            this.slur = null;

            this.formatter = new Formatter();
            this.voice = new Voice(new VoiceTimeModel() {
                numBeats = 4,
                numValue = 4,
                resolution = Flow.RESOLUTION
            });
            this.voice.Strict = false;
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
            this.Width = this.formatter.MinTotalWidth;
            this.preFormatted = true;
        }
        public GraceNoteGroup BeamNotes()
        {
            if(this.graceNotes.Count > 1)
            {
                Beam beam = new Beam(this.graceNotes);
                beam.RenderOptions = new BeamRenderOpts() {
                    beamWidth = 3,
                    partialBeamLength = 4
                };
                this.beam = beam;
            }
            return this;
        }
        public override Note Note
        {
            set
            {
                this.Note = value;
            }
        }
        public override string Category
        {
            get
            {
                return "gracenotegroups";
            }
        }
        public override double Width
        {
            get
            {
                return this.width;
            }
            set
            {
                this.width = value;
            }
        }
        public override double XShift
        {
            set
            {
                this.xShift = value;
            }
        }
        public override void Draw()
        {
            throw new NotImplementedException();
        }
        #endregion

        #region 隐含的字段
        protected bool preFormatted;
        protected Beam beam;
        protected IList<StemmableNote> graceNotes;
        protected bool showSlur;
        protected object slur;
        protected Formatter formatter;
        protected Voice voice;
        #endregion
    }
}
