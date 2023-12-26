namespace Algorithms.Course.DataStructures.Queue;

public interface IQueue<T>
{
    int Count { get; }
    void Enqueue(T item);
    T? Dequeue();
    T? Peek();
}