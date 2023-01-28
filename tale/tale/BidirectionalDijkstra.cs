
namespace tale;
internal class BidirectionalDijkstra
{
    public static List<int> FindPath(int[,] graph, int[] weights, int startA, int startB, int endA, int endB)
    {
        int n = graph.GetLength(0);
        // Create two priority queues, one for each search front
        var queueA = new PriorityQueue<Tuple<int, int>>();
        var queueB = new PriorityQueue<Tuple<int, int>>();
        // Initialize the distances and previous vertices arrays
        var distA = Enumerable.Repeat(int.MaxValue, n).ToArray();
        var distB = Enumerable.Repeat(int.MaxValue, n).ToArray();
        var prevA = Enumerable.Repeat(-1, n).ToArray();
        var prevB = Enumerable.Repeat(-1, n).ToArray();
        // Create the visited arrays
        var visitedA = new bool[n];
        var visitedB = new bool[n];
        // Enqueue the start vertices
        queueA.Enqueue(new Tuple<int, int>(startA, 0));
        queueB.Enqueue(new Tuple<int, int>(startB, 0));
        distA[startA] = 0;
        distB[startB] = 0;

        while (queueA.Count > 0 && queueB.Count > 0)
        {
            // Dequeue the vertex with the smallest distance from the first queue
            var vertexA = queueA.Dequeue();
            // Mark the vertex as visited
            visitedA[vertexA.Item1] = true;
            // Check if the vertex has been visited by the second search front
            if (visitedB[vertexA.Item1])
            {
                // Build the path from startA to endA
                var pathA = BuildPath(prevA, startA, endA, vertexA.Item1);
                // Build the path from startB to endB
                var pathB = BuildPath(prevB, startB, endB, vertexA.Item1);
                // Reverse the path from startB to endB
                pathB.Reverse();
                // Concatenate the two paths
                pathA.AddRange(pathB);
                // Return the final path
                return pathA;
            }
            // Iterate through all the neighbors of the vertex
            for (int i = 0; i < n; i++)
            {
                if (graph[vertexA.Item1, i] > 0)
                {
                    // Calculate the new distance
                    int newDist = distA[vertexA.Item1] + weights[vertexA.Item1, i];
                    // If the new distance is smaller than the current distance, update it
                    if (newDist < distA[i])
                    {
                        distA[i] = newDist;
                        prevA[i] = vertexA.Item1;
                        queueA.Enqueue(new Tuple<int, int>(i, distA[i]));
                    }
                }
            }

            // Dequeue the vertex with the smallest distance from the second queue
            var vertexB = queueB.Dequeue();
            // Mark the vertex as visited
            visitedB[vertexB.Item1] = true;
            // Check if the vertex has been visited by the first search front
            if (visitedA[vertexB.Item1])
            {
                // Build the path from startA to endA
                var pathA = BuildPath(prevA, startA, endA, vertexB.Item1);
                // Build the path from startB to endB
                var pathB = BuildPath(prevB, startB, endB, vertexB.Item1);
                // Reverse the path from startB to endB
                pathB.Reverse();
                // Concatenate the two paths
                pathA.AddRange(pathB);
                // Return the final path
                return pathA;
            }
            // Iterate through all the neighbors of the vertex
            for (int i = 0; i < n; i++)
            {
                if (graph[vertexB.Item1, i] > 0)
                {
                    // Calculate the new distance
                    int newDist = distB[vertexB.Item1] + weights[vertexB.Item1, i];
                    // If the new distance is smaller than the current distance, update it
                    if (newDist < distB[i])
                    {
                        distB[i] = newDist;
                        prevB[i] = vertexB.Item1;
                        queueB.Enqueue(new Tuple<int, int>(i, distB[i]));
                    }
                }
            }
        }
    }
        return null;
    }

private static List<int> BuildPath(int[] prev, int start, int end, int collision)
{
    var path = new List<int>();
    int current = collision;
    while (current != start)
    {
        path.Add(current);
        current = prev[current];
    }
    path.Add(start);
    path.Reverse();
    return path;
}
