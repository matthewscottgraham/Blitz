using Game.Simulation.Entities;
using Shared;

namespace Game.Simulation.Conditions
{
    public class IsPlayerAbleToReachBall : ICondition
    {
        private const float Radius = 3f;
        public bool IsConditionMet(IMatch match, Player player)
        {
            return MathUtility.IsWithinRadius(player.CurrentPosition, match.Ball.CurrentPosition,
                Radius);
        }
    }
}