namespace Game.Simulation.Strategies
{
    public class MockStrategyFactory : IStrategyFactory
    {
        public IStrategy CreateStrategy<T>() where T : IStrategy, new()
        {
            return new T();
        }
    }
}