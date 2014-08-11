using System.Collections.Generic;
using NVexFlow.Model;

namespace NVexFlow
{
    public partial class Flow
    {
        public static double STEM_WIDTH = 1.5;
        public static double STEM_HEIGHT = 32;
        public static double STAVE_LINE_THICKNESS = 2;

        public static object ClefProperties(string clef)
        {
            return null;
        }

        public static IDictionary<string, object> clefPropertiesValues;//待初始化

        public static NoteProps KeyProperties(object key, string clef)
        {
            return null;
        }

        public static IDictionary<string, object> keyPropertiesNoteValues;


        public static IDictionary<string, object> keyPropertiesNoteGlyph;


        public static IDictionary<int, string> integerToNoteTable = new Dictionary<int, string>()
                {
                    {0, "C"},
                    {1, "C#"},
                    {2, "D"},
                    {3, "D#"},
                    {4,"E"},
                    {5, "F"},
                    {6, "F#"},
                    {7, "G"},
                    {8, "G#"},
                    {9, "A"},
                    {10, "A#"},
                    {11, "B"}
                };

        public static string IntegerToNote(int integer)
        {
            return integerToNoteTable[integer];
        }



        public static Glyph4TabNote TabToGlyph(object fret)
        {
            //          return {
            //  text: fret,
            //  code: glyph,
            //  width: width,
            //  shift_y: shift_y
            //};
            return null;
        }

        public static ArticulationCode ArticulationCodes(string artic)
        {
            return null;
        }

        public static IDictionary<string, ArticulationCode> articulationCodesArticulations;


        public static AccidentalOpts AccidentalCodes(string acc)
        {
            return null;
        }

        public static IDictionary<string, AccidentalOpts> accidentalCodesAccidentals;



        public static object keySignature(string spec)
        {
            return null;
        }

        public static IDictionary<string, object> keySignatureKeySpecs;


        public static void Unicode()
        { }

        public static NoteInitData ParseNoteDurationString(string duration)
        {
            //              if (typeof(durationString) !== "string") {
            //  return null;
            //}

            //var regexp = /(\d+|[a-z])(d*)([nrhms]|$)/;

            //var result = regexp.exec(durationString);
            //if (!result) {
            //  return null;
            //}

            //var duration = result[1];
            //var dots = result[2].length;
            //var type = result[3];

            //if (type.length === 0) {
            //  type = "n";
            //}

            //return {
            //  duration: duration,
            //  dots: dots,
            //  type: type
            //};
            return null;
        }



        public static NoteInitData ParseNoteData(NoteStruct noteData)
        {
            //              var duration = noteData.duration;

            //// Preserve backwards-compatibility
            //var durationStringData = Vex.Flow.parseNoteDurationString(duration);
            //if (!durationStringData) {
            //  return null;
            //}

            //var ticks = Vex.Flow.durationToTicks(durationStringData.duration);
            //if (ticks == null) {
            //  return null;
            //}

            //var type = noteData.type;

            //if (type) {
            //  if (!(type === "n" || type === "r" || type === "h" ||
            //        type === "m" || type === "s")) {
            //    return null;
            //  }
            //} else {
            //  type = durationStringData.type;
            //  if (!type) {
            //    type = "n";
            //  }
            //}

            //var dots = 0;
            //if (noteData.dots) {
            //  dots = noteData.dots;
            //} else {
            //  dots = durationStringData.dots;
            //}

            //if (typeof(dots) !== "number") {
            //  return null;
            //}

            //var currentTicks = ticks;

            //for (var i = 0; i < dots; i++) {
            //  if (currentTicks <= 1) {
            //    return null;
            //  }

            //  currentTicks = currentTicks / 2;
            //  ticks += currentTicks;
            //}

            //return {
            //  duration: durationStringData.duration,
            //  type: type,
            //  dots: dots,
            //  ticks: ticks
            //};
            return null;
        }


        public static object DurationToTicks(string duration)
        {
            return null;
        }


        public static IDictionary<string, object> durationToTicksDurations;


        public static IDictionary<string, string> durationAliases;

        public static Glyph4Note DurationToGlyph(string duration, string type)
        {
            return null;
        }

        public static IDictionary<string, object> durationToGlyphDurationCodes;

        public static object TIME4_4;

        public static int TextWidth(object text)
        {
            return 6 * text.ToString().Length;
        }


        public static class Tables
        {

        }
    }
}
