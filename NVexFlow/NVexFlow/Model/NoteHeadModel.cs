using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NVexFlow.Model
{
    public class NoteHeadStruct : NoteStruct
    {
        public int? line;
    }

    /// <summary>
    /// `style` is an `object` with the following properties: `shadowColor`, `shadowBlur`, `fillStyle`, `strokeStyle`
    /// </summary>
    public class NoteHeadStyle
    {
        public object shadowColor;
        public object shadowBlur;
        public object fillStyle;
        public object strokeStyle;
    }
}
