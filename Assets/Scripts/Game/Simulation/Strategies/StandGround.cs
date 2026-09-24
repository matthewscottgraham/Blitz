using Game.Simulation.Entities;
using Game.Simulation.Formations;
using Game.Simulation.Match;

namespace Game.Simulation.Strategies
{
    public class StandGround : IStrategy
    {
        private const float PlayerSpeedMultiplier = TuningConfig.PlayerSpeedMultiplier;
        
        public void Execute(ISimulationContext context, ISimulationTeamMember teamMember)
        {
            var direction = 
                context.FormationFactory.GetFormationPosition(FormationType.Standard, teamMember.Team, teamMember.Role) 
                - teamMember.CurrentPosition;
            teamMember.ApplyForce(direction, teamMember.Stats.Speed * PlayerSpeedMultiplier);
        }
    }
}