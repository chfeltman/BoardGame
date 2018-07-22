namespace TerraMystica
{
    using System;
    using BoardGame;
    using TerraMystica.Gameplay.Cults;
    using TerraMystica.Terrain;

    internal class TerraMysticaBoard : Board<TerraTile>
    {
        public TerraMysticaBoard()
        {
            throw new NotImplementedException();
        }

        public CultistTrackBoard CultTracks { get; }
    }
}
