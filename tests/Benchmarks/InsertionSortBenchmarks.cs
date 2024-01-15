using Algorithms.Course;
using BenchmarkDotNet.Attributes;

namespace Benchmarks;

[MemoryDiagnoser]
public class InsertionSortBenchmarks
{
    private int[] _data;
    private Random _random;
    
    [Params(100, 1000, 10000, 100000)]
    public int N;

    public InsertionSortBenchmarks()
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
    public void InsertionSortBenchmark()
    {
        /*
            O(n²)
            For small data sets, it is pretty fast. Quadratic growth -> when size increase by 10 (100 to 1000)
            time increases by 100 (1.13 us to 113.025 us) 
            
        
         * | Method                 | N      | Mean             | Error          | StdDev         | Gen0   | Allocated |
           |----------------------- |------- |-----------------:|---------------:|---------------:|-------:|----------:|
           | InsertionSortBenchmark | 100    |         1.192 us |      0.0228 us |      0.0280 us | 0.0496 |     424 B |
           | InsertionSortBenchmark | 1000   |       118.911 us |      1.5624 us |      1.4615 us | 0.2441 |    4024 B |
           | InsertionSortBenchmark | 10000  |    11,101.859 us |     18.1469 us |     16.0868 us |      - |   40036 B |
           | InsertionSortBenchmark | 100000 | 1,178,712.833 us | 22,921.7935 us | 35,686.4710 us |      - |  400760 B |
         */
        
        var dataToSort = (int[])_data.Clone();
        InsertionSort.Sort(dataToSort);
    }
}