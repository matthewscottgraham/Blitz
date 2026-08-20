using Game.Simulation.Entities;
using Shared;

namespace Game.Simulation.Conditions
{
    public class IsOpponentCloseToPlayer : ICondition
    {
        private const float Radius = 0.5f;
        public bool IsConditionMet(IMatch match, Player player)
        {
            var otherTeam = match.GetTeam((player.Team + 1) % 2);
            foreach (var opponent in otherTeam.Players)
            {
                if (MathUtility.IsWithinRadius(player.CurrentPosition, opponent.CurrentPosition, Radius))
                    return true;
            }
            return false;
        }
    }
}