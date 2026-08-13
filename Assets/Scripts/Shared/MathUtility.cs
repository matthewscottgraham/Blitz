using System.Numerics;

namespace Shared
{
    public static class MathUtility
    {
        public static UnityEngine.Vector3 ToUnityVector(this Vector3 vector)
        {
            return new UnityEngine.Vector3(vector.X, vector.Y, vector.Z);
        }

        public static Vector3 Lerp(Vector3 a, Vector3 b, float t)
        {
            return a + (b - a) * t;
        }
    }
}