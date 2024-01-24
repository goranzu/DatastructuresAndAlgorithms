using Newtonsoft.Json;

namespace UnitTests.DataStructureTests;

public class GraphTests
{
    public GraphData GraphData { get; set; }

    public GraphTests()
    {
        using StreamReader reader = new("./Data/graphsData.json");
        var json = reader.ReadToEnd();
        var data = JsonConvert.DeserializeObject<GraphData>(json);
        GraphData = data!;
    }

    [Fact]
    public void TestCreateGraphFromLijnlijst()
    {
        var graph = new Graph();
        graph.BuildFromEdgeList(GraphData.lijnlijst);
        Assert.NotNull(graph);

        var path = graph.DijkstraShortestPath(new Vertex() { Id = 0 }, new Vertex() { Id = 4 });
        Assert.NotNull(path);
        Assert.Equal(2, path.Count);
        Assert.Equal(0, path[0].From.Id);
        Assert.Equal(2, path[0].To.Id);
        Assert.Equal(2, path[1].From.Id);
        Assert.Equal(4, path[1].To.Id);
    }


    [Fact]
    public void TestCreateGraphFromVerbindingslijst()
    {
        var graph = new Graph();
        graph.BuildFromAdjacencyList(GraphData.verbindingslijst);
        Assert.NotNull(graph);

        var path = graph.DijkstraShortestPath(new Vertex() { Id = 0 }, new Vertex() { Id = 4 });
        Assert.NotNull(path);
        Assert.Equal(2, path.Count);
        Assert.Equal(0, path[0].From.Id);
        Assert.Equal(2, path[0].To.Id);
        Assert.Equal(2, path[1].From.Id);
        Assert.Equal(4, path[1].To.Id);
    }

    [Fact]
    public void TestCreateGraphFromVerbindingsmatrix()
    {
        var graph = new Graph();
        graph.BuildFromAdjacencyMatrix(GraphData.verbindingsmatrix);
        Assert.NotNull(graph);

        var path = graph.DijkstraShortestPath(new Vertex() { Id = 0 }, new Vertex() { Id = 4 });
        Assert.NotNull(path);
        Assert.Equal(2, path.Count);
        Assert.Equal(0, path[0].From.Id);
        Assert.Equal(2, path[0].To.Id);
        Assert.Equal(2, path[1].From.Id);
        Assert.Equal(4, path[1].To.Id);
    }

    [Fact]
    public void TestCreateGraphFromLijnlijstGewogen()
    {
        var graph = new Graph();
        graph.BuildFromWeightedEdgeList(GraphData.lijnlijst_gewogen);
        Assert.NotNull(graph);

        var path = graph.DijkstraShortestPath(new Vertex() { Id = 0 }, new Vertex() { Id = 4 });

        var totalWeight = path.Sum(edge => edge.Weight);

        Assert.NotNull(path);
        Assert.Equal(2, path.Count);
        Assert.Equal(0, path[0].From.Id);
        Assert.Equal(1, path[0].To.Id);

        Assert.Equal(1, path[1].From.Id);
        Assert.Equal(4, path[1].To.Id);

        Assert.Equal(149, totalWeight);
    }

    [Fact]
    public void TestCreateGraphFromVerbindingslijstGewogen()
    {
        var graph = new Graph();
        graph.BuildFromWeightedAdjacencyList(GraphData.verbindingslijst_gewogen);
        Assert.NotNull(graph);

        var path = graph.DijkstraShortestPath(new Vertex() { Id = 0 }, new Vertex() { Id = 4 });

        var totalWeight = path.Sum(edge => edge.Weight);

        Assert.NotNull(path);
        Assert.Equal(2, path.Count);
        Assert.Equal(0, path[0].From.Id);
        Assert.Equal(1, path[0].To.Id);

        Assert.Equal(1, path[1].From.Id);
        Assert.Equal(4, path[1].To.Id);

        Assert.Equal(149, totalWeight);
    }

    [Fact]
    public void TestCreateGraphFromVerbindingsmatrixGewogen()
    {
        var graph = new Graph();
        graph.BuildFromWeightedAdjacencyMatrix(GraphData.verbindingsmatrix_gewogen);
        Assert.NotNull(graph);

        var path = graph.DijkstraShortestPath(new Vertex() { Id = 0 }, new Vertex() { Id = 4 });

        var totalWeight = path.Sum(edge => edge.Weight);

        Assert.NotNull(path);
        Assert.Equal(2, path.Count);
        Assert.Equal(0, path[0].From.Id);
        Assert.Equal(1, path[0].To.Id);

        Assert.Equal(1, path[1].From.Id);
        Assert.Equal(4, path[1].To.Id);

        Assert.Equal(149, totalWeight);
    }
}