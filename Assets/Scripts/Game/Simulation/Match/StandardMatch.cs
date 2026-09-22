using System;
using System.Numerics;
using Game.Simulation.Entities;
using Game.Simulation.Formations;
using Game.Simulation.Utilities;

namespace Game.Simulation.Match
{
    public class StandardMatch : ISimulationContext, IMatchController
    {
        private bool _isPlaying = false;
        private float _resetCooldown = 0;
        private Team[] _teams;
        private readonly Vector3[] _goalPositions;
        private int[] _points;
        
        public IFormationFactory FormationFactory { get; }

        public int[] Points => _points;
        public float SimulationSpeed { get; } = 1f;
        public Random Random { get; }
        public float FieldRadius { get; } = 5f;
        public float GoalRadius { get; } = 1f;
        
        public Vector3 GoalPosition(int teamIndex) => _goalPositions[teamIndex];
        
        public ISimulationTeamMember GetPlayerByRole(int teamIndex, PlayerRole role)
        {
            foreach (var teamMember in _teams[teamIndex].TeamMembers)
            {
                if (teamMember.Role == role) return teamMember;
            }
            return null;
        }

        public ISimulationEntity Ball { get; }
        public Team GetTeam(int teamIndex) => _teams[teamIndex];
        
        public StandardMatch(IFormationFactory formationFactory, ISimulationEntity ball, Team[] teams, Random random)
        {
            FormationFactory = formationFactory;
            Random = random;
            Ball = ball;
            _teams = teams;

            for (var i = 0; i < teams.Length; i++)
            {
                foreach (var teamMember in teams[i].TeamMembers)
                {
                    teamMember.SetContext(this);
                    teamMember.AssignOpposingTeam((i + 1) % teams.Length);
                }
            }
            
            _goalPositions = new Vector3[_teams.Length];
            _goalPositions[0] = new Vector3(0f, 0f, -FieldRadius);
            _goalPositions[1] = new Vector3(0f, 0f, FieldRadius);
            
            _points = new int[_teams.Length];
        }

        public void Dispose()
        {
            _isPlaying = false;
            foreach (var team in _teams)
            {
                team.Dispose();
            }
            _teams = null;
        }

        public void Tick(float deltaTime)
        {
            if (!_isPlaying) return;
            var adjustedDeltaTime = deltaTime * SimulationSpeed;
            if (_resetCooldown > 0)
            {
                _resetCooldown -= adjustedDeltaTime;
                return;
            }

            if (!MathUtility.IsWithinRadius(Ball.CurrentPosition, Vector3.Zero, FieldRadius))
            {
                ResetPlay();
                return;
            }
            
            Ball.Tick(adjustedDeltaTime);
            foreach (var team in _teams)
            {
                foreach (var player in team.TeamMembers)
                {
                    player.Tick(adjustedDeltaTime);
                }
            }

            CheckForGoal();
        }

        public void StartMatch()
        {
            ResetPlay();
            _isPlaying = true;
        }

        public void PauseMatch()
        {
            
        }

        public void ResumeMatch()
        {
            
        }

        public void EndMatch()
        {
            
        }

        public void ResetPlay()
        {
            _resetCooldown = 0.5f;
            Ball.Reset();
            foreach (var team in _teams)
            {
                foreach (var player in team.TeamMembers)
                {
                    player.Reset();
                }
            }
        }
        
        private void CheckForGoal()
        {
            var scoredGoal = false;
            if (MathUtility.IsWithinRadius(Ball.CurrentPosition, GoalPosition(0), GoalRadius))
            {
                AddPoint(1);
                scoredGoal = true;
            }
            else if (MathUtility.IsWithinRadius(Ball.CurrentPosition, GoalPosition(1), GoalRadius))
            {
                AddPoint(0);
                scoredGoal = true;
            }

            if (scoredGoal)
            {
                ResetPlay();
            }
        }
        
        private void AddPoint(int teamIndex)
        {
            Points[teamIndex] += 1;
        }
    }
}