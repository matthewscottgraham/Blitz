using System.Numerics;
using Game.Simulation.Entities;
using Game.Simulation.Match;

namespace Game.Simulation.Strategies
{
    public class Dribble : IStrategy
    {
        private const float PlayerSpeedMultiplier = TuningConfig.PlayerSpeedMultiplier;
        private const float PlayerKickMultiplier = TuningConfig.PlayerKickMultiplier;
        
        public void Execute(ISimulationContext context, ISimulationTeamMember teamMember)
        {
            var goalPosition = context.GoalPosition(teamMember.OpposingTeam);
            var goalDirection = Vector3.Normalize(goalPosition - teamMember.CurrentPosition);
            var idealBallPosition = teamMember.CurrentPosition + goalDirection * 0.5f;
            var ballCorrection =  idealBallPosition - context.Ball.CurrentPosition;
            context.Ball.ApplyForce(ballCorrection, teamMember.Stats.KickPower * PlayerKickMultiplier);
            teamMember.ApplyForce(goalDirection, teamMember.Stats.Speed * PlayerSpeedMultiplier);
        }
    }
}