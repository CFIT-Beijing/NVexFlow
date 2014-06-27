using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZhCJB.VexFlow.CS
{//StemmableNote
    public partial class Vex
    {
        public partial class Flow
        {
            public class StemmableNote : Note
            {

                #region 属性字段
                private object stem;

                public object Stem
                {
                    get { return stem; }
                    set { stem = value; }
                }

                object stemExtensionOverride;

                object stemLength;

                public object StemLength
                {
                    get
                    {
                        //
                        return stemLength;
                    }

                }

                object beamCount;

                public object BeamCount
                {
                    get
                    {
                        //
                        return beamCount;
                    }

                }

                object stemMinumumLength;

                public object StemMinumumLength
                {
                    get
                    {
                        //
                        return stemMinumumLength;
                    }
                }

                object stemDirection;

                public object StemDirection
                {
                    get { return stemDirection; }
                    set
                    {
                        //
                        stemDirection = value;
                    }
                }

                object stemX;

                public object StemX
                {
                    get
                    {
                        //
                        return stemX;
                    }
                }

                object centerGlyphX;

                public object CenterGlyphX
                {
                    get
                    {
                        //
                        return centerGlyphX;
                    }
                }

                double stemExtension;

                public double StemExtension
                {
                    get
                    {
                        //
                        return 0;
                    }

                }

                object stemExtents;

                public object StemExtents
                {
                    get
                    {
                        //
                        return stemExtents;
                    }

                }

                private object beam;

                public object Beam
                {
                    set { beam = value; }
                }

                object yForTopText;

                public object YForTopText
                {
                    get
                    {
                        //
                        return yForTopText;
                    }
                }

                object yForBottomText;

                public object YForBottomText
                {
                    get
                    {
                        //
                        return yForBottomText;
                    }
                } 
                #endregion


                #region 方法
                public StemmableNote(object note_struct)
                    : base(note_struct)
                {
                    Init(note_struct);
                }
                public override void Init(object note_struct)
                {

                }


                public StemmableNote PostFormat()
                {
                    return this;
                }

                public virtual void DrawStem()
                { } 
                #endregion
            }
        }

    }
}
