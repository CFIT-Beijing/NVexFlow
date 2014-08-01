//对应 gracenotegroup.js
//框架：    未完成
//类型定义：存在改进空间
//原js：    存在改进空间
using System;
using System.Collections.Generic;
using NVexFlow.Model;
using System.Linq;
namespace NVexFlow
{
    public partial class Vex
    {
        public partial class Flow
        {
            public class GraceNoteGroup:Modifier
            {
                #region js直译部分
                public GraceNoteGroup(IList<Tickable> graceNotes,bool config)
                {
                    Init(graceNotes,config);
                }
                private void Init(IList<Tickable> graceNotes,bool showSlur)
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
                    this.voice = new Vex.Flow.Voice(new VoiceTimeModel() {
                        numBeats = 4,
                        numValue = 4,
                        resolution = Vex.Flow.RESOLUTION
                    });
                    this.voice.Strict = false;
                    this.voice.AddTickables(graceNotes);
                }
                public void PreFormat()
                {
                    if(this.preFormatted) {
                        return;
                    }
                    this.formatter.JoinVoices(new List<Voice>() { this.voice })
                        .Format(new List<Voice>() { this.voice },0);
                    this.Width = this.formatter.MinTotalWidth;
                    this.preFormatted = true;
                }
                public GraceNoteGroup BeamNotes()
                {
                    if(this.graceNotes.Count > 1) {
                        Beam beam = new Beam(this.graceNotes);
                        beam.RenderOptions = new BeamRenderOpts() {
                            BeamWidth = 3,
                            PartialBeamLength = 4
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
                protected IList<Tickable> graceNotes;
                protected bool showSlur;
                protected object slur;
                protected Formatter formatter;
                protected Voice voice;
                #endregion
            }
        }
    }
}
