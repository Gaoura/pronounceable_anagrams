public abstract class GraphemeSet<T>
    where T : Grapheme
{
    protected int _grapheme_length;

    public int GetGraphemeLength()
    {
        return _grapheme_length;
    }

    public abstract void Add(T grapheme);
    public abstract bool Exists(T grapheme);
}