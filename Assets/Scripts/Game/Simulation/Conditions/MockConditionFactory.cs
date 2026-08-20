namespace Game.Simulation.Conditions
{
    public class MockConditionFactory : IConditionFactory
    {
        public ICondition CreateCondition<T>() where T : ICondition, new()
        {
            return new T();
        }
    }
}