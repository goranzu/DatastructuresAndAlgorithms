namespace Algorithms.Course.DataStructures.Queue;

public sealed class Dequeue<T> : IDequeue<T>
{
    public int Count { get; private set; } = 0;
    private Node<T>? Head { get; set; } = null;
    private Node<T>? Tail { get; set; } = null;

    public void InsertLeft(T item)
    {
        Count++;
        var node = new Node<T>(item);
        if (Count == 1)
        {
            Tail = node;
            Head = node;
            return;
        }

        node.Next = Head;
        Head = node;
    }

    public void InsertRight(T item)
    {
        Count++;
        var node = new Node<T>(item);
        if (Count == 1)
        {
            Tail = node;
            Head = node;
            return;
        }

        if (Tail is not null)
        {
            Tail.Next = node;
        }

        Tail = node;
    }

    public T? DeleteLeft()
    {
        if (Head is null)
        {
            return default(T?);
        }

        Count--;
        var head = Head;
        Head = Head.Next;
        if (Head is null)
        {
            Tail = null;
        }

        return head.Value;
    }

    public T? DeleteRight()
    {
        if (Tail is null)
        {
            return default;
        }

        Count--;

        if (Head == Tail)
        {
            var tail = Tail;
            Head = Tail = null;
            return tail.Value;
        }

        var current = Head;

        while (current?.Next != Tail)
        {
            current = current?.Next;
        }

        var tailNode = Tail;
        Tail = current;
        Tail.Next = null;
        return tailNode.Value;
    }
}