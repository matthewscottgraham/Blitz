using System;
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
            
            var random = new Random();
            TargetPosition = new Vector3((float)random.NextDouble(), (float)random.NextDouble(),
                (float)random.NextDouble());
        }
        
        public override void Tick(float deltaTime)
        {
            GetTargetPosition();
            MoveTowardsTarget(deltaTime);
        }

        private void GetTargetPosition()
        {
            // TODO
        }

        private void MoveTowardsTarget(float deltaTime)
        {
            CurrentPosition += MathUtility.Lerp(CurrentPosition, TargetPosition, p);
            p += deltaTime * _playerStats.TopSpeed;
        }
    }
}
