namespace TerraMysticaUnitTests.Actions
{
    using System;
    using System.Linq;
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TerraMystica.Actions;
    using TerraMystica.Gameplay;
    using TerraMystica.Util;

    [TestClass]
    public class UpgradeTerraformActionTests : ActionTests
    {
        public override void ModifyPlayerBeforeTest()
        {
            this.Player.Resources.Add(new PriestResource(1), new GoldResource(5), new WorkerResource(2));
        }

        [TestMethod]
        public void UpgradeTerraform_Succees()
        {
            this.UpgradeTerraformAndAssertSuccess();
        }

        [TestMethod]
        public void UpgradeTerraform_CannotAfford()
        {
            this.UpgradeTerraformAndAssertFailure(() => this.Player.Resources.Priests.Remove(1));
        }

        [TestMethod]
        public void UpgradeTerraform_ReachedMin()
        {
            this.Race.TestMinSpadeCost = new WorkerResource(2).ToCost();

            // upgrade first time, now at max
            this.UpgradeTerraformAndAssertSuccess();

            // Fail to move past min
            this.UpgradeTerraformAndAssertFailure();
        }

        private void UpgradeTerraformAndAssertSuccess(Action beforeAction = null, WorkerResource expectedValue = null)
        {
            this.PerformActionAndAssertResult(true, () => new UpgradeTerraformAction(this.Player), beforeAction);

            this.Race.SpadeCost.Resources.FirstOrDefault(r => r.Name.Equals(WorkerResource.Key))
                .ShouldBeEquivalentTo(expectedValue ?? new WorkerResource(2));
        }

        private void UpgradeTerraformAndAssertFailure(Action beforeAction = null)
        {
            this.PerformActionAndAssertResult(false, () => new UpgradeTerraformAction(this.Player), beforeAction);
        }
    }
}
