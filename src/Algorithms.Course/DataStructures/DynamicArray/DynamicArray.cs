namespace Algorithms.Course.DataStructures.DynamicArray;

public interface IDynamicArray<T>
{
    int Count { get; }
    int Capacity { get; }

    T this[int index] { get; set; }

    void Add(T item);
    void InsertAt(int index, T item);
    int IndexOf(T item);
    T? Get(int index);
    T? Find(T item);
    bool Contains(T item);
    bool Remove(T item);
    void RemoveAt(int index);
    void Clear();
}

public sealed class DynamicArray<T> : IDynamicArray<T>
{
    public int Count { get; private set; } = 0;
    public int Capacity { get; }
    private T[] _data;

    public DynamicArray(int capacity = 10)
    {
        Capacity = capacity;
        _data = new T[Capacity];
    }

    public T this[int index]
    {
        get
        {
            if (index < 0 || index >= Count)
            {
                throw new InvalidOperationException();
            }

            return _data[index];
        }
        set
        {
            if (index < 0 || index >= Count)
            {
                throw new InvalidOperationException();
            }

            if (Count == _data.Length)
            {
                Array.Resize(ref _data, Capacity * 2);
            }

            for (var i = Count; i > index; i--)
            {
                _data[i] = _data[i - 1];
            }

            _data[index] = value;
            Count++;
        }
    }

    public void Add(T item)
    {
        if (Count == Capacity)
        {
            Array.Resize(ref _data, Capacity * 2);
        }

        // add to the end
        _data[Count] = item;
        Count++;
    }

    public void InsertAt(int index, T item)
    {
        if (index < 0 || index >= Count)
        {
            throw new InvalidOperationException();
        }

        if (Count == _data.Length)
        {
            Array.Resize(ref _data, Capacity * 2);
        }

        // shift all to the right one place
        for (var i = Count; i > index; i--)
        {
            _data[i] = _data[i - 1];
        }

        // insert at the index
        _data[index] = item;
        Count++;
    }

    public int IndexOf(T item)
    {
        var comparer = EqualityComparer<T>.Default;
        var index = -1;
        for (var i = 0; i <= Count; i++)
        {
            if (comparer.Equals(item, _data[i]))
            {
                index = i;
                break;
            }
        }

        return index;
    }

    public T Get(int index)
    {
        if (index < 0 || index >= Count)
        {
            throw new InvalidOperationException();
        }

        return _data[index];
    }

    public T? Find(T item)
    {
        var comparer = EqualityComparer<T>.Default;
        T? returnValue = default(T);
        for (var i = 0; i <= Count; i++)
        {
            if (comparer.Equals(item, _data[i]))
            {
                returnValue = _data[i];
                break;
            }
        }

        return returnValue;
    }

    public bool Contains(T item)
    {
        var found = false;
        var comparer = EqualityComparer<T>.Default;
        for (var i = 0; i <= Count; i++)
        {
            if (comparer.Equals(item, _data[i]))
            {
                found = true;
                break;
            }
        }

        return found;
    }

    public bool Remove(T item)
    {
        var removed = false;
        var comparer = EqualityComparer<T>.Default;

        for (var i = 0; i < Count; i++)
        {
            if (comparer.Equals(item, _data[i]))
            {
                // if found, shift all one place to left from the index it is found at
                for (var j = i; j < Count - 1; j++)
                {
                    _data[j] = _data[j + 1];
                }

                Count--;
                removed = true;
                break;
            }
        }

        return removed;
    }

    public void RemoveAt(int index)
    {
        if (index < 0 || index >= Count)
        {
            throw new InvalidOperationException();
        }

        for (var i = index; i < Count - 1; i++)
        {
            _data[i] = _data[i + 1];
        }

        Count--;
    }

    public void Clear()
    {
        Count = 0;
    }
}