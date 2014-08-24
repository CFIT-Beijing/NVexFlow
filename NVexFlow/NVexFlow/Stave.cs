//stave.js
using System.Collections.Generic;

namespace NVexFlow
{
    public class Stave
    {
        #region js直译部分
        public Stave(double x, double y, double width, IList<object> options)
        {
            Init(x, y, width, options);
        }

      //  var THICKNESS = (Vex.Flow.STAVE_LINE_THICKNESS > 1 ?
      //Vex.Flow.STAVE_LINE_THICKNESS : 0);

        public virtual void Init(double x, double y, double width, IList<object> options)
        {
    //        init: function(x, y, width, options) {
    //  this.x = x;
    //  this.y = y;
    //  this.width = width;
    //  this.glyph_start_x = x + 5;
    //  this.glyph_end_x = x + width;
    //  this.start_x = this.glyph_start_x;
    //  this.end_x = this.glyph_end_x;
    //  this.context = null;
    //  this.glyphs = [];
    //  this.end_glyphs = [];
    //  this.modifiers = [];  // non-glyph stave items (barlines, coda, segno, etc.)
    //  this.measure = 0;
    //  this.clef = "treble";
    //  this.font = {
    //    family: "sans-serif",
    //    size: 8,
    //    weight: ""
    //  };
    //  this.options = {
    //    vertical_bar_width: 10,       // Width around vertical bar end-marker
    //    glyph_spacing_px: 10,
    //    num_lines: 5,
    //    fill_style: "#999999",
    //    spacing_between_lines_px: 10, // in pixels
    //    space_above_staff_ln: 4,      // in staff lines
    //    space_below_staff_ln: 4,      // in staff lines
    //    top_text_position: 1          // in staff lines
    //  };
    //  this.bounds = {x: this.x, y: this.y, w: this.width, h: 0};
    //  Vex.Merge(this.options, options);

    //  this.resetLines();

    //  this.modifiers.push(
    //      new Vex.Flow.Barline(Vex.Flow.Barline.type.SINGLE, this.x)); // beg bar
    //  this.modifiers.push(
    //      new Vex.Flow.Barline(Vex.Flow.Barline.type.SINGLE,
    //      this.x + this.width)); // end bar
    //},
        }

        public void ResetLines()
        { 
    //        resetLines: function() {
    //  this.options.line_config = [];
    //  for (var i = 0; i < this.options.num_lines; i++) {
    //    this.options.line_config.push({visible: true});
    //  }
    //  this.height = (this.options.num_lines + this.options.space_above_staff_ln) *
    //     this.options.spacing_between_lines_px;
    //  this.options.bottom_text_position = this.options.num_lines + 1;
    //},
        }

   

        public Stave SetNoteStartX(double x)
        {
            //        setNoteStartX: function(x) { this.start_x = x; return this; },
            return null;
        }
        public double GetNoteStartX()
        {
            //getNoteStartX: function() {
            //  var start_x = this.start_x;

            //  // Add additional space if left barline is REPEAT_BEGIN and there are other
            //  // start modifiers than barlines
            //  if (this.modifiers[0].barline == Vex.Flow.Barline.type.REPEAT_BEGIN &&
            //      this.modifiers.length > 2)
            //    start_x += 20;
            //  return start_x;
            //},
            return 0;
        }
        public double GetNoteEndX()
        {
        //function() { return this.end_x; },
            return 0;
        }
        public double GetTieStartX()
        {
            return this.startX;
        }
        public double GetTieEndX()
        {
            return this.endX;
        }
        public CanvasContext GetContext()
        {
            return this.context;
        }
        public Stave SetContext(CanvasContext context)
        {
            this.context = context;
            return this;
        }
        public double GetX()
        {
            return this.x;
        }
        public object GetNumLines()
        {
            //return this.options.num_lines;
            return null;
        }
        public Stave SetNumLines(CanvasContext context)
        {  //  this.options.num_lines = parseInt(lines, 10);
            //  this.resetLines();
            //  return this;
            return this;
        }
        public Stave SetY(double y)
        {
            this.y = y;
            return this;
        }
        public Stave SetWidth(double width)
        {
            //     setWidth: function(width) {
            //  this.width = width;
            //  this.glyph_end_x = this.x + width;
            //  this.end_x = this.glyph_end_x;

            //  // reset the x position of the end barline
            //  this.modifiers[1].setX(this.end_x);
            //  return this;
            //},
            return null;
        }

        public double GetWidth()
        {
            return this.width;
        }

        public Stave SetMeasure(int measure )
        {
            this.measure = measure;
            return this;
        }

    //  





        // Bar Line functions
        public Stave SetBegBarType(object type)
        {
            //setBegBarType: function(type) {
            //  // Only valid bar types at beginning of stave is none, single or begin repeat
            //  if (type == Vex.Flow.Barline.type.SINGLE ||
            //      type == Vex.Flow.Barline.type.REPEAT_BEGIN ||
            //      type == Vex.Flow.Barline.type.NONE) {
            //      this.modifiers[0] = new Vex.Flow.Barline(type, this.x);
            //  }
            //  return this;
            //},
            return this;
        }

        public Stave SetEndBarType(object type)
        {
            //setEndBarType: function(type) {
            //  // Repeat end not valid at end of stave
            //  if (type != Vex.Flow.Barline.type.REPEAT_BEGIN)
            //    this.modifiers[1] = new Vex.Flow.Barline(type, this.x + this.width);
            //  return this;
            //},
            return this;
        }

        public double GetModifierXShift(int index)
        { return 0; }

        public Stave SetRepetitionTypeLeft(object type, double y)
        {
            return this;
        }

        public Stave SetRepetitionTypeRight(object type, double y)
        {
            return this;
        }


        public Stave SetVoltaType(object type, object number_t, double y)
        {
            return this;
        }

        public Stave SetSection(object section, double y)
        {
            return this;
        }

        public Stave SetTempo(object tempo, double y)
        {
            return this;
        }


        public Stave SetText(string text, object position, IList<object> options)
        {
            return this;
        }




        public double SpacingBetweenLines
        {
            get
            { return 0; }
        }

        public BoundingBox BoundingBox
        {
            get
            { return null; }
        }



        public object BottomY
        {
            get
            { return null; }
        }




        public double BottomLineY
        {
            get
            {
                return 0;
            }
        }


        public double GetYForTopText(double line)
        {
            return 0;
        }


        public double GetYForBottomText(object line)
        {
            return 0;
        }



        public double GetYForNote(object line)
        {
            return 0;
        }



        public double GetYForLine(double line)
        {
            return 0;
        }

        public double GetYForGlyph()
        {
            return GetYForLine(3);
        }

        public Stave AddGlyph(Glyph glyph)
        {
            return null;
        }

        public Stave AddEndGlyph(Glyph glyph)
        {
            return null;
        }


        public Stave AddModifier(object modifier)
        {
            return this;
        }


        public Stave AddEndModifier(object modifier)
        {
            return this;
        }


        public Stave AddKeySignature(object keySpec)
        {
            return this;
        }


        public Stave AddClef(object clef)
        {
            return this;
        }


        public Stave AddEndClef(object clef)
        {
            return this;
        }



        public Stave AddTimeSignature(object timeSpec, object customPadding)
        {
            return this;
        }


        public void AddEndTimeSignature(object timeSpec, object customPadding)
        {

        }


        public Stave AddTrebleGlyph()
        {
            return this;
        }


        public void Draw()
        { }



        public void DrawVertical(double x, object isDouble)
        { }

        public void DrawVerticalFixed(double x, object isDouble)
        { }

        public object GetConfigForLines()
        {
            return null;
        }

        public Stave SetConfigForLine(int line_number, object line_config)
        {
            return this;
        }

        public Stave SetConfigForLines(object lines_configuration)
        { return null; }
        #endregion


        #region 隐含字段

        double startX;



        double endX;



        double width;
        

        public CanvasContext context;//Note没有通过GetContext来访问context字段



        double x;



        double numLines;

        public double NumLines
        {
            get
            { return numLines; }
            set
            { numLines = value; }
        }

        double y;




        public double Width
        {
            get
            { return width; }
            set
            { width = value; }
        }

        int measure;

        public int Measure
        {
            set
            { measure = value; }
        }

        double height;

        public double Height
        {
            get
            { return height; }
        }

        IList<object> glyphs;
        IList<object> endGlyphs;
        IList<object> modifiers;
        double glyphStartX;
        double glyphEndX;
        public string clef;//keySignatrue用到
        Font font;
        IList<object> options;
        object bounds;
        #endregion


      

    }
}
