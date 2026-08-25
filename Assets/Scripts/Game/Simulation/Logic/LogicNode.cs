using Game.Simulation.Conditions;
using Game.Simulation.Entities;
using Game.Simulation.Match;
using Game.Simulation.Strategies;

namespace Game.Simulation.Logic
{
    public class LogicNode
    {
        private readonly ICondition _condition;
        private readonly IStrategy _strategy;

        public LogicNode(ICondition condition, IStrategy strategy)
        {
            _condition = condition;
            _strategy = strategy;
        }

        public bool Evaluate(ISimulationContext simulationContext, StandardTeamMember teamMember)
        {
            if (!_condition.IsConditionMet(simulationContext, teamMember)) return false;
            _strategy.Execute(simulationContext, teamMember);
            return true;
        }
    }
}