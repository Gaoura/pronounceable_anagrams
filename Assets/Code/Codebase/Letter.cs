using System;
using System.Text.RegularExpressions;

public sealed class Letter
{
    public char Value { get; private set; }


    // Constructors 

    public Letter(char value)
    {
        if (!IsLetter(value))
            throw new LetterException($"{value} is not a letter");

        Value = value;
    }

    // static

    public static bool IsLetter(char value)
    {
        Regex regex = new Regex(@"^(?=\D)\w$");
        Match match = regex.Match(value.ToString());
        return match.Success;
    }


    // Inherited methods

    public override string ToString()
    {
        return Value.ToString();
    }

    public override int GetHashCode()
    {
        return Value.GetHashCode();
    }

    public override bool Equals(object o)
    {
        return Value.Equals(((Letter)o)?.Value);
    }


    public static bool operator ==(Letter a, Letter b)
    {
        // if both are null, or both are same instance, return true
        if (Object.ReferenceEquals(a, b))
            return true;

        // if one or both are null, return false
        if (((object)a == null) || ((object)b == null))
            return false;

        return a.Value == b.Value;
    }

    public static bool operator !=(Letter a, Letter b)
    {
        return !(a == b);
    }
}
