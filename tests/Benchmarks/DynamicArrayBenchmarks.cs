using Algorithms.Course.DataStructures.DynamicArray;
using BenchmarkDotNet.Attributes;

namespace Benchmarks;

[MemoryDiagnoser]
public class DynamicArrayBenchmarks
{
    private DynamicArray<int> _list = null!;

    [Params(10, 100, 1_000)] public int N;

    private int _randomIndex;
    private Random _random = null!;
    
    /*
     * | Method                 | N    | Mean         | Error        | StdDev      | Median       | Allocated |
       |----------------------- |----- |-------------:|-------------:|------------:|-------------:|----------:|
       | AddBenchmark           | 10   |     53.36 ns |     9.694 ns |    28.12 ns |     42.00 ns |     736 B |
       | InsertAtBenchmark      | 10   |     80.49 ns |    12.268 ns |    35.00 ns |     84.00 ns |     736 B |
       | IndexOfBenchmark       | 10   |    129.65 ns |    16.559 ns |    46.43 ns |    125.00 ns |     736 B |
       | FindBenchmark          | 10   |    149.51 ns |    22.757 ns |    66.74 ns |    125.00 ns |     736 B |
       | ContainsBenchmark      | 10   |    137.01 ns |    16.933 ns |    49.39 ns |    125.00 ns |     736 B |
       | RemoveBenchmark        | 10   |    199.87 ns |    19.297 ns |    55.98 ns |    208.00 ns |     736 B |
       | RemoveAtBenchmark      | 10   |     65.27 ns |    10.366 ns |    29.57 ns |     83.00 ns |     736 B |
       
       | AddBenchmark           | 100  |     48.58 ns |    11.448 ns |    32.29 ns |     41.00 ns |     736 B |
       | InsertAtBenchmark      | 100  |    220.66 ns |    31.609 ns |    92.70 ns |    208.00 ns |     736 B |
       | IndexOfBenchmark       | 100  |    671.77 ns |   107.295 ns |   316.36 ns |    666.00 ns |     736 B |
       | FindBenchmark          | 100  |    620.29 ns |   119.061 ns |   351.06 ns |    667.00 ns |     736 B |
       | ContainsBenchmark      | 100  |    655.95 ns |   108.508 ns |   319.94 ns |    666.50 ns |     736 B |
       | RemoveBenchmark        | 100  |    847.62 ns |    76.903 ns |   226.75 ns |    874.50 ns |     736 B |
       | RemoveAtBenchmark      | 100  |    211.51 ns |    37.241 ns |   109.81 ns |    209.00 ns |     736 B |
       
       | AddBenchmark           | 1000 |     47.10 ns |     9.224 ns |    26.32 ns |     41.00 ns |     736 B |
       | InsertAtBenchmark      | 1000 |  2,501.40 ns |   538.509 ns | 1,570.86 ns |  2,562.00 ns |     736 B |
       | IndexOfBenchmark       | 1000 |  5,630.50 ns | 1,172.709 ns | 3,457.76 ns |  5,249.50 ns |     736 B |
       | FindBenchmark          | 1000 |  5,853.79 ns | 1,119.365 ns | 3,300.47 ns |  6,083.00 ns |     736 B |
       | ContainsBenchmark      | 1000 |  6,240.05 ns | 1,078.074 ns | 3,178.72 ns |  6,583.00 ns |     736 B |
       | RemoveBenchmark        | 1000 | 10,739.95 ns |   623.552 ns | 1,828.77 ns | 10,583.00 ns |     736 B |
       | RemoveAtBenchmark      | 1000 |  2,933.36 ns |   484.538 ns | 1,413.42 ns |  3,020.50 ns |     736 B |
     */

    [IterationSetup]
    public void IterationSetup()
    {
        _list = new DynamicArray<int>((int)(N / 1.5));
        for (int i = 0; i < N; i++)
        {
            _list.Add(i);
        }

        _random = new Random();
        _randomIndex = _random.Next(0, N);
    }

    [Benchmark]
    public void AddBenchmark()
    {
        _list.Add(_random.Next());
    }

    [Benchmark]
    public void InsertAtBenchmark()
    {
        var index = _random.Next(0, _list.Count);
        _list.InsertAt(index, _random.Next());
    }

    [Benchmark]
    public void IndexOfBenchmark()
    {
        _list.IndexOf(_random.Next(0, N));
    }

    [Benchmark]
    public void FindBenchmark()
    {
        _list.Find(_random.Next(0, N));
    }

    [Benchmark]
    public void ContainsBenchmark()
    {
        _list.Contains(_random.Next(0, N));
    }

    [Benchmark]
    public void RemoveBenchmark()
    {
        _list.Remove(_random.Next(0, N));
    }

    [Benchmark]
    public void RemoveAtBenchmark()
    {
        var index = _random.Next(0, _list.Count);
        _list.RemoveAt(index);
    }
}