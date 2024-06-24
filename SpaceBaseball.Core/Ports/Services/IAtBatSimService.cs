using SpaceBaseball.Core.Dto;
using SpaceBaseball.Core.Services.Simulation;

namespace SpaceBaseball.Core.Ports.Services;

public interface IAtBatSimService
{
    Task<AtBatResult> InvokeAtBat(long pitcherId, long batterId);
    PlateAppearanceTransition SimAtBat(PlayerDto pitcher, PlayerDto batter);
}