using BenchmarkDotNet.Attributes;

namespace Benchmarks;

public class StackBenchmarks
{
    /*
       Method        | N     | Mean      | Error     | StdDev   | Median      |
       |-------------- |------ |----------:|----------:|---------:|------------:|
       | PushBenchmark | 10    | 278.40 ns | 23.371 ns | 67.43 ns | 250.0000 ns |
       | PopBenchmark  | 10    |  43.56 ns | 12.201 ns | 35.78 ns |  41.0000 ns |
       | PeekBenchmark | 10    |  22.46 ns |  8.951 ns | 25.54 ns |   0.0000 ns |
       | PushBenchmark | 100   | 245.98 ns | 15.936 ns | 44.16 ns | 251.0000 ns |
       | PopBenchmark  | 100   |  23.45 ns |  9.424 ns | 27.34 ns |   0.0000 ns |
       | PeekBenchmark | 100   |  13.39 ns |  7.776 ns | 22.81 ns |   0.0000 ns |
       | PushBenchmark | 1000  | 261.62 ns | 13.894 ns | 38.96 ns | 250.0000 ns |
       | PopBenchmark  | 1000  |  32.51 ns |  9.842 ns | 27.92 ns |  41.0000 ns |
       | PeekBenchmark | 1000  |  16.51 ns |  8.651 ns | 25.10 ns |   1.0000 ns |
       | PushBenchmark | 10000 | 284.47 ns | 16.931 ns | 49.12 ns | 291.0000 ns |
       | PopBenchmark  | 10000 |  47.01 ns | 12.644 ns | 36.48 ns |  41.0000 ns |
       | PeekBenchmark | 10000 |  27.76 ns |  9.383 ns | 26.77 ns |  41.0000 ns |
       
       These results tell use that the stack is O(1) for push, pop, and peek. We can see this because the time it takes
       to perform these operations does not increase as the size of the stack increases.
     */
    
    private Algorithms.Course.DataStructures.Stack.Stack<int> _stack;
    [Params(10, 100, 1000, 10000)] public int N;

    [IterationSetup]
    public void IterationSetup()
    {
        _stack = new Algorithms.Course.DataStructures.Stack.Stack<int>();

        for (int i = 0; i < N; i++)
        {
            _stack.Push(i);
        }
    }

    [Benchmark]
    public void PushBenchmark()
    {
        _stack.Push(0);
    }
    
    [Benchmark]
    public void PopBenchmark()
    {
        _stack.Pop();
    }
    
    [Benchmark]
    public void PeekBenchmark()
    {
        _stack.Peek();
    }
}