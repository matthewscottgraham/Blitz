namespace Game.Simulation.Entities
{
    public class StandardBallFactory : IBallFactory
    {
        public SimulationEntity GetNewBall()
        {
            return new StandardBall(GetBallStats());
        }

        private PlayerStats GetBallStats()
        {
            return new PlayerStats
            {
                Accuracy = 10,
                Acceleration = 10,
                TopSpeed = 10,
                Agility = 0,
                Intercept = 0,
                KickPower = 0,
                Mass = 1,
            };
        }
    }
}