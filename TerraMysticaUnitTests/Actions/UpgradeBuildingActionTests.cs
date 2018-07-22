namespace TerraMysticaUnitTests.Actions
{
    using System;
    using BoardGame.Coordinates;
    using BoardGame.Gameplay;
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TerraMystica.Actions;
    using TerraMystica.Gameplay;
    using TestResources;

    [TestClass]
    public class UpgradeBuildingActionTests : ActionTests
    {
        public override void ModifyPlayerBeforeTest()
        {
            this.Player.Resources.Gold.Add(3);
        }

        [TestMethod]
        public void Upgrade_Success()
        {
            this.UpgradeAndAssertSuccess();
        }

        [TestMethod]
        public void Upgrade_CannotAfford()
        {
            this.UpgradeAndAssertFailure(() => this.Player.Resources.Gold.Remove(3));
        }

        [TestMethod]
        public void Upgrade_MissingBuilding()
        {
            this.UpgradeAndAssertFailure(target: new Building(BuildingType.Dwelling, new HexLocation(1234, 1234)));
        }

        [TestMethod]
        public void Upgrade_TileOwnerByAnotherPlayer()
        {
            this.UpgradeAndAssertFailure(() => this.Board.TileForLocation(new HexLocation(1, 1)).Owner = new TestPlayer());
        }

        private void UpgradeAndAssertSuccess(Action beforeExecute = null, Building target = null, BuildingUpgrade upgrade = null)
        {
            this.UpgradeAndAssertResult(true, beforeExecute, target, upgrade);
        }

        private void UpgradeAndAssertFailure(Action beforeExecute = null, Building target = null, BuildingUpgrade upgrade = null)
        {
            this.UpgradeAndAssertResult(false, beforeExecute, target, upgrade);
        }

        private void UpgradeAndAssertResult(bool expectation, Action beforeExecute = null, Building target = null, BuildingUpgrade targetUpgrade = null)
        {
            Building building = target;
            if(building == null)
            {
                var loc = new HexLocation(1, 1);
                building = new Building(BuildingType.Dwelling, loc);

                var tile = this.Board.TileForLocation(building.Location);
                tile.Building = building;
                tile.Owner = this.Player;
            }

            var upgrade = targetUpgrade ?? new BuildingUpgrade(BuildingType.TradingHouse, new Cost(new GoldResource(3)));

            this.PerformActionAndAssertResult(
                expectation,
                () => new UpgradeBuildingAction(this.Board, this.Player, building, upgrade),
                beforeExecute);

            if(expectation)
            {
                var tile = this.Board.TileForLocation(building.Location);
                tile.Building.Type.ShouldBeEquivalentTo(upgrade.NewType);
            }
        }
    }
}
