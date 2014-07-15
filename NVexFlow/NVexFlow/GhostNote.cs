////对应 ghostnote.js
using NVexFlow.Model;
namespace NVexFlow
{//GhostNote
    public partial class Vex
    {
        public partial class Flow
        {
            public class GhostNote : StemmableNote
            {
                #region 属性字段
                double width;

                public override double Width
                {
                    set
                    {
                        base.Width = value;
                    }
                }


                #endregion


                #region 方法
                public GhostNote(NoteStruct duration)
                    : base(duration)
                {

                }

                private void Init(object parameter)
                {
                    if (parameter == null)
                    { }
                    object note_struct = null;
                    //判断参数parameter的类型，如果是string则  如是是obj则  为note_struct赋值
                    this.Width = 0;
                }

                public bool IsRest()
                {
                    return true;
                }

                public void Draw()
                {

                }

                public GhostNote PreFormat()
                {
                    this.PreFormatted = true;
                    return this;
                }
                #endregion
            }
        }

    }
}
