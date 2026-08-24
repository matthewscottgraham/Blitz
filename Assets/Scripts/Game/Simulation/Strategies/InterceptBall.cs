using Game.Simulation.Entities;
using Game.Simulation.Match;

namespace Game.Simulation.Strategies
{
    public class InterceptBall : IStrategy
    {
        public void Execute(ISimulationContext context, StandardPlayer  player)
        {
            var direction = context.Ball.CurrentPosition - context.GoalPosition(player.Team);
            context.Ball.ApplyForce(direction, player.Stats.KickPower);
        }
    }
}