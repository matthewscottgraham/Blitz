namespace Extensions
{
    public static class MathExtensions
    {
        public static UnityEngine.Vector3 ToUnityVector(this System.Numerics.Vector3 vector)
        {
            return new UnityEngine.Vector3(vector.X, vector.Y, vector.Z);
        }
    }
}