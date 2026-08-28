using Game.Simulation.Entities;
using Game.Simulation.Match;

namespace Game.Simulation.Strategies
{
    public interface IStrategy
    {
        public void Execute(ISimulationContext context, ISimulationTeamMember  teamMember);
    }
}