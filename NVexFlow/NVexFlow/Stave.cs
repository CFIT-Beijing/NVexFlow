using System.Collections.Generic;

namespace NVexFlow
{
    public class Stave
    {
        #region 隐含字段

        double startX;

        public double NoteStartX
        {
            get
            { return startX; }
            set
            { startX = value; }
        }

        double endX;

        public double NoteEndX
        {
            get
            { return endX; }
        }

        public double TieStartX
        {
            get
            { return startX; }
        }

        double width;
        public double TieEndX
        {
            get
            { return this.startX + this.width; }
        }

        public CanvasContext context;//Note没有通过GetContext来访问context字段

        public CanvasContext Context
        {
            get
            { return context; }
            set
            { context = value; }
        }

        double x;

        public double X
        {
            get
            { return x; }
        }

        double numLines;

        public double NumLines
        {
            get
            { return numLines; }
            set
            { numLines = value; }
        }

        double y;

        public double Y
        {
            set
            { y = value; }
        }


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


        #region js直译部分
        public Stave(double x,double y,double width,IList<object> options)
        {
            Init(x,y,width,options);
        }



        public virtual void Init(double x,double y,double width,IList<object> options)
        {

        }

        public void ResetLines()
        { }


        public Stave SetBegBarType(object type)
        {
            return this;
        }

        public Stave SetEndBarType(object type)
        {
            return this;
        }

        public double GetModifierXShift(int index)
        { return 0; }

        public Stave SetRepetitionTypeLeft(object type,double y)
        {
            return this;
        }

        public Stave SetRepetitionTypeRight(object type,double y)
        {
            return this;
        }


        public Stave SetVoltaType(object type,object number_t,double y)
        {
            return this;
        }

        public Stave SetSection(object section,double y)
        {
            return this;
        }

        public Stave SetTempo(object tempo,double y)
        {
            return this;
        }


        public Stave SetText(string text,object position,IList<object> options)
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



        public Stave AddTimeSignature(object timeSpec,object customPadding)
        {
            return this;
        }


        public void AddEndTimeSignature(object timeSpec,object customPadding)
        {

        }


        public Stave AddTrebleGlyph()
        {
            return this;
        }


        public void Draw()
        { }



        public void DrawVertical(double x,object isDouble)
        { }

        public void DrawVerticalFixed(double x,object isDouble)
        { }

        public object GetConfigForLines()
        {
            return null;
        }

        public Stave SetConfigForLine(int line_number,object line_config)
        {
            return this;
        }

        public Stave SetConfigForLines(object lines_configuration)
        { return null; }
        #endregion

    }
}
