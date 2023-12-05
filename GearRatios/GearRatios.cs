using AOC2023.HelperMethods;

namespace AOC2023.GearRatios;

public class GearRatios
{
    public static void GetSumOfPartNumbers()
    {
        var input = InputHelper.GetInput(nameof(GearRatios));
        var schematic = new Schematic();
        List<int> partNumbers = new List<int>();
        foreach (var line in input)
        {
            schematic.AddRow(line);
        }
        var symbols = schematic.grid.SelectMany((list, row) => list.Select((c, col) => (row, col, c))).Where(x => x.c != '.' && !char.IsDigit(x.c));

        foreach (var (row, col, symbol) in symbols)
        {
            var adjacentChars = schematic.GetAdjacentChars((row, col)).Where(x => char.IsDigit(x.Item1));
            partNumbers.AddRange(adjacentChars.Select(x => schematic.GetPartNumber(x.Item2)).Distinct());
        }

        Console.Out.WriteLine(partNumbers.Sum());
    }
    public static void GetSumOfGearRatio()
    {
        var input = InputHelper.GetInput(nameof(GearRatios));
        var schematic = new Schematic();
        int sum = 0;
        foreach (var line in input)
        {
            schematic.AddRow(line);
        }
        var symbols = schematic.grid.SelectMany((list, row) => list.Select((c, col) => (row, col, c))).Where(x => x.c != '.' && !char.IsDigit(x.c));

        foreach (var (row, col, symbol) in symbols)
        {
            var adjacentChars = schematic.GetAdjacentChars((row, col)).Where(x => char.IsDigit(x.Item1));
            var gears = adjacentChars.Select(x => schematic.GetPartNumber(x.Item2)).Distinct().ToList();
            if (gears.Count == 2)
            {
                sum += gears[0] * gears[1];
            }
        }

        Console.Out.WriteLine(sum);
    }
}