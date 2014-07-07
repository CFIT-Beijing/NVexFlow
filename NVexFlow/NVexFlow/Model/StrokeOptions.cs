using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NVexFlow.Model
{
    public class StrokeOptions
    {
        bool? allVoices;

        public bool? AllVoices
        {
            get { return allVoices; }
            set
            {
                allVoices = value;
            }
        }
    }
}
