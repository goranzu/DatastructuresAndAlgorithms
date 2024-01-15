public class Vertex
{
    public int Id { get; set; }
}

public class Edge
{
    public Vertex From { get; set; }
    public Vertex To { get; set; }
    public double Weight { get; set; }
}

public class GraphList
{
    private Dictionary<Vertex, List<Edge>> _adjacencyList;

    public GraphList()
    {
        _adjacencyList = new Dictionary<Vertex, List<Edge>>();
    }

    public void AddVertex(Vertex vertex)
    {
        _adjacencyList[vertex] = [];
    }

    public void RemoveVertex(Vertex vertex)
    {
        _adjacencyList.Remove(vertex);
        foreach (var edges in _adjacencyList.Values)
        {
            edges.RemoveAll(edge => edge.From == vertex || edge.To == vertex);
        }
    }

    public void AddEdge(Edge edge)
    {
        if (!_adjacencyList.ContainsKey(edge.From))
        {
            AddVertex(edge.From);
        }

        if (!_adjacencyList.ContainsKey(edge.To))
        {
            AddVertex(edge.To);
        }

        _adjacencyList[edge.From].Add(edge);
    }

    public void RemoveEdge(Edge edge)
    {
        if (_adjacencyList.ContainsKey(edge.From))
        {
            _adjacencyList[edge.From].Remove(edge);
        }
    }
}