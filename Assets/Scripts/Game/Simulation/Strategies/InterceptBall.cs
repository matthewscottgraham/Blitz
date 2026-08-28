using Game.Simulation.Entities;
using Game.Simulation.Match;

namespace Game.Simulation.Strategies
{
    public class InterceptBall : IStrategy
    {
        public void Execute(ISimulationContext context, ISimulationTeamMember  teamMember)
        {
            var direction = context.Ball.CurrentPosition - context.GoalPosition(teamMember.Team);
            context.Ball.ApplyForce(direction, teamMember.Stats.KickPower);
        }
    }
}