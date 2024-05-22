namespace SpaceBaseball.Core.Ports;

public interface ITrainingDataReader
{
    List<string> ReadNamesFromFile(string filepath);
}