using System.Collections.Generic;


public abstract class LetterGroup
{
    protected List<Letter> _letters = new List<Letter>();


    // Constructors 

    protected LetterGroup() { }

    protected LetterGroup(char value)
        : this(value.ToString()) { }

    protected LetterGroup(string value)
    {
        if (value == null || value.Length == 0)
            throw new LetterGroupException("Parameter is empty");

        foreach (char c in value)
            _letters.Add(new Letter(c));
    }

    protected LetterGroup(Letter letter)
    {
        _letters.Add(letter);
    }

    protected LetterGroup(LetterGroup letters)
        : this(letters.GetLetters()) { }

    protected LetterGroup(List<Letter> list)
    {
        foreach (Letter v in list)
            _letters.Add(v);
    }


    // Interface

    public List<Letter> GetLetters()
    {
        return _letters;
    }

    public Letter Get(int index)
    {
        return _letters[index];
    }

    public Letter this[int index]
    {
        get { return _letters[index]; }
    }


    public abstract int Length();


    // Inherited methods

    public override string ToString()
    {
        string str = "";
        foreach (Letter v in _letters)
            str += v.GetLetter();
        return str;
    }
}