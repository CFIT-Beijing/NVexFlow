using System.Collections.Generic;
using NVexFlow.Model;
using System.Linq;
namespace NVexFlow
{//GraceNoteGroup
    public partial class Vex
    {
        public partial class Flow
        {
            public class GraceNoteGroup : Modifier
            {
                #region 方法
                public GraceNoteGroup(IList<Tickable> graceNotes, bool config)
                {
                    Init(graceNotes, config);
                }

                public void Init(IList<Tickable> graceNotes, bool showSlur)
                {
                    this.note = null;
                    this.index = null;
                    this.position = Vex.Flow.Modifier.ModifierPosition.LEFT;
                    this.graceNotes = graceNotes;
                    this.width = 0;

                    this.preFormatted = false;

                    this.showSlur = showSlur;
                    this.slur = null;

                    this.formatter = new Vex.Flow.Formatter();
                    this.voice = new Vex.Flow.Voice(new VoiceTimeModel()
                    {
                        NumBeats = 4,
                        NumValue = 4,
                        Resolution = Vex.Flow.RESOLUTION
                    });
                    this.voice.Strict = false;
                    this.voice.AddTickables(graceNotes);
                }



                public void PreFormat()
                {
                    if (this.preFormatted)
                    {
                        return;
                    }
                    this.formatter.JoinVoices(new List<Voice>() { this.voice }).Format(new List<Voice>() { this.voice }, 0, null);
                    base.Width = this.formatter.MinTotalWidth;

                    this.preFormatted = true;
                }

                public GraceNoteGroup BeamNotes()
                {
                    if (this.graceNotes.Count() > 1)
                    {
                        Beam beam = new Beam(this.graceNotes, null);
                        beam.RenderOptions = new BeamRenderOptions()
                        {
                            BeamWidth = 3,
                            PartialBeamLength = 4
                        };
                        this.beam = beam;
                    }
                    return this;
                }


                public override void Draw()
                { }
                #endregion


                #region 属性字段
                public override Note Note
                {
                    set
                    {
                        this.Note = value;
                    }
                }
                Note note;


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
                double width;


                public override double XShift
                {
                    set
                    {
                        this.xShift = value;
                    }
                }
                double xShift;



                private bool preFormatted;
                private Beam beam;
                Modifier.ModifierPosition position;
                object index;
                IList<Tickable> graceNotes;             
                bool showSlur;
                object slur;
                Formatter formatter;
                Voice voice;


                #endregion



            }
        }
    }
}
