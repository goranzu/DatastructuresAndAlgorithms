using BenchmarkDotNet.Attributes;

namespace Benchmarks;

[MemoryDiagnoser]
public class GraphBenchmarks
{
    private Graph graph;
    private List<Vertex> verticesToAdd;
    private List<Edge> edgesToAdd;
    private readonly Random _random = new Random();

    [Params(100, 1000, 10000)] public int N;

    /*
     * | Method         | N     | Mean       | Error     | StdDev    | Median     | Allocated |
       |--------------- |------ |-----------:|----------:|----------:|-----------:|----------:|
       | AddVertices    | 100   |   2.270 us | 0.0998 us | 0.2894 us |   2.167 us |   10848 B |
       | AddEdges       | 100   |   5.261 us | 0.1053 us | 0.1926 us |   5.208 us |   13008 B |
       | RemoveVertices | 100   |   1.432 us | 0.0293 us | 0.0457 us |   1.417 us |    3136 B |
       | RemoveEdges    | 100   |   1.426 us | 0.0242 us | 0.0346 us |   1.417 us |     736 B |
       
       | AddVertices    | 1000  |  19.373 us | 0.4450 us | 1.2911 us |  19.500 us |  102872 B |
       | AddEdges       | 1000  |  41.585 us | 0.8115 us | 1.6018 us |  41.083 us |  119440 B |
       | RemoveVertices | 1000  |  16.229 us | 0.4269 us | 1.2318 us |  16.083 us |   24736 B |
       | RemoveEdges    | 1000  |  15.380 us | 0.4177 us | 1.2119 us |  15.000 us |     736 B |
       
       | AddVertices    | 10000 |  82.594 us | 2.1687 us | 6.3262 us |  79.228 us |  942664 B |
       | AddEdges       | 10000 | 182.528 us | 3.6019 us | 5.5004 us | 181.416 us | 1205088 B |
       | RemoveVertices | 10000 |  55.715 us | 1.1032 us | 1.3549 us |  55.333 us |  240736 B |
       | RemoveEdges    | 10000 |  60.362 us | 1.0315 us | 1.3412 us |  60.041 us |     736 B |

       AddVertices has a linear time complexity of O(n) because it has to iterate over the list of vertices to add.
       AddEdges has a linear time complexity of O(n) because it has to iterate over the list of edges to add.
       RemoveVertices has a linear time complexity of O(n) because it has to iterate over the list of vertices to remove.
       RemoveEdges has a linear time complexity of O(n) because it has to iterate over the list of edges to remove.

       The space complexity of AddVertices is O(n) because it has to store the list of vertices to add.
       The space complexity of AddEdges is O(n) because it has to store the list of edges to add.
       The space complexity of RemoveVertices is O(n) because it has to store the list of vertices to remove.
       The space complexity of RemoveEdges is O(n) because it has to store the list of edges to remove.
     */

    [GlobalSetup]
    public void GlobalSetup()
    {
        verticesToAdd = new List<Vertex>();
        edgesToAdd = new List<Edge>();

        for (int i = 0; i < N; i++)
        {
            verticesToAdd.Add(new Vertex { Id = i });

            if (i > 0)
            {
                var fromVertex = new Vertex { Id = 1 - 1 };
                var toVertex = new Vertex { Id = i };
                var edge = new Edge() { From = fromVertex, To = toVertex };
                edgesToAdd.Add(edge);
            }
        }
    }

    [IterationSetup]
    public void IterationSetup()
    {
        graph = new Graph();
    }

    [Benchmark]
    public void AddVertices()
    {
        foreach (var vertex in verticesToAdd)
        {
            graph.AddVertex(vertex);
        }
    }

    [Benchmark]
    public void AddEdges()
    {
        foreach (var edge in edgesToAdd)
        {
            graph.AddEdge(edge);
        }
    }

    [Benchmark]
    public void RemoveVertices()
    {
        foreach (var vertex in verticesToAdd)
        {
            graph.RemoveVertex(vertex);
        }
    }

    [Benchmark]
    public void RemoveEdges()
    {
        foreach (var edge in edgesToAdd)
        {
            graph.RemoveEdge(edge);
        }
    }

    [Benchmark]
    public void DijkstraShortestPathBenchmark()
    {
        var from = new Vertex() { Id = _random.Next(0, N) };
        var to = new Vertex() { Id = _random.Next(0, N) };
        graph.DijkstraShortestPath(from, to);
    }
}