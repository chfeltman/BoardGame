namespace TerraMystica.Actions
{
    using System;
    using BoardGame.Gameplay;
    using TerraMystica.Player;
    using TerraMystica.Resources;

    internal class UpgradeShippingAction : TerraMysticaAction
    {
        public UpgradeShippingAction(TerraMysticaPlayer player) 
            : base(player)
        {
        }

        public override Cost ActionCost => this.Player.Race.ShippingUpgradeCost;

        public override Decision CanExecute()
        {
            var decision = Decision.True();
            if(this.Player.Race.ShippingDistance == this.Player.Race.MaxShippingDistance)
            {
                decision = Decision.False(Exceptions.CannotUpgradeShippingPastMax);
            }
            else
            {
                decision = base.CanExecute();
            }

            return decision;
        }

        protected override void ExecuteAction()
        {
            this.Player.Race.UpgradeShippingDistance();
        }
    }
}
