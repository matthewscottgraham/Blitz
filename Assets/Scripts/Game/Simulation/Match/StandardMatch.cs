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
        private Team[] _teams;
        private readonly Vector3[] _goalPositions;
        
        public IFormationFactory FormationFactory { get; }

        public int[] Points { get; }
        public float SimulationSpeed { get; } = 0.01f;
        public Random Random { get; }
        public float FieldRadius { get; } = 5f;
        public float GoalRadius { get; } = 1f;
        
        public Vector3 GoalPosition(int teamIndex) => _goalPositions[teamIndex];
        public SimulationEntity Ball { get; }
        public Team GetTeam(int teamIndex) => _teams[teamIndex];
        
        public StandardMatch(IFormationFactory formationFactory, SimulationEntity ball, Team[] teams, Random random)
        {
            FormationFactory = formationFactory;
            Random = random;
            Ball = ball;
            _teams = teams;

            for (var i = 0; i < teams.Length; i++)
            {
                foreach (var simulationEntity in teams[i].Players)
                {
                    var player = (ITeamMember)simulationEntity;
                    player.SetContext(this);
                }
            }
            
            _goalPositions = new Vector3[_teams.Length];
            _goalPositions[0] = new Vector3(0f, 0f, -FieldRadius);
            _goalPositions[1] = new Vector3(0f, 0f, FieldRadius);
            
            Points = new int[_teams.Length];
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
            Ball.Tick(deltaTime);
            foreach (var team in _teams)
            {
                foreach (var player in team.Players)
                {
                    player.Tick(deltaTime);
                }
            }

            CheckForGoal();
        }

        public void StartMatch()
        {
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
            Ball.Reset();
            foreach (var team in _teams)
            {
                foreach (var player in team.Players)
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