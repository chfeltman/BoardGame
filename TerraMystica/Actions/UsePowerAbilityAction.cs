namespace TerraMystica.Actions
{
    using System;
    using BoardGame.Gameplay;
    using TerraMystica.Player;
    using TerraMystica.Gameplay.PowerAbility;

    internal class UsePowerAbilityAction : TerraMysticaAction
    {
        public UsePowerAbilityAction(TerraMysticaPlayer player, IPowerAbility ability) : base(player)
        {
            if(player == null)
            {
                throw new ArgumentNullException(nameof(player));
            }

            if(ability == null)
            {
                throw new ArgumentNullException(nameof(ability));
            }

            this.Ability = ability;
        }

        public IPowerAbility Ability { get; }

        public override Cost ActionCost => this.Ability.Cost;

        public override Decision CanExecute()
        {
            var decision = this.Ability.CanExecute();

            if(decision.Result)
            {
                decision = base.CanExecute();
            }

            return decision;
        }

        protected override void ExecuteAction()
        {
            this.Ability.Execute();
        }
    }
}
