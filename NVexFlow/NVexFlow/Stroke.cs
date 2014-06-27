using System.Collections.Generic;

namespace NVexFlow
{
    public partial class Vex
    {
        public partial class Flow
        {
            public class Stroke : Modifier
            {

                #region 属性字段

                object note_end;

                public object EndNote
                {
                    set { note_end = value; }
                }

                IList<object> options;
                object note;
                object index;
                Modifier.ModifierPosition position;
                object type;
                Font font;
                object renderOptions;
                double width;
                double xShift;

                public enum StrokeType
                {
                    BRUSH_DOWN,
                    BRUSH_UP,
                    ROLL_DOWN,        // Arpegiated chord
                    ROLL_UP,          // Arpegiated chord
                    RASQUEDO_DOWN,
                    RASQUEDO_UP
                }


                #endregion


                #region 方法
                public Stroke(object type, IList<object> options)
                { Init(type, options); }


                public void Init(object type, IList<object> options)
                { }


                public void Draw()
                { }
                #endregion
            }
        }
    }
}
