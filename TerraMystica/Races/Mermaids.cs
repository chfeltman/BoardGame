namespace TerraMystica.Races
{
    using System.Collections.Generic;
    using System.Linq;
    using BoardGame;
    using BoardGame.Gameplay;
    using TerraMystica.Gameplay;
    using TerraMystica.Gameplay.Cults;
    using TerraMystica.Terrain;
    using TerraMystica.Resources;

    internal class Mermaids : Race
    {
        public override string Name => GameStrings.Mermaids;

        public override TerrainType HomeTerrain => TerrainType.Lake;

        public override TerraMysticaCultTrackResources StartingCultResources { get; } = new TerraMysticaCultTrackResources(0, 2, 0, 0);

        public override IEnumerable<BuildingUpgrade> UpgradeOptions(Building building, IBoard<TerraTile> board)
        {
            var options = Enumerable.Empty<BuildingUpgrade>();
            var tile = board.TileForLocation(building.Location);
            var terraTile = tile;
            switch(building.Type)
            {
                case BuildingType.Dwelling:
                    var goldCost = 6;
                    if(tile.Neighbors.Select(t => t as TerraTile)
                                     .Where(c => c != null)
                                     .Any(c => c.Owner != null && c.Owner != terraTile.Owner))
                    {
                        goldCost = 3;
                    }

                    options = new[] { new BuildingUpgrade(BuildingType.TradingHouse, new Cost(new GoldResource(goldCost), new WorkerResource(2))) };
                    break;

                case BuildingType.TradingHouse:
                    options = new[]
                    {
                        new BuildingUpgrade(BuildingType.Temple, new Cost(new GoldResource(5), new WorkerResource(2))),
                        new BuildingUpgrade(BuildingType.StrongHold, new Cost(new GoldResource(6), new WorkerResource(4))),
                    };
                    break;

                case BuildingType.Temple:
                    options = new[] { new BuildingUpgrade(BuildingType.Sanctuary, new Cost(new GoldResource(8), new WorkerResource(4))) };
                    break;
            }

            return options;
        }
    }
}
