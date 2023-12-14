namespace AOC2023.HauntedWasteland;

public class DesertNetwork
{
    private readonly Dictionary<string, TreeNode> _network = new();

    public void AddNode(string node, (string left, string right) children)
    {
        if (!_network.ContainsKey(children.left))
            _network.Add(children.left, new TreeNode(children.left));
        
        if (!_network.ContainsKey(children.right))
            _network.Add(children.right, new TreeNode(children.right));
        
        if(!_network.ContainsKey(node))
            _network.Add(node, new TreeNode(node));
        
        _network[node].Left = _network[children.left];
        _network[node].Right = _network[children.right];
    }

    public int FindNode(string start, string destination, List<char> instructions)
    {
        int steps = 0;
        bool found = false;
        TreeNode currentNode = _network[start];
        while (!found)
        {
            var instruction = instructions[steps % instructions.Count];
            steps++;
            currentNode = currentNode.GetNode(instruction);
            if (currentNode.Node == destination)
                found = true;
        }
        return steps;
    }
    
    public int FindNode(string start, List<char> instructions)
    {
        int steps = 0;
        bool found = false;
        TreeNode currentNode = _network[start];
        while (!found)
        {
            var instruction = instructions[steps % instructions.Count];
            steps++;
            currentNode = currentNode.GetNode(instruction);
            if (currentNode.Node.EndsWith('Z'))
                found = true;
        }
        return steps;
    }
    
    public long GetStepsGhosts(List<char> instructions)
    {
        long steps = 0;
        var starts = _network.Keys.Where(x => x.EndsWith('A')).ToList();

        foreach (var node in starts)
        {
            var nodeSteps = FindNode(node, instructions);
            if (steps == 0)
                steps = nodeSteps;
            else
            {
                steps = GetLCM(steps, nodeSteps);
            }
        }

        return steps;
    }

    private static long GetLCM(long a, long b)
    {
        return (b / Gcd(a, b)) * a; 
    }
    
  
    private static long Gcd(long  a, long b)
    {
        while (b != 0)
        {
            var t = b;
            b = a % b;
            a = t;
        }

        return a;
    }

}