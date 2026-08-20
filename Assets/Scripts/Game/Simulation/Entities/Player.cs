using System;
using System.Numerics;
using Game.Simulation.Logic;
using Game.Simulation.Utils;
using Shared;

namespace Game.Simulation.Entities
{
    public class Player : SimulationEntity
    {
        public readonly PlayerStats Stats;
        private PlayerRole _role;
        private LogicNode[] _logicNodes = Array.Empty<LogicNode>();
        private IMatch _match;
        
        public int Team { get; private set; }

        public Player(PlayerStats playerStats, PlayerRole role)
        {
            Stats = playerStats;
            _role = role;
            CurrentPosition = MatchUtility.GetStartingPosition(_role);
        }
        
        public override void Tick(float deltaTime)
        {
            foreach (var logicNode in _logicNodes)
            {
                if (logicNode.Evaluate(_match, this))
                    break;

            }
            
            MoveTowardsTarget(deltaTime);
        }

        public override void SetMatch(IMatch match, int team = -1)
        {
            _match = match;
            Team = team;
        }

        public void SetLogic(LogicNode[] logicNodes)
        {
            _logicNodes = logicNodes;
        }

        private void SetNewRandomPosition(IMatch match)
        {
            TargetPosition = MathUtility.RandomPointInSphere(Vector3.Zero, match.FieldRadius, match.Random);
            P = 0;
        }

        private void MoveTowardsTarget(float deltaTime)
        {
            CurrentPosition = MathUtility.Lerp(CurrentPosition, TargetPosition, P);
            P += deltaTime * Stats.TopSpeed * _match.SimulationSpeed;
            
            var hasArrived = MathUtility.ApproximatelyEqual(TargetPosition, CurrentPosition);
            if (hasArrived)
            {
                P = 0;
            }
        }
    }
}
