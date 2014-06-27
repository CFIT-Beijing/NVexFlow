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

            public class Voice
            {
                public enum VoiceMode
                {
                    STRICT,
                    SOFT,
                    FULL
                }
                public Voice(object time)
                { Init(time); }

                public void Init(object time)
                { }

                IList<object> totalTicks;

                public IList<object> TotalTicks
                {
                    get { return totalTicks; }
                }

                object ticksUsed;

                public object TicksUsed
                {
                    get { return ticksUsed; }
                }

                double largestTickWidth;

                public double LargestTickWidth
                {
                    get { return largestTickWidth; }
                }

                object smallestTickCount;

                public object SmallestTickCount
                {
                    get { return smallestTickCount; }
                }

                IList<object> tickables;

                public IList<object> Tickables
                {
                    get { return tickables; }
                }

                VoiceMode mode;

                public VoiceMode Mode
                {
                    get { return mode; }
                    set { mode = value; }
                }

                object resolutionMultiplier;

                public object ResolutionMultiplier
                {
                    get { return resolutionMultiplier; }
                    set { resolutionMultiplier = value; }
                }

                object actualResolution;

                public object ActualResolution
                {
                    get
                    {
                        //return this.resolutionMultiplier * this.time.resolution; 
                        return actualResolution;
                    }
                }

                object stave;

                public object Stave
                {
                    set
                    {
                        stave = value;
                        this.boundingBox = null;
                    }
                }
                object boundingBox;

                public object BoundingBox
                {
                    get
                    {
                        //
                        return boundingBox;
                    }
                }

                object voiceGroup;

                public object VoiceGroup
                {
                    get
                    {
                        //
                        return voiceGroup;
                    }
                    set
                    {
                        //
                        voiceGroup = value;
                    }
                }

                VoiceMode strict;

                public VoiceMode Strict
                {
                    set
                    {
                        if (value == VoiceMode.STRICT || value == VoiceMode.SOFT)
                        { this.strict = value; }
                    }
                }

                public bool IsComplete()
                {
                    return false;
                }

                public Voice AddTickable(object tickable)
                {
                    return this;
                }

                public Voice AddTickables(IList<object> tickables)
                {
                    return this;
                }

                public void Draw(object context,object stave)
                { }
            }
        }

    }
}
