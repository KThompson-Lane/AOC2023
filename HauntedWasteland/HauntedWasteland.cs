using AOC2023.HelperMethods;

namespace AOC2023.HauntedWasteland;

public class HauntedWasteland
{
    public static void PartOne()
    {
        // Get Input file
        using var input = InputHelper.GetInput(nameof(HauntedWasteland)).GetEnumerator();
        // Get instructions line
        if (!input.MoveNext())
            throw new IOException("Input doesn't contain instructions");
        var instructions = input.Current.Select(x => x);
        
        var network = CreateNetwork(input);

        var steps = network.FindNode("AAA", "ZZZ", instructions.ToList());
        Console.Out.WriteLine(steps);
    }

    public static void PartTwo()
    {
        // Get Input file
        using var input = InputHelper.GetInput(nameof(HauntedWasteland)).GetEnumerator();
        // Get instructions line
        if (!input.MoveNext())
            throw new IOException("Input doesn't contain instructions");
        
        var instructions = input.Current.Select(x => x);
        
        var network = CreateNetwork(input);
        
        var steps = network.GetStepsGhosts(instructions.ToList());
        Console.Out.WriteLine(steps);
    }

    private static DesertNetwork CreateNetwork(IEnumerator<string> input)
    {
        
        var network = new DesertNetwork();
        
        // Iterate and set up the network
        while (input.MoveNext())
        {
            var line = input.Current;
            if(string.IsNullOrWhiteSpace(line))
                continue;
            var halves = line.Split('=');

            var nodeString = halves[0].Trim();
            var children = halves[1].Split(',').Select(x => x.Trim(' ', '(', ')')).ToArray();
            network.AddNode(nodeString, (children[0], children[1]));
        }

        return network;
    }
}