using System;
using System.Text.RegularExpressions;

public struct Letter
{
    private readonly string _letter;
    private int _rank;


    // Constructors 

    public Letter(char value) 
        : this(value.ToString()) {}

    public Letter(string value)
        : this(value, 0) {}

    public Letter(string value, int rank)
    {
        if (IsLetter(value))
            _letter = value;
        else
            throw new LetterException("Parameter is not a letter");

        _rank = rank;
    }

    public Letter(Letter value) 
    {
        _letter = value.GetLetter();
        _rank = value.GetRank();
    }


    // Interface

    public string GetLetter()
    {
        return _letter;
    }

    public int GetRank()
    {
        return _rank;
    }

    public void SetRank(int rank)
    {
        // if (rank < 0) throw new LetterException("Parameter is not a positive number");
        _rank = rank;
    }



    // static


    public static bool IsLetter(char value)
    {
        return IsLetter(value.ToString());
    }

    public static bool IsLetter(string value)
    {
        Regex regex = new Regex(@"^(?=\D)\w$");
        Match match = regex.Match(value);
        return match.Success;
    }



    // Inherited methods

    public override string ToString()
    {
        return _letter;
    }

    public override int GetHashCode()
    {
        return _letter.GetHashCode();
    }

    public override bool Equals(object o)
    {
        return _letter.Equals(o.ToString());
    }



    public static bool operator ==(Letter a, Letter b)
    {
        // If both are null, or both are same instance, return true.
        if (Object.ReferenceEquals(a, b))
            return true;

        // If one is null, but not both, return false.
        if (((object)a == null) || ((object)b == null))
            return false;

        return a._letter == b._letter;
    }

    public static bool operator !=(Letter a, Letter b)
    {
        return !(a == b);
    }
}
