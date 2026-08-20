using Game.Simulation.Entities;
using Game.Simulation.Match;
using Game.Simulation.Utilities;

namespace Game.Simulation.Strategies
{
    public class KickBallTowardsGoal : IStrategy
    {
        public void Execute(ISimulationContext simulationContext, Player  player)
        {
            if (!MathUtility.IsWithinRadius(player.CurrentPosition, simulationContext.Ball.CurrentPosition, player.Stats.Intercept / 100f))
                return;
            simulationContext.Ball.SetTargetPosition(simulationContext.GoalPosition(1 - player.Team));
        }
    }
}