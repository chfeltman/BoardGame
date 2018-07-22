namespace BoardGame
{
    using System.Collections.Generic;

    public interface ITile
    {
        ILocation Location { get; set; }

        IEnumerable<ITile> Neighbors { get; }
    }
}
