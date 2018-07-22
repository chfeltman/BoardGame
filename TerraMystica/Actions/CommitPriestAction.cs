namespace TerraMystica.Actions
{
    using System;
    using System.Linq;
    using BoardGame.Gameplay;
    using Resources;
    using TerraMystica.Gameplay;
    using TerraMystica.Gameplay.Cults;
    using TerraMystica.Player;
    using TerraMystica.Util;

    internal class CommitPriestAction : TerraMysticaAction
    {
        public CommitPriestAction(TerraMysticaPlayer player, CultTrack track, PriestSlot slot) 
            : base(player)
        {
            if(track == null)
            {
                throw new ArgumentNullException(nameof(track));
            }

            if(slot == null)
            {
                throw new ArgumentNullException(nameof(slot));
            }

            this.CultTrack = track;
            this.Slot = slot;
        }

        public CultTrack CultTrack { get; }

        public PriestSlot Slot { get; }

        public override Cost ActionCost => new Cost(this.Slot.PermanentCost, new PriestResource(1));

        public override Decision CanExecute()
        {
            Decision decision;
            if(this.Slot.Used)
            {
                decision = Decision.False(Exceptions.CannotCommitPriestUsedSlot);
            }
            else if(!this.CultTrack.UsableSlots.Contains(this.Slot, PriestSlot.Comparer))
            {
                decision = Decision.False(Exceptions.CannotCommitPriestSlotNotFound);
            }
            else
            {
                decision = base.CanExecute();
            }

            return decision;
        }

        protected override void ExecuteAction()
        {
            var priestSlot = this.CultTrack.UsableSlots.First(s => PriestSlot.Comparer.Equals(s, this.Slot));
            var cultValue = priestSlot.Use();

            var allResources = this.Player.Resources.AllResources;
            var cultResource = this.Player.Resources.CultResources.ResourceForType(this.CultTrack.Type);

            var previousAmount = cultResource.Amount;
            foreach (var bonus in this.CultTrack.Bonuses.Where(b => b.TargetValue > previousAmount && b.TargetValue <= previousAmount + cultValue))
            {
                if(allResources.ContainsKey(bonus.Boon.Name))
                {
                    allResources[bonus.Boon.Name].Add(bonus.Boon.Amount);
                }
            }

            cultResource.Add(cultValue);

        }
    }
}
