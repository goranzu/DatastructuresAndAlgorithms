using Algorithms.Course.DataStructures;
using BenchmarkDotNet.Attributes;

namespace Benchmarks;

public class AvlBenchmarks
{
    private AvlGeneric<int> _avlTree;
    private int _itemToFind;
    private int _itemToRemove;

    [Params(100, 1000, 10000)]
    public int N { get; set; }

    // [GlobalSetup]
    // public void Setup()
    // {
    //     _avlTree = new AvlGeneric<int>();
    //     var random = new Random();
    //
    //     for (int i = 0; i < N; i++)
    //     {
    //         _avlTree.Insert(random.Next());
    //     }
    //
    //     _itemToFind = random.Next();
    //     _itemToRemove = random.Next();
    // }
    
    /*
     * | Method  | N     | Mean        | Error     | StdDev    | Median      |
       |-------- |------ |------------:|----------:|----------:|------------:|
       | Insert  | 100   | 1,248.82 ns |  63.54 ns | 183.32 ns | 1,208.00 ns |
       | Remove  | 100   |   468.82 ns |  35.17 ns | 103.70 ns |   458.00 ns |
       | FindMin | 100   |    43.34 ns |  11.16 ns |  32.21 ns |    42.00 ns |
       | FindMax | 100   |    63.19 ns |  11.50 ns |  32.81 ns |    84.00 ns |
       | Find    | 100   |   136.88 ns |  13.94 ns |  39.32 ns |   125.00 ns |
       | Insert  | 1000  | 1,414.14 ns |  58.31 ns | 165.42 ns | 1,416.00 ns |
       | Remove  | 1000  |   635.76 ns |  24.22 ns |  70.64 ns |   625.00 ns |
       | FindMin | 1000  |   110.47 ns |  10.81 ns |  30.85 ns |   124.00 ns |
       | FindMax | 1000  |   127.31 ns |  13.88 ns |  40.28 ns |   125.00 ns |
       | Find    | 1000  |   222.74 ns |  13.45 ns |  38.16 ns |   208.00 ns |
       | Insert  | 10000 | 1,596.36 ns | 128.65 ns | 367.05 ns | 1,583.00 ns |
       | Remove  | 10000 |   701.65 ns | 111.75 ns | 325.98 ns |   833.00 ns |
       | FindMin | 10000 |   243.82 ns |  27.74 ns |  78.24 ns |   249.00 ns |
       | FindMax | 10000 |   215.67 ns |  19.83 ns |  55.94 ns |   208.00 ns |
       | Find    | 10000 |   305.48 ns |  35.61 ns | 101.60 ns |   291.50 ns |
       
       These results show that the AVL tree is not as fast as the binary search tree.
       The AVL tree is slower because it has to balance itself after every insert and remove. 
       You can see this in the Insert and Remove methods. But the FindMin, FindMax and Find methods are faster than the binary search tree.
       Because the AVL tree is balanced, it has to search less nodes to find the item. Searching is done in O(log n) time.
       And inserting and Removing is done in O(log n) time.
     */
    
    [IterationSetup]
    public void IterationSetup()
    {
        _avlTree = new AvlGeneric<int>();
        var random = new Random();

        for (int i = 0; i < N; i++)
        {
            _avlTree.Insert(random.Next());
        }

        _itemToFind = random.Next();
        _itemToRemove = random.Next();
    }

    [Benchmark]
    public void Insert()
    {
        _avlTree.Insert(new Random().Next());
    }

    [Benchmark]
    public void Remove()
    {
        _avlTree.Remove(_itemToRemove);
    }

    [Benchmark]
    public void FindMin()
    {
        _avlTree.FindMin();
    }

    [Benchmark]
    public void FindMax()
    {
        _avlTree.FindMax();
    }

    [Benchmark]
    public void Find()
    {
        _avlTree.Find(_itemToFind);
    }
}