using System.Collections.Generic;

namespace NVexFlow
{
    public partial class Vex
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

            public static object KeyProperties(object key, string clef)
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



            public static object TabToGlyph(object fret)
            {
                return null;
            }

            public static object articulationCodes(string artic)
            {
                return null;
            }

            public static IDictionary<string, object> articulationCodesArticulations;


            public static object AccidentalCodes(string acc)
            {
                return null;
            }

            public static IDictionary<string, object> accidentalCodesAccidentals;



            public static object keySignature(string spec)
            {
                return null;
            }

            public static IDictionary<string, object> keySignatureKeySpecs;


            public static void Unicode()
            { }

            public static object ParseNoteDurationString(string duration)
            {
                return null;
            }



            public static object ParseNoteData(object noteData)
            {
                return null;
            }


            public static object DurationToTicks(string duration)
            {
                return null;
            }


            public static IDictionary<string, object> durationToTicksDurations;


            public static IDictionary<string, string> durationAliases;

            public static object DurationToGlyph(object duration, object type)
            {
                return null;
            }

            public static IDictionary<string, object> durationToGlyphDurationCodes;

            public static object TIME4_4;




            public static class Tables
            {

            }
        }
    }
}
