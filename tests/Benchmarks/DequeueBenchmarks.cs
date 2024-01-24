using Algorithms.Course.DataStructures.Queue;
using BenchmarkDotNet.Attributes;

namespace Benchmarks;

[MemoryDiagnoser]
public class DequeueBenchmarks
{
    private readonly IDequeue<int> _dequeue = new Dequeue<int>();

    [Params(100, 1000, 10000)] public int N;
    
    /*
     * | Method      | N     | Mean            | Error         | StdDev          | Median          | Allocated |
       |------------ |------ |----------------:|--------------:|----------------:|----------------:|----------:|
       | InsertLeft  | 100   |       285.41 ns |      24.12 ns |        69.19 ns |       292.00 ns |     768 B |
       | InsertRight | 100   |       271.37 ns |      21.40 ns |        60.72 ns |       251.00 ns |     768 B |
       | DeleteLeft  | 100   |        49.34 ns |      11.43 ns |        32.80 ns |        42.00 ns |     736 B |
       | DeleteRight | 100   |    67,816.77 ns |   8,681.74 ns |    25,598.30 ns |    68,103.50 ns |     736 B |
       | InsertLeft  | 1000  |       250.70 ns |      14.23 ns |        37.98 ns |       250.00 ns |     768 B |
       | InsertRight | 1000  |       310.37 ns |      25.05 ns |        70.64 ns |       292.00 ns |     768 B |
       | DeleteLeft  | 1000  |        59.73 ns |      15.81 ns |        44.34 ns |        42.00 ns |     736 B |
       | DeleteRight | 1000  |   543,184.24 ns |  91,646.39 ns |   270,221.45 ns |   530,729.50 ns |     736 B |
       | InsertLeft  | 10000 |     1,127.33 ns |     249.56 ns |       716.03 ns |     1,083.00 ns |     768 B |
       | InsertRight | 10000 |     1,345.54 ns |     324.28 ns |       919.93 ns |     1,208.00 ns |     768 B |
       | DeleteLeft  | 10000 |       630.61 ns |     198.33 ns |       565.85 ns |       521.00 ns |     736 B |
       | DeleteRight | 10000 | 5,283,576.74 ns | 829,683.90 ns | 2,446,341.70 ns | 5,254,041.50 ns |     736 B |
       
       Because of not using a doubly linked list, DeleteRight is O(n) and InsertLeft is O(1).
       
       InsertRight is O(1) because we keep track of the tail.
       InsertLeft is O(1) because we keep track of the head.
       Deleteleft is O(1) because we keep track of the head.
       DeleteRight is O(n) because we don't keep track of the previous node. 
     */
    
    [IterationSetup]
    public void Setup()
    {
        for (var i = 0; i < N; i++)
        {
            _dequeue.InsertLeft(i);
        }
    }

    [Benchmark]
    public void InsertLeft()
    {
        _dequeue.InsertLeft(1);
    }

    [Benchmark]
    public void InsertRight()
    {
        _dequeue.InsertRight(1);
    }

    [Benchmark]
    public void DeleteLeft()
    {
        _dequeue.DeleteLeft();
    }

    [Benchmark]
    public void DeleteRight()
    {
        _dequeue.DeleteRight();
    }
}