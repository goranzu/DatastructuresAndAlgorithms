using Algorithms.Course;
using BenchmarkDotNet.Attributes;

namespace Benchmarks;

[MemoryDiagnoser]
public class MergeSortBenchmarks
{
    private int[] _data;
    private Random _random;

    [Params(100, 1000, 10000, 100000)] public int N;

    public MergeSortBenchmarks()
    {
        _random = new Random(42);
    }


    [IterationSetup]
    public void IterationSetup()
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
        /*
         * | Method             | N      | Mean         | Error      | StdDev     |
           |------------------- |------- |-------------:|-----------:|-----------:|
           | MergeSortBenchmark | 100    |     21.80 us |   0.427 us |   0.771 us |
           | MergeSortBenchmark | 1000   |    106.80 us |   2.133 us |   1.781 us | bigger than linear increase in time
           | MergeSortBenchmark | 10000  |    945.16 us |   4.387 us |   3.425 us | less then fold increase better scaling through parallelism?
           | MergeSortBenchmark | 100000 | 11,377.37 us | 226.348 us | 352.396 us | increase by 12

            O(n log n) because divide and conquer. We split the problem in multiple smaller problems
            Parallelism does not effect Big O. Does not effect size of dataset

            | Method             | N      | Mean         | Error      | StdDev    | Median       | Gen0      | Gen1     | Gen2     | Allocated   |
           |------------------- |------- |-------------:|-----------:|----------:|-------------:|----------:|---------:|---------:|------------:|
           | MergeSortBenchmark | 100    |     22.11 us |   0.441 us |  0.911 us |     22.27 us |    6.9580 |   0.2441 |        - |    56.58 KB |
           | MergeSortBenchmark | 1000   |    103.61 us |   2.014 us |  5.089 us |    102.00 us |   70.6787 |   8.6670 |        - |   572.33 KB |
           | MergeSortBenchmark | 10000  |    973.75 us |   6.142 us |  5.745 us |    972.96 us |  722.6563 |   3.9063 |        - |  5853.84 KB |
           | MergeSortBenchmark | 100000 | 10,637.85 us | 106.884 us | 99.980 us | 10,655.18 us | 7468.7500 | 718.7500 | 468.7500 | 59799.98 KB |
           
           
           With in place sorting
           | Method             | N      | Mean            | Error        | StdDev       | Allocated |
           |------------------- |------- |----------------:|-------------:|-------------:|----------:|
           | MergeSortBenchmark | 100    |        25.70 us |     0.760 us |     2.204 us |     736 B |
           | MergeSortBenchmark | 1000   |       389.18 us |     6.446 us |     5.714 us |     736 B |
           | MergeSortBenchmark | 10000  |    14,268.11 us |    67.129 us |    96.275 us |     736 B |
           | MergeSortBenchmark | 100000 | 1,369,726.22 us | 3,810.183 us | 2,974.740 us |     736 B |
           
           
           With in place sorting and parallelism
           | Method             | N      | Mean          | Error        | StdDev      | Median        | Gen0      | Allocated  |
           |------------------- |------- |--------------:|-------------:|------------:|--------------:|----------:|-----------:|
           | MergeSortBenchmark | 100    |      88.47 us |     9.137 us |    26.80 us |      94.96 us |         - |   50.34 KB |
           | MergeSortBenchmark | 1000   |     353.61 us |    10.263 us |    29.61 us |     345.46 us |         - |  494.18 KB |
           | MergeSortBenchmark | 10000  |  11,937.02 us |   235.423 us |   418.46 us |  12,005.04 us |         - | 4925.02 KB |
           | MergeSortBenchmark | 100000 | 940,648.68 us | 2,576.734 us | 2,410.28 us | 940,205.33 us | 6000.0000 |   49221 KB |


           | Method                               | N      | Mean         | Error      | StdDev     | Gen0      | Gen1     | Gen2     | Allocated   |
           |------------------------------------- |------- |-------------:|-----------:|-----------:|----------:|---------:|---------:|------------:|
           | MergeSortBenchmark                   | 100    |     20.25 us |   0.366 us |   0.965 us |    6.9580 |   0.2441 |        - |    56.63 KB |
           | MergeSortWithoutParallelismBenchmark | 100    |     29.57 us |   0.491 us |   0.459 us |    6.9885 |   0.1526 |   0.0305 |    56.71 KB |
           | MergeSortBenchmark                   | 1000   |    100.54 us |   1.000 us |   0.886 us |   70.6787 |   8.6670 |        - |   572.33 KB |
           | MergeSortWithoutParallelismBenchmark | 1000   |    121.27 us |   2.356 us |   3.453 us |   70.8008 |   7.3242 |        - |   573.64 KB |
           | MergeSortBenchmark                   | 10000  |    965.48 us |   3.026 us |   2.363 us |  722.6563 |  35.1563 |        - |  5853.92 KB |
           | MergeSortWithoutParallelismBenchmark | 10000  |  1,024.74 us |   6.434 us |   5.703 us |  722.6563 |   1.9531 |        - |  5855.78 KB |
           | MergeSortBenchmark                   | 100000 | 10,513.35 us | 151.539 us | 141.749 us | 7468.7500 | 734.3750 | 484.3750 | 59799.68 KB |
           | MergeSortWithoutParallelismBenchmark | 100000 | 11,397.80 us | 134.239 us | 125.567 us | 7250.0000 | 734.3750 | 703.1250 | 59802.89 KB |
         */

        MergeSort.Sort(_data, 0, _data.Length);
    }

    // [Benchmark]
    // public void MergeSortWithoutParallelismBenchmark()
    // {
    //     var dataToSort = (int[])_data.Clone();
    //     MergeSort.SortWithOutParallelism(dataToSort,0 , dataToSort.Length);
    // }
}