namespace TerraMystica.Gameplay.Scrolls
{
    using System.Collections.Generic;
    using BoardGame;

    internal interface ITerraMysticaScroll
    {
        IEnumerable<IReadOnlyResource> Upkeep();

        void TurnInAction();
    }
}
