using BenchmarkDotNet.Attributes;

namespace Benchmarks;

[MemoryDiagnoser]
public class BinarySearchBenchmarks
{
    [Params(10, 100, 1_000, 10_000, 100_000, 1_000_000)] public int N;
    
    private int[] _array;
    private int _needle;
    
    /*
     * | Method | N       | Mean      | Error    | StdDev    | Median    | Allocated |
       |------- |-------- |----------:|---------:|----------:|----------:|----------:|
       | Search | 10      |  75.58 ns | 12.89 ns |  37.19 ns |  83.00 ns |     736 B |
       | Search | 100     | 114.95 ns | 11.93 ns |  33.25 ns | 124.50 ns |     736 B |
       | Search | 1000    | 170.95 ns | 16.18 ns |  47.72 ns | 167.00 ns |     736 B |
       | Search | 10000   | 225.37 ns | 16.57 ns |  46.48 ns | 249.00 ns |     736 B |
       | Search | 100000  | 380.83 ns | 37.99 ns | 108.99 ns | 374.00 ns |     736 B |
       | Search | 1000000 | 648.24 ns | 68.88 ns | 199.83 ns | 583.00 ns |     736 B |
       
       These results show that the binary search is done in O(log n) time.
       You can see this because the time increases by a small amount when N increases by a large amount.
     */
    
    [IterationSetup]
    public void IterationSetup()
    {
        _array = new int[N];
        _needle = new Random().Next(0, N);
        
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
}