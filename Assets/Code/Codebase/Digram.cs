using System.Collections.Generic;


namespace Old
{
    public class Digram : Grapheme
    {
        // Constructors 

        public Digram() { }

        public Digram(string value)
            : base(value) { }

        public Digram(LetterGroup letters)
            : base(letters) { }

        public Digram(List<Letter> list)
            : base(list) { }


        // Interface

        public override int Length()
        {
            return 2;
        }
    }
}