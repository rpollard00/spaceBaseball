using Xunit;
using SpaceBaseball.Core.Services.Generators.NameGeneration;

namespace SpaceBaseball.Test.Core.Test;

public class MarkovGeneratorTest
{
    [Fact]
    public void NameGeneration_GeneratesExpectedName()
    {
       // arrange
       var markovGenerator = new MarkovGenerator(lookbackSize: 2);
       var nextLetterQueue = new Queue<char>(new[] { 'B', 'r', 'o', 's', 'e', 's', '*' });
       
       // act
       markovGenerator.Train("Broses");
       
       var name = markovGenerator.Generate((_, _) => nextLetterQueue.Dequeue());
       // assert
       Assert.Equal("Broses", name);
    }
    
    [Fact]
    public void NameGeneration_UntrainedGeneratorThrowsInvalidOperationException()
    {
       // arrange
       var markovGenerator = new MarkovGenerator(lookbackSize: 2);
       
       // act
       var nextLetterQueue = new Queue<char>(new[] { 'B', 'r', 'o', 's', 'e', 's', '*' });
       
       // assert
       var exception = Assert.Throws<InvalidOperationException>(() => markovGenerator.Generate((_, _) => nextLetterQueue.Dequeue()));
       Assert.Equal("Name Generator has not been trained with any data. Please train the generator before invoking Generate.", exception.Message);
    }

    [Fact]
    public void NameGenerator_TryGetPoolReturnsPoolWhenValid()
    {
        // arrange
        var nameGenerator = new NameGenerator();
        nameGenerator.BuildNamePool("dummyPool", ["Dan", "Sandy", "Peanut"]);
        
        // act
        var dummyPool = nameGenerator.TryGetPool("dummyPool");
        
        // assert
        Assert.NotNull(dummyPool);
    }

    [Fact]
    public void NameGeneratorTryGetPoolThrowsWhenInvalid()
    {
        // arrange
        var nameGenerator = new NameGenerator();

        // act
        var exception = Assert.Throws<ArgumentException>(() => nameGenerator.TryGetPool("notAPool"));
        
        // assert
        Assert.Equal("No name pool found for selector: 'notAPool' (Parameter 'selector')", exception.Message); 
    }
}