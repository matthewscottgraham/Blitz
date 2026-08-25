using Game.Simulation.Entities;
using Game.Simulation.Match;

namespace Game.Simulation.Conditions
{
    public class AlwaysFalse : ICondition
    {
        public bool IsConditionMet(ISimulationContext simulationContext, StandardTeamMember teamMember)
        {
            return false;
        }
    }
}