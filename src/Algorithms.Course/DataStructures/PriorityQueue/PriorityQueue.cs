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
    public Node<T>? Tail { get; set; }

    public void Enqueue(T item)
    {
        Count++;
        var node = new Node<T>(item);

        if (Head == null)
        {
            Head = node;
            Tail = node;
            return;
        }

        if (Head.Value.CompareTo(item) > 0)
        {
            node.Next = Head;
            Head = node;
            return;
        }

        var current = Head;
        while (current.Next is not null && current.Next.Value.CompareTo(item) <= 0)
        {
            current = current.Next;
        }

        node.Next = current.Next;
        current.Next = node;

        if (current == Tail)
        {
            Tail = node;
        }
    }

    public T? Dequeue()
    {
        if (Head is null)
        {
            return default;
        }

        Count--;
        var head = Head;
        Head = Head.Next;

        if (Head is null)
        {
            Tail = null;
        }

        head.Next = null;
        return head.Value;
    }

    public T? Peek()
    {
        return Head is not null ? Head.Value : default;
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