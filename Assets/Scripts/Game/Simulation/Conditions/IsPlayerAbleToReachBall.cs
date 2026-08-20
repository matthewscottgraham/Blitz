using Game.Simulation.Entities;
using Game.Simulation.Match;
using Game.Simulation.Utilities;

namespace Game.Simulation.Conditions
{
    public class IsPlayerAbleToReachBall : ICondition
    {
        private const float Radius = 1f;
        public bool IsConditionMet(ISimulationContext simulationContext, StandardPlayer player)
        {
            return MathUtility.IsWithinRadius(player.CurrentPosition, simulationContext.Ball.CurrentPosition,
                Radius);
        }
    }
}