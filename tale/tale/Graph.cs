namespace tale;

public class Graph
{
    private readonly int[,] _vertices;

    public Graph(int[,] vertices)
    {
        _vertices = vertices;
    }

    private static int MinDistance(int[] distance, bool[] shortestPathTreeSet)
    {
        int min = int.MaxValue;
        int minIndex = 0;

        for (int v = 0; v < distance.Length; v++)
        {
            if (shortestPathTreeSet[v] == false && distance[v] <= min)
            {
                min = distance[v];
                minIndex = v;
            }
        }

        return minIndex;
    }

    public Tuple<int[], int[]> Djikstra(int source)
    {
        int n = _vertices.GetLength(0);
        int[] distance = new int[n];
        int[] path = new int[n];
        bool[] shortestPathTreeSet = new bool[n];

        for (int i = 0; i < n; i++)
        {
            distance[i] = int.MaxValue;
            shortestPathTreeSet[i] = false;
            path[i] = -1;
        }

        distance[source] = 0;

        for (int count = 0; count < n - 1; count++)
        {
            int u = MinDistance(distance, shortestPathTreeSet);
            shortestPathTreeSet[u] = true;

            for (int v = 0; v < n; v++)
            {
                if (!shortestPathTreeSet[v] && _vertices[u, v] != 0 && distance[u] != int.MaxValue && distance[u] + _vertices[u, v] < distance[v])
                {
                    distance[v] = distance[u] + _vertices[u, v];
                    path[v] = u;
                }
            }
        }

        return Tuple.Create(distance, path);
    }
     void PrintShortestPath(int[] dist)
    {
        Console.Write("Vertex \t\t Distance "
                      + "from Source\n");
        for (int i = 0; i < _vertices.GetLength(0); i++)
            Console.Write(i + " \t\t " + dist[i] + "\n");
    }
}