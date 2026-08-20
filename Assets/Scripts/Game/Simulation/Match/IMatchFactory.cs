using System;
using Game.Simulation.Entities;

namespace Game.Simulation.Match
{
    public interface IMatchFactory
    {
        (ISimulationContext context, IMatchController controller) CreateMatch(SimulationEntity ball, Team[] teams, Random random);
    }

    public class StandardMatchFactory : IMatchFactory
    {
        public (ISimulationContext context, IMatchController controller) CreateMatch(SimulationEntity ball, Team[] teams, Random random)
        {
            var match = new StandardMatch(ball, teams, random);
            return (match, match);
        }
    }
}