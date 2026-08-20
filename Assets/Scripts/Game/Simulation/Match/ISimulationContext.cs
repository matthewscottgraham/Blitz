using System;
using System.Numerics;
using Game.Simulation.Entities;

namespace Game.Simulation.Match
{
    public interface ISimulationContext : IDisposable
    {
        public float SimulationSpeed { get; }
        Random Random { get; }
        float FieldRadius { get; }
        float GoalRadius { get; }
        SimulationEntity Ball { get; }
        public int[]  Points { get; }
        Team GetTeam(int index);
        Vector3 GoalPosition(int teamIndex);
    }
}