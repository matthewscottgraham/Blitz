using System.Numerics;
using Game.Simulation.Entities;
using Game.Simulation.Match;

namespace Game.Simulation.Strategies
{
    public class Dribble : IStrategy
    {
        public void Execute(ISimulationContext context, StandardPlayer player)
        {
            var goalPosition = context.GoalPosition(player.Team);
            var goalDirection = Vector3.Normalize(goalPosition - player.CurrentPosition);
            var idealBallPosition = player.CurrentPosition + goalDirection * 0.5f;
            var ballCorrection =  idealBallPosition - context.Ball.CurrentPosition;
            context.Ball.ApplyForce(ballCorrection, player.Stats.KickPower * 0.4f);
            player.ApplyForce(goalDirection, player.Stats.Speed * 10f);
        }
    }
}