using Game.Simulation.Entities;
using Game.Simulation.Match;
using Shared;

namespace Game.Simulation.Conditions
{
    public class IsOpponentCloseToPlayer : ICondition
    {
        private const float Radius = 0.5f;
        public bool IsConditionMet(ISimulationContext simulationContext, Player player)
        {
            var otherTeam = simulationContext.GetTeam((player.Team + 1) % 2);
            foreach (var opponent in otherTeam.Players)
            {
                if (MathUtility.IsWithinRadius(player.CurrentPosition, opponent.CurrentPosition, Radius))
                    return true;
            }
            return false;
        }
    }
}