using System.Text.RegularExpressions;
using AOC2023.HelperMethods;

namespace AOC2023.Scratchcards;

public class Scratchcards
{
    
    public static void GetTotalPoints()
    {
        var input = InputHelper.GetInput(nameof(Scratchcards));
        int sum = GetCards(input).Sum(card => (int)Math.Pow(2, card.CountWins - 1));
        Console.Out.WriteLine(sum);
    }

    public static void GetTotalScratchCards()
    {
        var input = InputHelper.GetInput(nameof(Scratchcards));
        var originalCards = GetCards(input).ToList();
        
        Dictionary<Scratchcard, List<Scratchcard>> duplicates = new();
        var processQueue = new Queue<Scratchcard>();

        int sum = 0;
        // Initialize duplicate list
        foreach (var card in originalCards)
        {
            var wins = card.CountWins;
            if (wins == 0)
            {
                sum++;
                continue;
            }
            var cardDupes = new List<Scratchcard>();
            for (int i = 0; i < wins; i++)
            {
                var duplicate = originalCards[card.Number + i];
                cardDupes.Add(duplicate);
            }
            duplicates.Add(card, cardDupes);
            processQueue.Enqueue(card);
        }
        
        // Iterate over original cards adding them to processing list
        while (processQueue.Count != 0)
        {
            var card = processQueue.Dequeue();
            sum++;
            if (!duplicates.ContainsKey(card))
            {
                continue;
            }
            else
            {
                foreach (var duplicate in duplicates[card])
                {
                    processQueue.Enqueue(duplicate);
                }
            }
        }
        Console.Out.WriteLine(sum);
    }
    
    private struct Scratchcard
    {
        public int Number;
        public IEnumerable<int> WinningNumbers;
        public IEnumerable<int> MyNumbers;
        public int CountWins => 
            MyNumbers.Intersect(WinningNumbers).Count();
    }
    private static IEnumerable<Scratchcard> GetCards(IEnumerable<string> input)
    {
        foreach (var line in input)
        {
            var sections = line.Split('|', ':');
            var cardNumber = int.Parse(sections[0].Last().ToString());
            var winningNumbers = Regex.Matches(sections[1], @"\d+").Select(x => int.Parse(x.Value));
            var myNumbers = Regex.Matches(sections[2], @"\d+").Select(x => int.Parse(x.Value));
            yield return new Scratchcard{Number = cardNumber, WinningNumbers = winningNumbers, MyNumbers = myNumbers};
        }
    }
}