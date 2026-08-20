using Game.Simulation.Entities;
using Game.Simulation.Match;

namespace Game.Simulation.Conditions
{
    public interface ICondition
    {
        public bool IsConditionMet(ISimulationContext simulationContext, StandardPlayer player);
    }
}
