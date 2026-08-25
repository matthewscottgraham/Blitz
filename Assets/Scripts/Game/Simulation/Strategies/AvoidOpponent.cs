using Game.Simulation.Entities;
using Game.Simulation.Match;
using Game.Simulation.Utilities;

namespace Game.Simulation.Strategies
{
    public class AvoidOpponent : IStrategy
    {
        private const float AvoidRadius = 1f;
        
        public void Execute(ISimulationContext context, StandardTeamMember teamMember)
        {
            var direction = 
                MathUtility.RandomPointInSphere(teamMember.CurrentPosition, AvoidRadius, context.Random)
                            - teamMember.CurrentPosition;
            teamMember.ApplyForce(direction, teamMember.Stats.Agility);
        }
    }
}