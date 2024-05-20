using SpaceBaseball.Core.Ports;

namespace SpaceBaseball.Core.NameGenerator;


public class NameGenerator : INameGenerator
{
    private Dictionary<string, MarkovGenerator> NamePool { get; set; } = new();

    public bool TryAddNamePool(string selector, MarkovGenerator generator)
    {
        return NamePool.TryAdd(selector, generator);
    }

    public string GetNameFromPool(string selector)
    {
        var selectedGenerator = TryGetPool(selector);
        return selectedGenerator.Generate();
    }

    public void TrainPoolOn(string selector, string input)
    {
        var selectedGenerator = TryGetPool(selector);
        selectedGenerator.Train(input);
    }

    private MarkovGenerator TryGetPool(string selector)
    {
        try
        {
            var selectedGenerator = NamePool[selector];
            return selectedGenerator;
        }
        catch (KeyNotFoundException ex)
        {
            Console.WriteLine($"Unable to find name pool {selector}...");
            throw;
        }
    }
}