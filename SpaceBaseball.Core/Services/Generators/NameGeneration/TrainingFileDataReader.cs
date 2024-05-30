using SpaceBaseball.Core.Ports;

namespace SpaceBaseball.Core.Services.Generators.NameGeneration;

public class TrainingFileDataReader : ITrainingDataReader {
    
    public List<string> ReadNamesFromFile(string filename)
    {
        List<string> output = new();
        using StreamReader reader = new StreamReader(filename);
        string? line;
        while ((line = reader.ReadLine()) != null)
        {
            output.Add(line);
        }

        return output;
    }
}