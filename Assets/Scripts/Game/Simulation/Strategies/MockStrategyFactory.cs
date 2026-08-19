namespace Game.Simulation.Strategies
{
    public class MockStrategyFactory : IStrategyFactory
    {
        public IStrategy[] GetStrategies()
        {
            return new IStrategy[]
            {
                new KickBallTowardsGoal(),
                new ChaseBall(),
                //new InterceptBall(),
                //new MarkPlayer(),
                //new PassBall()
            };
        }
    }
}