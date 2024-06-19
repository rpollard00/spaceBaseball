using Xunit;
using Moq;
using SpaceBaseball.Core.Adapters.PlayerGenerator;
using SpaceBaseball.Core.Ports;
using SpaceBaseball.Core.Dto;
using SpaceBaseball.Core.Services;

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
        var playerService = new PlayerService();

        PlayerDto player = playerGenerator.GeneratePlayer(mockNameGenerator.Object, playerService);
        
        Assert.Equal("Julio", player.FirstName);
        Assert.Equal("Rodriguez", player.LastName);
        Assert.Equal(50, player.Fielding);
        Assert.Equal(50, player.HitChance);
    }
}
