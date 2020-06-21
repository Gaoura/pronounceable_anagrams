using System;

public sealed partial class RankedWord
{
    private sealed partial class RankedLetter
    {
        public Letter Letter { get; private set; }
        public uint Rank { get; set; }

        public RankedLetter(Letter letter, uint rank)
        {
            Letter = letter;
            Rank = rank;
        }

        public override int GetHashCode()
        {
            return Letter.GetHashCode();
        }

        public override bool Equals(object o)
        {
            return Letter.Equals(((RankedLetter)o)?.Letter);
        }

        public static bool operator ==(RankedLetter a, RankedLetter b)
        {
            // if both are null, or both are same instance, return true
            if (Object.ReferenceEquals(a, b))
                return true;

            // if one or both are null, return false
            if (((object)a == null) || ((object)b == null))
                return false;

            return a.Letter == b.Letter;
        }

        public static bool operator !=(RankedLetter a, RankedLetter b)
        {
            return !(a == b);
        }
    }
}