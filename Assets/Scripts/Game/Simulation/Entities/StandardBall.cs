using Game.Simulation.Match;

namespace Game.Simulation.Entities
{
    public class StandardBall : SimulationEntity
    {
        private ISimulationContext _simulationContext;

        public override void SetContext(ISimulationContext simulationContext)
        {
            _simulationContext = simulationContext;
        }

        public override void Tick(float deltaTime)
        {
            ApplyPhysics(deltaTime);
        }
    }
}