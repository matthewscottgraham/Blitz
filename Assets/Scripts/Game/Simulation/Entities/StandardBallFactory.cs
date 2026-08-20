namespace Game.Simulation.Entities
{
    public class StandardBallFactory : IBallFactory
    {
        public SimulationEntity GetNewBall()
        {
            return new StandardBall();
        }
    }
}