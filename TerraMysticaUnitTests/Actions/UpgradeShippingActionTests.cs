namespace TerraMysticaUnitTests.Actions
{
    using System;
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TerraMystica.Actions;

    [TestClass]
    public class UpgradeShippingActionTests : ActionTests
    {
        public override void ModifyPlayerBeforeTest()
        {
            this.Player.Resources.Gold.Add(4);
            this.Player.Resources.Priests.Add(1);
        }

        [TestMethod]
        public void UpgradeShipping_Succees()
        {
            this.UpgradeShippingAndAssertSuccess();
        }

        [TestMethod]
        public void UpgradeShipping_CannotAfford()
        {
            this.UpgradeShippingAndAssertFailure(() => this.Player.Resources.Priests.Remove(1));
        }

        [TestMethod]
        public void UpgradeShipping_ReachedMax()
        {
            this.Race.TestMaxShippingDistance = 1;

            // upgrade first time, now at max
            this.UpgradeShippingAndAssertSuccess(expectedValue: 1);

            // Fail to move past max
            this.UpgradeShippingAndAssertFailure();
        }

        public void UpgradeShippingAndAssertSuccess(Action beforeAction = null, int expectedValue = 1)
        {
            this.PerformActionAndAssertResult(true, () => new UpgradeShippingAction(this.Player), beforeAction);

            this.Race.ShippingDistance.ShouldBeEquivalentTo(expectedValue);
        }

        public void UpgradeShippingAndAssertFailure(Action beforeAction = null)
        {
            this.PerformActionAndAssertResult(false, () => new UpgradeShippingAction(this.Player), beforeAction);
        }
    }
}
