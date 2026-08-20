using Game.Simulation.Entities;
using Game.Simulation.Match;
using Game.Simulation.Utilities;

namespace Game.Simulation.Conditions
{
    public class IsPlayerCloseToBall : ICondition
    {
        public bool IsConditionMet(ISimulationContext simulationContext, StandardPlayer player)
        {
            return MathUtility.IsWithinRadius(player.CurrentPosition, simulationContext.Ball.CurrentPosition,
                player.Stats.Intercept / 100f);
        }
    }
}