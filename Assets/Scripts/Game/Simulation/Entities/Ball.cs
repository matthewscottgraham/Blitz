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
            CheckForGoal();
        }
        
        private void MoveTowardsTarget(IMatch match, float deltaTime)
        {
            CurrentPosition = MathUtility.Lerp(CurrentPosition, TargetPosition, P);
            P += deltaTime * TopSpeed * match.SimulationSpeed;
        }

        private void CheckForGoal()
        {
            if (MathUtility.IsWithinRadius(CurrentPosition, _match.GoalPosition(0), _match.GoalRadius))
            {
                _match.AddPoint(0);
                ResetPosition();
            }
            else if (MathUtility.IsWithinRadius(CurrentPosition, _match.GoalPosition(1), _match.GoalRadius))
            {
                _match.AddPoint(1);
                ResetPosition();
            }
        }
    }
}