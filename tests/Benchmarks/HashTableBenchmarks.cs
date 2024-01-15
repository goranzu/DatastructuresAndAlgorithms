using Algorithms.Course;
using BenchmarkDotNet.Attributes;

namespace Benchmarks;

[MemoryDiagnoser]
public class HashTableBenchmarks
{
    private HashTable<string, List<int>> _hashTable;
    private List<KeyValuePair<string, List<int>>> _data;
    private List<int> _newValue;
    private Random _random;

    [Params(100, 1_000, 10_000, 100_000)] public int N;

    [GlobalSetup]
    public void Setup()
    {
        _hashTable = new HashTable<string, List<int>>(N);
        _data = GenerateData(N);
        _newValue = [-1];
        _random = new Random();

        foreach (var keyValuePair in _data)
        {
            _hashTable.Insert(keyValuePair.Key, keyValuePair.Value);
        }
    }

    /*
       | Method | N      | Mean             | Error         | StdDev        | Gen0     | Gen1     | Gen2     | Allocated |
       |------- |------- |-----------------:|--------------:|--------------:|---------:|---------:|---------:|----------:|
       | Insert | 100    |      2,024.11 ns |     29.375 ns |     27.477 ns |   0.5836 |   0.0038 |        - |    4888 B |
       | Search | 100    |         20.84 ns |      0.064 ns |      0.060 ns |        - |        - |        - |         - |
       | Update | 100    |         22.15 ns |      0.034 ns |      0.031 ns |        - |        - |        - |         - |
       | Remove | 100    |         14.40 ns |      0.013 ns |      0.010 ns |        - |        - |        - |         - |
       | Insert | 1000   |     25,696.00 ns |    133.509 ns |    124.885 ns |   5.7373 |   0.0305 |        - |   48088 B |
       | Search | 1000   |         22.74 ns |      0.108 ns |      0.101 ns |        - |        - |        - |         - |
       | Update | 1000   |         23.36 ns |      0.093 ns |      0.087 ns |        - |        - |        - |         - |
       | Remove | 1000   |         15.40 ns |      0.036 ns |      0.033 ns |        - |        - |        - |         - |
       | Insert | 10000  |    333,377.86 ns |  3,921.893 ns |  3,668.541 ns |  57.1289 |  14.1602 |        - |  480088 B |
       | Search | 10000  |         30.57 ns |      0.630 ns |      1.086 ns |        - |        - |        - |         - |
       | Update | 10000  |         30.71 ns |      0.492 ns |      0.436 ns |        - |        - |        - |         - |
       | Remove | 10000  |         18.58 ns |      0.386 ns |      0.379 ns |        - |        - |        - |         - |
       | Insert | 100000 | 11,136,329.47 ns | 54,222.280 ns | 50,719.554 ns | 562.5000 | 343.7500 | 187.5000 | 4800252 B |
       | Search | 100000 |         37.59 ns |      0.772 ns |      0.977 ns |        - |        - |        - |         - |
       | Update | 100000 |         37.97 ns |      0.787 ns |      1.023 ns |        - |        - |        - |         - |
       | Remove | 100000 |         23.61 ns |      0.418 ns |      0.391 ns |        - |        - |        - |         - |
       
       
       Very fast searching, updating and removing. Size of the table has very little effect on these operations.
       But as the table grows insertions get slow(when table grows large) and take up much memory.
       
       Search is O(1) constant. IN LL and DA it is linear O(n).
       
       Insertion/Removing in Stack, Dequeue is faster O(1) but no random index accessor.
       
       Linked List better at removing and inserting but you need to know which node. Finding a node is linear O(n)
       
       This benchmark proves that weak points of a hash table are insertion when table grows large and memory usage.
       Other operations are fast and size of table has little impact on them.
       
       Memory is especially bad because of Chaining. Linked Lists need to store extra pointers.
            */

    [Benchmark]
    public void Insert()
    {
        var localHashTable = new HashTable<string, List<int>>(N);

        foreach (var keyValuePair in _data)
        {
            localHashTable.Insert(keyValuePair.Key, keyValuePair.Value);
        }
    }

    [Benchmark]
    public void Search()
    {
        _ = _hashTable.Search(GetRandomKey());
    }

    [Benchmark]
    public void Update()
    {
        _hashTable.Update(GetRandomKey(), _newValue);
    }

    [Benchmark]
    public void Remove()
    {
        _hashTable.Remove(GetRandomKey());
    }


    private List<KeyValuePair<string, List<int>>> GenerateData(int count)
    {
        var data = new List<KeyValuePair<string, List<int>>>(count);
        for (int i = 0; i < count; i++)
        {
            data.Add(new KeyValuePair<string, List<int>>("key" + i, [i]));
        }

        return data;
    }

    private string GetRandomKey()
    {
        int index = _random.Next(_data.Count);
        return _data[index].Key;
    }
}