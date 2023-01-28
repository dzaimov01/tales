namespace tale;

class Djikstra
{
    class Node
    {
        public int vertex;
        public int weight;

        public Node(int v, int w)
        {
            vertex = v;
            weight = w;
        }
    }
    
    static List<List<Node>> EnterGraphData() {
        Console.Write("Enter the number of nodes in the graph: ");
        int n = int.Parse(Console.ReadLine());

        List<List<Node>> graph = new List<List<Node>>();

        for (int i = 0; i < n; i++) {
            graph.Add(new List<Node>());
        }

        for (int i = 0; i < n; i++) {
            Console.Write("Enter the number of edges for node " + i + ": ");
            int m = int.Parse(Console.ReadLine());

            for (int j = 0; j < m; j++) {
                Console.Write("Enter the destination node and weight for edge " + j + ": ");
                string[] input = Console.ReadLine().Split();
                int dest = int.Parse(input[0]);
                int weight = int.Parse(input[1]);

                graph[i].Add(new Node(dest, weight));
            }
        }

        return graph;
    }

    static int[] DijkstraBetweenTwoPoints(List<List<Node>> graph, int sourceNode, int destinationNode)
    {
        int n = graph.Count;
        int[] distance = new int[n];
        bool[] visited = new bool[n];

        for (int i = 0; i < n; i++)
        {
            distance[i] = int.MaxValue;
            visited[i] = false;
        }

        distance[sourceNode] = 0;

        for (int i = 0; i < n - 1; i++)
        {
            int min = int.MaxValue;
            int minIndex = -1;

            for (int j = 0; j < n; j++)
            {
                if (!visited[j] && distance[j] <= min)
                {
                    min = distance[j];
                    minIndex = j;
                }
            }

            visited[minIndex] = true;

            for (int j = 0; j < graph[minIndex].Count; j++)
            {
                int neighbor = graph[minIndex][j].vertex;
                int weight = graph[minIndex][j].weight;

                if (!visited[neighbor] && distance[minIndex] != int.MaxValue &&
                    distance[minIndex] + weight < distance[neighbor])
                {
                    distance[neighbor] = distance[minIndex] + weight;
                }
            }
        }

        if (distance[destinationNode] != int.MaxValue)
        {
            int[] path = new int[n];
            int count = 0;
            int temp = destinationNode;
            path[count] = temp;

            while (temp != sourceNode)
            {
                for (int i = 0; i < graph[temp].Count; i++)
                {
                    int neighbor = graph[temp][i].vertex;
                    int weight = graph[temp][i].weight;

                    if (distance[temp] - weight == distance[neighbor])
                    {
                        count++;
                        temp = neighbor;
                        path[count] = temp;
                    }
                }
            }

            Array.Reverse(path, 0, count + 1);
            return path;
        }
        return new int[] { };
    }

    static int[] DijkstraForAllNodes(List<List<Node>> graph, int sourceNode)
    {
        int n = graph.Count;
        int[] distance = new int[n];
        bool[] visited = new bool[n];

        for (int i = 0; i < n; i++)
        {
            distance[i] = int.MaxValue;
            visited[i] = false;
        }

        distance[sourceNode] = 0;

        for (int i = 0; i < n - 1; i++)
        {
            int min = int.MaxValue;
            int minIndex = -1;

            for (int j = 0; j < n; j++)
            {
                if (!visited[j] && distance[j] <= min)
                {
                    min = distance[j];
                    minIndex = j;
                }
            }

            visited[minIndex] = true;

            for (int j = 0; j < graph[minIndex].Count; j++)
            {
                int neighbor = graph[minIndex][j].vertex;
                int weight = graph[minIndex][j].weight;

                if (!visited[neighbor] && distance[minIndex] != int.MaxValue &&
                    distance[minIndex] + weight < distance[neighbor])
                {
                    distance[neighbor] = distance[minIndex] + weight;
                }
            }
        }

        return distance;
    }
}
