using Game.Simulation.Entities;
using Game.Simulation.Match;
using Game.Simulation.Utilities;

namespace Game.Simulation.Conditions
{
    public class IsPlayerCloseToBall : ICondition
    {
        public bool IsConditionMet(ISimulationContext simulationContext, StandardTeamMember teamMember)
        {
            return MathUtility.IsWithinRadius(teamMember.CurrentPosition, simulationContext.Ball.CurrentPosition,
                teamMember.Stats.Intercept / 10f);
        }
    }
}