namespace TerraMysticaUnitTests.TestResources
{
    using System.Collections.Generic;
    using System.Linq;
    using BoardGame;
    using TerraMystica.Gameplay.Scrolls;

    internal class TestScroll : ITerraMysticaScroll
    {
        public void TurnInAction()
        {
        }

        public IEnumerable<IReadOnlyResource> Upkeep()
        {
            return Enumerable.Empty<IReadOnlyResource>();
        }
    }
}
