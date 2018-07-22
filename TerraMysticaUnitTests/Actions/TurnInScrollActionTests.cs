namespace TerraMysticaUnitTests.Actions
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TerraMystica.Actions;
    using TestResources;

    [TestClass]
    public class TurnInScrollActionTests : ActionTests
    {
        [TestMethod]
        public void TestTurnIn_Success()
        {
            this.TurnInAndAssertSuccess();
        }

        [TestMethod]
        public void TestTurnIn_PlayerHasPassed()
        {
            this.TurnInAndAssertFailure(() => this.Player.HasPassed = true);
        }

        private void TurnInAndAssertSuccess(Action beforeExecute = null)
        {
            this.PerformActionAndAssertResult(true, () => new TurnInScrollAction(this.Player, new TestScroll()), beforeExecute);
        }

        private void TurnInAndAssertFailure(Action beforeExecute = null)
        {
            this.PerformActionAndAssertResult(false, () => new TurnInScrollAction(this.Player, new TestScroll()), beforeExecute);
        }
    }
}
