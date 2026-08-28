using Game.Simulation.Entities;
using Game.Simulation.Match;

namespace Game.Simulation.Strategies
{
    public class MarkPlayer : IStrategy
    {
        public void Execute(ISimulationContext context, ISimulationTeamMember teamMember)
        {
            var markedPlayer = context.GetPlayerByRole(teamMember.OpposingTeam, teamMember.MarkedPlayerRole);
            if (markedPlayer == null) return;
            
            var direction = markedPlayer.CurrentPosition - teamMember.CurrentPosition;
            teamMember.ApplyForce(direction, teamMember.Stats.Speed * 10f);
        }
    }
}