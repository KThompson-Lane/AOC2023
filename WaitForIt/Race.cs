using System.Diagnostics;

namespace AOC2023.WaitForIt;

public class Race
{
    public long Time;
    public long Distance;

    public Race((long time, long distance) race)
    {
        Time = race.time;
        Distance = race.distance;
    }

    public int GetPossibleWins()
    {
        int distanceCovered = 0;
        int possibleWins = 0;
        for (int i = 1; i < Time; i++)
        {
            distanceCovered = 0;
            var remainingTime = Time - i;
            for (int j = 0; j < remainingTime; j++)
            {
                distanceCovered += i;
            }
            if (distanceCovered > Distance)
                possibleWins++;
        }

        return possibleWins;
    }

    public int GetPossibleWinsImproved()
    {
        // Furthest you can go is (T/2 * T-T/2)
        // D = T-x * y == D = T-y * x
        var possibleWins = 0;
        var halfTime = (Time / 2);
        for (long i = halfTime; i > 1; i--)
        {
            var distance = i * (Time - i);
            if (distance <= Distance)
                break;
            possibleWins += 2;
        }

        if (Time % 2 == 0)
            possibleWins--;
        return possibleWins;
    }

    public int GetPossibleWinsFinal()
    {
        // Similar to above but counting up
        var halfTime = (Time / 2);
        int testTime = 1;
        do
        {
            var distanceCovered = testTime * (Time - testTime);
            if (distanceCovered <= Distance)
                testTime++;
            else
                break;
        } while (true);

        var possibleWins = (int)(halfTime - testTime) * 2;
        if (Time % 2 != 0)
            possibleWins++;
        return ++possibleWins;
    }
    
    public static void Tests()
    {
        var times = new List<long>();
        // Get Input race
        var inputRace = new Race((1088698992, 9003797889445));
        
        //  Test First Version
        var sw = Stopwatch.StartNew();
        var test = inputRace.GetPossibleWinsImproved();
        Console.Out.WriteLine(test);
        sw.Stop();
        times.Add(sw.ElapsedMilliseconds);
        
        // Test improved version
        sw.Restart();
        test = inputRace.GetPossibleWinsImproved();
        Console.Out.WriteLine(test);
        sw.Stop();
        times.Add(sw.ElapsedMilliseconds);
        
        // Test final version
        sw.Restart();
        test = inputRace.GetPossibleWinsFinal();
        Console.Out.WriteLine(test);
        sw.Stop();
        times.Add(sw.ElapsedMilliseconds);
        foreach (var time in times)
        {
            Console.Out.WriteLine(time);
        }
    }
}