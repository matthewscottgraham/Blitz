using System;
using System.Numerics;

namespace Game.Simulation
{
    public class Match : IMatch
    {
        private readonly SimulationEntity _ball;
        private Team[] _teams;

        public float SimulationSpeed { get; } = 0.01f;
        public Random Random { get; }
        public float FieldRadius { get; } = 5f;
        public Vector3 BallPosition => _ball.CurrentPosition;

        public Team GetTeam(int teamIndex) => _teams[teamIndex];
        
        public Match(Team[] teams)
        {
            Random = new Random();
            _ball = new Ball();
            _teams = teams;
        }

        public void Dispose()
        {
            foreach (var team in _teams)
            {
                team.Dispose();
            }
            _teams = null;
        }

        public void Tick(float deltaTime)
        {
            _ball.Tick(this, deltaTime);
            foreach (var team in _teams)
            {
                foreach (var player in team.Players)
                {
                    player.Tick(this, deltaTime);
                }
            }
        }

        public void StartMatch()
        {
            
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