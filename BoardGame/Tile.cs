namespace BoardGame
{
    using System.Collections.Generic;

    public class Tile : ITile
    {
        List<ITile> neighbors = new List<ITile>();

        public ILocation Location { get; set; }

        public Tile() { }

        public IEnumerable<ITile> Neighbors
        {
            get { return this.neighbors; }
        }
    }
}
