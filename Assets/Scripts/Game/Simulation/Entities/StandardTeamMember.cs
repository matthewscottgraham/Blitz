using System;
using System.Numerics;
using Game.Simulation.Formations;
using Game.Simulation.Logic;
using Game.Simulation.Match;

namespace Game.Simulation.Entities
{
    public class StandardTeamMember : ISimulationTeamMember
    {
        private LogicNode[] _logicNodes = Array.Empty<LogicNode>();
        private ISimulationContext _simulationContext;
        private PlayerStats _stats;
        private Vector3 _currentPosition;
        private Vector3 _currentVelocity;

        public Vector3 CurrentPosition => _currentPosition;
        public Vector3 CurrentVelocity => _currentVelocity;
        public PlayerStats Stats => _stats;
        
        public int Team { get; private set; }
        public int OpposingTeam {get; private set;}
        public PlayerRole Role { get; private set; }
        public PlayerRole MarkedPlayerRole { get; private set; }

        public StandardTeamMember(PlayerStats playerStats, PlayerRole role, int teamIndex)
        {
            _stats = playerStats;
            Role = role;
            MarkedPlayerRole = role;
            AssignTeam(teamIndex);
        }

        public void SetContext(ISimulationContext simulationContext)
        {
            _simulationContext = simulationContext;
        }

        public void AssignTeam(int team)
        {
            Team = team;
        }

        public void AssignOpposingTeam(int opposingTeam)
        {
            OpposingTeam = opposingTeam;
        }

        public void SetLogic(LogicNode[] logicNodes)
        {
            _logicNodes = logicNodes;
        }

        public void ApplyForce(Vector3 direction, float magnitude)
        {
            if (direction.LengthSquared() < 0.0001f) return;
            var acceleration = Vector3.Normalize(direction) * (magnitude / Stats.Mass);
            _currentVelocity += acceleration;
        }

        public void Tick(float deltaTime)
        {
            foreach (var logicNode in _logicNodes)
            {
                if (logicNode.Evaluate(_simulationContext, this))
                    break;
            }
            
            ApplyMove(deltaTime);
        }

        public void Reset()
        {
            _currentPosition = _simulationContext.FormationFactory.GetFormationPosition(FormationType.Standard, Team, Role);
            _currentVelocity = Vector3.Zero;
        }

        private void ApplyMove(float deltaTime)
        {
            if (CurrentVelocity.Length() > Stats.Speed)
                _currentVelocity = Vector3.Normalize(CurrentVelocity) * Stats.Speed;
            
            _currentPosition += CurrentVelocity * deltaTime;
            _currentVelocity *= 1 - Stats.Drag / 100f * deltaTime;
        }
    }
}
