using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NVexFlow
{//StaveHairpin
    public partial class Vex
    {
        public partial class Flow
        {
            public class StaveHairpin
            {
                public StaveHairpin(IList<object> notes,object type)
                {
                    Init(notes, type);
                }

                public enum StaveHairpinType
                {
                    CRESC,
                    DECRESC
                }

                public static void FormatByTicksAndDraw(object ctx, object formatter, IList<object> notes, object type, object position, IList<object> options)
                { }

                public void Init(IList<object> notes, object type)
                { }

                object context;

                public object Context
                {
                    set { context = value; }
                }

                Modifier.ModifierPosition position;

                public Modifier.ModifierPosition Position
                {
                    set {
                        if (value == Modifier.ModifierPosition.ABOVE || value == Modifier.ModifierPosition.BELOW)
                        {
                            position = value;
                        }
                    }
                }

                object renderOptions;

                public object RenderOptions
                {

                    set { 
                        //需要重写
                        renderOptions = value; 
                    }
                }

                IList<object> notes;

                public IList<object> Notes
                {
                    set {
                        //需要重写
                        notes = value; 
                    }
                }

                public void RenderHairpin(IList<object> @params)
                { }

                public void Draw()
                { }
            }
        }
    }
}
