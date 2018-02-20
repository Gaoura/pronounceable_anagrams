using System.Collections.Generic;


public class Trigram : Grapheme
{
    // Constructors 

    public Trigram() { }

    public Trigram(string value)
        : base(value) { }

    public Trigram(LetterGroup letters)
        : base(letters) { }

    public Trigram(List<Letter> list)
        : base(list) { }


    // Interface

    public override int Length()
    {
        return 3;
    }
}
