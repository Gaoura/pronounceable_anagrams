using System.Collections.Generic;

public class TrigramSet : GraphemeSet<Trigram>
{
    private Dictionary
                <Letter, Dictionary
                            <Letter, List<Letter> > > _graphemes 
        = new Dictionary<Letter, Dictionary<Letter, List<Letter> > >();

    public TrigramSet()
    {
        _grapheme_length = new Trigram().Length();
    }

    public override void Add(Trigram grapheme)
    {
        Dictionary<Letter, List<Letter> > dict;
        List<Letter> list;

        if (_graphemes.ContainsKey(grapheme[0]))
        {
            dict = _graphemes[grapheme[0]];

            if (_graphemes[grapheme[0]].ContainsKey(grapheme[1]))
            {
                list = _graphemes[grapheme[0]][grapheme[1]];
                if (!list.Contains(grapheme[2]))
                    list.Add(grapheme[2]);
            }
            else
            {
                list = new List<Letter>();
                list.Add(grapheme[2]);
                dict.Add(grapheme[1], list);
            }
        }
        else
        {
            list = new List<Letter>();
            list.Add(grapheme[2]);
            dict = new Dictionary<Letter, List<Letter>>();
            dict.Add(grapheme[1], list);
            _graphemes.Add(grapheme[0], dict);
        }
    }

    public override bool Exists(Trigram grapheme)
    {
        if (_graphemes.ContainsKey(grapheme[0]))
            if (_graphemes[grapheme[0]].ContainsKey(grapheme[1]))
                return _graphemes[grapheme[0]][grapheme[1]].Contains(grapheme[2]);

        return false;
    }
}