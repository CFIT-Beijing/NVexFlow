//对应 articulation.js
//框架：    已完成
//类型定义：存在改进空间
//原js：    存在改进空间
using System;
using NVexFlow.Model;
namespace NVexFlow
{
    public partial class Vex
    {
        public partial class Flow
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
                public void Init(string type)
                {
                    this.note=null;
                    this.index=null;
                    this.type=type;
                    this.position=Modifier.ModifierPosition.BELOW;
                    this.renderOptions=new RenderOptions() {
                        fontScale=38
                    };
                    this.articulation=Vex.Flow.ArticulationCodes(this.type);
                    if(this.articulation==null)
                    {
                        throw new ArgumentException("ArgumentError,Articulation not found: '"+this.type+"'");
                    }
                    // Default width comes from articulation table.
                    Width=this.articulation.width;
                }
                // Get modifier category for `ModifierContext`.
                public override string Category
                {
                    get
                    {
                        return "articulations";
                    }
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
                protected string type;
                protected RenderOptions renderOptions;
                protected ArticulationCode articulation;
                #endregion
            }
        }
    }
}
