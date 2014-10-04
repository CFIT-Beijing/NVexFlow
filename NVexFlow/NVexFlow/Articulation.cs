//对应 articulation.js
using System;
using NVexFlow.Model;
namespace NVexFlow
{
    /// <summary>
    /// This file implements articulations and accents as modifiers that can be
    /// attached to notes. The complete list of articulations is available in
    /// `tables.js` under `Vex.Flow.articulationCodes`.
    ///
    /// See `tests/articulation_tests.js` for usage examples.
    /// </summary>
    public class Articulation:Modifier
    {
        #region js直译部分
        public Articulation(string type)
        {
            Init(type);
        }
        // Create a new articulation of type `type`, which is an entry in `Vex.Flow.articulationCodes` in `tables.js`.
        private void Init(string type)
        {
            this.note = null;
            this.index = null;
            this.type = type;
            this.position = ModifierPosition.BELOW;
            this.render_options = new RenderOptions() {
                font_scale = 38
            };
            this.articulation = Flow.ArticulationCodes(this.type);
            if(this.articulation == null)
            {
                throw new ArgumentException("ArgumentError,Articulation not found: '" + this.type + "'");
            }
            // Default width comes from articulation table.
            this.SetWidth(this.articulation.width);
        }
        // Get modifier category for `ModifierContext`.
        public override string GetCategory()
        {
            return "articulations";
        }
        /// <summary>
        /// Render articulation in position next to note.
        /// </summary>
        public override void Draw()
        {
            throw new NotImplementedException();
        }
        #endregion

        #region 隐含的字段
        public string type;
        public RenderOptions render_options;
        public ArticulationCode articulation;
        #endregion
    }
}
