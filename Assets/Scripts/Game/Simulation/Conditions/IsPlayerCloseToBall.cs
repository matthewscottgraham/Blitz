using Game.Simulation.Entities;
using Game.Simulation.Match;
using Shared;

namespace Game.Simulation.Conditions
{
    public class IsPlayerCloseToBall : ICondition
    {
        public bool IsConditionMet(ISimulationContext simulationContext, Player player)
        {
            return MathUtility.IsWithinRadius(player.CurrentPosition, simulationContext.Ball.CurrentPosition,
                player.Stats.Intercept / 100f);
        }
    }
}