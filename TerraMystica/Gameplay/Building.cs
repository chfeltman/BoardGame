namespace TerraMystica.Gameplay
{
    using BoardGame;

    internal class Building
    {
        public Building(BuildingType type, ILocation location)
        {
            this.Type = type;
            this.Location = location;
        }

        public BuildingType Type { get; set; }

        public ILocation Location { get; set; }
    }
}
