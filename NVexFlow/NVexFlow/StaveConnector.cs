//staveconnector.js
using System.Collections.Generic;
using NVexFlow.Model;

namespace NVexFlow
{
    // Vex Flow Notation
    // Mohit Muthanna <mohit@muthanna.com>
    //
    // Copyright Mohit Muthanna 2010
    //
    // Requires vex.js.
    public class StaveConnector
    {
        #region js直译部分
        public StaveConnector(Stave top_stave, Stave bottom_stave)
        { Init(top_stave, bottom_stave); }
        // SINGLE_LEFT and SINGLE are the same value for compatibility
        // with older versions of vexflow which didn't have right sided
        // stave connectors
        public enum StaveConnectorType
        {
            SINGLE_RIGHT = 0,
            SINGLE_LEFT = 1,
            SINGLE = 1,
            DOUBLE = 2,
            BRACE = 3,
            BRACKET = 4,
            BOLD_DOUBLE_LEFT = 5,
            BOLD_DOUBLE_RIGHT = 6,
            THIN_DOUBLE = 7
        }


        private void Init(Stave top_stave, Stave bottom_stave)
        {
            this.width = 3;
            this.top_stave = top_stave;
            this.bottom_stave = bottom_stave;
            this.type = StaveConnectorType.DOUBLE;
            this.x_shift = 0; // Mainly used to offset Bold Double Left to align with offset Repeat Begin bars
        }


        public StaveConnector SetContext(CanvasContext ctx)
        {
            this.ctx = ctx;
            return this;
        }

        public StaveConnector SetType(StaveConnectorType type)
        {
            if (type >= StaveConnectorType.SINGLE_RIGHT && type <= StaveConnectorType.THIN_DOUBLE)
            {
                this.type = type;
            }
            return this;
        }

        public StaveConnector SetText(string text, TextOpts text_options)
        {
            this.text = text;
            this.text_options = new TextOpts()
            {
                shift_x = 0,
                shift_y = 0
            };
            if (text_options.shift_x.HasValue)
            {
                this.text_options.shift_x = text_options.shift_x;
            }
            if (text_options.shift_y.HasValue)
            {
                this.text_options.shift_y = text_options.shift_y;
            }
            this.font = new Font()
            {
                family = "times",
                size = 16,
                weight = "normal"
            };

            return this;
        }

        public void SetFont(Font font)
        {
            if (!string.IsNullOrEmpty(font.family))
            {
                this.font.family = font.family;
            }
            if (!string.IsNullOrEmpty(font.weight))
            {
                this.font.weight = font.weight;
            }
            if (!string.IsNullOrEmpty(font.style))
            {
                this.font.style = font.style;
            }
            if (!string.IsNullOrEmpty(font.font))
            {
                this.font.font = font.font;
            }
            if (font.size.HasValue)
            {
                this.font.size = font.size;
            }
        }

        public StaveConnector SetXShift(double x_shift)
        {
            this.x_shift = x_shift;
            return this;
        }


        public void Draw()
        {
            //       draw: function() {
            //  if (!this.ctx) throw new Vex.RERR(
            //      "NoContext", "Can't draw without a context.");
            //  var topY = this.top_stave.getYForLine(0);
            //  var botY = this.bottom_stave.getYForLine(this.bottom_stave.getNumLines() - 1) +
            //    THICKNESS;
            //  var width = this.width;
            //  var topX = this.top_stave.getX();

            //  var isRightSidedConnector = (
            //    this.type === StaveConnector.type.SINGLE_RIGHT ||
            //    this.type === StaveConnector.type.BOLD_DOUBLE_RIGHT ||
            //    this.type === StaveConnector.type.THIN_DOUBLE
            //  );

            //  if (isRightSidedConnector){
            //    topX = this.top_stave.getX() + this.top_stave.width;
            //  }

            //  var attachment_height = botY - topY;
            //  switch (this.type) {
            //    case StaveConnector.type.SINGLE:
            //      width = 1;
            //      break;
            //    case StaveConnector.type.SINGLE_LEFT:
            //      width = 1;
            //      break;
            //    case StaveConnector.type.SINGLE_RIGHT:
            //      width = 1;
            //      break;
            //    case StaveConnector.type.DOUBLE:
            //      topX -= (this.width + 2);
            //      break;
            //    case StaveConnector.type.BRACE:
            //      width = 12;
            //      // May need additional code to draw brace
            //      var x1 = this.top_stave.getX() - 2;
            //      var y1 = topY;
            //      var x3 = x1;
            //      var y3 = botY;
            //      var x2 = x1 - width;
            //      var y2 = y1 + attachment_height/2.0;
            //      var cpx1 = x2 - (0.90 * width);
            //      var cpy1 = y1 + (0.2 * attachment_height);
            //      var cpx2 = x1 + (1.10 * width);
            //      var cpy2 = y2 - (0.135 * attachment_height);
            //      var cpx3 = cpx2;
            //      var cpy3 = y2 + (0.135 * attachment_height);
            //      var cpx4 = cpx1;
            //      var cpy4 = y3 - (0.2 * attachment_height);
            //      var cpx5 = x2 - width;
            //      var cpy5 = cpy4;
            //      var cpx6 = x1 + (0.40 * width);
            //      var cpy6 = y2 + (0.135 * attachment_height);
            //      var cpx7 = cpx6;
            //      var cpy7 = y2 - (0.135 * attachment_height);
            //      var cpx8 = cpx5;
            //      var cpy8 = cpy1;
            //      this.ctx.beginPath();
            //      this.ctx.moveTo(x1, y1);
            //      this.ctx.bezierCurveTo(cpx1, cpy1, cpx2, cpy2, x2, y2);
            //      this.ctx.bezierCurveTo(cpx3, cpy3, cpx4, cpy4, x3, y3);
            //      this.ctx.bezierCurveTo(cpx5, cpy5, cpx6, cpy6, x2, y2);
            //      this.ctx.bezierCurveTo(cpx7, cpy7, cpx8, cpy8, x1, y1);
            //      this.ctx.fill();
            //      this.ctx.stroke();
            //      break;
            //    case StaveConnector.type.BRACKET:
            //      topY -= 4;
            //      botY += 4;
            //      attachment_height = botY - topY;
            //      Vex.Flow.renderGlyph(this.ctx, topX - 5, topY - 3, 40, "v1b", true);
            //      Vex.Flow.renderGlyph(this.ctx, topX - 5, botY + 3, 40, "v10", true);
            //      topX -= (this.width + 2);
            //      break;
            //    case StaveConnector.type.BOLD_DOUBLE_LEFT:
            //      drawBoldDoubleLine(this.ctx, this.type, topX + this.x_shift, topY, botY);
            //      break;
            //    case StaveConnector.type.BOLD_DOUBLE_RIGHT:
            //      drawBoldDoubleLine(this.ctx, this.type, topX, topY, botY);
            //      break;
            //    case StaveConnector.type.THIN_DOUBLE:
            //      width = 1;
            //      break;
            //  }

            //  if (this.type !== StaveConnector.type.BRACE &&
            //    this.type !== StaveConnector.type.BOLD_DOUBLE_LEFT &&
            //    this.type !== StaveConnector.type.BOLD_DOUBLE_RIGHT) {
            //    this.ctx.fillRect(topX , topY, width, attachment_height);
            //  }

            //  // If the connector is a thin double barline, draw the paralell line
            //  if (this.type === StaveConnector.type.THIN_DOUBLE) {
            //    this.ctx.fillRect(topX - 3, topY, width, attachment_height);
            //  }

            //  // Add stave connector text
            //  if (this.text !== undefined) {
            //    this.ctx.save();
            //    this.ctx.lineWidth = 2;
            //    this.ctx.setFont(this.font.family, this.font.size, this.font.weight);
            //    var text_width = this.ctx.measureText("" + this.text).width;

            //    var x = this.top_stave.getX() - text_width - 24 + this.text_options.shift_x;
            //    var y = (this.top_stave.getYForLine(0) + this.bottom_stave.getBottomLineY()) / 2 +
            //      this.text_options.shift_y;

            //    this.ctx.fillText("" + this.text, x, y + 4);
            //    this.ctx.restore();
            //  }
            //}
        }

        public static void DrawBoldDoubleLine(object ctx, object type, double topX, double topY, double botY)
        {
            //        function drawBoldDoubleLine(ctx, type, topX, topY, botY){
            //  if (type !== StaveConnector.type.BOLD_DOUBLE_LEFT &&
            //      type !== StaveConnector.type.BOLD_DOUBLE_RIGHT) {
            //    throw Vex.RERR("InvalidConnector",
            //      "A REPEAT_BEGIN or REPEAT_END type must be provided.");
            //  }

            //  var x_shift = 3;
            //  var variableWidth = 3.5; // Width for avoiding anti-aliasing width issues
            //  var thickLineOffset = 2; // For aesthetics

            //  if (type === StaveConnector.type.BOLD_DOUBLE_RIGHT) {
            //    x_shift = -5; // Flips the side of the thin line
            //    variableWidth = 3;
            //  }

            //  // Thin line
            //  ctx.fillRect(topX + x_shift, topY, 1, botY - topY);
            //  // Thick line
            //  ctx.fillRect(topX - thickLineOffset, topY, variableWidth, botY - topY);
            //}
        }
        #endregion


        #region 隐含字段
        public double width;
        public Stave top_stave;
        public Stave bottom_stave;
        public CanvasContext ctx;
        public StaveConnectorType type;
        public string text;
        public TextOpts text_options;
        public Font font;
        public double x_shift;

        #endregion
    }
}
