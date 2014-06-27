using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NVexFlow
{
    public partial class Vex
    {
        public partial class Flow
        {
            public class Tuplet
            {
                public static int LOCATION_TOP = 1;
                public static int LOCATION_BOTTOM = -1;

                public Tuplet(IList<object> notes,IList<object> options)
                { }

                public void Init(IList<object> notes, IList<object> options)
                { }

                public void Attach()
                { }

                public void Detach()
                { }

                object context;

                public object Context
                {
                    set { context = value; }
                }

                bool bracketed;

                public bool Bracketed
                {
                    set { bracketed = value; }
                }

                bool ratioed;

                public bool Ratioed
                {
                    get { return ratioed; }
                    set { ratioed = value; }
                }

                object location;

                public object TupletLocation
                {
                    set { location = value; }
                }

                IList<object> notes;

                public IList<object> Notes
                {
                    get { return notes; }
                    set { notes = value; }
                }
                int num_notes;

                public int NotesCount
                {
                    get { return num_notes; }
                    set { num_notes = value; }
                }

                object beats_occupied;

                public object Beats_occupied
                {
                    get { return beats_occupied; }
                    set { 
                        //
                        beats_occupied = value; }
                }

                public void ResolveGlyphs()
                { }

                public void Draw()
                { }
            }
        }
    }
}
