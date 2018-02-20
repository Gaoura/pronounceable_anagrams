using System;

public class LetterGroupException : ArgumentException
{
    public LetterGroupException(string message) : base(message)
    {
    }
}