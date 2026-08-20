using Game.Simulation.Entities;
using Game.Simulation.Match;
using Game.Simulation.Utilities;

namespace Game.Simulation.Strategies
{
    public class KickBallTowardsGoal : IStrategy
    {
        public void Execute(ISimulationContext context, StandardPlayer  player)
        {
            var direction = context.GoalPosition(player.Team) - context.Ball.CurrentPosition;
            context.Ball.ApplyForce(direction, player.Stats.KickPower);
        }
    }
}