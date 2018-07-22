namespace TerraMysticaUnitTests.Actions
{
    using System;
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TerraMystica.Actions;
    using TerraMystica.Gameplay;
    using TestResources;

    [TestClass]
    public class UsePowerAbilityActionTests : ActionTests
    {
        public override void ModifyPlayerBeforeTest()
        {
            this.Player.Resources.Gold.Add(3);
        }

        [TestMethod]
        public void UsePowerAbility_Succees()
        {
            this.UsePowerAbilityAndAssertSuccess();
        }

        [TestMethod]
        public void UsePowerAbility_CannotAfford()
        {
            this.UsePowerAbilityAndAssertFailure(() => this.Player.Resources.Gold.Remove(3));
        }

        private void UsePowerAbilityAndAssertSuccess(Action beforeAction = null, WorkerResource expectedValue = null)
        {
            var ability = new TestPowerAbility(this.Player);
            this.PerformActionAndAssertResult(true, () => new UsePowerAbilityAction(this.Player, ability), beforeAction);
            this.Player.TestHit.Should().BeTrue();
        }

        private void UsePowerAbilityAndAssertFailure(Action beforeAction = null)
        {
            var ability = new TestPowerAbility(this.Player);
            this.PerformActionAndAssertResult(false, () => new UsePowerAbilityAction(this.Player, ability), beforeAction);
            this.Player.TestHit.Should().BeFalse();
        }
    }
}
