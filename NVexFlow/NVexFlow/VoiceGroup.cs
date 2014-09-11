//voicegroup.js
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
            //        init: function() {
            //  this.voices = [];
            //  this.modifierContexts = [];
            //},
        }
        // Every tickable must be associated with a voiceGroup. This allows formatters
        // and preformatters to associate them with the right modifierContexts.

        public IList<object> GetVoices()
        {
            //getVoices: function() { return this.voices; },
            return null;
        }
        public ModifierContext GetModifierContexts()
        {
            //getModifierContexts: function() { return this.modifierContexts; },
            return null;
        }


        public void AddVoice(object voice)
        { 
    //     addVoice: function(voice) {
    //  if (!voice) throw new Vex.RERR("BadArguments", "Voice cannot be null.");
    //  this.voices.push(voice);
    //  voice.setVoiceGroup(this);
    //}
        } 
        #endregion



        #region 隐含字段
        public IList<object> voices;
        public IList<object> modifierContexts; 
        #endregion
    }
}
