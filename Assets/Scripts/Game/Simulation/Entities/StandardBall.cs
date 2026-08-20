using System.Numerics;
using Game.Simulation.Match;
using Shared;

namespace Game.Simulation.Entities
{
    public class StandardBall : SimulationEntity
    {
        private const int TopSpeed = 5;
        private ISimulationContext _simulationContext;

        public override void SetMatch(ISimulationContext simulationContext, int team = -1)
        {
            _simulationContext = simulationContext;
        }

        public override void Tick(float deltaTime)
        {
            MoveTowardsTarget(_simulationContext, deltaTime);
        }
        
        private void MoveTowardsTarget(ISimulationContext simulationContext, float deltaTime)
        {
            CurrentPosition = MathUtility.Lerp(CurrentPosition, TargetPosition, MoveProgress);
            MoveProgress += deltaTime * TopSpeed * simulationContext.SimulationSpeed;
        }

        
    }
}