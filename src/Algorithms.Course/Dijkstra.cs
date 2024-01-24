namespace Algorithms.Course;

class DijkstraGraph
{
    private int _vertices;
    private int[,] _adjacencyMatrix;

    public DijkstraGraph(int vertices)
    {
        _vertices = vertices;
        _adjacencyMatrix = new int[vertices, vertices];
    }

    public void AddEdge(int source, int destination, int weight)
    {
        _adjacencyMatrix[source, destination] = weight;
        _adjacencyMatrix[destination, source] = weight; // For undirected graph
    }

    private int MinimumDistance(int[] distance, bool[] shortestPathTreeSet)
    {
        int min = int.MaxValue, minIndex = -1;

        for (int v = 0; v < _vertices; v++)
            if (shortestPathTreeSet[v] == false && distance[v] <= min)
            {
                min = distance[v];
                minIndex = v;
            }

        return minIndex;
    }

    public Dictionary<int, (int Distance, List<int> Path)> Dijkstra(int source)
    {
        int[] distance = new int[_vertices];
        bool[] sptSet = new bool[_vertices];
        int[] parents = new int[_vertices];
        var results = new Dictionary<int, (int Distance, List<int> Path)>();

        for (int i = 0; i < _vertices; i++)
        {
            parents[i] = -1;
            distance[i] = int.MaxValue;
            sptSet[i] = false;
        }

        distance[source] = 0;

        for (int count = 0; count < _vertices - 1; count++)
        {
            int u = MinimumDistance(distance, sptSet);
            sptSet[u] = true;

            for (int v = 0; v < _vertices; v++)
                if (!sptSet[v] && _adjacencyMatrix[u, v] != 0 && distance[u] != int.MaxValue &&
                    distance[u] + _adjacencyMatrix[u, v] < distance[v])
                {
                    distance[v] = distance[u] + _adjacencyMatrix[u, v];
                    parents[v] = u;
                }
        }

        for (int i = 0; i < _vertices; i++)
        {
            var path = new List<int>();
            int crawl = i;
            path.Add(crawl);
            while (parents[crawl] != -1)
            {
                path.Add(parents[crawl]);
                crawl = parents[crawl];
            }

            path.Reverse();

            results[i] = (distance[i], path);
        }

        return results;
    }
}