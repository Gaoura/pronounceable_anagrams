using System;

namespace Old
{
    public class LetterGroupException : ArgumentException
    {
        public LetterGroupException(string message) : base(message)
        {
        }
    }
}