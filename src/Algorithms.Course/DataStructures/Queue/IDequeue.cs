namespace Algorithms.Course.DataStructures.Queue;

public interface IDequeue<T>
{
    int Count { get; }
    void InsertLeft(T item);
    void InsertRight(T item);
    T? DeleteLeft();
    T? DeleteRight();
}