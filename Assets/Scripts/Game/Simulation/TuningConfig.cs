namespace Game.Simulation
{
    // Magic numbers for tuning.
    public static class TuningConfig
    {
        // Player strategy tuning
        public const float PlayerAvoidRadius = 1f;
        public const float PlayerSpeedMultiplier = 10f;
        public const float PlayerKickMultiplier = 0.4f;
        public const float PlayerInterceptMultiplier = 0.1f;
        public const float PlayerInterceptRadius = 0.5f;

        // Ball tuning
        public const float BallMass = 1.5f;
        public const float BallDragCoefficient = 0.05f;
    }
}