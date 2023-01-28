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
