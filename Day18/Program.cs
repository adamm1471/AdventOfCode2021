// this is the data we need to represent as a binary tree
string data = "[[[[[9,8],1],2],3],4]";




// basic implementation
// one issue; i want to represent a pair of numbers in a node.. maybe int[] _data,
// then that could be the pair.  or the node could contain a single number.
public class Node
{
    private Node Left;
    private Node Right;
    private int Value;

    public Node(Node lnode, Node rnode)
    {
        Left = lnode;
        Right = rnode;
    }

    public bool IsPairNode()
    {
        if (_data != null && _data.Count == 2)
        {
            return true;
        }
        return false;
    }

    // not sure about this one
    public bool IsDataNode()
    {
        if (Left == null && Right == null)
        {
            return true;
        }
        return false;
    }
}