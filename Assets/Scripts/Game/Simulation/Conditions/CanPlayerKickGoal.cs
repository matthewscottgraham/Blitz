using System.Numerics;
using Game.Simulation.Entities;
using Game.Simulation.Match;

namespace Game.Simulation.Conditions
{
    public class CanPlayerKickGoal : ICondition
    {
        public bool IsConditionMet(ISimulationContext context, StandardTeamMember teamMember)
        {
            return Vector3.Distance(teamMember.CurrentPosition, context.GoalPosition(teamMember.Team)) <= teamMember.Stats.Range;
        }
    }
}