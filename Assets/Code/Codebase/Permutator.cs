using System;
using System.Collections.Generic;


public class Permutator
{
    public static IEnumerable<VariableLetterGroup> AnalyzedUniquePermutations<T>(VariableLetterGroup letters, GraphemeSet<T> graphemes)
        where T : Grapheme, new()
    {
        foreach (VariableLetterGroup vlg in UniquePermutations(letters))
            if (vlg.IsValidAccordingToGraphemeSet<T>(graphemes))
                yield return vlg;
    }

    public static IEnumerable<VariableLetterGroup> AnalyzedPermutations<T>(VariableLetterGroup letters, GraphemeSet<T> graphemes)
        where T : Grapheme, new()
    {
        foreach (VariableLetterGroup vlg in Permutations(letters))
            if (vlg.IsValidAccordingToGraphemeSet<T>(graphemes))
                yield return vlg;
    }


    public static IEnumerable<VariableLetterGroup> UniquePermutations(VariableLetterGroup letters)
    {
        VariableLetterGroup vlg = RankLetters(letters);

        foreach (VariableLetterGroup v in Permutations(vlg))
        {
            VariableLetterGroup copy = new VariableLetterGroup(v);
            bool copy_is_consumed = false;

            while (!copy_is_consumed)
            {
                int i = 0;
                int j = 1;
                bool permutation_is_valid = true;

                while (j < copy.Length())
                {
                    if (copy[j] == copy[i])
                    {
                        // we suppose the job is well done : unique rank for each identical letter
                        if (copy[j].GetRank() > copy[i].GetRank())
                        {
                            copy.RemoveAt(i);
                            i = j - 1;
                        }
                        else
                        {
                            permutation_is_valid = false;
                            break;
                        }                            
                    }
                    else
                        j++;
                }

                if (!permutation_is_valid)
                    break;

                copy.RemoveAt(i);
                
                if (copy.Length() == 0)
                    copy_is_consumed = true;
            }

            if (copy_is_consumed)
                yield return v;
        }
    }

    public static IEnumerable<VariableLetterGroup> Permutations(VariableLetterGroup letters)
    {
        int letters_length = letters.Length();
        
        for (int i = 0; i < letters_length; i++)
        {
            if (letters_length == 1)
                yield return letters;
            else
            {
                VariableLetterGroup res = new VariableLetterGroup(letters[i]);
                VariableLetterGroup vlg_to_permute = new VariableLetterGroup(letters);
                vlg_to_permute.RemoveAt(i);
                foreach (VariableLetterGroup vlg_permuted in Permutations(vlg_to_permute))
                    yield return res + vlg_permuted;
            }
        }
    }

    private static VariableLetterGroup RankLetters(VariableLetterGroup letters)
    {
        VariableLetterGroup copy = new VariableLetterGroup(letters);
        VariableLetterGroup res = new VariableLetterGroup();

        while (copy.Length() > 0)
        {
            res.Add(new Letter(copy[0].GetLetter()));

            int i = 1;
            int rank = 1;

            while (i < copy.Length())
            {
                if (copy[i] == copy[0])
                {
                    res.Add(new Letter(copy[i].GetLetter(), rank));
                    copy.RemoveAt(i);
                    rank++;
                }
                else
                    i++;
            }

            copy.RemoveAt(0);
        }

        return res;
    }
}
