using System.Collections.Generic;

namespace NVexFlow
{//StaveTie
    public partial class Vex
    {
        public partial class Flow
        {
            public class StaveTie
            {

                #region 属性字段
                object context;

                public object Context
                {
                    get { return context; }
                    set { context = value; }
                }

                object text;
                IList<object> renderOptions;
                Font font;

                public Font Font
                {
                    get { return font; }
                    set { font = value; }
                }

                IList<object> notes;

                public IList<object> Notes
                {
                    get { return notes; }
                    set
                    {
                        //............................
                        notes = value;

                        //                        if (!notes.first_note && !notes.lastNote)
                        //  throw new Vex.RuntimeError("BadArguments",
                        //      "Tie needs to have either first_note or lastNote set.");

                        //if (!notes.first_indices) notes.first_indices = [0];
                        //if (!notes.last_indices) notes.last_indices = [0];

                        //if (notes.first_indices.length != notes.last_indices.length)
                        //  throw new Vex.RuntimeError("BadArguments", "Tied notes must have similar" +
                        //    " index sizes");

                        //// Success. Lets grab 'em notes.
                        //this.first_note = notes.first_note;
                        //this.first_indices = notes.first_indices;
                        //this.lastNote = notes.lastNote;
                        //this.last_indices = notes.last_indices;
                    }
                }

                private object first_note;
                private object last_note;

                public bool IsPartial()
                {
                    if (this.first_note == null && this.last_note == null)
                    { return true; }
                    return false;
                }
                #endregion


                #region 方法


                public StaveTie(IList<object> notes, string text)
                {
                    /**
     * Notes is a struct that has:
     *
     *  {
     *    first_note: Note,
     *    lastNote: Note,
     *    first_indices: [n1, n2, n3],
     *    last_indices: [n1, n2, n3]
     *  }
     *
     **/
                }

                public virtual void Init(IList<object> notes, string text)
                {

                }


                public void RenderTie(IList<object> @params)
                { }

                public void RenderText(double first_x_px, double last_x_px)
                { }

                public void Draw()
                { }
                #endregion
            }
        }

    }
}
