namespace BoardGame
{
    using System.Collections.Generic;
    using System.Linq;

    public class Board<T> : IBoard<T> where T : ITile
    {
        private IEnumerable<T> tiles = new List<T>();

        private Dictionary<ILocation, T> tileLookup = new Dictionary<ILocation, T>();

        public IEnumerable<T> Tiles
        {
            get
            {
                return this.tiles;
            }

            set
            {
                this.tiles = value;
                this.Width = this.tiles.Max(t => t.Location.X + 1);
                this.Height = this.tiles.Max(t => t.Location.Y + 1);
            }
        }

        public int Width { get; private set; }

        public int Height { get; private set; }

        public T TileForLocation(ILocation location)
        {
            T tile;
            if(!this.tileLookup.TryGetValue(location, out tile))
            {
                tile = this.tiles.FirstOrDefault(t => t.Location.Equals(location));
                this.tileLookup[location] = tile;
            }

            return tile;
        }
    }
}
