using Game.Simulation.Entities;
using Shared;

namespace Game.Simulation.Strategies
{
    public class KickBallTowardsGoal : IStrategy
    {
        public void Execute(IMatch match, Player  player)
        {
            if (!MathUtility.IsWithinRadius(player.CurrentPosition, match.Ball.CurrentPosition, player.Stats.Intercept / 100f))
                return;
            match.Ball.SetTargetPosition(match.GoalPosition(player.Team));
        }
    }
}