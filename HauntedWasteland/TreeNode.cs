namespace AOC2023.HauntedWasteland;

public class TreeNode
{
    public string Node { get; init; }
    public TreeNode Left { get; set; }
    public TreeNode Right { get; set; }

    public bool EndNode = false;

    public TreeNode(string node)
    {
        Node = node;
        if (node.ToLower().EndsWith('Z'))
            EndNode = true;
    }


    public TreeNode(string node, TreeNode left, TreeNode right)
    {
        Node = node;
        Left = left;
        Right = right;
    }

    public TreeNode GetNode(char side)
    {
        return char.ToLower(side) switch
        {
            'l' => Left,
            'r' => Right,
            _ => throw new ArgumentOutOfRangeException(nameof(side), "Invalid node side, should be 'L' or 'R'")
        };
    }
}