namespace TerraMystica.Actions
{
    using System;
    using BoardGame.Gameplay;
    using TerraMystica.Player;
    using TerraMystica.Resources;
    using TerraMystica.Util;

    internal abstract class TerraMysticaAction : IAction
    {
        protected TerraMysticaAction(TerraMysticaPlayer player)
        {
            if(player == null)
            {
                throw new ArgumentNullException(nameof(player));
            }

            this.Player = player;
        }

        public TerraMysticaPlayer Player { get; }

        public abstract Cost ActionCost { get; }

        public virtual Decision CanExecute()
        {
            var decision = Decision.True();
            if(!this.Player.CanAfford(this.ActionCost.Resources))
            {
                decision = Decision.False(Exceptions.CannotAfford);
            }

            return decision;
        }

        public void Execute()
        {
            var decision = this.CanExecute();
            if (!decision.Result)
            {
                throw new InvalidOperationException(decision.Reason);
            }

            this.ExecuteAction();
        }

        protected abstract void ExecuteAction();
    }
}
