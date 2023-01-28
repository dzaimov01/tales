
namespace tale;

public class Graph
{
    public List<Node> Nodes { get; set; }

    public Graph()
    {
        this.Nodes = new List<Node>();
    }

    public void AddNode(Node node)
    {
        this.Nodes.Add(node);
    }

    public void AddEdge(Node startNode, Node endNode, int weight)
    {
        Edge edge = new Edge(startNode, endNode, weight);
        startNode.Edges.Add(edge);
    }
}
