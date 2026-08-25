using Game.Simulation.Entities;
using Game.Simulation.Match;

namespace Game.Simulation.Strategies
{
    public class MarkPlayer : IStrategy
    {
        public void Execute(ISimulationContext context, StandardTeamMember teamMember)
        {
            var markedPlayer = context.GetPlayerByRole(teamMember.OpposingTeam, teamMember.MarkedPlayerRole);
            if (markedPlayer == null) return;

            var markedEntity = (ISimulationEntity)markedPlayer;
            var direction = markedEntity.CurrentPosition - teamMember.CurrentPosition;
            teamMember.ApplyForce(direction, teamMember.Stats.Speed * 10f);
        }
    }
}