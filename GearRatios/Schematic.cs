namespace AOC2023.GearRatios;

public class Schematic
{
    //  List of chars in the form row, column
    public List<List<char>> grid = new List<List<char>>();

    public void AddRow(IEnumerable<char> row)
    {
        grid.Add(row.ToList());
    }

    public IEnumerable<(char, (int row, int col))> GetAdjacentChars((int row, int col) index)
    {
        yield return GetElement((index.row+1, index.col+1));
        yield return GetElement((index.row+1, index.col));
        yield return GetElement((index.row+1, index.col-1));
        yield return GetElement((index.row, index.col+1));
        yield return GetElement((index.row, index.col-1));
        yield return GetElement((index.row-1, index.col+1));
        yield return GetElement((index.row-1, index.col));
        yield return GetElement((index.row-1, index.col-1));
    }

    private (char, (int row, int col)) GetElement((int row, int col) index)
    {
        return ((grid.ElementAtOrDefault(index.row)?.ElementAtOrDefault(index.col) ?? '.'), (index.row, index.col));
    }
    
    public int GetPartNumber((int row, int col) index)
    {
        var start = index.col;
        char item;
        do
        {
            item = grid.ElementAtOrDefault(index.row)?.ElementAtOrDefault(--start) ?? '.';
        } while (char.IsDigit(item));

        string partNumber = "";
        item = grid.ElementAtOrDefault(index.row)?.ElementAtOrDefault(++start) ?? '.';
        while (char.IsDigit(item))
        {
            partNumber += item;
            item = grid.ElementAtOrDefault(index.row)?.ElementAtOrDefault(++start) ?? '.';
        }

        return int.Parse(partNumber);
    }
}