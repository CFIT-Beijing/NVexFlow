
namespace NVexFlow
{//Accidental
    public partial class Vex
    {
        public partial class Flow
        {
            public class Accidental : Modifier
            {
                #region 属性字段
                object note;
                object type;
                object index;
                Modifier.ModifierPosition position;
                object renderOptions;
                object accidental;
                bool cautionary;
                object parenLeft;
                object parenRight;
                double width;

                #endregion


                #region 方法
                public Accidental(object type)
                {

                    Init(type);
                }

                public void Init(object type)
                { }


                public void SerNote(object note)
                { }

                public Accidental SetAsCautionary()
                {
                    return null;
                }

                public override void Draw()
                { }
                #endregion
            }
        }
    }
}
