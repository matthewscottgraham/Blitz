namespace Game.Simulation.Strategies
{
    public class StandardStrategyFactory : IStrategyFactory
    {
        public IStrategy CreateStrategy<T>() where T : IStrategy, new()
        {
            return new T();
        }
    }
}