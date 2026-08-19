namespace Game.Simulation.Strategies
{
    public interface IStrategyFactory
    {
        public IStrategy[] GetStrategies();
    }
}