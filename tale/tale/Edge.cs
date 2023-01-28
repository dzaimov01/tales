namespace tale;

public class Edge
{
    public Node StartNode { get; set; }
    public Node EndNode { get; set; }
    public int Weight { get; set; }

    public Edge(Node startNode, Node endNode, int weight)
    {
        this.StartNode = startNode;
        this.EndNode = endNode;
        this.Weight = weight;
    }
}