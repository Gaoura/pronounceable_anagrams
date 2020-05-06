using System;

namespace Old
{
    public class LetterException : ArgumentException
    {
        public LetterException(string message) : base(message)
        {
        }
    }
}