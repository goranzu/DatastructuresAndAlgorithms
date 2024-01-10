using Algorithms.Course;
using BenchmarkDotNet.Attributes;

namespace Benchmarks;

[MemoryDiagnoser]
public class SelectionSortBenchmarks
{
    private int[] _data;
    private Random _random;

    [Params(100, 1000, 10000, 100000)] public int N;

    public SelectionSortBenchmarks()
    {
        _random = new Random(42);
    }

    [GlobalSetup]
    public void Setup()
    {
        _data = new int[N];

        for (int i = 0; i < N; i++)
        {
            _data[i] = _random.Next(N);
        }
    }

    [Benchmark]
    public void SelectionSortBenchmark()
    {
        /*
         * | Method                 | N      | Mean             | Error         | StdDev        | Gen0   | Allocated |
           |----------------------- |------- |-----------------:|--------------:|--------------:|-------:|----------:|
           | SelectionSortBenchmark | 100    |         3.157 us |     0.0153 us |     0.0136 us | 0.0496 |     424 B |
           | SelectionSortBenchmark | 1000   |       299.211 us |     3.5163 us |     3.2891 us |      - |    4024 B |
           | SelectionSortBenchmark | 10000  |    26,482.032 us |   153.6117 us |   143.6884 us |      - |   40047 B |
           | SelectionSortBenchmark | 100000 | 2,666,829.259 us | 1,813.6661 us | 1,607.7678 us |      - |  400760 B |
         */
        var dataToSort = (int[])_data.Clone();
        SelectionSort.Sort(dataToSort);
    }
}