using System.Numerics;
using Game.Simulation.Entities;
using Game.Simulation.Match;
using Game.Simulation.Utilities;

namespace Game.Simulation.Strategies
{
    public class PassBall : IStrategy
    {
        public void Execute(ISimulationContext context, StandardPlayer  player)
        {
            var teamMates = context.GetTeam(player.Team);
            SimulationEntity closestPlayer = null;
            var closestDistance = float.MaxValue;
            foreach (var teamMate in teamMates.Players)
            {
                if (teamMate == player) continue;
                var distance = Vector3.Distance(teamMate.CurrentPosition, context.GoalPosition((player.Team + 1) % 2));
                if (!(distance < closestDistance)) continue;
                closestPlayer = teamMate;
                closestDistance = distance;
            }

            if (closestPlayer == null) return;
            var direction = closestPlayer.CurrentPosition - player.CurrentPosition;
            direction.ApplyStatNoise(context.Random, player.Stats.Accuracy);
            context.Ball.ApplyForce(direction, player.Stats.KickPower);
        }
    }
}