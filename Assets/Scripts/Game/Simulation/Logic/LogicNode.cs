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

        public bool Evaluate(ISimulationContext simulationContext, StandardPlayer player)
        {
            if (!_condition.IsConditionMet(simulationContext, player)) return false;
            _strategy.Execute(simulationContext, player);
            return true;
        }
    }
}