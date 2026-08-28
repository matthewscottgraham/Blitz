using Game.Simulation.Entities;
using Game.Simulation.Match;
using Game.Simulation.Utilities;

namespace Game.Simulation.Conditions
{
    public class IsPlayerCloseToBall : ICondition
    {
        public bool IsConditionMet(ISimulationContext context, ISimulationTeamMember teamMember)
        {
            return MathUtility.IsWithinRadius(teamMember.CurrentPosition, context.Ball.CurrentPosition,
                teamMember.Stats.Intercept / 10f);
        }
    }
}