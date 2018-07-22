namespace TerraMysticaUnitTests.Actions
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using FluentAssertions;
    using BoardGame.Coordinates;
    using TerraMystica.Terrain;
    using TerraMystica.Actions;
    using TestResources;
    using TerraMystica.Gameplay;

    [TestClass]
    public class BuildActionTests : ActionTests
    {
        public override void ModifyPlayerBeforeTest()
        {
            this.Player.Resources.Add(new GoldResource(2), new WorkerResource(1));
        }

        [TestMethod]
        public void TestBuild_Success()
        {
            this.BuildAndAssertSuccess();
        }

        [TestMethod]
        public void TestBuild_CannotAfford()
        {
            this.BuildAndAssertFailure(tile =>
            {
                this.Player.Resources.Gold.Remove(2);
            });
        }

        [TestMethod]
        public void TestBuild_TileAlreadyOwnedFailure()
        {
            var loc = new HexLocation(1, 1);
            this.BuildAndAssertFailure(tile => this.Board.TileForLocation(loc).Owner = new TestPlayer(), loc);
        }

        [TestMethod]
        public void TestBuild_TileWrongTypeFailure()
        {
            this.BuildAndAssertFailure(tile => tile.Type = TerrainType.Mountain);
        }

        private void BuildAndAssertFailure(Action<TerraTile> beforeExecute = null, HexLocation location = null)
        {
            this.BuildAndAssertResult(false, beforeExecute, location);
        }

        private void BuildAndAssertSuccess(Action<TerraTile> beforeExecute = null, HexLocation location = null)
        {
            var loc = location ?? new HexLocation(1, 1);

            this.BuildAndAssertResult(true, beforeExecute, location);

            var tile = this.Board.TileForLocation(loc);
            var building = tile.Building;
            building.Should().NotBeNull();
            building.Type.ShouldBeEquivalentTo(BuildingType.Dwelling);
            tile.Owner.Should().Be(this.Player);
        }

        private void BuildAndAssertResult(bool expectation, Action<TerraTile> beforeExecute = null, HexLocation location = null)
        {
            var loc = location ?? new HexLocation(1, 1);
            var tile = this.Board.TileForLocation(loc);

            Func<TerraMysticaAction> prepareAction = () => new BuildAction(this.Board, this.Player, loc);
            Action before = () => beforeExecute?.Invoke(tile);

            this.PerformActionAndAssertResult(expectation, prepareAction, before);
        }
    }
}
