using Algorithms.Course.DataStructures.DoublyLinkedList;
using BenchmarkDotNet.Attributes;

namespace Benchmarks;

[MemoryDiagnoser]
public class DoublyLinkedListBenchmarks
{
    private DoublyLinkedList<int> _list = null!;
    [Params(10, 100, 1_000, 10_000, 100_000)] public int N;
    private int _randomIndex;
    private int _randomValue;

    // [GlobalSetup]
    // public void Setup()
    // {
    //     _list = new DoublyLinkedList<int>();
    //     for (int i = 0; i < N; i++)
    //     {
    //         _list.AddLast(i);
    //     }
    // }
    
    
    /*
     * | Method               | N      | Mean           | Error         | StdDev         | Median          | Allocated |
       |--------------------- |------- |---------------:|--------------:|---------------:|----------------:|----------:|
       | AddFirstBenchmark    | 10     |     280.466 ns |     18.832 ns |      51.868 ns |     291.0000 ns |     776 B |
       | AddLastBenchmark     | 10     |     267.885 ns |     15.000 ns |      41.062 ns |     291.0000 ns |     776 B |
       | InsertAtBenchmark    | 10     |     367.935 ns |     20.580 ns |      58.383 ns |     375.0000 ns |     776 B |
       | RemoveFirstBenchmark | 10     |      33.670 ns |      9.587 ns |      26.884 ns |      41.0000 ns |     736 B |
       | RemoveLastBenchmark  | 10     |      43.226 ns |     14.506 ns |      41.152 ns |      42.0000 ns |     736 B |
       | RemoveAtBenchmark    | 10     |      61.079 ns |     11.994 ns |      33.235 ns |      42.0000 ns |     736 B |
       | GetFirstBenchmark    | 10     |      20.463 ns |      9.147 ns |      26.245 ns |       0.0000 ns |     736 B |
       | GetLastBenchmark     | 10     |      11.515 ns |      6.748 ns |      19.578 ns |       0.0000 ns |     736 B |
       | GetAtBenchmark       | 10     |      55.000 ns |     12.046 ns |      34.562 ns |      42.0000 ns |     736 B |
       | ContainsBenchmark    | 10     |     375.543 ns |     20.028 ns |      56.816 ns |     375.5000 ns |    1120 B |
       
       | AddFirstBenchmark    | 100    |     279.966 ns |     13.514 ns |      37.222 ns |     291.0000 ns |     776 B |
       | AddLastBenchmark     | 100    |     262.144 ns |     12.949 ns |      36.096 ns |     250.0000 ns |     776 B |
       | InsertAtBenchmark    | 100    |     780.788 ns |     78.230 ns |     229.435 ns |     666.0000 ns |     776 B |
       | RemoveFirstBenchmark | 100    |      29.880 ns |      6.975 ns |      18.616 ns |      41.0000 ns |     736 B |
       | RemoveLastBenchmark  | 100    |      31.742 ns |      9.201 ns |      25.801 ns |      41.5000 ns |     736 B |
       | RemoveAtBenchmark    | 100    |     223.141 ns |     43.326 ns |     127.067 ns |     208.0000 ns |     736 B |
       | GetFirstBenchmark    | 100    |      13.639 ns |      8.166 ns |      23.691 ns |       0.0000 ns |     736 B |
       | GetLastBenchmark     | 100    |      13.500 ns |      8.093 ns |      23.609 ns |       0.0000 ns |     736 B |
       | GetAtBenchmark       | 100    |     243.010 ns |     36.361 ns |     107.212 ns |     250.0000 ns |     736 B |
       | ContainsBenchmark    | 100    |     800.040 ns |     97.978 ns |     288.891 ns |     791.0000 ns |    1504 B |
       
       | AddFirstBenchmark    | 1000   |     286.916 ns |     18.396 ns |      52.783 ns |     291.0000 ns |     776 B |
       | AddLastBenchmark     | 1000   |     258.124 ns |     14.367 ns |      39.812 ns |     250.0000 ns |     776 B |
       | InsertAtBenchmark    | 1000   |   6,659.582 ns |    263.563 ns |     739.060 ns |   6,376.0000 ns |     776 B |
       | RemoveFirstBenchmark | 1000   |      32.011 ns |      9.764 ns |      27.698 ns |      41.5000 ns |     736 B |
       | RemoveLastBenchmark  | 1000   |      40.479 ns |     11.074 ns |      31.594 ns |      41.0000 ns |     736 B |
       | RemoveAtBenchmark    | 1000   |   2,916.340 ns |    634.305 ns |   1,870.263 ns |   2,541.5000 ns |     736 B |
       | GetFirstBenchmark    | 1000   |      18.361 ns |      8.494 ns |      24.643 ns |       0.0000 ns |     736 B |
       | GetLastBenchmark     | 1000   |      16.579 ns |      8.794 ns |      25.231 ns |       0.0000 ns |     736 B |
       | GetAtBenchmark       | 1000   |   2,557.580 ns |    536.976 ns |   1,583.284 ns |   2,458.0000 ns |     736 B |
       | ContainsBenchmark    | 1000   |   7,077.590 ns |  1,506.264 ns |   4,441.253 ns |   7,541.5000 ns |   42976 B |
       
       | AddFirstBenchmark    | 10000  |     284.606 ns |     17.150 ns |      48.931 ns |     291.0000 ns |     776 B |
       | AddLastBenchmark     | 10000  |     295.582 ns |     15.816 ns |      46.136 ns |     291.0000 ns |     776 B |
       | InsertAtBenchmark    | 10000  |  17,567.358 ns |    350.607 ns |     731.847 ns |  17,333.0000 ns |     776 B |
       | RemoveFirstBenchmark | 10000  |      56.000 ns |     13.719 ns |      38.469 ns |      41.0000 ns |     736 B |
       | RemoveLastBenchmark  | 10000  |      51.812 ns |     16.072 ns |      46.371 ns |      41.0000 ns |     736 B |
       | RemoveAtBenchmark    | 10000  |  10,770.525 ns |  1,576.437 ns |   4,623.417 ns |  10,834.0000 ns |     736 B |
       | GetFirstBenchmark    | 10000  |       4.515 ns |      4.405 ns |      12.780 ns |       0.0000 ns |     736 B |
       | GetLastBenchmark     | 10000  |      20.879 ns |      9.684 ns |      27.156 ns |       0.0000 ns |     736 B |
       | GetAtBenchmark       | 10000  |  11,152.540 ns |  1,364.707 ns |   4,023.868 ns |  11,291.5000 ns |     736 B |
       | ContainsBenchmark    | 10000  |  32,530.730 ns |  4,847.871 ns |  14,294.057 ns |  32,813.5000 ns |  404224 B |
       
       | AddFirstBenchmark    | 100000 |     479.586 ns |     80.985 ns |     221.694 ns |     375.0000 ns |     776 B |
       | AddLastBenchmark     | 100000 |     383.079 ns |     47.122 ns |     130.574 ns |     375.0000 ns |     776 B |
       | InsertAtBenchmark    | 100000 | 124,720.120 ns |  4,099.789 ns |  11,563.527 ns | 122,791.5000 ns |     776 B |
       | RemoveFirstBenchmark | 100000 |     350.489 ns |     96.017 ns |     269.243 ns |     270.5000 ns |     736 B |
       | RemoveLastBenchmark  | 100000 |     239.379 ns |     87.857 ns |     240.506 ns |     167.0000 ns |     736 B |
       | RemoveAtBenchmark    | 100000 |  61,726.050 ns | 11,638.710 ns |  34,316.999 ns |  60,166.5000 ns |     736 B |
       | GetFirstBenchmark    | 100000 |     144.589 ns |     48.499 ns |     135.195 ns |     124.0000 ns |     736 B |
       | GetLastBenchmark     | 100000 |      88.942 ns |     39.664 ns |     107.909 ns |      42.0000 ns |     736 B |
       | GetAtBenchmark       | 100000 |  70,243.778 ns | 12,060.834 ns |  35,372.338 ns |  72,208.0000 ns |     736 B |
       | ContainsBenchmark    | 100000 | 225,516.551 ns | 46,452.964 ns | 136,238.503 ns | 213,895.5000 ns | 2720848 B |
       
       
       These results show that the AddFirst, AddLast, RemoveFirst, RemoveLast, GetFirst, and GetLast methods are O(1) operations.
       InsertAt and RemoveAt methods are O(n) operations.
       Contains method is O(n) operation.
     */
    
    [IterationSetup]
    public void IterationSetup()
    {
        _list = new DoublyLinkedList<int>();
        for (int i = 0; i < N; i++)
        {
            _list.AddLast(i);
        }
        var rnd = new Random();
        _randomIndex = rnd.Next(0, N);
        _randomValue = rnd.Next(0, N);
    }

    [Benchmark]
    public void AddFirstBenchmark()
    {
        _list.AddFirst(-1);
    }

    [Benchmark]
    public void AddLastBenchmark()
    {
        _list.AddLast(N + 1);
    }

    [Benchmark]
    public void InsertAtBenchmark()
    {
        _list.InsertAt(_randomIndex, 999);
    }

    [Benchmark]
    public void RemoveFirstBenchmark()
    {
        _list.RemoveFirst();
    }

    [Benchmark]
    public void RemoveLastBenchmark()
    {
        _list.RemoveLast();
    }

    [Benchmark]
    public void RemoveAtBenchmark()
    {
        _list.RemoveAt(_randomIndex);
    }

    [Benchmark]
    public void GetFirstBenchmark()
    {
        _list.GetFirst();
    }

    [Benchmark]
    public void GetLastBenchmark()
    {
        _list.GetLast();
    }

    [Benchmark]
    public void GetAtBenchmark()
    {
        _list.GetAt(_randomIndex);
    }

    [Benchmark]
    public void ContainsBenchmark()
    {
        _list.Contains(_randomValue);
    }
}