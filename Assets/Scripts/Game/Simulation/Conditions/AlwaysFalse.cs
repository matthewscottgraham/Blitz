using Game.Simulation.Entities;
using Game.Simulation.Match;

namespace Game.Simulation.Conditions
{
    public class AlwaysFalse : ICondition
    {
        public bool IsConditionMet(ISimulationContext simulationContext, StandardPlayer player)
        {
            return false;
        }
    }
}