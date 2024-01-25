using BenchmarkDotNet.Attributes;

namespace Benchmarks;

[MemoryDiagnoser]
public class DijkstraBenchmarks
{
    private Graph graph;
    private Vertex startVertex;
    private Vertex endVertex;

    [Params(10, 100, 1000)] public int NumberOfVertices { get; set; }

    /*
     *
     * With low density
       | Method                        | NumberOfVertices | Mean           | Error       | StdDev      | Gen0     | Gen1     | Gen2     | Allocated  |
       |------------------------------ |----------------- |---------------:|------------:|------------:|---------:|---------:|---------:|-----------:|
       | DijkstraShortestPathBenchmark | 10               |       247.7 ns |     1.91 ns |     1.69 ns |   0.1836 |   0.0005 |        - |     1.5 KB |
       | DijkstraShortestPathBenchmark | 100              |     5,445.2 ns |     7.80 ns |     7.29 ns |   1.3962 |   0.0305 |        - |   11.43 KB |
       | DijkstraShortestPathBenchmark | 1000             |    83,584.6 ns |   296.44 ns |   247.54 ns |  13.1836 |   2.4414 |        - |  108.37 KB |
       
       With high density
       | Method                        | NumberOfVertices | Mean           | Error          | StdDev         | Gen0   | Gen1   | Allocated  |
       |------------------------------ |----------------- |---------------:|---------------:|---------------:|-------:|-------:|-----------:|
       | DijkstraShortestPathBenchmark | 10               |       1.191 us |      0.0230 us |      0.0265 us | 0.3929 | 0.0019 |    3.21 KB |
       | DijkstraShortestPathBenchmark | 100              |     387.199 us |      5.9165 us |      5.2448 us | 9.2773 |      - |    78.9 KB |
       | DijkstraShortestPathBenchmark | 1000             | 283,553.835 us | 10,260.5945 us | 30,253.5943 us |      - |      - | 3625.43 KB |
       
       // When using a priority queue and a high density graph
       | Method                        | NumberOfVertices | Mean            | Error         | StdDev        | Gen0     | Gen1   | Allocated  |
       |------------------------------ |----------------- |----------------:|--------------:|--------------:|---------:|-------:|-----------:|
       | DijkstraShortestPathBenchmark | 10               |        486.2 ns |       3.13 ns |       2.92 ns |   0.3080 |      - |    2.52 KB |
       | DijkstraShortestPathBenchmark | 100              |      9,610.4 ns |      39.56 ns |      37.01 ns |   2.7924 | 0.0610 |   22.86 KB |
       | DijkstraShortestPathBenchmark | 1000             | 89,037,086.6 ns | 707,207.31 ns | 661,522.16 ns | 166.6667 |      - | 1732.06 KB |
       
       You can clearly see what difference the density of the graph makes. The higher the density, the more edges there are to check.
       This results in a higher time complexity. The space complexity is the same for both graphs. The time complexity in the dense graph gets closer to O(n^2) than the sparse graph.
       So worst case time complexity is O(n^2) and best case time complexity is O(n).
       
       When using a priority queue, the time complexity is (N) log N, where N is the number of vertices and E is the number of edges. This is much faster than the naive implementation.
       When using a list, the time complexity is O(N^2), where N is the number of vertices and E is the number of edges. This is much slower than the priority queue implementation.
     */

    [GlobalSetup]
    public void Setup()
    {
        graph = new Graph();

        for (int i = 0; i < NumberOfVertices; i++)
        {
            graph.AddVertex(new Vertex { Id = i });
        }

        var random = new Random();

        // Add edges - creating a connected graph
        for (int i = 0; i < NumberOfVertices - 1; i++)
        {
            var from = new Vertex { Id = 1 };
            var to = new Vertex { Id = i + 1 };
            var weight = random.Next(1, 10);
            var edge = new Edge { From = from, To = to, Weight = weight };
            graph.AddEdge(edge);
        }

        // Add additional edges to increase density
        int additionalEdges = (NumberOfVertices * (NumberOfVertices - 1)) / 4; 

        for (int i = 0; i < additionalEdges; i++)
        {
            int from = random.Next(NumberOfVertices);
            int to = random.Next(NumberOfVertices);

            if (from != to && !graph.HasEdge(new Vertex {Id = from}, new Vertex{Id = to}))
            {
                var fromVertex = new Vertex { Id = from };
                var toVertex = new Vertex { Id = to };
                var weight = random.Next(1, 10);
                var edge = new Edge { From = fromVertex, To = toVertex, Weight = weight };
                graph.AddEdge(edge);
            }
        }


        // Set start and end vertices for Dijkstra's algorithm
        startVertex = new Vertex() { Id = 0 };
        endVertex = new Vertex() { Id = NumberOfVertices - 1 };
    }

    [Benchmark]
    public void DijkstraShortestPathBenchmark()
    {
        var shortestPath = graph.DijkstraShortestPath(startVertex, endVertex);
    }
}