namespace SpaceBaseball.Core.NameGeneration;

public static class GeneratorUtils 
{
    public static char WheelSelect(Dictionary<char, int> charFrequencyDict, int totalCount)
    {
        Random rng = new();
        int selectedIndex = rng.Next(totalCount+1);
        int currentIndex = 0;

        foreach (var (k, v) in charFrequencyDict)
        {
            if (selectedIndex <= currentIndex + v)
            {
                return k;
            }

            currentIndex += v;
        }

        throw new IndexOutOfRangeException("Provided totalCount was incorrect");
    }
    
    public static List<string> NameFileReader(string filename)
    {
        List<string> output = new(); 
        using (StreamReader reader = new StreamReader(filename))
        {
            string? line;
            while ((line = reader.ReadLine()) != null)
            {
                output.Add(line);
            }
        }

        return output;
    }
}