using System;
using System.Numerics;
using Game.Simulation.Entities;
using Game.Simulation.Formations;

namespace Game.Simulation.Match
{
    public interface ISimulationContext
    {
        public float SimulationSpeed { get; }
        public IFormationFactory FormationFactory { get; }
        Random Random { get; }
        float FieldRadius { get; }
        float GoalRadius { get; }
        SimulationEntity Ball { get; }
        public int[]  Points { get; }
        Team GetTeam(int index);
        Vector3 GoalPosition(int teamIndex);
    }
}