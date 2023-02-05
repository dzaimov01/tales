namespace tale;

public class Graph
{
    private readonly int[,] _vertices;

    public Graph(int[,] vertices)
    {
        _vertices = vertices;
    }

    private int MinmumDistance(int[] distances, bool[] visited)
    {
        int min = int.MaxValue;
        int minIndex = -1;

        for (int i = 0; i < distances.Length; i++)
        {
            if(!visited[i] && min >= distances[i])
            {
                min = distances[i];
                minIndex = i;
            }
        }

        return minIndex;
    }
    
    public void PerformDjikstra(int src)
    {
        int size = _vertices.GetLength(0);


        int[] dist = new int[size];  
        
        bool[] visited = new bool[size];
        
        for (int i = 0; i < size; i++)
        {
            dist[i] = int.MaxValue;
            visited[i] = false;
        }
        
        dist[src] = 0;
 
        for (int count = 0; count < size - 1; count++)
        {
            int currentNode = MinmumDistance(dist, visited);
            
            visited[currentNode] = true;
            
            for (int v = 0; v < size; v++)
                if (!visited[v] && _vertices[currentNode, v] != int.MaxValue &&
                    dist[currentNode] != int.MaxValue &&
                    dist[currentNode] + _vertices[currentNode, v] < dist[v])
                {
                    dist[v] = dist[currentNode] + _vertices[currentNode, v];
                }
        }
        PrintShortestPath(dist);
    }
    void PrintShortestPath(int[] dist)
    {
        Console.Write("Vertex \t\t Distance "
                      + "from Source\n");
        for (int i = 0; i < _vertices.GetLength(0); i++)
            Console.Write(i + " \t\t " + dist[i] + "\n");
    }
}