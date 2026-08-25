using Game.Simulation.Entities;
using Game.Simulation.Match;
using Game.Simulation.Utilities;

namespace Game.Simulation.Conditions
{
    public class IsOpponentCloseToPlayer : ICondition
    {
        private const float Radius = 0.5f;
        public bool IsConditionMet(ISimulationContext simulationContext, StandardTeamMember teamMember)
        {
            var otherTeam = simulationContext.GetTeam((teamMember.Team + 1) % 2);
            foreach (var opponent in otherTeam.Entities)
            {
                if (MathUtility.IsWithinRadius(teamMember.CurrentPosition, opponent.CurrentPosition, Radius))
                    return true;
            }
            return false;
        }
    }
}