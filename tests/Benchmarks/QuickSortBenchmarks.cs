using Algorithms.Course;
using BenchmarkDotNet.Attributes;

namespace Benchmarks;

[MemoryDiagnoser]
public class QuickSortBenchmarks
{
    private int[] _data;
    private Random _random;

    [Params(100, 1000, 10000, 100000)] public int N;

    public QuickSortBenchmarks()
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
    public void QuickSortBenchmark()
    {
        /*
         * | Method             | N      | Mean           | Error        | StdDev       | Gen0     | Gen1     | Gen2    | Allocated |
           |------------------- |------- |---------------:|-------------:|-------------:|---------:|---------:|--------:|----------:|
           | QuickSortBenchmark | 100    |       974.1 ns |     19.45 ns |     45.45 ns |   0.0496 |        - |       - |     424 B |
           | QuickSortBenchmark | 1000   |    14,361.2 ns |     83.81 ns |     78.40 ns |   0.4730 |        - |       - |    4024 B |
           | QuickSortBenchmark | 10000  |   274,744.1 ns |  5,391.52 ns |  7,558.15 ns |   4.3945 |        - |       - |   40024 B |
           | QuickSortBenchmark | 100000 | 5,048,276.6 ns | 11,169.03 ns | 10,447.51 ns | 296.8750 | 296.8750 | 85.9375 |  400087 B |
         */
        var dataToSort = (int[])_data.Clone();
        QuickSort.Sort(dataToSort, 0, dataToSort.Length - 1);
    }
}