namespace Game.Simulation.Strategies
{
    public interface IStrategyFactory
    {
        public IStrategy CreateStrategy<T>() where T : IStrategy, new();
    }

    
}