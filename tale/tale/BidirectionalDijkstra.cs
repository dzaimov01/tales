
namespace tale;
public class BidirectionalDjikstra
{
    public List<Node> FindShortestPath(Node start, Node end, Graph graph)
    {
        // Create a priority queue and a dictionary to store the cost of each node
        PriorityQueue<Node, int> queue = new PriorityQueue<Node, int>();
        Dictionary<Node, int> costs = new Dictionary<Node, int>();

        // Initialize the start node's cost to 0
        queue.Enqueue(start, 0);
        costs[start] = 0;

        // Create a dictionary to store the parent of each node
        Dictionary<Node, Node> parents = new Dictionary<Node, Node>();

        // Perform the search
        while (queue.Count > 0)
        {
            Node currentNode = queue.Dequeue();

            // If we have reached the end node, we can reconstruct the path
            if (currentNode == end)
            {
                return ReconstructPath(end, parents);
            }

            // Visit each neighbor of the current node
            foreach (Edge edge in currentNode.Edges)
            {
                Node neighbor = edge.EndNode;
                int cost = costs[currentNode] + edge.Weight;

                // If the neighbor has not been visited or if the current path is shorter
                if (!costs.ContainsKey(neighbor) || cost < costs[neighbor])
                {
                    // Update the neighbor's cost and parent
                    queue.Enqueue(neighbor, cost);
                    costs[neighbor] = cost;
                    parents[neighbor] = currentNode;
                }
            }
        }

        // If the while loop exits, it means the search has failed
        // and there is no path from start to end
        return null;
    }

    private List<Node> ReconstructPath(Node currentNode, Dictionary<Node, Node> parents)
    {
        List<Node> path = new List<Node>();
        while (currentNode != null)
        {
            path.Add(currentNode);
            currentNode = parents.ContainsKey(currentNode) ? parents[currentNode] : null;
        }
        path.Reverse();
        return path;
    }
}
