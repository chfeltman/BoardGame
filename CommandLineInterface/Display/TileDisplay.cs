namespace CommandLineInterface.Display
{
    using System;
    using TerraMystica.Terrain;
    using Util;

    internal class TileDisplay
    {
        public TileDisplay(IDisplayFactory displayFactory)
        {
            if(displayFactory == null)
            {
                throw new ArgumentNullException(nameof(displayFactory));
            }

            this.DisplayFactory = displayFactory;
        }

        public IDisplayFactory DisplayFactory { get; }

        public void PrintTile(TerraTile tile)
        {
            IPrint displayer = tile.Building != null
                ? (IPrint)this.DisplayFactory.CreateBuildingDisplay(tile)
                : this.DisplayFactory.CreateTerrainDisplay(tile);

            displayer?.Print();
        }
    }
}
