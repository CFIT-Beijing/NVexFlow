using System.Collections.Generic;
using NVexFlow.Model;

namespace NVexFlow
{
    public partial class Vex
    {
        public partial class Flow
        {
            public class Beam
            {
                BeamRenderOpts renderOptions;

                public BeamRenderOpts RenderOptions
                {
                    get { return renderOptions; }
                    set { renderOptions = value; }
                }
                object context;

                public object Context
                {
                    set { context = value; }
                }

                IList<object> notes;

                public IList<object> Notes
                {
                    get { return notes; }
                }

                object breakOnIndices;



                public Beam(IList<Tickable> notes, bool? autoStem=null)
                {
                    Init(notes, autoStem);
                }

                private void Init(IList<Tickable> notes, bool? autoStem)
                { }

                public object GetBeamCount()
                {
                    return null;
                }

                public Beam BreakSecondaryAt(object indices)
                {
                    this.breakOnIndices = indices;
                    return this;
                }

                public double GetSlopeY(double x, double first_x_px, double first_y_px, object slope)
                {
                    return 0;
                }

                public void CalculateSlope()
                { }


                public void ApplyStemExtensions()
                { }


                public object GetBeamLines(object duration)
                { return null; }

                public Beam PreFormat()
                {
                    return this;
                }

                public void DrawStems()
                { }


                public void DrawBeamLines()
                { }

                public void PostFormat()
                { }

                public void Draw()
                { }

                public static object GetDefaultBeamGroups(object timeSig)
                {
                    return null;
                }


                public static object ApplyAndGetBeams(object voice, object stemDirection, IList<object> groups)
                {
                    return null;
                }

                public static IList<Beam> GenerateBeams(IList<object> notes, object config)
                {
                    return null;
                }


            }
        }
    }
}
