using SpaceBaseball.Core.Ports;
using SpaceBaseball.Core.Utils;

namespace SpaceBaseball.Core.Services.Generators.NameGeneration;

public class NameGenerator : INameGenerator
{
    private Dictionary<string, MarkovGenerator> NamePool { get; set; } = new();

    public void BuildNamePool(string selector, List<string> trainingSet, int lookbackSize = 2)
    {
        Console.WriteLine($"Creating name pool: {selector}");
        var didPoolAdd = TryAddNamePool(selector, new MarkovGenerator(lookbackSize));
        if (!didPoolAdd)
        {
            throw new ArgumentException($"A name pool with the given selector already exists.", nameof(selector));
        }
        Console.WriteLine($"Training name pool: {selector}");
        trainingSet.ForEach(name => TrainPoolOn(selector, name));
        Console.WriteLine($"Trained {selector} generator");
    }
    public bool TryAddNamePool(string selector, MarkovGenerator generator)
    {
        return NamePool.TryAdd(selector, generator);
    }

    public string GetNameFromPool(string selector)
    {
        var selectedGenerator = TryGetPool(selector);
        return selectedGenerator.Generate(GeneratorUtils.WheelSelect);
    }

    
    public void TrainPoolOn(string selector, string input)
    {
        var selectedGenerator = TryGetPool(selector);
        selectedGenerator.Train(input);
    }

    public MarkovGenerator TryGetPool(string selector)
    {
        if (!NamePool.TryGetValue(selector, out var pool))
        {
            throw new ArgumentException($"No name pool found for selector: '{selector}'", nameof(selector));
        }
        return pool;
    }
}