using System.Collections.Generic;
using NVexFlow.Model;

namespace NVexFlow
{
    /// <summary>
    /// [VexFlow](http://vexflow.com) - Copyright (c) Mohit Muthanna Cheppudira 2013.
    // Co-author: Benjamin W. Bohl
    //
    // ## Description
    //
    // This file implements various types of clefs that can be rendered on a stave.
    //
    // See `tests/clef_tests.js` for usage examples.
    /// </summary>
    public class Clef : StaveModifier
    {
        #region js直译部分
        public Clef(string clef)
        {
            Init(clef);
        }
        // Every clef name is associated with a glyph code from the font file, a point size, and a default stave line number.
        public static IDictionary<string, ClefType> clefTypes = new Dictionary<string, ClefType>() { 
         {"treble",new ClefType(){code="v83",point=40,line=3}},
         {"bass",new ClefType(){code="v79",point=40,line=1}},
         {"alto",new ClefType(){code="vad",point=40,line=2}},
         {"tenor",new ClefType(){code="vad",point=40,line=1}},
         {"percussion",new ClefType(){code="v59",point=40,line=2}},
         {"soprano",new ClefType(){code="vad",point=40,line=4}},
         {"mezzo-soprano",new ClefType(){code="vad",point=40,line=3}},
         {"baritone-c",new ClefType(){code="vad",point=40,line=0}},
         {"baritone-f",new ClefType(){code="v79",point=40,line=2}},
         {"subbass",new ClefType(){code="v79",point=40,line=0}},
         {"french",new ClefType(){code="v83",point=40,line=4}},
         {"treble_small",new ClefType(){code="v83",point=32,line=3}},
         {"bass_small",new ClefType(){code="v79",point=32,line=1}},
         {"alto_small",new ClefType(){code="vad",point=32,line=2}},
         {"tenor_small",new ClefType(){code="vad",point=32,line=1}},
         {"soprano_small",new ClefType(){code="vad",point=32,line=4}},
         {"mezzo-soprano_small",new ClefType(){code="vad",point=32,line=3}},
         {"baritone-c_small",new ClefType(){code="vad",point=32,line=0}},
         {"baritone-f_small",new ClefType(){code="v79",point=32,line=2}},
         {"subbass_small",new ClefType(){code="v79",point=32,line=0}},
         {"french_small",new ClefType(){code="v83",point=32,line=4}},
         {"percussion_small",new ClefType(){code="v59",point=32,line=2}}
        };
        /// <summary>
        /// // Create a new clef. The parameter `clef` must be a key from `Clef.types`.
        /// </summary>
        /// <param name="clef"></param>
        private void Init(string clef)
        {
            this.clef = clefTypes[clef];
        }
        /// <summary>
        /// Add this clef to the start of the given `stave`.
        /// </summary>
        /// <param name="stave"></param>
        public override void AddModifier(Stave stave)
        {
            Glyph glyph = new Glyph(this.clef.code, this.clef.point);
            this.PlaceGlyphOnLine(glyph, stave, this.clef.point);
            stave.AddGlyph(glyph);
        }
        /// <summary>
        /// Add this clef to the end of the given `stave`.
        /// </summary>
        /// <param name="stave"></param>
        public override void AddEndModifier(Stave stave)
        {
            Glyph glyph = new Glyph(this.clef.code, this.clef.point);
            this.PlaceGlyphOnLine(glyph, stave, this.clef.point);
            stave.AddEndGlyph(glyph);
        }
        #endregion

        #region 隐含字段
        protected ClefType clef;
        #endregion



    }
}
