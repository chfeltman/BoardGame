namespace CommandLineInterface.Display
{
    using System.Collections.Generic;
    using System.Linq;
    using TerraMystica.Terrain;

    internal class TileDisplay
    {
        public TileDisplay(IEnumerable<ITerrainTypeDisplay> typeDisplays)
        {
            this.TypeDisplays = typeDisplays ?? Enumerable.Empty<ITerrainTypeDisplay>();
        }

        IEnumerable<ITerrainTypeDisplay> TypeDisplays { get; }

        public void PrintTile(TerraTile tile)
        {
            var display = this.TypeDisplays.FirstOrDefault(d => d.Type == tile.Type);
            display?.Print();
        }
    }
}
