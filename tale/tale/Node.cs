namespace tale;

public class Node
{
    public string Name { get; set; }
    public List<Edge> Edges { get; set; }

    public Node(string name)
    {
        this.Name = name;
        this.Edges = new List<Edge>();
    }
}