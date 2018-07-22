namespace BoardGameUnitTests.TestResources
{
    using BoardGame;

    internal class TestPlayer : IPlayer
    {
        public TestPlayer(string name = "Player1")
        {
            this.Name = name;
        }

        public string Name { get; }
    }
}
