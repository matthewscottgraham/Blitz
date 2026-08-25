using Game.Simulation.Entities;
using Game.Simulation.Formations;
using Game.Simulation.Match;

namespace Game.Simulation.Strategies
{
    public class StandGround : IStrategy
    {
        public void Execute(ISimulationContext context, StandardTeamMember teamMember)
        {
            var direction = 
                context.FormationFactory.GetFormationPosition(FormationType.Standard, teamMember.Team, teamMember.Role) 
                - teamMember.CurrentPosition;
            teamMember.ApplyForce(direction, teamMember.Stats.Speed * 10f);
        }
    }
}