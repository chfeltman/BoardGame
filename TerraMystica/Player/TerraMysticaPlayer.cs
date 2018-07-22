namespace TerraMystica.Player
{
    using System.Collections.Generic;
    using BoardGame;
    using TerraMystica.Gameplay;
    using TerraMystica.Races;

    internal class TerraMysticaPlayer : IPlayer
    {
        public TerraMysticaPlayer(string name, Race race)
        {
            this.Name = name;
            this.Race = race;
            this.Resources = new TerraMysticaPlayerResources(
                gold: this.Race.StartingGold,
                workers: this.Race.StartingWorkers,
                priests: this.Race.StartingPriests,
                power: new Power(this.Race.StartingBowlIPower, this.Race.StartingBowlIPower),
                cultResources: this.Race.StartingCultResources
            );
        }

        public string Name { get; }

        public TerraMysticaPlayerResources Resources { get; }

        public Race Race { get; set; }

        public ICollection<Building> PlacedBuildings { get; } = new List<Building>();

        public bool HasPassed { get; set; }
    }
}
