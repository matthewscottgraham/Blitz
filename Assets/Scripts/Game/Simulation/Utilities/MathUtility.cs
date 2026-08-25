using System;
using System.Numerics;

namespace Game.Simulation.Utilities
{
    public static class MathUtility
    {
        public static Vector3 Lerp(Vector3 a, Vector3 b, float t)
        {
            return a + (b - a) * t;
        }

        public static Vector3 ApplyStatNoise(this Vector3 position, Random random, float accuracy)
        {
            return new Vector3(
                (float)(random.NextDouble() - 0.5f) * 2,
                (float)(random.NextDouble() - 0.5f) * 2,
                (float)(random.NextDouble() - 0.5f) * 2
            ) * (1f - accuracy / 10f);
        }
        
        public static Vector3 RandomPointInSphere(Vector3 center, float radius, Random random)
        {
            float x, y, z;

            do
            {
                x = (float)(random.NextDouble() * 2.0 - 1.0);
                y = (float)(random.NextDouble() * 2.0 - 1.0);
                z = (float)(random.NextDouble() * 2.0 - 1.0);
            }
            while (x * x + y * y + z * z > 1.0);

            return center + new Vector3(x, y, z) * radius;
        }
        
        public static bool ApproximatelyEqual(Vector3 a, Vector3 b)
        {
            const float tolerance = 0.001f;
            return IsWithinRadius(a, b, tolerance);
        }

        public static bool IsWithinRadius(Vector3 a, Vector3 b, float radius)
        {
            return Vector3.DistanceSquared(a, b) <= radius * radius;
        } 
    }
}