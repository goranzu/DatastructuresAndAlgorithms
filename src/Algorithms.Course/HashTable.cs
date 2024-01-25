namespace Algorithms.Course;

public interface IHashTable<in TKey, TValue>
{
    int Count { get; }
    void Insert(TKey key, TValue? value);
    TValue? Search(TKey key);
    void Remove(TKey key);
    void Update(TKey key, TValue newValue);
}

public class HashTable<TKey, TValue> : IHashTable<TKey, TValue>
{
    private class HashNode
    {
        public TKey Key;
        public TValue? Value;
        public HashNode? Next;

        public HashNode(TKey key, TValue? value)
        {
            Key = key;
            Value = value;
            Next = null;
        }
    }

    private List<HashNode?> _buckets;
    private int _size;
    public int Count { get; private set; } = 0;

    
    public HashTable(int size)
    {
        this._size = size;
        _buckets = new List<HashNode?>(size);
        for (int i = 0; i < size; i++)
        {
            _buckets.Add(null);
        }
    }

    private int GetBucketIndex(TKey key)
    {
        int hashCode = key!.GetHashCode();
        int index = hashCode % _size;
        return Math.Abs(index);
    }

    public void Insert(TKey key, TValue? value)
    {
        int bucketIndex = GetBucketIndex(key);
        HashNode? head = _buckets[bucketIndex];

        while (head is not null)
        {
            if (head.Key is not null && head.Key.Equals(key))
            {
                head.Value = value;
                return;
            }

            head = head.Next;
        }

        head = _buckets[bucketIndex];
        HashNode? newNode = new HashNode(key, value);
        newNode.Next = head;
        _buckets[bucketIndex] = newNode;

        if (!Search(key)?.Equals(value) is not null)
        {
            Count++;
        }
    }

    public TValue? Search(TKey key)
    {
        int bucketIndex = GetBucketIndex(key);
        HashNode? head = _buckets[bucketIndex];

        while (head is not null)
        {
            if (head.Key is not null && head.Key.Equals(key))
            {
                return head.Value;
            }

            head = head.Next;
        }

        return default;
    }

    public void Remove(TKey key)
    {
        int bucketIndex = GetBucketIndex(key);
        HashNode? head = _buckets[bucketIndex];

        HashNode? prev = null;

        while (head is not null)
        {
            if (head.Key is not null && head.Key.Equals(key))
            {
                break;
            }

            prev = head;
            head = head.Next;
        }

        if (head is null)
        {
            return;
        }

        if (prev is not null)
        {
            prev.Next = head.Next;
        }
        else
        {
            _buckets[bucketIndex] = head.Next;
        }

        Count--;
    }

    public void Update(TKey key, TValue newValue)
    {
        var bucketIndex = GetBucketIndex(key);
        HashNode? head = _buckets[bucketIndex];

        while (head is not null)
        {
            if (head.Key is not null && head.Key.Equals(key))
            {
                head.Value = newValue;
                return;
            }

            head = head.Next;
        }
    }
}