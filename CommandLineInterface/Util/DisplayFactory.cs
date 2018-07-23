namespace CommandLineInterface.Util
{
    using System;
    using Display;
    using TerraMystica.Gameplay;
    using TerraMystica.Terrain;

    interface IDisplayFactory
    {
        BuildingTypeDisplay CreateBuildingDisplay(TerraTile tile);

        TerrainTypeDisplay CreateTerrainDisplay(TerraTile tile);
    }

    internal sealed class DisplayFactory : IDisplayFactory
    {
        public BuildingTypeDisplay CreateBuildingDisplay(TerraTile tile)
        {
            var buildingType = tile.Building.Type;
            var owner = tile.Owner;

            var color = CreateTerrainDisplay(tile).ForegroundColor;

            switch(buildingType)
            {
                case BuildingType.Void:
                    return new VoidBuildingDisplay();

                case BuildingType.Dwelling:
                    return new DwellingBuildingDisplay(color);

                case BuildingType.TradingHouse:
                    return new TradingHouseBuildingDisplay(color);

                case BuildingType.Temple:
                    return new TempleBuildingDisplay(color);

                case BuildingType.StrongHold:
                    return new StrongHoldBuildingDisplay(color);

                case BuildingType.Sanctuary:
                    return new SanctuaryBuildingDisplay(color);
            }

            throw new ArgumentOutOfRangeException(nameof(tile), $"Building type '{buildingType}' not supported");
        }

        public TerrainTypeDisplay CreateTerrainDisplay(TerraTile tile)
        {
            switch (tile.Type)
            {
                case TerrainType.Void:
                    return new VoidTerrainDisplay();

                case TerrainType.Lake:
                    return new LakeTerrainDisplay();

                case TerrainType.Swamp:
                    return new SwampTerrainDisplay();

                case TerrainType.Plain:
                    return new PlainTerrainDisplay();

                case TerrainType.Desert:
                    return new DesertTerrainDisplay();

                case TerrainType.Wasteland:
                    return new WastelandTerrainDisplay();

                case TerrainType.Mountain:
                    return new MountainTerrainDisplay();

                case TerrainType.Forest:
                    return new ForestTerrainDisplay();

                case TerrainType.River:
                    return new RiverTerrainDisplay();
            }

            throw new ArgumentOutOfRangeException(nameof(tile), $"Terrain type '{tile.Type}'not supported");
        }
    }
}
