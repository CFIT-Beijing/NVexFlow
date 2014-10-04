//voicegroup.js
using System;
using System.Collections.Generic;

namespace NVexFlow
{
    // Vex Music Notation
    // Mohit Muthanna <mohit@muthanna.com>
    //
    // Copyright Mohit Muthanna 2010
    public class VoiceGroup
    {
        #region js直译部分
        public VoiceGroup()
        {
            Init();
        }
        private void Init()
        {
            this.voices = new List<Voice>();
            this.modifier_contexts = new List<ModifierContext>();
        }
        // Every tickable must be associated with a voiceGroup. This allows formatters
        // and preformatters to associate them with the right modifierContexts.

        public IList<Voice> GetVoices()
        {
            return this.voices;
        }
        public IList<ModifierContext> GetModifierContexts()
        {
            return this.modifier_contexts;
        }


        public void AddVoice(Voice voice)
        { 
            if (voice == null)
            {
                throw new Exception("BadArguments,Voice cannot be null.");
            }
            this.voices.Add(voice);
            voice.SetVoiceGroup(this);
        } 
        #endregion



        #region 隐含字段
        public IList<Voice> voices;
        public IList<ModifierContext> modifier_contexts; 
        #endregion
    }
}
