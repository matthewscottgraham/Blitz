namespace Game.Simulation.Entities
{
    public class StandardBallFactory : IBallFactory
    {
        public ISimulationEntity GetNewBall()
        {
            return new StandardBall();
        }
    }
}