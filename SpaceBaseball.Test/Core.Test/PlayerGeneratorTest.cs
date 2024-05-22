using Xunit;
using Moq;
using SpaceBaseball.Core.Ports;
using SpaceBaseball.Core.PlayerGenerator;
using SpaceBaseball.Core.Dto;

namespace SpaceBaseball.Test.Core.Test;

public class PlayerGeneratorTest 
{
    [Fact]
    public void GeneratePlayer_ReturnsCorrectlyInstantiatedPlayer()
    {
        var mockNameGenerator = new Mock<INameGenerator>();
        mockNameGenerator.Setup(ng => ng.GetNameFromPool("firstName")).Returns("Julio");
        mockNameGenerator.Setup(ng => ng.GetNameFromPool("lastName")).Returns("Rodriguez");

        var playerGenerator = new PlayerGenerator();

        PlayerDto player = playerGenerator.GeneratePlayer(mockNameGenerator.Object);
        
        Assert.Equal("Julio", player.FirstName);
        Assert.Equal("Rodriguez", player.LastName);
        Assert.Equal(50, player.Fielding);
        Assert.Equal(50, player.HitChance);
    }
}
