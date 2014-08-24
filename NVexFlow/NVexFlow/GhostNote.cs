using System;
////对应 ghostnote.js
using NVexFlow.Model;
namespace NVexFlow
{
    /// <summary>
    ///Vex Flow Notation
    // Mohit Muthanna <mohit@muthanna.com>
    //
    // Copyright Mohit Muthanna 2010
    //
    // Requires vex.js.
    /// </summary>
    public class GhostNote : StemmableNote
    {
        #region js直译部分
        public GhostNote(NoteStruct duration)
            : base(duration)
        {
            // Sanity check
            if (duration == null)
            {
                throw new Exception("BadArguments,Ghost note must have valid initialization data to identify duration.");
            }
            Init();
        }
        public GhostNote(string duration)
            : base(new NoteStruct() { duration = duration })
        {
            // Sanity check
            if (duration == null)
            {
                throw new Exception("BadArguments,Ghost note must have valid initialization data to identify duration.");
            }
            Init();
        }
        private void Init()
        {
            // Note properties
            this.SetWidth(0);
        }
        public override bool IsRest()
        {
            return true;
        }
        public override Stave Stave
        {
            set
            {
                base.stave = value;
            }
        }
        public new GhostNote AddToModifierContext(ModifierContext mc)
        {
            /* intentionally overridden */
            return this;
        }
        public new GhostNote PreFormat()
        {
            this.PreFormatted = true;
            return this;
        }
        public void Draw()
        {

        }
        #endregion


        #region 隐含字段

        #endregion
    }
}
