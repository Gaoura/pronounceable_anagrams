using System.Collections.Generic;
using System.Linq;


namespace Old
{
    public class VariableLetterGroup : LetterGroup
    {
        // Constructors 
        public VariableLetterGroup() { }

        public VariableLetterGroup(char value)
            : base(value) { }

        public VariableLetterGroup(string value)
            : base(value) { }

        public VariableLetterGroup(Letter letter)
            : base(letter) { }

        public VariableLetterGroup(LetterGroup letters)
            : base(letters) { }

        public VariableLetterGroup(List<Letter> list)
            : base(list) { }


        // Interface

        public void Add(VariableLetterGroup value)
        {
            foreach (Letter v in value.GetLetters())
                _letters.Add(v);
        }

        public void Add(Letter value)
        {
            _letters.Add(value);
        }

        public void Add(string value)
        {
            _letters.Add(new Letter(value));
        }

        public void RemoveAt(int index)
        {
            _letters.RemoveAt(index);
        }

        public override int Length()
        {
            return _letters.Count;
        }

        public static VariableLetterGroup operator +(VariableLetterGroup a, VariableLetterGroup b)
        {
            VariableLetterGroup c = new VariableLetterGroup(a);
            c.Add(b);
            return c;
        }







        // PERMUTATIONS


        public IEnumerable<VariableLetterGroup> SortedAndAnalyzedUniquePermutations<T>(GraphemeSet<T> graphemes)
            where T : Grapheme, new()
        {
            var sorted = from element in AnalyzedUniquePermutations(graphemes)
                         orderby element.ToString()
                         select element;
            foreach (VariableLetterGroup vlg in sorted)
                yield return vlg;
        }

        public IEnumerable<VariableLetterGroup> AnalyzedUniquePermutations<T>(GraphemeSet<T> graphemes)
            where T : Grapheme, new()
        {
            foreach (VariableLetterGroup vlg in this.UniquePermutations())
                if (vlg.IsValidAccordingToGraphemeSet<T>(graphemes))
                    yield return vlg;
        }

        public IEnumerable<VariableLetterGroup> AnalyzedPermutations<T>(GraphemeSet<T> graphemes)
            where T : Grapheme, new()
        {
            foreach (VariableLetterGroup vlg in this.Permutations())
                if (vlg.IsValidAccordingToGraphemeSet<T>(graphemes))
                    yield return vlg;
        }

        public IEnumerable<VariableLetterGroup> UniquePermutations()
        {
            VariableLetterGroup vlg = this.RankLetters();

            foreach (VariableLetterGroup v in vlg.Permutations())
                if (v.IsOrderedAccordingToLetterRanks())
                    yield return v;
        }

        public IEnumerable<VariableLetterGroup> Permutations()
        {
            int letters_length = _letters.Count;

            for (int i = 0; i < letters_length; i++)
            {
                if (letters_length == 1)
                    yield return this;
                else
                {
                    VariableLetterGroup res = new VariableLetterGroup(_letters[i]);
                    VariableLetterGroup vlg_to_permute = new VariableLetterGroup(_letters);
                    vlg_to_permute.RemoveAt(i);
                    foreach (VariableLetterGroup vlg_permuted in vlg_to_permute.Permutations())
                        yield return res + vlg_permuted;
                }
            }
        }






        public VariableLetterGroup RankLetters()
        {
            VariableLetterGroup copy = new VariableLetterGroup(this);
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

        public bool IsValidAccordingToGraphemeSet<T>(GraphemeSet<T> graphemes)
            where T : Grapheme, new()
        {
            int letters_length = _letters.Count;
            int grapheme_length = graphemes.GetGraphemeLength();
            int last_index_index_to_check = letters_length - grapheme_length;
            bool permutation_is_valid = true;
            int i = 0;

            do
            {
                T grapheme = new T();
                grapheme.SetGrapheme(StringInRange(this.ToString(), i, grapheme_length));

                if (!graphemes.Exists(grapheme))
                    permutation_is_valid = false;

                i++;
            }
            while (i <= last_index_index_to_check && permutation_is_valid);

            return permutation_is_valid;
        }

        public bool IsOrderedAccordingToLetterRanks()
        {
            VariableLetterGroup copy = new VariableLetterGroup(this);
            bool permutation_is_valid = false;

            while (!permutation_is_valid)
            {
                int i = 0;
                int j = 1;
                bool analyzed_letter_is_well_ordered = true;

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
                            analyzed_letter_is_well_ordered = false;
                            break;
                        }
                    }
                    else
                        j++;
                }

                if (!analyzed_letter_is_well_ordered)
                    break;

                copy.RemoveAt(i);

                if (copy.Length() == 0)
                    permutation_is_valid = true;
            }

            return permutation_is_valid;
        }

        private static string StringInRange(string s, int start_index, int length)
        {
            string str = "";
            for (int i = start_index; i <= start_index + length - 1; i++)
                str += s[i];

            return str;
        }
    }
}