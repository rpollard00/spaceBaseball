using System.Runtime.InteropServices;
using SpaceBaseball.Core.Dto;
using SpaceBaseball.Core.Models;

namespace SpaceBaseball.Core.Services;

public class PlayerService
{
    // 1 -5
    // 2-3 -4
    // 4-5 -3
    // 6-7 -2
    // 8-9 -1
    //10-11 +0
    //12-13 +1
    //14-15 +2
    //16-17 +3
    //18-19 +4
    //20-21 +5
    //22-23 +6
    //24-25 +7
    //26-27 +8
    //28-29 +9
    //30 +10
    // calculate hit (attack modifier) 
    public int GetAbilityScoreModifier(int score)
    {
        // formula is int division (score - 10) / 2
        return (score - 10) / 2;
    }
    public int CalculateHitModifier(Player player)
    {
        return 0;
    }

    // Strength = GeneratorUtils.DiceRoller(4, 6, 1),
    // Dexterity = GeneratorUtils.DiceRoller(4, 6, 1),
    // Constitution = GeneratorUtils.DiceRoller(4, 6, 1),
    // Intelligence = GeneratorUtils.DiceRoller(4, 6, 1),
    // Wisdom = GeneratorUtils.DiceRoller(4, 6, 1),

    // Charisma = GeneratorUtils.DiceRoller(4, 6, 1),

    // Ok so, classes that are baseball positions
    // Str favored - 1B, RF, LF
    // Cha favored - Catcher
    // Dex based - SS, 2B, CF
    // Str/Dex - 3B
    // Int/Con based - Starting Pitcher
    // Reliever
    /* Primary weight 2, secondary weight 1.5, tertiary weight 0.5? can play with the math
           1S  2S  3S
     * C  CHA CON INT
     * 1B STR DEX CON
     * 2B DEX INT WIS
     * 3B DEX STR CON
     * SS DEX INT WIS
     * LF DEX STR CHA
     * CF DEX WIS CON
     * RF STR DEX CHA
     * DH STR CHA WIS
     * SP CON INT DEX
     * MR DEX CON WIS
     * HL DEX WIS CHA 
     */

    public Dictionary<string, PlayerClass> PlayerPositions = new()
    {
        {"C", new PlayerClass("CHA", "CON", "INT")},
        {"1B", new PlayerClass("STR", "DEX", "CON")},
        {"2B", new PlayerClass("DEX", "INT", "STR")},
        {"3B", new PlayerClass("DEX", "STR", "CON")},
        {"SS", new PlayerClass("DEX", "INT", "WIS")},
        {"LF", new PlayerClass("DEX", "STR", "CHA")},
        {"CF", new PlayerClass("DEX", "WIS", "CON")},
        {"RF", new PlayerClass("STR", "DEX", "CHA")},
        {"DH", new PlayerClass("STR", "CHA", "WIS")},
        {"SP", new PlayerClass("CON", "INT", "DEX")},
        {"RL", new PlayerClass("DEX", "CON", "WIS")},
    };

    public int GetPositionScore(PlayerDto player, string inputPosition)
    {
        var validPosition = PlayerPositions.TryGetValue(inputPosition, out var position);
        if (!validPosition)
        {
            throw new KeyNotFoundException($"Invalid inputPosition {inputPosition} value.");
        }

        var primaryScore = position!.PrimaryWeight * AbilityScoreService.GetAbilityScoreByShortStr(position!.PrimaryAbility, player.AbilityScores);
        var secondaryScore = position!.SecondaryWeight * AbilityScoreService.GetAbilityScoreByShortStr(position!.SecondaryAbility, player.AbilityScores);
        var tertiaryScore = position!.TertiaryWeight = AbilityScoreService.GetAbilityScoreByShortStr(position!.TertiaryAbility, player.AbilityScores);

        return primaryScore + secondaryScore + tertiaryScore;
    }

    private PriorityQueue<string, int> GetPositionScores(PlayerDto player)
    {
        PriorityQueue<string, int> positionScores = new();
        foreach (var (k, _) in PlayerPositions)
        {
            var posScore = GetPositionScore(player, k);
            positionScores.Enqueue(k, -posScore);
            Console.WriteLine($"{player.FirstName} {player.LastName}: Position {k} Score: {posScore}.");
        }

        return positionScores;
    }

    public List<PositionsEntry> GetPreferredPositionList(PlayerDto player)
    {
        PriorityQueue<string, int> positionScores = GetPositionScores(player);
        List<PositionsEntry> positions = new();
        while (positionScores.Count > 0)
        {
            positionScores.TryDequeue(out string? pos, out int rating);
            positions.Add(new PositionsEntry()
            {
                Position = pos!,
                Rating = -rating,
            });
        }

        return positions;
    }
    // ok so I think i want to use a DC system, and then roll a D20 against the DC
    // apply modifier from stats
    // calculate hit power 
    // calculate pitch stuff
    // calculate defensive ability
}

public class PlayerClass(string primaryAbility, string secondaryAbility, string tertiaryAbility)
{
    public string PrimaryAbility { get; set; } = primaryAbility;
    public string SecondaryAbility { get; set; } = secondaryAbility;
    public string TertiaryAbility { get; set; } = tertiaryAbility;

    public int PrimaryWeight { get; set; } = 3;
    public int SecondaryWeight { get; set; } = 2;
    public int TertiaryWeight { get; set; } = 1;
}

public static class AbilityScoreService
{
    public static int GetAbilityScoreByShortStr(string shortStr, AbilityScores abilityScores)
    {
        switch (shortStr)
        {
            case "STR":
                return abilityScores.Strength;
            case "DEX":
                return abilityScores.Dexterity;
            case "CON":
                return abilityScores.Constitution;
            case "INT":
                return abilityScores.Intelligence;
            case "WIS":
                return abilityScores.Wisdom;
            case "CHA":
                return abilityScores.Charisma;
            default:
                throw new ArgumentException($"Invalid shortStr: {shortStr} provided");
        }
    }
}
