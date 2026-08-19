using System.Numerics;
using Game.Simulation.Utils;
using Shared;

namespace Game.Simulation
{
    public class Player : SimulationEntity
    {
        private PlayerStats _playerStats;
        private PlayerRole _role;
        
        private float p = 0;

        public Player(PlayerStats playerStats, PlayerRole role)
        {
            _playerStats = playerStats;
            _role = role;
            CurrentPosition = MatchUtility.GetStartingPosition(_role);
        }
        
        public override void Tick(IMatch match, float deltaTime)
        {
            GetTargetPosition(match);
            MoveTowardsTarget(match, deltaTime);
        }

        private void GetTargetPosition(IMatch match)
        {
            var inside = Vector3.DistanceSquared(CurrentPosition, Vector3.Zero) <= match.FieldRadius * match.FieldRadius;
            var hasArrived = MathUtility.ApproximatelyEqual(TargetPosition, CurrentPosition);
            if (!inside || hasArrived) SetNewRandomPosition(match);
        }

        private void SetNewRandomPosition(IMatch match)
        {
            TargetPosition = MathUtility.RandomPointInSphere(Vector3.Zero, match.FieldRadius, match.Random);
            p = 0;
        }

        private void MoveTowardsTarget(IMatch match, float deltaTime)
        {
            CurrentPosition = MathUtility.Lerp(CurrentPosition, TargetPosition, p);
            p += deltaTime * _playerStats.TopSpeed * match.SimulationSpeed;
        }
    }
}
