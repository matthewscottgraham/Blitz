using System;
using Game.Simulation.Entities;
using Game.Simulation.Formations;

namespace Game.Simulation.Match
{
    public class StandardMatchFactory : IMatchFactory
    {
        public (ISimulationContext context, IMatchController controller) CreateMatch(IFormationFactory formationFactory, SimulationEntity ball, Team[] teams, Random random)
        {
            var match = new StandardMatch(formationFactory, ball, teams, random);
            return (match, match);
        }
    }
}