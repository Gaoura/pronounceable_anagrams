using System;

public class LetterException : ArgumentException
{
    public LetterException(string message) : base(message)
    {
    }
}