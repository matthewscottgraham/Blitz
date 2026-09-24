using Game.Simulation.Entities;
using Game.Simulation.Match;
using Game.Simulation.Utilities;

namespace Game.Simulation.Conditions
{
    public class IsPlayerCloseToBall : ICondition
    {
        private const float PlayerInterceptMultiplier = TuningConfig.PlayerInterceptMultiplier;
        
        public bool IsConditionMet(ISimulationContext context, ISimulationTeamMember teamMember)
        {
            return MathUtility.IsWithinRadius(teamMember.CurrentPosition, context.Ball.CurrentPosition,
                teamMember.Stats.Intercept * PlayerInterceptMultiplier);
        }
    }
}