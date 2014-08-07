using System.Collections.Generic;

namespace NVexFlow
{//KeyManager
    public class KeyManager
    {
        public static IDictionary<string,IList<int>> KeyManagerScales = new Dictionary<string,IList<int>>()
                {
                    {"M",Music.MusicScale.major},
                    {"m", Music.MusicScale.minor}
                };

        public KeyManager(object key)
        {
            Init(key);
        }

        private void Init(object key)
        { }

        public void Reset()
        { }

        private object key;

        public object Key
        {
            get
            { return key; }
            set
            {
                key = value;
                Reset();
            }
        }

        public object GetAccidental(object key)
        {
            return null;
        }

        public object SelectNote(object note)
        {
            return null;
        }
    }
}
