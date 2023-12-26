namespace Algorithms.Course.DataStructures.Stack;

public interface IStack<T>
{
    int Count { get; }
    void Push(T item);
    T Pop();
    T Peek();
    bool IsEmpty();
}