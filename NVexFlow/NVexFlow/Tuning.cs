using System.Collections.Generic;

namespace NVexFlow
{//Tuning
    public class Tuning
    {
        public Tuning(string tuningString)
        {
            Init(tuningString);
        }

        public static IDictionary<string,string> names = new Dictionary<string,string>() {
                    {"standard","E/5,B/4,G/4,D/4,A/3,E/3"},
                    {"dagdad", "D/5,A/4,G/4,D/4,A/3,D/3"},
                    {"dropd", "E/5,B/4,G/4,D/4,A/3,D/3"},
                    {"eb", "Eb/5,Bb/4,Gb/4,Db/4,Ab/3,Db/3"}
                };

        private void Init(string tuningString)
        { }

        public int NoteToInteger(string noteString)
        {
            return Flow.KeyProperties(noteString,"").intValue;
        }

        private string tuningString;

        public string TuningString
        {
            get
            { return tuningString; }
            set
            {
                //set方法需要重写
                tuningString = value;
            }
        }

        private IList<int> tuningValues;

        public IList<int> TuningValues
        {
            get
            { return tuningValues; }
            set
            { tuningValues = value; }
        }

        public int GetValueForString(string stringNum)
        {
            return TuningValues[0];
        }

        public int GetValueForFret(string fretNum,string stringNum)
        {
            return TuningValues[0];
        }

        public string GetNoteForFret(string fretNum,string stringNum)
        {
            return Flow.IntegerToNote(0);
        }
    }
}
