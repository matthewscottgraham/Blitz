using Game.Simulation.Entities;
using Game.Simulation.Match;

namespace Game.Simulation.Strategies
{
    public class ChaseBall : IStrategy
    {
        public void Execute(ISimulationContext context, StandardTeamMember teamMember)
        {
            var direction = context.Ball.CurrentPosition - teamMember.CurrentPosition;
            teamMember.ApplyForce(direction, teamMember.Stats.Speed * 10f);
        }
    }
}