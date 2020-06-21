public interface IPermutable<T>
{
    int Count { get; }
    T Swap(int position1, int position2);
}
