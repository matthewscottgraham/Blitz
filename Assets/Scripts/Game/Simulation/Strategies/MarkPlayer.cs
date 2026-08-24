using Game.Simulation.Entities;
using Game.Simulation.Match;

namespace Game.Simulation.Strategies
{
    public class MarkPlayer : IStrategy
    {
        public void Execute(ISimulationContext context, StandardPlayer player)
        {
            var markedPlayer = context.GetPlayerByRole(player.OtherTeam, player.MarkedPlayerRole);
            if (markedPlayer == null) return;
            
            var direction = markedPlayer.CurrentPosition - player.CurrentPosition;
            player.ApplyForce(direction, player.Stats.Speed * 10f);
        }
    }
}