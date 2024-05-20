using System.Text;

namespace SpaceBaseball.Core.NameGenerator;

internal class MarkovCell(string? priorLetters)
{
    public string? PriorLetters { get; set; } = priorLetters;
    public int TotalCount { get; set; }
    public Dictionary<char, int> NextLetter { get; set; } = new();

    public void AddLetter(char letter)
    {
        TotalCount++;
        if (!NextLetter.TryAdd(letter, 1))
        {
            NextLetter[letter]++;
        } 
    }
    
    public override string ToString()
    {
        StringBuilder output = new StringBuilder();
        foreach (var (letter, count) in NextLetter)
        {
            output.Append($"MarkovCell({letter}:{count})");
        }

        return output.ToString();
    }
    
}