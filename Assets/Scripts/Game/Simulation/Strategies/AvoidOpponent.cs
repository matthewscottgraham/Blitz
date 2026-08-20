using Game.Simulation.Entities;
using Game.Simulation.Match;
using Game.Simulation.Utilities;

namespace Game.Simulation.Strategies
{
    public class AvoidOpponent : IStrategy
    {
        private const float AvoidRadius = 1f;
        
        public void Execute(ISimulationContext simulationContext, Player player)
        {
            player.SetTargetPosition(MathUtility.RandomPointInSphere(player.CurrentPosition, AvoidRadius, simulationContext.Random));
        }
    }
}