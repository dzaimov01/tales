using System.Text;

namespace tale;

public class EdgeWeightedGraph
{
    private readonly int _v;
    private int _e;
    private LinkedList<Edge>[] _adj;

    public EdgeWeightedGraph(int vertices)
    {
        if (vertices < 0)
            throw new Exception("Number of vertices in a Graph must be nonnegative");

        this._v = vertices;
        
        this._e = 0;

        _adj = new LinkedList<Edge>[vertices];

        for (int v = 0; v < vertices; v++)
        {
            _adj[v] = new LinkedList<Edge>();
        }
    }

    public int V()
    {
        return _v;
    }

    public int E()
    {
        return _e;
    }

    public void AddEdge(Edge e)
    {
        int v = e.Source();
        int w = e.Target(v);
        _adj[v].AddFirst(e);
        _adj[w].AddFirst(e);
        _e++;
    }

    public IEnumerable<Edge> Adj(int v)
    {
        return _adj[v];
    }

    public IEnumerable<Edge> Edges()
    {
        LinkedList<Edge> list = new LinkedList<Edge>();
        
        for (int v = 0; v < _v; v++)
        {
            int selfLoops = 0;

            foreach (Edge e in Adj(v))
            {
                if (e.Target(v) > v)
                {
                    list.AddFirst(e);
                }
                else if (e.Target(v) == v)
                {
                    if (selfLoops % 2 == 0) 
                        list.AddFirst(e);
                    selfLoops++;
                }
            }
        }

        return list;
    }

    public override String ToString()
    {
        StringBuilder s = new StringBuilder();

        s.Append(_v + " " + _e + Environment.NewLine);

        for (int v = 0; v < _v; v++)
        {
            s.Append(v + ": ");
            
            foreach (Edge e in _adj[v])
            {
                s.Append(e + "  ");
            }
            
            s.Append(Environment.NewLine);
        }
        return s.ToString();
    }
}
    