using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZhCJB.VexFlow.CS
{//Music
    public partial class Vex
    {
        public partial class Flow
        {
            public class Music
            {
                public static int NUM_TONES = 12;

                public static IList<string> roots = new List<string>() { "c", "d", "e", "f", "g", "a", "b" };
                public static IList<int> root_values = new List<int>() { 0, 2, 4, 5, 7, 9, 11 };
                public static IDictionary<string,int> root_indices=new Dictionary<string,int>();
                public static IList<string> canonical_notes = new List<string>();
                public static IList<string> diatonic_intervals = new List<string>();
                public static IDictionary<string, object> diatonic_accidentals = new Dictionary<string, object>();
                public static IDictionary<string, int> intervals = new Dictionary<string, int>();
                public static class MusicScale
                {
                    public static IList<int> major = new List<int>() { 2, 2, 1, 2, 2, 2, 1 };
                    public static IList<int> dorian = new List<int>() { 2, 1, 2, 2, 2, 1, 2 };
                    public static IList<int> mixolydian = new List<int>() { 2, 2, 1, 2, 2, 1, 2 };
                    public static IList<int> minor = new List<int>() { 2, 1, 2, 2, 1, 2, 2 };
                }
                public static IList<string> accidentals = new List<string>() { "bb", "b", "n", "#", "##" };
                public static IDictionary<string, object> noteValues = new Dictionary<string, object>();


                public Music()
                {
                    Init();
                }

                public void Init()
                { }

                public bool IsValidNoteValue(object note)
                {
                    return false;
                }

                public bool IsValidIntervalValue(object interval)
                {
                    return IsValidNoteValue(interval);
                }

                public object GetNoteParts(string noteString)
                {
                    return null;
                }

                public object GetKeyParts(string keyString)
                {
                    return null;
                }

                public object GetNoteValue(string noteString)
                {
                    return null;
                }

                public object GetIntervalValue(string intervalString)
                {
                    return null;
                }

                public string GetCanonicalNoteName(int noteValue)
                {
                    return Music.canonical_notes[noteValue];
                }

                public string GetCanonicalIntervalName(int intervalValue)
                {
                    return Music.diatonic_intervals[intervalValue];
                }

                public double GetRelativeNoteValue(object noteValue, object intervalValue, object direction)
                {
                    return 0;
                }

                public string GetRelativeNoteName(object root, object noteValue)
                {
                    return "";
                }

                public IList<object> GetScaleTones(object key,object intervals)
                {
                    return null;
                }

                public object GetIntervalBetween(object note1, object note2, object direction)
                {
                    return null;
                }
            }
        }
    }
}
