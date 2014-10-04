namespace NVexFlow.Model
{
    public class StemOpts
    {
        public double? y_extend;
        public double? x_begin;
        public double? x_end;
        public double? y_top;
        public double? y_bottom;
        public double? stem_direction;
        public double? stem_extension;
        
        //note.setStem(new Vex.Flow.Stem({
        //      x_begin: centerGlyphX,
        //      x_end: centerGlyphX,
        //      y_bottom: this.stem_direction === 1 ? end_y : start_y,
        //      y_top: this.stem_direction === 1 ? start_y : end_y,
        //      y_extend: y_displacement,
        //      stem_extension: -1, // To avoid protruding through the beam
        //      stem_direction: this.stem_direction
        //    }));
    }

    public class StemExtents
    { 
        public double top_y;
        public double base_y;
    }
}
