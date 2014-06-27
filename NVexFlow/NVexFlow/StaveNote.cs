using System.Collections.Generic;

namespace NVexFlow
{//StaveNote
    public partial class Vex
    {
        public partial class Flow
        {
            public class StaveNote : StemmableNote
            {
                #region 静态
                public static int STEM_UP = Vex.Flow.Stem.UP;
                public static int STEM_DOWN = Vex.Flow.Stem.Down;
                #endregion


                #region 属性字段
                object clef;
                object beam;
                object glyph;
                double dotShiftY;
                double useDefaultHeadX;
                IList<object> noteHeads;
                IList<object> modifiers;
                object glyphRest;
                object glyphStem;
                IList<object> keys;
                IList<object> keyProps;
                bool displaced;
                public bool Displaced
                {
                    get { return displaced; }
                    set { displaced = value; }
                }

                public IList<object> KeyProps
                {
                    get { return keyProps; }
                }

                public IList<object> Keys
                {
                    get { return keys; }
                }

                public override Stave Stave
                {
                    //get
                    //{
                    //    return base.Stave;
                    //}
                    set
                    {
                        base.Stave = value;
                    }
                }
                #endregion


                #region 方法

                public StaveNote(object note_struct)
                    : base(note_struct)
                {

                    Init(note_struct);

                }

                public override void Init(object note_struct)
                {

                }

                public void BuildStem()
                { }

                public void BuildNoteHeads()
                { }

                public void AutoStem()
                { }

                public void CalculateKeyProps()
                { }

                public BoundingBox GetBoundingBox()
                {
                    return null;
                }

                public object GetLineNumber(object is_top_note)
                {
                    return null;
                }

                public object IsRest() { return this.glyphRest; }

                public bool IsChord()
                {
                    return false;
                }

                public object HasStem()
                {
                    return this.glyphStem;
                }

                public override double GetYForTopText(object text_line)
                {
                    return 0;
                }

                public double GetYForBottomText(object text_line)
                {
                    return 0;
                }



                public double GetTieRightX()
                {
                    return 0;
                }

                public double GetTieLeftX()
                {
                    return 0;
                }

                public object GetLineForRest()
                {
                    return null;
                }

                public object GetModifierStartXY(object position, object index)
                {
                    return null;
                }

                public StaveNote SetKeyStyle(object index, object style)
                {
                    return this;
                }

                public override Tickable AddModifier(object mod)
                {
                    return null;
                }

                public StaveNote AddModifier(object index, object modifier)
                {
                    return null;
                }

                public StaveNote AddAccidental(object index, object accidental)
                {
                    return this.AddModifier(index, accidental);
                }

                public StaveNote AddArticulation(object index, object articulation)
                {
                    return this.AddModifier(index, articulation);
                }

                public StaveNote AddAnnotation(object index, object annotation)
                {
                    return this.AddModifier(index, annotation);
                }

                public StaveNote AddDot(object index)
                {
                    return null;
                }

                public StaveNote AddDotToAll()
                {
                    return null;
                }

                public object GetAccidentals()
                {
                    return null;
                }

                public object GetDots()
                {
                    return null;
                }

                public double GetVoiceShiftWidth()
                {
                    return 0;
                }

                public void CalcExtraPx()
                { }

                public override void PreFormat()
                {
                    base.PreFormat();
                }

                public object GetNoteHeadBounds()
                {
                    return null;
                }

                public double GetNoteHeadBeginX()
                {
                    return 0;
                }

                public double GetNoteHeadEndX()
                {
                    return 0;
                }

                public void DrawLedgerLines()
                { }

                public void DrawModifiers()
                { }

                public void DrawFlag()
                { }

                public void DrawNoteHeads()
                { }

                public void DrawStem()
                { }



                public void Draw()
                { }
                #endregion
            }
        }
    }
}
