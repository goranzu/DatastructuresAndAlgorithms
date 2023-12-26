namespace Algorithms.Course.DataStructures.DoublyLinkedList;

public interface IDoublyLinkedList<T>
{
    int Count { get; }
    void AddFirst(T item);
    void AddLast(T item);
    void InsertAt(int index, T item);

    T RemoveFirst();
    T RemoveLast();
    void Remove(T item);
    void RemoveAt(int index);

    T? GetFirst();
    T? GetLast();
    T? GetAt(int index);

    bool Contains(T item);
    void Clear();
}