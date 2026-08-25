namespace Game.Simulation.Entities
{
    public interface IBallFactory
    {
        ISimulationEntity GetNewBall();
    }
}