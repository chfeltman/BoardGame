namespace BoardGame
{
    using System.Collections.Generic;

    public interface IBoard<T> where T : ITile
    {
        IEnumerable<T> Tiles { get; set; }

        int Width { get; }

        int Height { get; }

        T TileForLocation(ILocation location);
    }
}
