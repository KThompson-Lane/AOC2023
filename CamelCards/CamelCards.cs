using AOC2023.HelperMethods;

namespace AOC2023.CamelCards;

public class CamelCards
{
    public static void PartOne()
    {
        var input = InputHelper.GetInput(nameof(CamelCards));
        var hands = input.Select(x =>
        {
            var halves = x.Split(' ');
            return new Hand(halves[0], int.Parse(halves[1]));
        });
        var sumTotal = hands.Order().Select((hand, index) => (hand,index)).Aggregate(0, (sum,x ) => sum += x.hand
            .Bid * (x.index+1));

        Console.Out.WriteLine(sumTotal);
    }

    public static void PartTwo()
    {
        var input = InputHelper.GetInput(nameof(CamelCards));
        var hands = input.Select(x =>
        {
            var halves = x.Split(' ');
            return new HandJ(halves[0], int.Parse(halves[1]));
        });

        var sumTotal = hands.Order().Select((hand, index) => (hand,index)).Aggregate(0, (sum,x ) => sum += x.hand
            .Bid * (x.index+1));

        Console.Out.WriteLine(sumTotal);
    }
}