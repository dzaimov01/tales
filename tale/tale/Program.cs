namespace tale;

class Program
{

    public static void Main(string[] args)
    {

        int[] graphChars = Array.ConvertAll(Console.ReadLine()?.Split(" ") ?? Array.Empty<string>(), int.Parse);

        int[] positions = Array.ConvertAll(Console.ReadLine()?.Split(" ") ?? Array.Empty<string>(), int.Parse);
        int c = positions[0];
        int w = positions[1];
        int b = positions[2];

        int edges = graphChars[0];
        int numberWeights = graphChars[1];

        int[,] graphInput = ReadGraph(edges, numberWeights);

        Graph graph = new Graph(graphInput);
        Tuple<int[], int[]> pathsForC = graph.Dijkstra(c);
        Tuple<int[], int[]> pathsForW = graph.Dijkstra(w);

        int timeForC = graph.Dijkstra(c).Item1[b];
        string[]? nodesForC = GetPath(pathsForC.Item2, b)?.Split(" -> ");
        int result = 0;
        if (nodesForC != null)
            for (int i = 1; i < nodesForC.Length; i++)
            {
                result = pathsForW.Item1[i] < timeForC ? 0 : timeForC;
            }

        Console.WriteLine(result > int.MinValue ? result : "No path available");
    }

    private static int[,] ReadGraph(int dimensions, int numberWeights)
    {
        int[,] graph = new int[dimensions + 1, dimensions + 1];

        for (int i = 0; i < numberWeights; i++)
        {
            int[] weightsInput = Array.ConvertAll(Console.ReadLine()?.Split(" ") ?? Array.Empty<string>(), int.Parse);

            int p1 = weightsInput[0];
            int p2 = weightsInput[1];
            int s1 = weightsInput[2];

            graph[p1, p2] = s1;
        }
        return graph;
    }
    private static string? GetPath(int[] path, int dest)
    {
        if (path[dest] == -1)
        {
            Console.WriteLine("No path exists");
            return null;
        }

        var pathList = new List<int>();
        int current = dest;
        while (current != -1)
        {
            pathList.Add(current);
            current = path[current];
        }

        pathList.Reverse();
        return "The path is: " + string.Join(" -> ", pathList);
    }
}

