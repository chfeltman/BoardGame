namespace BoardGameUnitTests
{
    using System.Linq;
    using BoardGame.Gameplay.Control;
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TestResources;

    [TestClass]
    public class TurnBasedControlTests
    {
        [TestMethod]
        public void TestControl_OnePlayer()
        {
            var testPlayer = new TestPlayer();
            var control = new TurnBasedControl<TestPlayer>(new[] { testPlayer });

            control.Players.Should().HaveCount(1);

            control.PreviousPlayer.Should().BeNull();
            control.CurrentPlayer.Should().Be(testPlayer);
            control.NextPlayer.Should().Be(testPlayer);

            control.MoveToNextPlayer();
            control.PreviousPlayer.Should().Be(testPlayer);
            control.CurrentPlayer.Should().Be(testPlayer);
            control.NextPlayer.Should().Be(testPlayer);
        }

        [TestMethod]
        public void TestControl_TwoPlayers()
        {
            var testPlayer1 = new TestPlayer("P1");
            var testPlayer2 = new TestPlayer("P2");
            var order = new[] { testPlayer1, testPlayer2 };
            var control = new TurnBasedControl<TestPlayer>(order);

            control.Players.Should().HaveCount(order.Count());
            control.TurnOrder().ShouldAllBeEquivalentTo(order);

            control.PreviousPlayer.Should().BeNull();
            control.CurrentPlayer.Should().Be(testPlayer1);
            control.NextPlayer.Should().Be(testPlayer2);

            control.MoveToNextPlayer();
            control.PreviousPlayer.Should().Be(testPlayer1);
            control.CurrentPlayer.Should().Be(testPlayer2);
            control.NextPlayer.Should().Be(testPlayer1);

            control.MoveToNextPlayer();
            control.PreviousPlayer.Should().Be(testPlayer2);
            control.CurrentPlayer.Should().Be(testPlayer1);
            control.NextPlayer.Should().Be(testPlayer2);
        }

        [TestMethod]
        public void TestControl_MultiplePlayers()
        {
            var testPlayer1 = new TestPlayer("P1");
            var testPlayer2 = new TestPlayer("P2");
            var testPlayer3 = new TestPlayer("P3");
            var testPlayer4 = new TestPlayer("P4");
            var order = new[] { testPlayer1, testPlayer2, testPlayer3, testPlayer4 };
            var control = new TurnBasedControl<TestPlayer>(order);

            control.Players.Should().HaveCount(order.Count());
            control.TurnOrder().ShouldAllBeEquivalentTo(order);

            control.PreviousPlayer.Should().BeNull();
            control.CurrentPlayer.Should().Be(testPlayer1);
            control.NextPlayer.Should().Be(testPlayer2);

            control.MoveToNextPlayer();
            control.PreviousPlayer.Should().Be(testPlayer1);
            control.CurrentPlayer.Should().Be(testPlayer2);
            control.NextPlayer.Should().Be(testPlayer3);

            control.MoveToNextPlayer();
            control.PreviousPlayer.Should().Be(testPlayer2);
            control.CurrentPlayer.Should().Be(testPlayer3);
            control.NextPlayer.Should().Be(testPlayer4);

            control.MoveToNextPlayer();
            control.PreviousPlayer.Should().Be(testPlayer3);
            control.CurrentPlayer.Should().Be(testPlayer4);
            control.NextPlayer.Should().Be(testPlayer1);
        }
    }
}
