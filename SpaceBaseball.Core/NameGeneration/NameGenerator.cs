using SpaceBaseball.Core.Ports;

namespace SpaceBaseball.Core.NameGeneration;

public class NameGenerator : INameGenerator
{
    private readonly ITrainingDataReader _trainingDataReader;
    private Dictionary<string, NameGeneration> NamePool { get; set; } = new();

    public NameGenerator(ITrainingDataReader trainingDataReader)
    {
        _trainingDataReader = trainingDataReader; 
        var firstNameMarkov = new NameGeneration(lookbackSize: 2);
        var lastNameMarkov = new NameGeneration(lookbackSize: 2);
        TryAddNamePool("firstName", firstNameMarkov);
        Console.WriteLine("Add firstName pool");
        TryAddNamePool("lastName", lastNameMarkov);
        Console.WriteLine("Add lastName pool");

        var firstNameInput = _trainingDataReader.ReadNamesFromFile("../data/sampleFirstNames.txt");
        Console.WriteLine("Load firstName input from txt");
        var lastNameInput = _trainingDataReader.ReadNamesFromFile("../data/sampleLastNames.txt");
        Console.WriteLine("Load lastName input from txt");

        firstNameInput.ForEach(name => TrainPoolOn("firstName", name));
        Console.WriteLine("Trained firstName generator");
        lastNameInput.ForEach(name => TrainPoolOn("lastName", name));
        Console.WriteLine("Trained lastName generator");
        
        Console.WriteLine("[Completed]: Constructed Name Generator");
    }

    public bool TryAddNamePool(string selector, NameGeneration generator)
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

    private NameGeneration TryGetPool(string selector)
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