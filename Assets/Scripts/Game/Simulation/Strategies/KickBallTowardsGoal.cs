using System.Numerics;
using Game.Simulation.Entities;
using Game.Simulation.Match;

namespace Game.Simulation.Strategies
{
    public class KickBallTowardsGoal : IStrategy
    {
        public void Execute(ISimulationContext context, StandardPlayer  player)
        {
            var targetGoalPosition = context.GoalPosition((player.Team + 1) % 2);
            var noise = new Vector3(
                (float)(context.Random.NextDouble() - 0.5f) * 2,
                (float)(context.Random.NextDouble() - 0.5f) * 2,
                (float)(context.Random.NextDouble() - 0.5f) * 2
                ) * (1f - player.Stats.Accuracy / 100f);
            var direction = (targetGoalPosition + noise) - context.Ball.CurrentPosition;
            context.Ball.ApplyForce(direction, player.Stats.KickPower);
        }
    }
}