namespace Algorithms.Course.DataStructures.Graph;

public interface IGraph
{
    void Init(int n);

    // Return the number of vertices
    int NodeCount();

    // Return the current number of edges
    int EdgeCount();

    // Get the value of node with index v
    object GetValue(int v);

    // Set the value of node with index v
    void SetValue(int v, object val);

    // Adds a new edge from node v to node w with weight wgt
    void AddEdge(int v, int w, int wgt);

    // Get the weight value for an edge
    int Weight(int v, int w);

    // Removes the edge from the graph.
    void RemoveEdge(int v, int w);

    // Returns true iff the graph has the edge
    bool HasEdge(int v, int w);

    // Returns an array containing the indicies of the neighbors of v
    int[] Neighbors(int v);
}

public class GraphL : IGraph
{
    private List<int>[] adjList;
    private object[] nodeValues;
    private int edges;

    public void Init(int n)
    {
        throw new NotImplementedException();
    }

    public int NodeCount()
    {
        throw new NotImplementedException();
    }

    public int EdgeCount()
    {
        throw new NotImplementedException();
    }

    public object GetValue(int v)
    {
        throw new NotImplementedException();
    }

    public void SetValue(int v, object val)
    {
        throw new NotImplementedException();
    }

    public void AddEdge(int v, int w, int wgt)
    {
        throw new NotImplementedException();
    }

    public int Weight(int v, int w)
    {
        throw new NotImplementedException();
    }

    public void RemoveEdge(int v, int w)
    {
        throw new NotImplementedException();
    }

    public bool HasEdge(int v, int w)
    {
        throw new NotImplementedException();
    }

    public int[] Neighbors(int v)
    {
        throw new NotImplementedException();
    }
}

public class GraphM : IGraph
{
    private int[,] matrix;
    private object[] nodeValues;
    private int edges;

    public void Init(int n)
    {
        matrix = new int[n, n];
        nodeValues = new object[n];
        edges = 0;
    }

    public int NodeCount()
    {
        return matrix.GetLength(0);
    }

    public int EdgeCount()
    {
        return edges;
    }

    public object GetValue(int v)
    {
        return nodeValues[v];
    }

    public void SetValue(int v, object val)
    {
        nodeValues[v] = val;
    }

    public void AddEdge(int v, int w, int wgt)
    {
        if (matrix[v, w] == 0)
        {
            matrix[v, w] = wgt;
            matrix[w, v] = wgt;
            edges++;
        }
    }

    public int Weight(int v, int w)
    {
        return matrix[v, w];
    }

    public void RemoveEdge(int v, int w)
    {
        if (matrix[v, w] != 0)
        {
            matrix[v, w] = 0;
            matrix[w, v] = 0;
            edges--;
        }
    }

    public bool HasEdge(int v, int w)
    {
        return matrix[v, w] != 0;
    }

    public int[] Neighbors(int v)
    {
        List<int> neighbors = [];
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            if (matrix[v, i] != 0)
            {
                neighbors.Add(i);
            }
        }

        return neighbors.ToArray();
    }
}