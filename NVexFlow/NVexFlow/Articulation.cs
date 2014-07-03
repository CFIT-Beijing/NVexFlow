
using System;
using NVexFlow.Model;
namespace NVexFlow
{
    public partial class Vex
    {
        public partial class Flow
        {
            /// <summary>
            /// ## Description
            //
            // This file implements articulations and accents as modifiers that can be
            // attached to notes. The complete list of articulations is available in
            // `tables.js` under `Vex.Flow.articulationCodes`.
            //
            // See `tests/articulation_tests.js` for usage examples.
            /// </summary>
            public class Articulation : Modifier
            {
                #region 属性字段
                Note note;
                object index;
                string type;
                Modifier.ModifierPosition position;
                RenderOptions renderOptions;
                ArticulationModel articulation;
                double width;
                public override double Width
                {
                    set { this.width = value; }
                }
                #endregion


                #region 方法
                public Articulation(string type)
                {
                    Init(type);
                }
                // Create a new articulation of type `type`, which is an entry in `Vex.Flow.articulationCodes` in `tables.js`.
                public void Init(string type)
                {
                    this.note = null;
                    this.index = null;
                    this.type = type;
                    this.position = Modifier.ModifierPosition.BELOW;
                    this.renderOptions = new RenderOptions() { FontScale = 38 };
                    this.articulation = Vex.Flow.articulationCodes(this.type);
                    if (this.articulation == null)
                    {
                        throw new Exception("ArgumentError,Articulation not found: '" + this.type + "'");
                    }
                    // Default width comes from articulation table.
                    this.Width = this.articulation.Width;
                }

                /// <summary>
                /// Render articulation in position next to note.
                /// </summary>
                public override void Draw()
                { }
                #endregion
            }
        }
    }
}
