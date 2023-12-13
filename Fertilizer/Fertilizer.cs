using System.Collections.Concurrent;
using AOC2023.HelperMethods;

namespace AOC2023.Fertilizer;

public class Fertilizer
{
    /// <summary>
    /// Currently non-functional, needs recreation
    /// </summary>
    public static void GetLowestLocation()
    {
        // var input = InputHelper.GetInput(nameof(Fertilizer));
        // var almanac = new SimpleAlmanac(input);
        //
        // var pairs = almanac.GetSeeds?
        //     .Select(seed => 
        //         almanac.Maps.Aggregate(seed, 
        //             (s, map) => map.Value.GetMapping(s), 
        //             location => (seed, location)));
        //
        // Console.Out.WriteLine(pairs.MinBy(pair => pair.location).location);
    }
    
    /// <summary>
    /// Currently non-functional, needs recreation
    /// </summary>
    public static void GetLowestLocationImproved()
    {
        // var input = InputHelper.GetInput(nameof(Fertilizer));
        // var almanac = new ImprovedAlmanac(input);
        //
        // var test = new ConcurrentBag<long>();
        //
        // var locations = almanac.Maps!.Last().Value;
        //
        //
        //
        // Parallel.ForEach(almanac.GetSeeds!, range =>
        // {
        //     long smallest = -1;
        //     for (long i = 0; i < range.length; i++)
        //     {
        //         var location = almanac.Maps!.Aggregate(range.start+i, (s, map) => map.Value.GetMapping(s));
        //         if (smallest == -1 || location < smallest)
        //             smallest = location;
        //     }
        //     test.Add(smallest);
        //     Console.Out.WriteLine($"Smallest in range: {smallest}");
        // });
        // var location = test.Order().First();
        // Console.Out.WriteLine(location);

    }
}