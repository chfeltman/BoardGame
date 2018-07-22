namespace TerraMystica.Gameplay
{
    using BoardGame.Gameplay;

    internal class BuildingUpgrade
    {
        public BuildingUpgrade(BuildingType toType, Cost cost)
        {
            this.NewType = toType;
            this.Cost = cost;
        }

        public BuildingType NewType { get; private set; }

        public Cost Cost { get; private set; }
    }
}
