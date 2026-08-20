using Game.Simulation.Entities;

namespace Game.Simulation.Conditions
{
    public interface ICondition
    {
        public bool IsConditionMet(IMatch match, Player player);
    }
}
