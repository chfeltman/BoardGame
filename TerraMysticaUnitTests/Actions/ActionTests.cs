namespace TerraMysticaUnitTests.Actions
{
    using System;
    using System.Linq;
    using BoardGame;
    using BoardGame.Util;
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TerraMystica.Actions;
    using TerraMystica.Player;
    using TerraMystica.Races;
    using TerraMystica.Terrain;
    using TerraMystica.Util;
    using TestResources;
    using TestUtil;

    [TestClass]
    public class ActionTests
    {
        internal TestPlayer Player { get; set; }
        internal IBoard<TerraTile> Board { get; set; }
        internal TestRace Race { get; set; }

        [TestInitialize]
        public void TestInitialize()
        {
            var r =
            " L L L L  " +
            "  L L L L " +
            " L L L L  ";

            this.Race = new TestRace();

            this.ModifyRaceBeforeTest();

            this.Player = new TestPlayer(race: this.Race);

            this.Board = new Board<TerraTile>()
            {
                Tiles = HexTileBuilder.CreateHexGrid(4, 3, r.Parse().ToArray()),
            };

            this.ModifyPlayerBeforeTest();
        }

        public virtual void ModifyRaceBeforeTest()
        {
        }

        public virtual void ModifyPlayerBeforeTest()
        {
        }

        internal void PerformActionAndAssertResult(bool expectation, Func<TerraMysticaAction> prepareAction, Action beforeExecute = null)
        {
            var action = prepareAction();
            beforeExecute?.Invoke();

            action.CanExecute().ShouldBeHaveResult(expectation);

            if (expectation)
            {
                action.Execute();
            }
            else
            {
                Action a = () => action.Execute();
                a.ShouldThrow<InvalidOperationException>();
            }
        }
    }
}
