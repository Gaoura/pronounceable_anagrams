using System.Collections.Generic;
using UnityEngine.Assertions;

public sealed partial class RankedWord : IRankable, IPermutable<RankedWord>
{
    private List<RankedLetter> øletters;

    public int Count 
        => øletters.Count;

    private RankedLetter this[int index]
    {
        get => øletters[index];
        set => øletters[index] = value;
    }

    private RankedWord(List<RankedLetter> list)
    {
        øletters = new List<RankedLetter>();

        Assert.IsNotNull(list);
        Assert.IsTrue(list.TrueForAll((RankedLetter letter) => { return letter != null; }));

        øletters.AddRange(list);
    }

    public RankedWord(Word word)
    {
        øletters = new List<RankedLetter>();

        Assert.IsNotNull(word);

        foreach (Letter letter in word)
        {
            øletters.Add(new RankedLetter(letter, 0));
        }

        Rank();
    }

    public void Rank()
    {
        Dictionary<Letter, uint> letter_occurrences = new Dictionary<Letter, uint>();

        foreach (RankedLetter ranked_letter in øletters)
        {
            Letter letter = ranked_letter.Letter;
            // the rank of a letter starts at 0
            uint letter_rank;
            if (letter_occurrences.ContainsKey(letter))
            {
                letter_rank = letter_occurrences[letter];
                letter_occurrences[letter] = letter_rank + 1;
            }
            else
            {
                letter_rank = 0;
                letter_occurrences.Add(letter, 1);
            }

            ranked_letter.Rank = letter_rank;
        }
    }

    public bool IsOrdered()
    {
        int letter_count = Count;

        for (int i = 0; i < letter_count; ++i)
        {
            for (int j = i + 1; j < letter_count; ++j)
            {
                RankedLetter a = øletters[i];
                RankedLetter b = øletters[j];

                if (a == b)
                    if (a.Rank > b.Rank)
                        return false;
            }
        }

        return true;
    }

    public Word UnrankWord()
    {
        List<Letter> unranked_letters = new List<Letter>();

        foreach (RankedLetter letter in øletters)
        {
            unranked_letters.Add(letter.Letter);
        }

        Word unranked_word = new Word(unranked_letters);
        return unranked_word;
    }

    RankedWord IPermutable<RankedWord>.Swap(int position1, int position2)
    {
        Assert.IsTrue(position1 >= 0);
        Assert.IsTrue(position2 >= 0);

        RankedWord word = new RankedWord(øletters);
        RankedLetter l1 = word[position1];
        word[position1] = word[position2];
        word[position2] = l1;
        return word;
    }

    private sealed partial class RankedLetter
    {
    }

}
