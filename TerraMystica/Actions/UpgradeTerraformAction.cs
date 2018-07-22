namespace TerraMystica.Actions
{
    using System;
    using BoardGame.Gameplay;
    using TerraMystica.Player;
    using TerraMystica.Resources;

    internal class UpgradeTerraformAction : TerraMysticaAction
    {
        public UpgradeTerraformAction(TerraMysticaPlayer player) : base(player)
        {
        }

        public override Cost ActionCost => this.Player.Race.SpadeUpgradeCost;

        public override Decision CanExecute()
        {
            var decision = Decision.True();
            if (Cost.Comparer.Equals(this.Player.Race.SpadeCost, this.Player.Race.MinSpadeCost))
            {
                decision = Decision.False(Exceptions.CannotUpgradeSpadePastMin);
            }
            else
            {
                decision = base.CanExecute();
            }

            return decision;
        }

        protected override void ExecuteAction()
        {
            this.Player.Race.UpgradeSpadeCost();
        }
    }
}
