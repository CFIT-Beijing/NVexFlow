using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NVexFlow
{//GraceNoteGroup
    public partial class Vex
    {
        public partial class Flow
        {
            public class GraceNoteGroup:Modifier
            {
                #region 属性字段
                private bool preFormatted;
                private object beam;
                Modifier.ModifierPosition position;
                object note;
                object index;
                object graceNotes;
                double width;
                object showSlur;
                object slur;
                Formatter formatter;
                object voice;


                #endregion


                #region 方法
                public GraceNoteGroup(IList<object> grace_notes, object config)
                { }

                public void Init(IList<object> grace_notes, object show_slur)
                { }



                public void PreFormat()
                { }

                public GraceNoteGroup BeamNotes()
                {
                    return this;
                }


                public void Draw()
                { } 
                #endregion
            }
        }
    }
}
