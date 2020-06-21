using System.Collections.Generic;
using UnityEngine;

public class LetterPool
{
    private Dictionary<char, Letter> øpool;

    public LetterPool()
    {
        øpool = new Dictionary<char, Letter>();
    }

    public Word GetLetters(string letters)
    {
        List<Letter> list = new List<Letter>();

        foreach (char c in letters)
        {
            if (øpool.ContainsKey(c))
            {
                list.Add(øpool[c]);
            }
            else
            {
                Letter letter = new Letter(c);
                list.Add(letter);
                øpool.Add(c, letter);
            }
        }

        return new Word(list);
    }
}
