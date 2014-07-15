using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NVexFlow.Model
{
    public class NoteStruct
    {
        //{ keys: ["a/3"], duration: "q", stem_direction: 1 }
        public IList<string> keys;
        public string duration;
        public int stemDirection;
        public string glyph;
        public int line;
    }
}
