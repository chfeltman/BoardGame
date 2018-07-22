namespace TerraMysticaUnitTests.TestResources
{
    using TerraMystica.Player;
    using TerraMystica.Races;

    internal class TestPlayer : TerraMysticaPlayer
    {
        public TestPlayer(string name = null, Race race = null) 
            : base(name ?? "Player1", race ?? new TestRace())
        {
        }

        public bool TestHit { get; set; }
    }
}
