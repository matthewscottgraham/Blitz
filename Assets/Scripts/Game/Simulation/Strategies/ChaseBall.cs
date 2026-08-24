using Game.Simulation.Entities;
using Game.Simulation.Match;

namespace Game.Simulation.Strategies
{
    public class ChaseBall : IStrategy
    {
        public void Execute(ISimulationContext context, StandardPlayer player)
        {
            var direction = context.Ball.CurrentPosition - player.CurrentPosition;
            player.ApplyForce(direction, player.Stats.Speed * 10f);
        }
    }
}