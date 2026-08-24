using System.Numerics;
using Game.Simulation.Entities;
using Game.Simulation.Match;
using Game.Simulation.Utilities;

namespace Game.Simulation.Strategies
{
    public class KickBallTowardsGoal : IStrategy
    {
        public void Execute(ISimulationContext context, StandardPlayer  player)
        {
            var targetGoalPosition = context.GoalPosition((player.Team + 1) % 2);
            targetGoalPosition.ApplyStatNoise(context.Random, player.Stats.Accuracy);
            var direction = targetGoalPosition - context.Ball.CurrentPosition;
            context.Ball.ApplyForce(direction, player.Stats.KickPower);
        }
    }
}