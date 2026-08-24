using Game.Simulation.Entities;
using Game.Simulation.Formations;
using Game.Simulation.Match;

namespace Game.Simulation.Strategies
{
    public class StandGround : IStrategy
    {
        public void Execute(ISimulationContext context, StandardPlayer player)
        {
            var direction = 
                context.FormationFactory.GetFormationPosition(FormationType.Standard, player.Team, player.Role) 
                - player.CurrentPosition;
            player.ApplyForce(direction, player.Stats.Speed * 10f);
        }
    }
}