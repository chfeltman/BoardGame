namespace TerraMysticaUnitTests.TestResources
{
    using System;
    using BoardGame;
    using BoardGame.Gameplay;
    using TerraMystica.Gameplay;
    using TerraMystica.Gameplay.PowerAbility;
    using TerraMystica.Util;

    internal class TestPowerAbility : IPowerAbility
    {
        private TestPlayer player;

        public TestPowerAbility(TestPlayer player)
        {
            this.player = player;
        }

        public Cost Cost => new GoldResource(3).ToCost();

        public bool Used { get; private set; }

        public Decision CanExecute()
        {
            var decision = Decision.True();
            if(this.Used)
            {
                decision = Decision.False("Already Used");
            }

            return decision;
        }

        public void Execute()
        {
            this.player.TestHit = true;
        }
    }
}
