using SpaceBaseball.Core.NameGeneration;

namespace SpaceBaseball.Core.Ports;

public interface INameGenerator
{
    public void BuildNamePool(string selector, List<string> trainingSet, int lookbackSize = 2);
    bool TryAddNamePool(string selector, MarkovGenerator generator);
    string GetNameFromPool(string selector);
    void TrainPoolOn(string selector, string input);
    public MarkovGenerator TryGetPool(string selector);
}