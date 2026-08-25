using System.Numerics;
using Game.Simulation.Entities;
using Game.Simulation.Match;
using Game.Simulation.Utilities;

namespace Game.Simulation.Strategies
{
    public class PassBall : IStrategy
    {
        public void Execute(ISimulationContext context, StandardTeamMember  teamMember)
        {
            var teamMates = context.GetTeam(teamMember.Team);
            ISimulationEntity closestPlayer = null;
            var closestDistance = float.MaxValue;
            foreach (var teamMate in teamMates.Entities)
            {
                if (teamMate == teamMember) continue;
                var distance = Vector3.Distance(teamMate.CurrentPosition, context.GoalPosition((teamMember.Team + 1) % 2));
                if (!(distance < closestDistance)) continue;
                closestPlayer = teamMate;
                closestDistance = distance;
            }

            if (closestPlayer == null) return;
            var direction = closestPlayer.CurrentPosition - teamMember.CurrentPosition;
            var adjustedDirection = direction.ApplyStatNoise(context.Random, teamMember.Stats.Accuracy);
            context.Ball.ApplyForce(adjustedDirection, teamMember.Stats.KickPower);
        }
    }
}