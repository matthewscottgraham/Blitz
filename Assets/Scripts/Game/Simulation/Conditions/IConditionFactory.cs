namespace Game.Simulation.Conditions
{
    public interface IConditionFactory
    {
            public ICondition CreateCondition<T>() where T : ICondition, new();
    }
}