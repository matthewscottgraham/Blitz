using Game.Simulation.Entities;
using Game.Simulation.Match;
using Game.Simulation.Utilities;

namespace Game.Simulation.Conditions
{
    public class IsOpponentCloseToPlayer : ICondition
    {
        private const float Radius = 0.5f;
        public bool IsConditionMet(ISimulationContext context, ISimulationTeamMember teamMember)
        {
            var otherTeam = context.GetTeam(teamMember.OpposingTeam);
            foreach (var opponent in otherTeam.TeamMembers)
            {
                if (MathUtility.IsWithinRadius(teamMember.CurrentPosition, opponent.CurrentPosition, Radius))
                    return true;
            }
            return false;
        }
    }
}