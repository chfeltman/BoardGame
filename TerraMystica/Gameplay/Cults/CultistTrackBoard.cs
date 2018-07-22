namespace TerraMystica.Gameplay.Cults
{
    using System.Collections.Generic;
    using System.Linq;

    internal class CultistTrackBoard
    {
        public CultistTrackBoard(IEnumerable<CultTrack> tracks)
        {
            this.Tracks = tracks.ToDictionary(t => t.Type);
        }

        public IReadOnlyDictionary<CultType, CultTrack> Tracks { get; }
    }
}
