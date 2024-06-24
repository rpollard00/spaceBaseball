using System.Runtime.InteropServices.JavaScript;
using SpaceBaseball.Core.Dto;
using SpaceBaseball.Core.Ports;
using SpaceBaseball.Core.Ports.DataPersistence;
using SpaceBaseball.Core.Ports.Services;
using SpaceBaseball.Core.Services.DataPersistence;
using SpaceBaseball.Core.Utils;


namespace SpaceBaseball.Core.Services.Simulation;

public sealed class AtBatSimService(PlayerService playerService, IPlayerQueryService playerQueryService) : IAtBatSimService
{
    const int HitDc = 15;

    public async Task<AtBatResult> InvokeAtBat(long pitcherId, long batterId)
    {
        try
        {
            var pitcher = await playerQueryService.GetPlayerById(pitcherId);
            var batter = await playerQueryService.GetPlayerById(batterId);
            var simResult = SimAtBat(pitcher, batter);

            Console.WriteLine($"Result of AB: {simResult.ToString()}"); 
            return new AtBatResult()
            {
                PitcherId = pitcherId,
                PitcherName = playerService.Name(pitcher),
                BatterId = batterId,
                BatterName = playerService.Name(batter),
                PlateAppearanceResult = simResult.ToString(),
                
            };
        }
        catch (ArgumentException)
        {
            throw;
        }
        catch (Exception ex)
        {
            throw new Exception("Batter and pitcher could not be fetched", ex);
        }

    }
    public PlateAppearanceTransition SimAtBat(PlayerDto pitcher, PlayerDto batter)
    {
        // simple for now just to have something

        var pitcherDexModifier = playerService.GetAbilityScoreModifier(pitcher.AbilityScores.Dexterity);
        var pitcherIntModifier = playerService.GetAbilityScoreModifier(pitcher.AbilityScores.Intelligence);
        var pitcherToHit = HitDc + Math.Max(pitcherDexModifier, pitcherIntModifier);

        var batterRoll = GeneratorUtils.DiceRoller(1, 20);
        var batterStrModifier = playerService.GetAbilityScoreModifier(batter.AbilityScores.Strength);
        var batterDexModifier = playerService.GetAbilityScoreModifier(batter.AbilityScores.Dexterity);
        
        var batterHit = batterRoll + Math.Max(batterStrModifier, batterDexModifier);

        if (batterRoll == 20)
        {
            Console.WriteLine($"CRITICAL HIT: Batter {playerService.Name(batter)} rolled a natural {batterRoll}");
            return PlateAppearanceTransition.BattedBallInPlayHit;
        } 
        if (batterHit > pitcherToHit)
        {
            Console.WriteLine($"Batter {playerService.Name(batter)} scored a hit off of {playerService.Name(pitcher)}. BatterHit <{batterHit}> beats PitcherToHit <{pitcherToHit}>");
            return PlateAppearanceTransition.BattedBallInPlayHit;
        }
        if (batterHit < pitcherToHit / 2)
        {
            return PlateAppearanceTransition.StrikeOut;
        }
        if (batterHit < pitcherToHit)
        {
            return PlateAppearanceTransition.BattedBallInPlayOut;
        }

        return PlateAppearanceTransition.Walk;

    }
}

public sealed class AtBatResult
{
    public long PitcherId { get; set; }
    public string PitcherName { get; set; } = String.Empty;
    public long BatterId { get; set; }
    public string BatterName { get; set; } = String.Empty;
    public string PlateAppearanceResult { get; set; } = String.Empty;
}
public enum PlateAppearanceTransition
{
    BattedBallInPlayOut,
    BattedBallInPlayHit,
    StrikeOut,
    Walk,
}

