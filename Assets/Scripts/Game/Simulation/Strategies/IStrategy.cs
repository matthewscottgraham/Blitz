using Game.Simulation.Entities;

namespace Game.Simulation.Strategies
{
    public interface IStrategy
    {
        public void Execute(IMatch match, Player  player);
    }
}