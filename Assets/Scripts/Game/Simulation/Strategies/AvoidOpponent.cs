using Game.Simulation.Entities;
using Game.Simulation.Match;
using Game.Simulation.Utilities;

namespace Game.Simulation.Strategies
{
    public class AvoidOpponent : IStrategy
    {
        private const float AvoidRadius = TuningConfig.PlayerAvoidRadius;

        public void Execute(ISimulationContext context, ISimulationTeamMember teamMember)
        {
            var direction = 
                MathUtility.RandomPointInSphere(teamMember.CurrentPosition, AvoidRadius, context.Random)
                            - teamMember.CurrentPosition;
            teamMember.ApplyForce(direction, teamMember.Stats.Agility);
        }
    }
}