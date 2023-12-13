using System.Text.RegularExpressions;
using AOC2023.HelperMethods;

namespace AOC2023.WaitForIt;

public class WaitForIt
{
    
    public static void PartOne()
    {
        var input = InputHelper.GetInput(nameof(WaitForIt));
        var races = GetRaces(input);
        
        var possibleScenarios = races.Aggregate(1, (scenarios, next) => scenarios * next.GetPossibleWinsFinal());
        Console.Out.WriteLine(possibleScenarios);
    }

    public static void PartTwo()
    {
        var input = InputHelper.GetInput(nameof(WaitForIt));
        var race = GetRace(input);
        Console.Out.WriteLine(race.GetPossibleWinsFinal());
    }

    private static Race GetRace(IEnumerable<string> input)
    {
        using var enumerator = input.GetEnumerator();
        if (!enumerator.MoveNext())
            throw new IOException("Input has no time!");
        var time = long.Parse(Regex.Matches(enumerator.Current, @"\d+").SelectMany(x => x.Value).ToArray());
        if(!enumerator.MoveNext())
            throw new IOException("Input has no distance!");
        
        var distance = long.Parse(Regex.Matches(enumerator.Current, @"\d+").SelectMany(x => x.Value).ToArray());
        return new Race((time, distance));
    }

    private static IEnumerable<Race> GetRaces(IEnumerable<string> input)
    {
        using var enumerator = input.GetEnumerator();
        if (!enumerator.MoveNext())
            throw new IOException("Input has no times!");
        var times = Regex.Matches(enumerator.Current, @"\d+").Select(x => uint.Parse(x.Value));
        if(!enumerator.MoveNext())
            throw new IOException("Input has no distances!");
        var distances = Regex.Matches(enumerator.Current, @"\d+").Select(x => uint.Parse(x.Value));
        return times.Zip(distances).Select(x => new Race(x));
    }
}