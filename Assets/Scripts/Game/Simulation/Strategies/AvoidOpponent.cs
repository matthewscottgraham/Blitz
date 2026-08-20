using Game.Simulation.Entities;
using Shared;

namespace Game.Simulation.Strategies
{
    public class AvoidOpponent : IStrategy
    {
        private const float AvoidRadius = 1f;
        
        public void Execute(IMatch match, Player player)
        {
            player.SetTargetPosition(MathUtility.RandomPointInSphere(player.CurrentPosition, AvoidRadius, match.Random));
        }
    }
}