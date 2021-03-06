﻿//对应 strokes.js
using System;
using NVexFlow.Model;
namespace NVexFlow
{
    /// <summary>
    /// Class implements chord strokes - arpeggiated, brush & rasquedo.
    /// </summary>
    public class Stroke:Modifier
    {
        #region js直译部分
        public Stroke(StrokeType type,StrokeOptions options)
        {
            Init(type,options);
        }
        public enum StrokeType
        {
            BRUSH_DOWN = 1,
            BRUSH_UP = 2,
            ROLL_DOWN = 3,    // Arpegiated chord
            ROLL_UP = 4,          // Arpegiated chord
            RASQUEDO_DOWN = 5,
            RASQUEDO_UP = 6
        }
        private void Init(StrokeType type,StrokeOptions options)
        {
            this.note = null;
            this.options = options;

            // multi voice - span stroke across all voices if true
            if(options.all_voices.HasValue)
            {
                this.all_voices = this.options.all_voices;
            }
            else
            {
                this.all_voices = true;
            }

            //  multi voice - end note of stroke, set in draw()
            this.note_end = null;
            this.index = null;
            this.type = type;
            this.position = Modifier.ModifierPosition.LEFT;

            this.render_options = new RenderOptions() {
                font_scale = 38,
                stroke_px = 3,
                stroke_spacing = 10
            };

            this.font = new Font() {
                family = "serif",
                size = 10,
                weight = "bold italic"
            };

            this.SetXShift(0);
            this.SetWidth(10);
        }
        public override string GetCategory()
        {
            return "strokes";
        }
        public override Modifier.ModifierPosition GetPosition()
        {
            return this.position;
        }
        public Stroke SetEndNote(object note)
        {
            note_end = note;
            return this;
        }
        public override void Draw()
        {
            throw new NotImplementedException();
        }
        #endregion
        #region 隐含的字段
        public object note_end;
        public StrokeOptions options;
        public bool? all_voices;
        public StrokeType type;
        public RenderOptions render_options;
        #endregion
    }
}
