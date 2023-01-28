namespace tale;

public class Edge : IComparable<Edge>
{
    private readonly int _v;
    private readonly int _w;
    private readonly double _weight;

    public Edge(int v, int w, double weight)
    {
        _v = v;
        _w = w;
        _weight = weight;
    }

    public double Weight()
    {
        return _weight;
    }

    public int CompareTo(Edge that)
    {
        if (Weight() < that.Weight())
            return -1;
        if (Weight() > that.Weight())
            return +1;
        return 0;
    }

    public int Source()
    {
        return _v;
    }

    public int Target(int vertex)
    {
        if (vertex == _v) return _w;
        if (vertex == _w) return _v;
        throw new Exception("Illegal endpoint");
    }

    public override String ToString()
    {
        return $"{_v:d}-{_w:d} {_weight:f5}";
    }
}