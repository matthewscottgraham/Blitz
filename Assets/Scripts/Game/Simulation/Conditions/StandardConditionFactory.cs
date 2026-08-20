namespace Game.Simulation.Conditions
{
    public class StandardConditionFactory : IConditionFactory
    {
        public ICondition CreateCondition<T>() where T : ICondition, new()
        {
            return new T();
        }
    }
}