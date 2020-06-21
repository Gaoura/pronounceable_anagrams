using System.Collections;
using System.Collections.Generic;
using UnityEngine.Assertions;
using System.Linq;

public class Word : IEnumerable<Letter>, IPermutable<Word>
{
    private List<Letter> øletters;

    public bool IsEmpty 
        => øletters.Count == 0; 

    public Letter this[int index]
    {
        get => øletters[index];
        private set => øletters[index] = value;
    }

    public int Count
        => øletters.Count;

    public Word(List<Letter> list)
    {
        øletters = new List<Letter>();

        Assert.IsNotNull(list);
        Assert.IsTrue(list.TrueForAll((Letter letter) => { return letter != null; }));

        øletters.AddRange(list);
    }

    public Word Slice(int start)
    {
        int sublist_count = Count - start;
        List<Letter> sublist = øletters.GetRange(start, sublist_count);
        return new Word(sublist);
    }

    

    public IEnumerable<Word> UniquePermutations()
    {
        Permutator permutator = new Permutator();
        RankedWord ranked_this = new RankedWord(this);

        foreach (RankedWord ranked_word in permutator.UniquePermutations(ranked_this))
        {
            Word unranked_word = ranked_word.UnrankWord();
            yield return unranked_word;
        }
    }

    public IEnumerable<Word> AnalyzedUniquePermutations(GraphemeRuleSet rules)
    {
        foreach (Word word in UniquePermutations())
            if (rules.RespectsRules(word))
                yield return word;
    }

    public IEnumerable<Word> SortedAndAnalyzedUniquePermutations(GraphemeRuleSet rules)
    {
        var sorted = from element in AnalyzedUniquePermutations(rules)
                     orderby element.ToString()
                     select element;
        foreach (Word word in sorted)
            yield return word;
    }

    public override string ToString()
    {
        string str = "";
        foreach (Letter v in this)
            str += v.Value;
        return str;
    }


    public IEnumerator<Letter> GetEnumerator()
    {
        return øletters.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }

    public Word Swap(int position1, int position2)
    {
        Word word = new Word(øletters);
        Letter l1 = word[position1];
        word[position1] = word[position2];
        word[position2] = l1;
        return word;
    }
}