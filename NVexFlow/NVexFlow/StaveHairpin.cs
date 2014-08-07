using System.Collections.Generic;

namespace NVexFlow
{//StaveHairpin
    public class StaveHairpin
    {
        public StaveHairpin(IList<object> notes,object type)
        {
            Init(notes,type);
        }

        public enum StaveHairpinType
        {
            CRESC,
            DECRESC
        }

        public static void FormatByTicksAndDraw(object ctx,object formatter,IList<object> notes,object type,object position,IList<object> options)
        { }

        private void Init(IList<object> notes,object type)
        { }

        object context;

        public object Context
        {
            set
            { context = value; }
        }

        Modifier.ModifierPosition position;

        public Modifier.ModifierPosition Position
        {
            set
            {
                if(value == Modifier.ModifierPosition.ABOVE || value == Modifier.ModifierPosition.BELOW)
                {
                    position = value;
                }
            }
        }

        object renderOptions;

        public object RenderOptions
        {

            set
            {
                //需要重写
                renderOptions = value;
            }
        }

        IList<object> notes;

        public IList<object> Notes
        {
            set
            {
                //需要重写
                notes = value;
            }
        }

        public void RenderHairpin(IList<object> @params)
        { }

        public void Draw()
        { }
    }
}
