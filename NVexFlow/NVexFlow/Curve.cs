using System.Collections.Generic;

namespace NVexFlow
{//Curve
    public partial class Vex
    {
        public partial class Flow
        {
            public class Curve
            {
                public enum CurvePosition
                {
                    NEAR_HEAD,
                    NEAR_TOP
                }
                public Curve(object from, object to, IList<object> options)
                { }

                private void Init(object from, object to, IList<object> options)
                {

                }

                private object context;

                public object Context
                {
                    set { context = value; }
                }

                private object from;
                private object to;
                public Curve SerNotes(object from, object to)
                {
                    if (from == null && to == null)
                    {
                        //vex.runTimeError..................
                    }
                    this.from = from;
                    this.to = to;
                    return this;
                }

                public bool IsPartial()
                {
                    if (this.from == null && this.to == null)
                    {
                        return true;
                    }
                    return false;
                }

                public void RenderCurve(IList<object> @params)
                { }

                public void Draw()
                { }
            }
        }
    }
}
