using SpaceBaseball.Core.NameGeneration;

namespace SpaceBaseball.Core.Ports;

public interface INameGenerator
{
    bool TryAddNamePool(string selector, NameGeneration.NameGeneration generator);
    string GetNameFromPool(string selector);
    void TrainPoolOn(string selector, string input);
}