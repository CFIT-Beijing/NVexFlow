using System.Collections.Generic;
using NVexFlow.Model;

namespace NVexFlow
{
    /// <summary>
    /// VexFlow - Music Engraving for HTML5
    // Copyright Mohit Muthanna 2010
    //
    // This class implements varies types of ties between contiguous notes. The
    // ties include: regular ties, hammer ons, pull offs, and slides.
    /// </summary>
    public class TabSlide:TabTie
    {
        #region js直译部分
        /**
 * Create a new tie from the specified notes. The notes must
 * be part of the same line, and have the same duration (in ticks).
 *
 * @constructor
 * @param {!Object} context The canvas context.
 * @param {!Object} notes The notes to tie up.
 * @param {!Object} Options
 */
        public TabSlide(Notes4StaveTie notes, int? direction)
            : base(notes, "sl.")
        {
            Init(notes, direction);
        }
        public static int SLIDE_UP = 1;
        public static int SLIDE_DOWN = -1;
        public static TabSlide CreateSlideUp(Notes4StaveTie notes)
        {
            return new TabSlide(notes, TabSlide.SLIDE_UP);
        }
        public static TabSlide CreateSlideDown(Notes4StaveTie notes)
        {
            return new TabSlide(notes, TabSlide.SLIDE_DOWN);
        }
        private void Init(Notes4StaveTie notes, int? direction)
        {
            /**
             * Notes is a struct that has:
             *
             *  {
             *    first_note: Note,
             *    last_note: Note,
             *    first_indices: [n1, n2, n3],
             *    last_indices: [n1, n2, n3]
             *  }
             *
             **/
            if (direction == null)
            {
                //此处有可能Null异常吧
                double firstFret= (notes.firstNote as TabNote).Positions[0].fret;
                double lastFret = (notes.lastNote as TabNote).Positions[0].fret;
                direction = firstFret > lastFret ? TabSlide.SLIDE_DOWN : TabSlide.SLIDE_UP;
            }
            this.slideDirection = direction.Value;
            this.renderOptions = new StaveTieRenderOpts() { 
            cp1=11,cp2=14,yShift=0.5
            };

            this.SetFont(new Font() {font="Times", size=10, style= "bold italic" });
            this.SetNotes(notes);
        }
        public override void RenderTie(IList<object> @params)
        {
            //      renderTie: function(params) {
            //    if (params.first_ys.length === 0 || params.last_ys.length === 0)
            //      throw new Vex.RERR("BadArguments", "No Y-values to render");

            //    var ctx = this.context;
            //    var first_x_px = params.first_x_px;
            //    var first_ys = params.first_ys;
            //    var last_x_px = params.last_x_px;

            //    var direction = this.slide_direction;
            //    if (direction != TabSlide.SLIDE_UP &&
            //        direction != TabSlide.SLIDE_DOWN) {
            //      throw new Vex.RERR("BadSlide", "Invalid slide direction");
            //    }

            //    for (var i = 0; i < this.first_indices.length; ++i) {
            //      var slide_y = first_ys[this.first_indices[i]] +
            //        this.render_options.y_shift;

            //      if (isNaN(slide_y))
            //        throw new Vex.RERR("BadArguments", "Bad indices for slide rendering.");

            //      ctx.beginPath();
            //      ctx.moveTo(first_x_px, slide_y + (3 * direction));
            //      ctx.lineTo(last_x_px, slide_y - (3 * direction));
            //      ctx.closePath();
            //      ctx.stroke();
            //    }
            //  }
            //}
        }


        #endregion


        #region 隐含字段
        protected int slideDirection;
        #endregion
    }
}
