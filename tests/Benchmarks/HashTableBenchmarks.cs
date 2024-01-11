using Algorithms.Course;
using BenchmarkDotNet.Attributes;

namespace Benchmarks;

[MemoryDiagnoser]
public class HashTableBenchmarks
{
    private HashTable<string, List<int>> _hashTable;
    private List<KeyValuePair<string, List<int>>> _data;
    private string _keyToSearch;
    private string _keyToUpdate;
    private string _keyToRemove;
    private List<int> _newValue;
    private Random _random;

    [Params(100, 10_000)] public int N;

    [GlobalSetup]
    public void Setup()
    {
        _hashTable = new HashTable<string, List<int>>(N);
        _data = GenerateData(N);
        _keyToSearch = _data[N / 2].Key;
        _keyToUpdate = _data[N / 4].Key;
        _keyToRemove = _data[3 * N / 4].Key;
        _newValue = [-1];

        foreach (var keyValuePair in _data)
        {
            _hashTable.Insert(keyValuePair.Key, keyValuePair.Value);
        }
    }

    /*
       | Method | N     | Mean           | Error         | StdDev        | Gen0    | Gen1    | Allocated |
       |------- |------ |---------------:|--------------:|--------------:|--------:|--------:|----------:|
       | Insert | 100   |   1,944.636 ns |    38.8111 ns |    38.1176 ns |  0.5836 |  0.0038 |    4888 B |
       | Search | 100   |       3.545 ns |     0.0122 ns |     0.0095 ns |       - |       - |         - |
       | Update | 100   |       4.214 ns |     0.0132 ns |     0.0117 ns |       - |       - |         - |
       | Remove | 100   |       3.305 ns |     0.0225 ns |     0.0211 ns |       - |       - |         - |
       | Insert | 10000 | 336,516.327 ns | 4,194.7487 ns | 3,923.7706 ns | 57.1289 | 14.1602 |  480088 B |
       | Search | 10000 |       6.409 ns |     0.0407 ns |     0.0381 ns |       - |       - |         - |
       | Update | 10000 |       7.073 ns |     0.0240 ns |     0.0225 ns |       - |       - |         - |
       | Remove | 10000 |       7.518 ns |     0.0282 ns |     0.0264 ns |       - |       - |         - |
       
       
       Very fast searching, updating and removing. Size of the table has very little effect on these operations.
       But as the table grows insertions get slow(when table grows large) and take up much memory.
       
       Search is O(1) constant. IN LL and DA it is linear O(n).
       
       Insertion/Removing in Stack, Dequeue is faster O(1) but no random index accessor.
       
       This benchmark proves that weak points of a hash table are insertion when table grows large and memory usage.
       Other operations are fast and size of table has little impact on them.
            */

    [Benchmark]
    public void Insert()
    {
        /*
         * | Method | N     | Mean       | Error     | StdDev    | Gen0    | Gen1    | Allocated |
           |------- |------ |-----------:|----------:|----------:|--------:|--------:|----------:|
           | Insert | 100   |   1.949 us | 0.0243 us | 0.0227 us |  0.5836 |  0.0019 |   4.77 KB |
           | Insert | 10000 | 328.415 us | 5.5247 us | 5.1678 us | 57.1289 | 14.1602 | 468.84 KB |

         */
        var localHashTable = new HashTable<string, List<int>>(N);

        foreach (var keyValuePair in _data)
        {
            localHashTable.Insert(keyValuePair.Key, keyValuePair.Value);
        }
    }

    [Benchmark]
    public void Search()
    {
        /*
         * | Method | N     | Mean     | Error     | StdDev    | Allocated |
           |------- |------ |---------:|----------:|----------:|----------:|
           | Search | 100   | 3.528 ns | 0.0304 ns | 0.0254 ns |         - |
           | Search | 10000 | 4.013 ns | 0.0074 ns | 0.0062 ns |         - |

         */
        _ = _hashTable.Search(_keyToSearch);
    }

    [Benchmark]
    public void Update()
    {
        /*
         * | Method | N     | Mean     | Error     | StdDev    | Allocated |
           |------- |------ |---------:|----------:|----------:|----------:|
           | Search | 100   | 3.528 ns | 0.0304 ns | 0.0254 ns |         - |
           | Search | 10000 | 4.013 ns | 0.0074 ns | 0.0062 ns |         - |
         */
        _hashTable.Update(_keyToUpdate, _newValue);
    }

    [Benchmark]
    public void Remove()
    {
        /*
         *  | Method | N     | Mean     | Error     | StdDev    | Allocated |
           |------- |------ |---------:|----------:|----------:|----------:|
           | Remove | 100   | 7.324 ns | 0.0327 ns | 0.0306 ns |         - |
           | Remove | 10000 | 3.762 ns | 0.0111 ns | 0.0098 ns |         - |
         */
        _hashTable.Remove(_keyToRemove);
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

    private void ResetHashTable()
    {
        _hashTable = new HashTable<string, List<int>>(N);
        foreach (var keyValuePair in _data)
        {
            _hashTable.Insert(keyValuePair.Key, keyValuePair.Value);
        }
    }

    private string GetRandomKey()
    {
        int index = _random.Next(_data.Count);
        return _data[index].Key;
    }
}