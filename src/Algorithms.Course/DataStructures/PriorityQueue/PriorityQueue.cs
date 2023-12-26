namespace Algorithms.Course.DataStructures.PriorityQueue;

public interface IPriorityQueue<T> where T : IComparable<T>
{
    int Count { get; }
    void Enqueue(T item);
    T? Dequeue();
    T? Peek();
}

public sealed class PriorityQueue<T> : IPriorityQueue<T> where T : IComparable<T>
{
    public int Count { get; private set; } = 0;
    public Node<T>? Head { get; set; }

    public void Enqueue(T item)
    {
        throw new NotImplementedException();
    }

    public T? Dequeue()
    {
        throw new NotImplementedException();
    }

    public T? Peek()
    {
        throw new NotImplementedException();
    }
}

public sealed class Node<T>(T value)
{
    public T Value { get; set; } = value;
    public Node<T>? Next { get; set; } = null;
}

public sealed class Person : IComparable<Person>
{
    public required string Name { get; set; }
    public int Age { get; set; }


    public int CompareTo(Person? other)
    {
        if (ReferenceEquals(this, other)) return 0;
        if (ReferenceEquals(null, other)) return 1;
        return Age.CompareTo(other.Age);
    }
}