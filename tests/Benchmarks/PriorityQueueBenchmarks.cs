using Algorithms.Course.DataStructures.PriorityQueue;
using BenchmarkDotNet.Attributes;

namespace Benchmarks;

[MemoryDiagnoser]
public class PriorityQueueBenchmarks
{
    private readonly PriorityQueue<Person> _priorityQueue = new();

    [Params(10, 100, 1000)] public int N;
    
    
    /*
     * | Method        | N    | Mean         | Error         | StdDev       | Median         | Allocated |
       |-------------- |----- |-------------:|--------------:|-------------:|---------------:|----------:|
       | AddBenchmark  | 10   |  2,705.47 ns |    384.323 ns |  1,133.18 ns |  2,666.0000 ns |     800 B |
       | PollBenchmark | 10   |     44.91 ns |     12.282 ns |     35.44 ns |     41.0000 ns |     736 B |
       | PeekBenchmark | 10   |     18.17 ns |      8.909 ns |     25.99 ns |      0.0000 ns |     736 B |
       | AddBenchmark  | 100  | 11,978.65 ns |  1,401.244 ns |  4,131.60 ns | 12,854.5000 ns |     800 B |
       | PollBenchmark | 100  |    104.45 ns |     26.794 ns |     75.13 ns |     83.0000 ns |     736 B |
       | PeekBenchmark | 100  |     77.45 ns |     23.038 ns |     66.47 ns |     63.0000 ns |     736 B |
       | AddBenchmark  | 1000 | 71,825.53 ns | 12,179.281 ns | 35,910.88 ns | 75,604.0000 ns |     800 B |
       | PollBenchmark | 1000 |    774.65 ns |    179.374 ns |    520.40 ns |    583.5000 ns |     736 B |
       | PeekBenchmark | 1000 |    582.98 ns |    121.763 ns |    353.26 ns |    416.0000 ns |     736 B |
       
       Add has O(n) time complexity because we need to find the right place to insert the new item.
       This means that the more items we have, the longer it will take to add a new item. Because of this,
       we can see that the AddBenchmark time increases as N increases by.
         
       Poll and Peek have O(1) time complexity because we always know where the head is.
     */

    [IterationSetup]
    public void IterationSetup()
    {
        for (var i = 0; i < N; i++)
        {
            var age = new Random().Next(12, 65);
            _priorityQueue.Add(new Person { Name = "John", Age = age });
        }
    }

    [Benchmark]
    public void AddBenchmark()
    {
        _priorityQueue.Add(new Person { Name = "John", Age = 20 });
    }

    [Benchmark]
    public void PollBenchmark()
    {
        _priorityQueue.Poll();
    }

    [Benchmark]
    public void PeekBenchmark()
    {
        _priorityQueue.Peek();
    }
}