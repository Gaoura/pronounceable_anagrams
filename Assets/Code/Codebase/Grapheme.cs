using System.Collections.Generic;


namespace Old
{
    public abstract class Grapheme : LetterGroup
    {
        // Constructors 

        protected Grapheme() { }

        protected Grapheme(char value)
            : base(value.ToString()) { }

        protected Grapheme(string value)
            : base(value)
        {
            if (value.Length != this.Length())
                throw new GraphemeException("Parameter is empty");
        }

        protected Grapheme(LetterGroup letters)
            : base(letters.GetLetters()) { }

        protected Grapheme(List<Letter> list)
            : base(list)
        {
            if (list.Count != this.Length())
                throw new GraphemeException("Parameter cannot be converted to a grapheme");
        }

        public void SetGrapheme(string value)
        {
            if (value.Length != this.Length())
                throw new GraphemeException("Parameter cannot be converted to a grapheme");

            foreach (char c in value)
                _letters.Add(new Letter(c));
        }
    }
}