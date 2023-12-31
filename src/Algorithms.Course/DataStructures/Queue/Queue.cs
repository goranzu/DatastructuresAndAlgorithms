namespace Algorithms.Course.DataStructures.Queue;

public sealed class Queue<T> : IQueue<T>
{
    public int Count { get; private set; } = 0;
    private Node<T>? Head { get; set; } = null;
    private Node<T>? Tail { get; set; } = null;

    public void Enqueue(T item)
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

    public T? Dequeue()
    {
        if (Head is null)
        {
            return default;
        }

        Count--;
        var head = Head;
        Head = Head.Next;
        if (Head is not null)
        {
            Head.Next = null;
        }

        if (Count == 0)
        {
            Tail = null;
        }

        return head.Value;
    }

    public T? Peek()
    {
        return Head is not null ? Head.Value : default;
    }
}