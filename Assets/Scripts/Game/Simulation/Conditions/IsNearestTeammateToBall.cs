using System.Numerics;
using Game.Simulation.Entities;
using Game.Simulation.Match;

namespace Game.Simulation.Conditions
{
    public class IsNearestTeammateToBall : ICondition
    {
        public bool IsConditionMet(ISimulationContext simulationContext, StandardPlayer player)
        {
            var teamMates = simulationContext.GetTeam(player.Team);
            var playerDistance = Vector3.Distance(player.CurrentPosition, simulationContext.Ball.CurrentPosition);
            foreach (var teamMate in teamMates.Players)
            {
                if (Vector3.Distance(teamMate.CurrentPosition, simulationContext.Ball.CurrentPosition) < playerDistance)
                    return false;
            }
            return true;
        }
    }
    
    public class CanPlayerKickGoal : ICondition
    {
        public bool IsConditionMet(ISimulationContext simulationContext, StandardPlayer player)
        {
            return false;
        }
    }
}