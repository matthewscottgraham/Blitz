using Game.Simulation.Entities;

namespace Game.Simulation.Conditions
{
    public class AlwaysTrue : ICondition
    {
        public bool IsConditionMet(IMatch match, Player player)
        {
            return true;
        }
    }
}