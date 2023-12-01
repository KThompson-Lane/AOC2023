using System.Text.RegularExpressions;
using AOC2023.HelperMethods;

namespace AOC2023.Trebuchet;

public class Trebuchet
{
    private static readonly Dictionary<string, int> Digits = new()
    {
        { "one", 1 },
        { "two", 2 },
        { "three", 3 },
        { "four", 4 },
        { "five", 5 },
        { "six", 6 },
        { "seven", 7 },
        { "eight", 8 },
        { "nine", 9 },
        { "1", 1 },
        { "2", 2 },
        { "3", 3 },
        { "4", 4 },
        { "5", 5 },
        { "6", 6 },
        { "7", 7 },
        { "8", 8 },
        { "9", 9 }
    };
    
    public static void GetCalibrationSum()
    {
        var input = InputHelper.GetInput(nameof(Trebuchet));
        var sum = GetCalibrationValues(input).Sum();
        Console.Out.WriteLine(sum);
    }
    public static void GetRealCalibrationSum()
    {
        var input = InputHelper.GetInput(nameof(Trebuchet));
        var sum = GetRealCalibrationValues(input).Sum();
        Console.Out.WriteLine(sum);
    }
    private static IEnumerable<int> GetCalibrationValues(IEnumerable<string> input)
    {
        foreach (var line in input)
        {
            var matches = Regex.Matches(line, @"\d");
            var num = matches.First().Value + matches.Last().Value;
            yield return int.TryParse(num, out int result)? result : 0;
        }
    }

    private static IEnumerable<int> GetRealCalibrationValues(IEnumerable<string> input)
    {
        foreach (var line in input)
        {
            var (first, last) = GetFirstAndLastDigits(line);
            yield return int.TryParse($"{first}{last}", out int digit)? digit : 0;
        }
    }

    private static (int, int) GetFirstAndLastDigits(string input)
    {
        var firstDigit = Digits.Select(x => (x.Value, input.IndexOf(x.Key, StringComparison.Ordinal))).Where(x => x.Item2 != -1).MinBy(x => x.Item2);
        var lastDigit = Digits.Select(x => (x.Value, input.LastIndexOf(x.Key, StringComparison.Ordinal))).Where(x => x.Item2 != -1).MaxBy(x => x.Item2);
        
        return (firstDigit.Value, lastDigit.Value);
    }
    
}