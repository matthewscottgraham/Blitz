using Game.Simulation.Entities;
using Game.Simulation.Match;
using Shared;

namespace Game.Simulation.Conditions
{
    public class IsPlayerAbleToReachBall : ICondition
    {
        private const float Radius = 3f;
        public bool IsConditionMet(ISimulationContext simulationContext, Player player)
        {
            return MathUtility.IsWithinRadius(player.CurrentPosition, simulationContext.Ball.CurrentPosition,
                Radius);
        }
    }
}