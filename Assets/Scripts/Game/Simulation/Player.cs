using Game.Simulation.Utils;

namespace Game.Simulation
{
    public class Player : SimulationEntity
    {
        private PlayerStats _playerStats;
        private PlayerRole _role;

        public Player(PlayerStats playerStats, PlayerRole role)
        {
            _playerStats = playerStats;
            _role = role;
            CurrentPosition = MatchUtility.GetStartingPosition(_role);
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
            // TODO
        }
    }
}
