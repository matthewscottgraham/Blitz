using System;
using System.Numerics;
using Game.Simulation.Entities;

namespace Game.Simulation
{
    public class Match : IMatch
    {
        private bool _isPlaying = false;
        private Team[] _teams;
        private readonly Vector3[] _goalPositions;

        public int[] Points { get; }
        public float SimulationSpeed { get; } = 0.01f;
        public Random Random { get; }
        public float FieldRadius { get; } = 5f;
        public float GoalRadius { get; } = 1f;
        
        public Vector3 GoalPosition(int teamIndex) => _goalPositions[teamIndex];
        
        public SimulationEntity Ball { get; }

        public Team GetTeam(int teamIndex) => _teams[teamIndex];
        
        public Match(Team[] teams)
        {
            Random = new Random();
            Ball = new Ball();
            Ball.SetMatch(this);
            _teams = teams;

            for (var i = 0; i < teams.Length; i++)
            {
                foreach (var simulationEntity in teams[i].Players)
                {
                    var player = (Player)simulationEntity;
                    player.SetMatch(this, i);
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
        }

        public void AddPoint(int teamIndex)
        {
            Points[teamIndex] += 1;
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
    }
}