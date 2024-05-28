using SpaceBaseball.Core.Models;
using SpaceBaseball.Core.NameGeneration;

namespace SpaceBaseball.Core.StatGeneration;

public static class AbilityScoreGenerator 
{
    public static AbilityScores GenerateAbilityScoreBlock()
    {
        AbilityScores abilities = new()
        {
            Strength = GeneratorUtils.DiceRoller(4, 6, 1),
            Dexterity = GeneratorUtils.DiceRoller(4, 6, 1),
            Constitution = GeneratorUtils.DiceRoller(4, 6, 1),
            Intelligence = GeneratorUtils.DiceRoller(4, 6, 1),
            Wisdom = GeneratorUtils.DiceRoller(4, 6, 1),
            Charisma = GeneratorUtils.DiceRoller(4, 6, 1),
        };

        return abilities;
    }
}