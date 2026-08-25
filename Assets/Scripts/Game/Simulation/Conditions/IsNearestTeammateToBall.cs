using System.Numerics;
using Game.Simulation.Entities;
using Game.Simulation.Match;

namespace Game.Simulation.Conditions
{
    public class IsNearestTeammateToBall : ICondition
    {
        public bool IsConditionMet(ISimulationContext simulationContext, StandardTeamMember teamMember)
        {
            var teamMates = simulationContext.GetTeam(teamMember.Team);
            var playerDistance = Vector3.Distance(teamMember.CurrentPosition, simulationContext.Ball.CurrentPosition);
            foreach (var teamMate in teamMates.Entities)
            {
                if (Vector3.Distance(teamMate.CurrentPosition, simulationContext.Ball.CurrentPosition) < playerDistance)
                    return false;
            }
            return true;
        }
    }
}