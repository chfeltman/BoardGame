namespace TerraMysticaUnitTests
{
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using FluentAssertions;
    using BoardGame;
    using BoardGame.Coordinates;
    using BoardGame.Gameplay;
    using BoardGame.Util;
    using TerraMystica.Gameplay;
    using TerraMystica.Util;
    using TerraMystica.Terrain;
    using TerraMystica.Races;
    using TerraMysticaUnitTests.TestResources;

    [TestClass]
    public class RaceTests
    {
        private IPlayer Player = new TestPlayer("P1", new Mermaids());
        private IBoard<TerraTile> Board { get; set; }

        [TestInitialize]
        public void TestInitialize()
        {
            var r =
            " L L L L  " +
            "  L L L L " +
            " L L L L  ";

            this.Board = new Board<TerraTile>()
            {
                Tiles = HexTileBuilder.CreateHexGrid(4, 3, r.Parse().ToArray()),
            };

            foreach(var tile in this.Board.Tiles)
            {
                tile.Owner = Player;
            }
        }

        [TestMethod]
        public void TestMermaidBuildingUpgrades()
        {
            var merms = new Mermaids();
            var dwelling = new Building(BuildingType.Dwelling, new HexLocation(1, 1));
            var tradingHouse = new Building(BuildingType.TradingHouse, new HexLocation(1, 1));
            var temple = new Building(BuildingType.Temple, new HexLocation(1, 1));

            merms.UpgradeOptions(dwelling, this.Board)
                .ShouldBeEquivalentTo(new[] { new BuildingUpgrade(BuildingType.TradingHouse, new Cost(new GoldResource(6), new WorkerResource(2))) });

            merms.UpgradeOptions(tradingHouse, this.Board)
                .ShouldBeEquivalentTo(new[] 
                {
                    new BuildingUpgrade(BuildingType.Temple, new Cost(new GoldResource(5), new WorkerResource(2))),
                    new BuildingUpgrade(BuildingType.StrongHold, new Cost(new GoldResource(6), new WorkerResource(4)))
                });

            merms.UpgradeOptions(temple, this.Board)
                .ShouldBeEquivalentTo(new[] 
                {
                    new BuildingUpgrade(BuildingType.Sanctuary, new Cost(new GoldResource(8), new WorkerResource(4)))
                });
        }
    }
}
