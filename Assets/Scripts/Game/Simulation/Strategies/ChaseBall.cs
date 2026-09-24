using Game.Simulation.Entities;
using Game.Simulation.Match;

namespace Game.Simulation.Strategies
{
    public class ChaseBall : IStrategy
    {
        private const float ChaseSpeedMultiplier = TuningConfig.PlayerSpeedMultiplier;

        public void Execute(ISimulationContext context, ISimulationTeamMember teamMember)
        {
            var direction = context.Ball.CurrentPosition - teamMember.CurrentPosition;
            teamMember.ApplyForce(direction, teamMember.Stats.Speed * ChaseSpeedMultiplier);
        }
    }
}