using System;
using Game.Simulation;
using Shared;
using UnityEngine;

namespace Game.View
{
    public class SimulationView : MonoBehaviour
    {
        private const float EntityRadius = 0.1f;
        
        private readonly Color _blue = Color.blue;
        private readonly Color _red = Color.red;
        
        private IMatch _match;

        public void Initialise(IMatch match)
        {
            _match = match;
        }

        private void OnDrawGizmos()
        {
            if (_match == null) return;
            DrawBall(_match.BallPosition.ToUnityVector());
            DrawTeam(_match.GetTeam(0).Players, _blue);
            DrawTeam(_match.GetTeam(1).Players, _red);
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