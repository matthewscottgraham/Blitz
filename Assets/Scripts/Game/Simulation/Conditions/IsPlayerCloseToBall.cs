using Game.Simulation.Entities;
using Shared;

namespace Game.Simulation.Conditions
{
    public class IsPlayerCloseToBall : ICondition
    {
        public bool IsConditionMet(IMatch match, Player player)
        {
            return MathUtility.IsWithinRadius(player.CurrentPosition, match.Ball.CurrentPosition,
                player.Stats.Intercept / 100f);
        }
    }
}