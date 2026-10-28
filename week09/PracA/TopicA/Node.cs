public class Node
{
    public string Data { get; set; }

    public HashSet<Node> Edges { get; set; }

    public Node(string data)
    {
        Data = data;
        Edges = new HashSet<Node>();
    }

    public override string ToString()
    {
        return Data;
    }
}