namespace Algorithms.Course.DataStructures.Stack;

public class Stack<T> : IStack<T>
{
    public int Count { get; private set; } = 0;
    private Node<T>? Head { get; set; } = null;

    public void Push(T item)
    {
        Count++;
        var sNode = new Node<T>(item);
        if (Count == 1)
        {
            Head = sNode;
            return;
        }

        sNode.Prev = Head;
        Head = sNode;
    }

    public T Pop()
    {
        Count = Math.Max(0, Count - 1);
        Node<T>? head;
        if (Count == 0)
        {
            head = Head;
            Head = null;
            return head is not null ? head.Value : throw new InvalidOperationException();
        }

        head = Head;

        Head = head?.Prev;
        return head is not null ? head.Value : throw new InvalidOperationException();
    }

    public T Peek()
    {
        return Head is not null ? Head.Value : throw new InvalidOperationException();
    }

    public bool IsEmpty()
    {
        return Count == 0;
    }
}