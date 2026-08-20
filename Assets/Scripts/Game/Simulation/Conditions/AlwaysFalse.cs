using Game.Simulation.Entities;

namespace Game.Simulation.Conditions
{
    public class AlwaysFalse : ICondition
    {
        public bool IsConditionMet(IMatch match, Player player)
        {
            return false;
        }
    }
}