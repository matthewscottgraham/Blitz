using System.Numerics;
using Game.Simulation.Entities;
using Game.Simulation.Match;

namespace Game.Simulation.Conditions
{
    public class IsNearestTeammateToBall : ICondition
    {
        public bool IsConditionMet(ISimulationContext context, ISimulationTeamMember teamMember)
        {
            var teamMates = context.GetTeam(teamMember.Team);
            var playerDistance = Vector3.Distance(teamMember.CurrentPosition, context.Ball.CurrentPosition);
            foreach (var teamMate in teamMates.TeamMembers)
            {
                if (Vector3.Distance(teamMate.CurrentPosition, context.Ball.CurrentPosition) < playerDistance)
                    return false;
            }
            return true;
        }
    }
}