using Game.Simulation.Entities;
using Game.Simulation.Match;
using Game.Simulation.Utilities;

namespace Game.Simulation.Strategies
{
    public class AvoidOpponent : IStrategy
    {
        private const float AvoidRadius = 1f;
        
        public void Execute(ISimulationContext context, StandardPlayer player)
        {
            var direction = 
                MathUtility.RandomPointInSphere(player.CurrentPosition, AvoidRadius, context.Random)
                            - player.CurrentPosition;
            player.ApplyForce(direction, player.Stats.Agility);
        }
    }
}