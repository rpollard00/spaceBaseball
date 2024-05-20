using SpaceBaseball.Core.NameGenerator;

namespace SpaceBaseball.Core.Ports;

public interface INameGenerator
{
    bool TryAddNamePool(string selector, MarkovGenerator generator);
    string GetNameFromPool(string selector);
    void TrainPoolOn(string selector, string input);
}