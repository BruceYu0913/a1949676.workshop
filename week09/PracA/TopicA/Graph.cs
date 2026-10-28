public class Graph
{
    public HashSet<Node> Nodes { get; set; }

    public Graph()
    {
        Nodes = new HashSet<Node>();
    }

    public void AddEdge(Node fromNode, Node toNode)
    {
        Nodes.Add(fromNode);
        Nodes.Add(toNode);

        fromNode.Edges.Add(toNode);
        toNode.Edges.Add(fromNode);
    }

    private Node GetNode(string data)
    {
        foreach (Node node in Nodes)
        {
            if (node.Data == data)
            {
                return node;
            }
        }

        throw new Exception("Node not found.");
    }

    private bool HasEdge(Node firstNode, Node secondNode)
    {
        return firstNode.Edges.Contains(secondNode);
    }

    public override string ToString()
    {
        Node A = GetNode("A");
        Node B = GetNode("B");
        Node C = GetNode("C");
        Node D = GetNode("D");
        Node E = GetNode("E");
        Node F = GetNode("F");
        Node G = GetNode("G");
        Node H = GetNode("H");
        Node I = GetNode("I");

        string result = "";

        result += $"        {A}\n";

        if (HasEdge(A, B) && HasEdge(A, C))
        {
            result += "       / \\\n";
        }

        result += $"      {B}   {C}\n";

        if (HasEdge(B, D) &&
            HasEdge(B, E) &&
            HasEdge(C, F))
        {
            result += "     / \\   \\\n";
        }

        result += $"    {D}   {E}   {F}\n";

        if (HasEdge(D, G) &&
            HasEdge(E, H) &&
            HasEdge(F, I))
        {
            result += "   /     \\   \\\n";
        }

        result += $"  {G}       {H}   {I}";

        return result;
    }
}