using System.Collections.Generic;
using NVexFlow.Model;

namespace NVexFlow
{
    public partial class Vex
    {
        public partial class Flow
        {
            /// <summary>
            /// Class implements chord strokes - arpeggiated, brush & rasquedo.
            /// </summary>
            public class Stroke : Modifier
            {
                #region 方法
                public Stroke(StrokeType type, StrokeOptions options)
                {
                    Init(type, options);
                }


                public void Init(StrokeType type, StrokeOptions options)
                {
                    this.note = null;
                    this.options = options;
                    // multi voice - span stroke across all voices if true

                    if (options.AllVoices!=null)
                    {
                        this.allVoices = this.options.AllVoices;
                    }
                    else
                    {
                        this.allVoices = true;
                    }


                    //  multi voice - end note of stroke, set in draw()
                    this.noteEnd = null;
                    this.index = null;
                    this.type = type;
                    this.position = Modifier.ModifierPosition.LEFT;


                    this.renderOptions = new RenderOptions()
                    {
                        FontScale = 38,
                        StrokePx = 3,
                        StrokeSpacing = 10
                    };


                    this.font = new Font()
                    {
                        Family = "serif",
                        Size = 10,
                        Weight = "bold italic"
                    };

                    base.XShift = 0;
                    base.Width = 10;
                }


                public override void Draw()
                { }
                #endregion


                #region 枚举
                public enum StrokeType
                {
                    BRUSH_DOWN = 1,
                    BRUSH_UP = 2,
                    ROLL_DOWN = 3,    // Arpegiated chord
                    ROLL_UP = 4,          // Arpegiated chord
                    RASQUEDO_DOWN = 5,
                    RASQUEDO_UP = 6
                } 
                #endregion


                #region 属性字段
                public override Modifier.ModifierPosition Position
                {
                    get
                    {
                        return this.Position;
                    }
                }
                Modifier.ModifierPosition position;

                public object AddEndNote
                {
                    set { noteEnd = value; }
                }
                object noteEnd;

                StrokeOptions options;
                bool? allVoices;
                Note note;
                object index;
                
                StrokeType type;
                Font font;
                RenderOptions renderOptions;




                #endregion



            }
        }
    }
}
