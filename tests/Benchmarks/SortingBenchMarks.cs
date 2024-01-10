using Algorithms.Course;
using BenchmarkDotNet.Attributes;

namespace Benchmarks;

[MemoryDiagnoser]
public class SortingBenchMarks
{
    private int[] _data;
    private Random _random;

    [Params(100, 1000, 10000, 100000)] public int N;

    public SortingBenchMarks()
    {
        _random = new Random(42);
    }

    /*
     * | Method                               | N      | Mean               | Error            | StdDev           | Median             | Gen0      | Gen1     | Gen2     | Allocated  |
       |------------------------------------- |------- |-------------------:|-----------------:|-----------------:|-------------------:|----------:|---------:|---------:|-----------:|
       | MergeSortBenchmark                   | 100    |        19,601.0 ns |        135.68 ns |        113.30 ns |        19,615.7 ns |    6.9580 |   0.2441 |        - |    57980 B |
       | MergeSortWithoutParallelismBenchmark | 100    |        28,297.9 ns |        561.78 ns |      1,528.36 ns |        27,762.0 ns |    6.9885 |   0.1526 |        - |    58084 B |
       | SelectionSortBenchmark               | 100    |         3,381.4 ns |          5.41 ns |          5.06 ns |         3,382.6 ns |    0.0496 |        - |        - |      424 B |
       | QuickSortBenchmark                   | 100    |           938.9 ns |         18.57 ns |         18.24 ns |           942.2 ns |    0.0496 |        - |        - |      424 B |
       | InsertionSortBenchmark               | 100    |         1,232.6 ns |         28.46 ns |         83.93 ns |         1,185.5 ns |    0.0496 |        - |        - |      424 B |
       | MergeSortBenchmark                   | 1000   |       110,843.5 ns |      2,632.47 ns |      7,679.03 ns |       108,508.0 ns |   70.5566 |   8.5449 |   0.2441 |   586116 B |
       | MergeSortWithoutParallelismBenchmark | 1000   |       122,353.7 ns |      2,336.62 ns |      2,500.15 ns |       123,196.7 ns |   71.0449 |   7.0801 |   0.2441 |   587273 B |
       | SelectionSortBenchmark               | 1000   |       318,356.6 ns |        192.15 ns |        179.74 ns |       318,389.1 ns |         - |        - |        - |     4024 B |
       | QuickSortBenchmark                   | 1000   |        14,380.7 ns |         71.41 ns |         66.80 ns |        14,368.6 ns |    0.4730 |        - |        - |     4024 B |
       | InsertionSortBenchmark               | 1000   |       134,805.0 ns |      1,024.57 ns |        908.25 ns |       135,094.9 ns |    0.2441 |        - |        - |     4024 B |
       | MergeSortBenchmark                   | 10000  |       934,996.7 ns |      8,593.50 ns |      8,038.36 ns |       935,144.4 ns |  722.6563 |   5.8594 |        - |  5994508 B |
       | MergeSortWithoutParallelismBenchmark | 10000  |     1,005,188.5 ns |      4,108.88 ns |      3,642.41 ns |     1,006,553.6 ns |  722.6563 | 238.2813 |        - |  5997214 B |
       | SelectionSortBenchmark               | 10000  |    27,434,659.3 ns |      8,485.92 ns |      7,937.74 ns |    27,432,533.2 ns |         - |        - |        - |    40047 B |
       | QuickSortBenchmark                   | 10000  |       294,495.6 ns |      4,722.86 ns |      3,943.80 ns |       295,242.2 ns |    4.3945 |        - |        - |    40024 B |
       | InsertionSortBenchmark               | 10000  |    12,396,465.8 ns |    361,427.03 ns |  1,054,299.62 ns |    12,444,902.7 ns |         - |        - |        - |    40036 B |
       | MergeSortBenchmark                   | 100000 |    10,628,325.3 ns |    143,827.19 ns |    134,536.04 ns |    10,616,662.8 ns | 7468.7500 | 718.7500 | 468.7500 | 61235051 B |
       | MergeSortWithoutParallelismBenchmark | 100000 |    11,491,130.0 ns |    164,360.83 ns |    153,743.22 ns |    11,490,577.5 ns | 7328.1250 | 796.8750 | 703.1250 | 61239074 B |
       | SelectionSortBenchmark               | 100000 | 2,674,372,801.3 ns |    997,876.58 ns |    833,272.14 ns | 2,674,145,042.0 ns |         - |        - |        - |   400760 B |
       | QuickSortBenchmark                   | 100000 |     5,058,995.1 ns |     14,910.77 ns |     12,451.17 ns |     5,057,068.7 ns |  289.0625 | 289.0625 |  93.7500 |   400092 B |
       | InsertionSortBenchmark               | 100000 | 1,314,113,042.6 ns | 26,006,002.03 ns | 46,225,642.18 ns | 1,335,378,375.0 ns |         - |        - |        - |   400760 B |

       // * Warnings *
       MultimodalDistribution
         SortingBenchMarks.InsertionSortBenchmark: Default -> It seems that the distribution is bimodal (mValue = 3.74)

       // * Hints *
       Outliers
         SortingBenchMarks.MergeSortBenchmark: Default                   -> 2 outliers were removed (19.99 us, 20.07 us)
         SortingBenchMarks.MergeSortWithoutParallelismBenchmark: Default -> 9 outliers were removed (33.47 us..38.88 us)
         SortingBenchMarks.MergeSortBenchmark: Default                   -> 2 outliers were removed (136.71 us, 138.24 us)
         SortingBenchMarks.MergeSortWithoutParallelismBenchmark: Default -> 1 outlier  was  removed, 2 outliers were detected (115.95 us, 134.72 us)
         SortingBenchMarks.InsertionSortBenchmark: Default               -> 1 outlier  was  removed, 3 outliers were detected (132.13 us, 133.40 us, 151.24 us)
         SortingBenchMarks.MergeSortBenchmark: Default                   -> 1 outlier  was  detected (909.02 us)
         SortingBenchMarks.MergeSortWithoutParallelismBenchmark: Default -> 1 outlier  was  removed (1.03 ms)
         SortingBenchMarks.QuickSortBenchmark: Default                   -> 2 outliers were removed (305.35 us, 307.67 us)
         SortingBenchMarks.InsertionSortBenchmark: Default               -> 2 outliers were removed (16.44 ms, 16.50 ms)
         SortingBenchMarks.SelectionSortBenchmark: Default               -> 2 outliers were removed (2.68 s, 2.69 s)
         SortingBenchMarks.QuickSortBenchmark: Default                   -> 2 outliers were removed (5.10 ms, 5.11 ms)
         SortingBenchMarks.InsertionSortBenchmark: Default               -> 1 outlier  was  removed, 10 outliers were detected (1.13 s..1.29 s, 1.37 s)

       // * Legends *
         N         : Value of the 'N' parameter
         Mean      : Arithmetic mean of all measurements
         Error     : Half of 99.9% confidence interval
         StdDev    : Standard deviation of all measurements
         Median    : Value separating the higher half of all measurements (50th percentile)
         Gen0      : GC Generation 0 collects per 1000 operations
         Gen1      : GC Generation 1 collects per 1000 operations
         Gen2      : GC Generation 2 collects per 1000 operations
         Allocated : Allocated memory per single operation (managed only, inclusive, 1KB = 1024B)
         1 ns      : 1 Nanosecond (0.000000001 sec)

     */

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
    public void MergeSortBenchmark()
    {
        var dataToSort = (int[])_data.Clone();
        MergeSort.Sort(dataToSort);
    }

    [Benchmark]
    public void MergeSortWithoutParallelismBenchmark()
    {
        var dataToSort = (int[])_data.Clone();
        MergeSort.SortWithOutParallelism(dataToSort);
    }

    [Benchmark]
    public void SelectionSortBenchmark()
    {
        var dataToSort = (int[])_data.Clone();
        SelectionSort.Sort(dataToSort);
    }

    [Benchmark]
    public void QuickSortBenchmark()
    {
        var dataToSort = (int[])_data.Clone();
        QuickSort.Sort(dataToSort, 0, dataToSort.Length - 1);
    }

    [Benchmark]
    public void InsertionSortBenchmark()
    {
        var dataToSort = (int[])_data.Clone();
        InsertionSort.Sort(dataToSort);
    }
}