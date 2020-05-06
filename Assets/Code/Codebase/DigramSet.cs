using System.Collections.Generic;


namespace Old
{
    public class DigramSet : GraphemeSet<Digram>
    {
        private Dictionary
                    <Letter, List<Letter>> _graphemes
            = new Dictionary<Letter, List<Letter>>();

        public DigramSet()
        {
            _grapheme_length = new Digram().Length();
        }

        public override void Add(Digram grapheme)
        {
            List<Letter> list;

            if (_graphemes.ContainsKey(grapheme[0]))
            {
                _graphemes.TryGetValue(grapheme[0], out list);
                if (!list.Contains(grapheme[1]))
                    list.Add(grapheme[1]);
            }
            else
            {
                list = new List<Letter>();
                list.Add(grapheme[1]);
                _graphemes.Add(grapheme[0], list);
            }
        }

        public override bool Exists(Digram grapheme)
        {
            if (_graphemes.ContainsKey(grapheme[0]))
                return _graphemes[grapheme[0]].Contains(grapheme[1]);

            return false;
        }
    }
}