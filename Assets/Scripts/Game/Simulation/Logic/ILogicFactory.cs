using Game.Simulation.Conditions;
using Game.Simulation.Strategies;

namespace Game.Simulation.Logic
{
    public interface ILogicFactory
    {
        LogicNode CreateLogicNode(ICondition  condition, IStrategy strategy);
        LogicNode[] CreateLogicNodes(PlayerRole playerRole);
    }
}