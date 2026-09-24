namespace Game.Simulation.Entities
{
    public class StandardBallFactory : IBallFactory
    {
        private const float DragCoefficient = TuningConfig.BallDragCoefficient;
        private const float BallMass = TuningConfig.BallMass;
        public ISimulationEntity GetNewBall()
        {
            return new StandardBall(BallMass, DragCoefficient);
        }
    }
}