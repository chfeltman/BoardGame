namespace TerraMystica.Terrain
{
    using BoardGame;
    using TerraMystica.Gameplay;

    internal class TerraTile : Tile
    {
        public TerrainType Type { get; set; }

        public IPlayer Owner { get; set; }

        public Building Building { get; set; }

        public static TerraTile LakeTile { get { return new TerraTile() { Type = TerrainType.Lake }; } }

        public static TerraTile SwampTile { get { return new TerraTile() { Type = TerrainType.Swamp }; } }

        public static TerraTile PlainTile { get { return new TerraTile() { Type = TerrainType.Plain }; } }

        public static TerraTile DesertTile { get { return new TerraTile() { Type = TerrainType.Desert }; } }

        public static TerraTile WastelandTile { get { return new TerraTile() { Type = TerrainType.Wasteland }; } }

        public static TerraTile MountainTile { get { return new TerraTile() { Type = TerrainType.Mountain }; } }

        public static TerraTile ForestTile { get { return new TerraTile() { Type = TerrainType.Forest }; } }

        public static TerraTile RiverTile { get { return new TerraTile() { Type = TerrainType.River }; } }
    }
}
