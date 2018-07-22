namespace TerraMysticaUnitTests.Actions
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using BoardGame.Coordinates;
    using TerraMystica.Terrain;
    using TerraMystica.Actions;
    using TerraMystica.Gameplay;

    [TestClass]
    public class TerraformActionTest : ActionTests
    {
        public override void ModifyPlayerBeforeTest()
        {
            this.Player.Resources.Add(new SpadeResource(2));
        }

        [TestMethod]
        public void TestTerraForm_Success()
        {
            this.TerraformAndAssertSuccess();
        }

        [TestMethod]
        public void TestTerraform_ToSameType()
        {
            this.TerraformAndAssertFailure(type: TerrainType.Lake);
        }

        [TestMethod]
        public void TestTerraform_PlayerCannotAfford()
        {
            this.TerraformAndAssertFailure(loc => this.Player.Resources.Remove(new SpadeResource(9)));
        }

        [TestMethod]
        public void TestTerraform_TileAlreadyOwned()
        {
            this.TerraformAndAssertFailure(loc => this.Board.TileForLocation(loc).Owner = this.Player);
        }

        private void TerraformAndAssertFailure(Action<HexLocation> beforeExecute = null, HexLocation location = null, TerrainType type = TerrainType.Mountain)
        {
            this.TerraformAndAssertResult(false, beforeExecute, location, type);
        }

        private void TerraformAndAssertSuccess(Action<HexLocation> beforeExecute = null, HexLocation location = null, TerrainType type = TerrainType.Mountain)
        {
            this.TerraformAndAssertResult(true, beforeExecute, location, type);
        }

        private void TerraformAndAssertResult(bool expectation, Action<HexLocation> beforeExecute = null, HexLocation location = null, TerrainType type = TerrainType.Mountain)
        {
            var loc = location ?? new HexLocation(1, 1);
            var target = type;
            Func<TerraMysticaAction> prepareAction = () => new TerraformAction(this.Board, this.Player, loc, target);
            Action before = () => beforeExecute?.Invoke(loc);

            this.PerformActionAndAssertResult(expectation, prepareAction, before);
        }
    }
}
