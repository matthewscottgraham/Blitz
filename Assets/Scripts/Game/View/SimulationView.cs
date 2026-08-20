using System;
using Extensions;
using Game.Simulation.Entities;
using Game.Simulation.Match;
using UnityEngine;

namespace Game.View
{
    public class SimulationView : MonoBehaviour
    {
        private const float BoundaryMarkerRadius = 0.1f;
        private const int BoundaryMarkerCount = 48;
        private const float EntityRadius = 0.1f;
        
        private readonly Color _blue = Color.blue;
        private readonly Color _cyan = Color.cyan;
        private readonly Color _red = Color.red;
        private readonly Color _magenta = Color.magenta;
        
        private ISimulationContext _simulationContext;

        public void Initialise(ISimulationContext simulationContext)
        {
            _simulationContext = simulationContext;
        }

        private void OnDrawGizmos()
        {
            if (_simulationContext == null) return;
            DrawGoal(_simulationContext.GoalPosition(0).ToUnityVector(), _cyan);
            DrawGoal(_simulationContext.GoalPosition(1).ToUnityVector(), _magenta);
            DrawBall(_simulationContext.Ball.CurrentPosition.ToUnityVector());
            DrawTeam(_simulationContext.GetTeam(0).Players, _blue);
            DrawTeam(_simulationContext.GetTeam(1).Players, _red);
        }

        private void DrawGoal(Vector3 goalPosition, Color color)
        {
            Gizmos.color = color;
            for (var i = 0; i < 12; i++)
            {
                var angle = i * (MathF.PI * 2f / 12);

                var offset = new Vector3(
                    MathF.Cos(angle) * _simulationContext.GoalRadius,
                    MathF.Sin(angle) * _simulationContext.GoalRadius,
                    0f
                );

                Gizmos.DrawSphere(
                    goalPosition + offset,
                    0.1f
                );    
            }
        }

        private void DrawBall(Vector3 ballPosition)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawSphere(ballPosition, EntityRadius);
        }

        private void DrawTeam(SimulationEntity[] players, Color color)
        {
            Gizmos.color = color;
            foreach (var player in players)
            {
                Gizmos.DrawSphere(player.CurrentPosition.ToUnityVector(), EntityRadius);
            }
        }
    }
}