namespace AOC2023.CubeConundrum;

public class Game
{
    public int Id { get;}

    public Game(int id)
    {
        Id = id;
    }
    
    public enum Colour
    {
        Red,
        Blue,
        Green
    }

    public static Colour GetColour(string col) =>
        col.ToLower() switch
        {
            "red" => Colour.Red,
            "blue" => Colour.Blue,
            "green" => Colour.Green,
            _ => throw new ArgumentOutOfRangeException(nameof(col), "Invalid colour")
        };

    private readonly List<HashSet<(Colour, int)>> _cubes = new();

    public void AddSet(IEnumerable<(Colour, int)> set)
    {
        var newSet = new HashSet<(Colour, int)>();
        foreach (var group in set)
        {
            newSet.Add(group);
        }

        _cubes.Add(newSet);
    }

    public bool Valid(IEnumerable<(Colour, int)> configuration)
    {
        foreach (var (colour, amount) in configuration)
        {
            var invalid = _cubes.Any(set => set.Where(grp => grp.Item1 == colour).Any(grp => grp.Item2 > amount));

            if (invalid)
            {
                return false;
            }
        }
        return true;
    }

    public IEnumerable<(Colour, int)> GetMinimumCubes()
    {
        var numbers = _cubes.SelectMany(x => x.Select(y => y)).GroupBy(x => x.Item1);
        var biggest = numbers.Select(x => x.MaxBy(y => y.Item2));
        return biggest;
    }
}