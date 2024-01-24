using BenchmarkDotNet.Attributes;

namespace Benchmarks;

[MemoryDiagnoser]
public class BinarySearchBenchmarks
{
    [Params(10, 100, 1_000, 10_000, 100_000, 1_000_000)] public int N;
    
    private int[] _array;
    private int _needle;
    
    /*
     * | Method | N       | Mean      | Error     | StdDev   | Median    | Allocated |
       |------- |-------- |----------:|----------:|---------:|----------:|----------:|
       | Search | 10      |  50.82 ns |  8.911 ns | 25.85 ns |  41.00 ns |     736 B |
       | Search | 100     |  69.11 ns |  9.744 ns | 28.11 ns |  83.00 ns |     736 B |
       | Search | 1000    |  73.32 ns |  7.540 ns | 19.99 ns |  83.00 ns |     736 B |
       | Search | 10000   | 125.13 ns | 14.093 ns | 39.52 ns | 125.00 ns |     736 B |
       | Search | 100000  | 115.77 ns |  8.264 ns | 20.88 ns | 125.00 ns |     736 B |
       | Search | 1000000 | 222.38 ns | 28.731 ns | 82.90 ns | 208.00 ns |     736 B |
       
       BinarySearch has a time complexity of O(log n) and a space complexity of O(1).
       You can see that the time complexity is logarithmic because the time it takes to search
       for a value in an array of 1,000,000 elements is only 4 times longer than the time it takes
       to search for a value in an array of 10 elements.
     */
    
    [IterationSetup]
    public void IterationSetup()
    {
        _array = new int[N];
        _needle = N / 2;
        
        for (var i = 0; i < N; i++)
        {
            _array[i] = i;
        }
    }
    
    
    [Benchmark]
    public void Search()
    {
        Algorithms.Course.BinarySearch.Search(_array, _needle);
    }
    
    // [GlobalSetup]
    // public void Setup()
    // {
    //     _array = new int[N];
    //     _needle = N / 2;
    //     
    //     for (var i = 0; i < N; i++)
    //     {
    //         _array[i] = i;
    //     }
    // }
}