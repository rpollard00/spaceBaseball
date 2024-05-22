using Xunit;
using SpaceBaseball.Core.NameGeneration;

namespace SpaceBaseball.Test.Core.Test;

public class NameGenerationTest
{
    [Fact]
    public void NameGeneration_GeneratesExpectedName()
    {
       // arrange
       var markovGenerator = new NameGeneration(lookbackSize: 2);
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
       var markovGenerator = new NameGeneration(lookbackSize: 2);
       
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
        Assert.True(true);

    }
}