namespace AOC2023.HelperMethods;

public static class InputHelper
{
    public static IEnumerable<string> GetInput(string task) => 
        File.ReadLines($@"C:\Users\kiallthompson-lane\Documents\personal-projects\AOC2023\{task}\input.txt");
}