using System.Drawing;
using System.Text.RegularExpressions;
using AOC2023.HelperMethods;

namespace AOC2023.CubeConundrum;

public class CubeConundrum
{
    public static void GetValidGames()
    {
        var confguration = new List<(Game.Colour, int)>()
        {
            new(Game.Colour.Red, 12),
            new(Game.Colour.Green, 13),
            new(Game.Colour.Blue, 14),
        };
        var sum = GetGames().Sum(x => x.Valid(confguration) ? x.Id : 0);
        Console.Out.WriteLine(sum);
    }

    public static void GetSumOfPowers()
    {
        var sum = GetGames().Sum(x => x.GetMinimumCubes().Aggregate(1, (power, next) => power * next.Item2));

        Console.Out.WriteLine(sum);
    }

    private static IEnumerable<Game> GetGames()
    {
        var input = InputHelper.GetInput(nameof(CubeConundrum));
        foreach (var line in input)
        {
            var parts = line.Split(':');
            var gameId = int.Parse(string.Concat(parts[0].Where(char.IsDigit)));
            var sets = parts[1].Split(';');
            var game = new Game(gameId);
            foreach (var set in sets)
            {
                var matches = Regex.Matches(set, @"(\d+)\s(\w+)");
                var cubes = matches.Select(match => (Game.GetColour(match.Groups[2].Value), int.Parse(match.Groups[1].Value)));
                game.AddSet(cubes);
            }
            yield return game;
        }
    }
}