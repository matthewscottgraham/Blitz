using System;
using System.Numerics;
using Game.Simulation.Entities;

namespace Game.Simulation
{
    public interface IMatch : IDisposable
    {
        public float SimulationSpeed { get; }
        Random Random { get; }
        float FieldRadius { get; }
        float GoalRadius { get; }
        SimulationEntity Ball { get; }
        public int[]  Points { get; }
        
        Team GetTeam(int index);
        Vector3 GoalPosition(int teamIndex);
        void AddPoint(int teamIndex);
        
        void StartMatch();
        void PauseMatch();
        void ResumeMatch();
        void EndMatch();

        void Tick(float deltaTime);
        
    }
}