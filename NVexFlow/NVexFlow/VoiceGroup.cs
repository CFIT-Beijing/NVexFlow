using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NVexFlow
{
    public partial class Vex
    {
        public partial class Flow
        {
            public class VoiceGroup 
            {
                public VoiceGroup()
                {
                    voices = new List<object>();
                    modifierContexts = new List<object>();
                }

                private IList<object> voices;

                public IList<object> Voices
                {
                    get { return voices; }
                }

                private IList<object> modifierContexts;

                public IList<object> ModifierContexts
                {
                    get { return modifierContexts; }
                }

                public void AddVoice(object voice) { }
            }
        }

    }
}
