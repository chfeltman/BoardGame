namespace TerraMystica.Gameplay.Cults
{
    using BoardGame;

    internal class CultTrackBonus
    {
        public CultTrackBonus(int targetValue, IReadOnlyResource bonus)
        {
            this.TargetValue = targetValue;
            this.Boon = bonus;
        }

        public int TargetValue { get; }

        public IReadOnlyResource Boon { get; }
    }
}
