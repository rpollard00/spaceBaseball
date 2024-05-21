using SpaceBaseball.Core.Ports;

namespace SpaceBaseball.Core.NameGeneration;


public class NameGenerator : INameGenerator
{
    private Dictionary<string, MarkovGenerator> NamePool { get; set; } = new();

    public NameGenerator()
    {   
        var firstNameMarkov = new MarkovGenerator(lookbackSize: 2);
        var lastNameMarkov = new MarkovGenerator(lookbackSize: 2);
        TryAddNamePool("firstName", firstNameMarkov);
        Console.WriteLine("Add firstName pool");
        TryAddNamePool("lastName", lastNameMarkov);
        Console.WriteLine("Add lastName pool");

        var firstNameInput = GeneratorUtils.NameFileReader("../data/sampleFirstNames.txt");
        Console.WriteLine("Load firstName input from txt");
        var lastNameInput = GeneratorUtils.NameFileReader("../data/sampleLastNames.txt");
        Console.WriteLine("Load lastName input from txt");

        firstNameInput.ForEach(name => TrainPoolOn("firstName", name));
        Console.WriteLine("Trained firstName generator");
        lastNameInput.ForEach(name => TrainPoolOn("lastName", name));
        Console.WriteLine("Trained lastName generator");
        
        Console.WriteLine("[Completed]: Constructed Name Generator");
    }

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