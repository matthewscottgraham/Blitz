using System;
using System.Numerics;

namespace Game.Simulation
{
    public interface IMatch : IDisposable
    {
        public float SimulationSpeed { get; }
        Random Random { get; }
        float FieldRadius { get; }
        Vector3 BallPosition { get; }
        Team GetTeam(int index);
        
        void StartMatch();
        void PauseMatch();
        void ResumeMatch();
        void EndMatch();

        void Tick(float deltaTime);
        
    }
}