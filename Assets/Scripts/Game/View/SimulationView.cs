using System;
using Game.Simulation;
using Shared;
using UnityEngine;

namespace Game.View
{
    public class SimulationView : MonoBehaviour
    {
        private const float BoundaryMarkerRadius = 0.1f;
        private const int BoundaryMarkerCount = 48;
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
            DrawField();
            DrawBall(_match.BallPosition.ToUnityVector());
            DrawTeam(_match.GetTeam(0).Players, _blue);
            DrawTeam(_match.GetTeam(1).Players, _red);
        }

        private void DrawField()
        {
            Gizmos.color = Color.white;
            var goldenAngle = Mathf.PI * (3f - Mathf.Sqrt(5f));

            for (var i = 0; i < BoundaryMarkerCount; i++)
            {
                // Y goes from 1 to -1
                var y = 1f - (i / (float)(BoundaryMarkerCount - 1)) * 2f;

                var radiusAtY = Mathf.Sqrt(1f - y * y);

                var theta = goldenAngle * i;

                var x = Mathf.Cos(theta) * radiusAtY;
                var z = Mathf.Sin(theta) * radiusAtY;

                var point = new Vector3(x, y, z) * _match.FieldRadius;

                Gizmos.DrawSphere(transform.position + point, BoundaryMarkerRadius);
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