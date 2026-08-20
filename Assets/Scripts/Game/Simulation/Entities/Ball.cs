using System.Numerics;
using Shared;

namespace Game.Simulation.Entities
{
    public class Ball : SimulationEntity
    {
        private const int TopSpeed = 5;
        private IMatch _match;

        public override void SetMatch(IMatch match, int team = -1)
        {
            _match = match;
        }

        public override void Tick(float deltaTime)
        {
            MoveTowardsTarget(_match, deltaTime);
        }
        
        private void MoveTowardsTarget(IMatch match, float deltaTime)
        {
            CurrentPosition = MathUtility.Lerp(CurrentPosition, TargetPosition, P);
            P += deltaTime * TopSpeed * match.SimulationSpeed;
        }

        
    }
}