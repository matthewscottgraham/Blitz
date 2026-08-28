using System.Numerics;
using Game.Simulation.Entities;
using Game.Simulation.Match;
using Game.Simulation.Utilities;

namespace Game.Simulation.Strategies
{
    public class KickBallTowardsGoal : IStrategy
    {
        public void Execute(ISimulationContext context, ISimulationTeamMember  teamMember)
        {
            var targetGoalPosition = context.GoalPosition((teamMember.Team + 1) % 2);
            var adjustedGoalPosition = targetGoalPosition.ApplyStatNoise(context.Random, teamMember.Stats.Accuracy);
            var direction = adjustedGoalPosition - context.Ball.CurrentPosition;
            context.Ball.ApplyForce(direction, teamMember.Stats.KickPower);
        }
    }
}