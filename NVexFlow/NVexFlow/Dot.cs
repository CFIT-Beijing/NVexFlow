
namespace NVexFlow
{
    public partial class Vex
    {
        public partial class Flow
        {
            public class Dot : Modifier
            {
                #region 属性字段
                double width;
                double dotShiftY;
                object index;
                Modifier.ModifierPosition position;
                private int radius;
                public int Radius
                {
                    get { return radius; }
                    set { radius = value; }
                }
                private object note;
                public override object Note
                {
                    get
                    {
                        return base.Note;
                    }
                    set
                    {
                        base.Note = value;
                        //                        this.note = note;
                        //if (this.note.getCategory() === 'gracenotes') {
                        //  this.radius *= 0.50;
                        //  this.setWidth(3);
                        //}
                    }
                }
                #endregion


                #region 方法
                public Dot()
                {

                }

                public override void Init()
                {
                    //this.note = null;
                    //this.index = null;
                    //this.position = Modifier.Position.RIGHT;

                    //this.radius = 2;
                    //this.setWidth(5);
                    //this.dot_shiftY = 0;
                }



                public void Draw()
                { }
                #endregion
            }
        }

    }
}
