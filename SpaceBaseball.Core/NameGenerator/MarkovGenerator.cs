using System.Text;

namespace SpaceBaseball.Core.NameGenerator;

public class MarkovGenerator(int lookbackSize = 2)
{
    private readonly char _endChar = '*';
    private readonly int _lookbackSize = lookbackSize;

    private Dictionary<string, MarkovCell> Cells { get; set; } = new();

    public void Train(string inputSample)
    {
        StringBuilder prevChars = new();
        string sample = $"{inputSample}{_endChar}";

        foreach (var currentChar in sample)
        {
            // Console.WriteLine($"char={currentChar}");

            // var currentCell = Cells.GetValueOrDefault(currentChar) ?? new MarkovCell(prevChars.ToString());
            // currentCell.AddLetter(currentChar);
            var currentCellExists = Cells.TryGetValue(prevChars.ToString(), out var currentCellValue);
            // Console.WriteLine($"PrevChars Value: {prevChars}");
            if (!currentCellExists)
            {
                currentCellValue = new MarkovCell(prevChars.ToString());
                Cells.Add(prevChars.ToString(), currentCellValue);
            }
            Cells[prevChars.ToString()].AddLetter(currentChar);
            
            prevChars.Append(currentChar);
            // Console.WriteLine($"Prevchars after add {prevChars}");
            // Keeps only the lookback window size
            
            prevChars = prevChars.Length > _lookbackSize ? prevChars.Remove(0, prevChars.Length - _lookbackSize) : prevChars;
        }
        
    }

    public string Generate()
    {
        StringBuilder output = new();
        string window = ""; 
        char letter = '\0';

        while (letter != _endChar)
        {
            var currentCell = Cells[window];
            letter = GeneratorUtils.WheelSelect(currentCell.NextLetter, currentCell.TotalCount);
            output.Append(letter);
            window = output.Length - _lookbackSize >= 0 ? output.ToString().Substring(output.Length - _lookbackSize) : output.ToString();
        }

        output.Remove(output.Length - 1, 1);
        return output.ToString();
    }

    public List<string> GenerateMany(int num)
    {
        List<string> output = new();

        for (int i = 0; i < num; i++)
        {
            output.Add(Generate());
        }

        return output;
    }
}