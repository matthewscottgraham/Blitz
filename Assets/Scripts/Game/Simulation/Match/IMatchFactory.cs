using System;
using Game.Simulation.Entities;
using Game.Simulation.Formations;

namespace Game.Simulation.Match
{
    public interface IMatchFactory
    {
        (ISimulationContext context, IMatchController controller) CreateMatch(IFormationFactory formationFactory, ISimulationEntity ball, Team[] teams, Random random);
    }
}