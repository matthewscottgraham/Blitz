using Game.Simulation.Entities;
using Game.Simulation.Match;
using Game.Simulation.Utilities;

namespace Game.Simulation.Conditions
{
    public class IsPlayerAbleToReachBall : ICondition
    {
        private const float PlayerInterceptRadius = TuningConfig.PlayerInterceptRadius;
        
        public bool IsConditionMet(ISimulationContext context, ISimulationTeamMember teamMember)
        {
            return MathUtility.IsWithinRadius(teamMember.CurrentPosition, context.Ball.CurrentPosition,
                PlayerInterceptRadius);
        }
    }
}