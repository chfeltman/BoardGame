namespace TerraMysticaUnitTests.Actions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TerraMystica.Actions;
    using TerraMystica.Gameplay;
    using TerraMystica.Gameplay.Cults;

    [TestClass]
    public class CommitPriestActionTests : ActionTests
    {
        public override void ModifyPlayerBeforeTest()
        {
            this.Player.Resources.Priests.Add(1);
        }

        [TestMethod]
        public void CommitPriest_Success()
        {
            this.CommitAndAssertSuccess();
        }

        [TestMethod]
        public void CommitPriest_PlayerBonus()
        {
            this.CommitAndAssertSuccess(track => this.Player.Resources.Power.Add(7));
            this.Player.Resources.Power.Usable.ShouldBeEquivalentTo(1);
            this.Player.Resources.CultResources.Water.Amount.ShouldBeEquivalentTo(3);
        }

        [TestMethod]
        public void CommitPriest_CannotAfford()
        {
            this.CommitAndAssertFailure(track => this.Player.Resources.Priests.Remove(1));
        }

        [TestMethod]
        public void CommitPriest_SlotUsed()
        {
            var targetSlot = new PriestSlot(2, true);
            this.CommitAndAssertFailure(track => track.UsableSlots.ElementAt(0).Use(), 
            slots: new[] { targetSlot }, 
            target: targetSlot);
        }

        [TestMethod]
        public void CommitPriest_SlotMissing()
        {
            this.CommitAndAssertFailure(target: new PriestSlot(1234, false));
        }

        private void CommitAndAssertFailure(Action<CultTrack> beforeExecute = null, CultTrack track = null, IEnumerable<PriestSlot> slots = null, PriestSlot target = null)
        {
            this.CommitAndAssertResult(false, beforeExecute, track, slots, target);
        }

        private void CommitAndAssertSuccess(Action<CultTrack> beforeExecute = null, CultTrack track = null, IEnumerable<PriestSlot> slots = null, PriestSlot target = null)
        {
            this.CommitAndAssertResult(true, beforeExecute, track, slots, target);
        }

        private void CommitAndAssertResult(bool expectation, Action<CultTrack> beforeExecute = null, CultTrack track = null, IEnumerable<PriestSlot> slots = null, PriestSlot target = null)
        {
            var priestSlots = slots ?? new[] { new PriestSlot(3, true) };
            var cultTrack = track ?? new WaterCultTrack(slots, new[] { new CultTrackBonus(3, new PowerResource(1)) });

            Func<TerraMysticaAction> prepareAction = () => new CommitPriestAction(this.Player, cultTrack, target ?? priestSlots.ElementAt(0));
            Action before = () => beforeExecute?.Invoke(cultTrack);

            this.PerformActionAndAssertResult(expectation, prepareAction, before);
        }
    }
}
