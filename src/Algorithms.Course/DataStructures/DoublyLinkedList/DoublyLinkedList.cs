namespace Algorithms.Course.DataStructures.DoublyLinkedList;

public sealed class DoublyLinkedList<T> : IDoublyLinkedList<T>
{
    private Node<T>? Head { get; set; }
    private Node<T>? Tail { get; set; }
    public int Count { get; private set; }

    public void AddFirst(T item)
    {
        var newNode = new Node<T>(item);
        if (Head is null)
        {
            Head = newNode;
            Tail = newNode;
        }
        else
        {
            newNode.Next = Head;
            Head.Prev = newNode;
            Head = newNode;
        }

        Count++;
    }

    public void AddLast(T item)
    {
        var newNode = new Node<T>(item);
        if (Tail is null)
        {
            Head = newNode;
            Tail = newNode;
        }
        else
        {
            Tail.Next = newNode;
            newNode.Prev = Tail;
            Tail = newNode;
        }

        Count++;
    }

    public void InsertAt(int index, T item)
    {
        if (index < 0 || index > Count)
        {
            throw new ArgumentOutOfRangeException(nameof(index));
        }

        var i = 0;
        var newNode = new Node<T>(item);

        if (index == 0)
        {
            newNode.Next = Head;
            if (Head is not null)
            {
                Head.Prev = newNode;
            }

            Head = newNode;
        }
        else if (index == Count)
        {
            newNode.Prev = Tail;
            if (Tail is not null)
            {
                Tail.Next = newNode;
            }

            Tail = newNode;
        }
        else
        {
            var current = Head;
            while (current is not null)
            {
                if (i == index)
                {
                    newNode.Next = current;
                    newNode.Prev = current.Prev;

                    if (current.Prev is not null)
                    {
                        current.Prev.Next = newNode;
                    }

                    current.Prev = newNode;
                }

                current = current.Next;
                i++;
            }

            Count++;
        }
    }

    public T RemoveFirst()
    {
        if (Head is null)
        {
            throw new InvalidOperationException();
        }

        var first = Head;
        if (Head.Next is not null)
        {
            Head.Next.Prev = null;
            Head = Head.Next;
        }
        else
        {
            Head = null;
            Tail = null;
        }

        Count--;

        return first.Val;
    }

    public T RemoveLast()
    {
        if (Tail is null)
        {
            throw new InvalidOperationException();
        }

        var last = Tail.Val;

        if (Tail.Prev is not null)
        {
            Tail.Prev.Next = null;
            Tail = Tail.Prev;
        }
        else
        {
            Head = null;
            Tail = null;
        }

        Count--;
        return last;
    }

    public void Remove(T item)
    {
        var current = Head;

        if (current is null)
        {
            return;
        }

        while (current is not null)
        {
            if (Equals(current.Val, item))
            {
                if (current.Prev is not null)
                {
                    current.Prev.Next = current.Next;
                }
                else
                {
                    Head = current.Next;
                }

                if (current.Next is not null)
                {
                    current.Next.Prev = current.Prev;
                }
                else
                {
                    Tail = current.Prev;
                }

                Count--;
                return;
            }

            current = current.Next;
        }
    }

    public void RemoveAt(int index)
    {
        if (index < 0 || index >= Count)
        {
            throw new ArgumentOutOfRangeException(nameof(index));
        }

        var current = Head;
        var i = 0;

        while (current is not null)
        {
            if (index == i)
            {
                if (current.Prev is not null)
                {
                    current.Prev.Next = current.Next;
                }
                else
                {
                    Head = current.Next;
                }

                if (current.Next is not null)
                {
                    current.Next.Prev = current.Prev;
                }
                else
                {
                    Tail = current.Prev;
                }

                Count--;
                return;
            }

            i++;
            current = current.Next;
        }
    }

    public T? GetFirst()
    {
        return Head is not null ? Head.Val : default;
    }

    public T? GetLast()
    {
        return Tail is not null ? Tail.Val : default;
    }

    public T? GetAt(int index)
    {
        if (index < 0 || index >= Count)
        {
            return default;
        }

        var current = Head;
        var i = 0;
        T? found = default;
        while (current is not null)
        {
            if (index == i)
            {
                found = current.Val;
                break;
            }

            i++;
            current = current.Next;
        }

        return found;
    }

    public bool Contains(T item)
    {
        var current = Head;
        var found = false;
        while (current is not null)
        {
            if (Equals(item, current.Val))
            {
                found = true;
                break;
            }

            current = current.Next;
        }

        return found;
    }

    public void Clear()
    {
        var current = Head;
        while (current is not null)
        {
            var temp = current.Next;
            current.Prev = null;
            current.Next = null;
            current = temp;
        }

        Head = null;
        Tail = null;
        Count = 0;
    }
}