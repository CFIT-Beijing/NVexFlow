using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NVexFlow.Model
{
    public class PhraseModel
    {
        NVexFlow.Vex.Flow.Bend.BendType type;

        public NVexFlow.Vex.Flow.Bend.BendType Type
        {
            get { return type; }
            set { type = value; }
        }
        string text;

        public string Text
        {
            get { return text; }
            set { text = value; }
        }
        double? width;

        public double? Width
        {
            get { return width; }
            set {
                width = value;
            }
        }

<<<<<<< HEAD
=======
        bool isWidthInit=false;

        public bool IsWidthInit
        {
            get { return isWidthInit; }
            set { isWidthInit = value; }
        }

>>>>>>> origin/master
        double drawWidth;

        public double DrawWidth
        {
            get { return drawWidth; }
            set { drawWidth = value; }
        }
    }
}
