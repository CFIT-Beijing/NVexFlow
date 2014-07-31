////对应 stemmablenote.js
using NVexFlow.Model;
namespace NVexFlow
{//StemmableNote
    public partial class Vex
    {
        public partial class Flow
        {
            /// <summary>
            /// ## Description
            //
            // `StemmableNote` is an abstract interface for notes with optional stems. 
            // Examples of stemmable notes are `StaveNote` and `TabNote`
            /// </summary>
            public class StemmableNote : Note
            {
                #region js直译部分
                public StemmableNote(NoteStruct note_struct)
                    : base(note_struct)
                {
                    Init(note_struct);
                }
                private void Init(NoteStruct note_struct)
                {

                }
                public object Stem
                {
                    get { return stem; }
                    set { stem = value; }
                }

                public StemmableNote PostFormat()
                {
                    return this;
                }

                public virtual void DrawStem()
                { }
                #endregion


                #region 隐含字段
                protected object stem;



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

                public override string Category
                {
                    get { throw new System.NotImplementedException(); }
                }
                #endregion
            }
        }

    }
}
