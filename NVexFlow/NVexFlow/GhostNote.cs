// 对应 ghostnote.js
using System;
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
    public class GhostNote:StemmableNote
    {
        #region js直译部分
        public GhostNote(NoteStruct duration)
            : base(duration)
        {
            // Sanity check
            if(duration == null)
            {
                throw new Exception("BadArguments,Ghost note must have valid initialization data to identify duration.");
            }
            Init();
        }
        //里程碑2时取消字符串duration构造函数
        // Preserve backwards-compatibility
        public GhostNote(string duration)
            : base(new NoteStruct() { duration = duration })
        {
            // Sanity check
            if(duration == null)
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
        //原js中实现很诡异，里程碑2时考虑去掉子类中没有必要的重复。
        public override Stave Stave
        {
            set
            {
                base.stave = value;
            }
        }
        public new GhostNote SetStave(Stave stave)
        {
            base.stave = stave;//建议修改成base.SetStave(stave);
            return this;
        }
        //注意和原js的对应，虽然是个诡异的无参数形式。
        public GhostNote AddToModifierContext()
        {
            /* intentionally overridden */
            return this;
        }
        public new GhostNote PreFormat()
        {
            this.PreFormatted = true;
            return this;
        }
        public override void Draw()
        {

        }
        #endregion


        #region 隐含字段

        #endregion
    }
}
