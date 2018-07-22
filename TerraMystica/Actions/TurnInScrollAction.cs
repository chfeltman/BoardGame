namespace TerraMystica.Actions
{
    using System;
    using BoardGame.Gameplay;
    using TerraMystica.Player;
    using TerraMystica.Resources;
    using TerraMystica.Gameplay.Scrolls;

    internal class TurnInScrollAction : TerraMysticaAction
    {
        public TurnInScrollAction(TerraMysticaPlayer player, ITerraMysticaScroll scroll)
            : base(player)
        {
            if(scroll == null)
            {
                throw new ArgumentNullException(nameof(scroll));
            }

            this.Scroll = scroll;
        }

        public ITerraMysticaScroll Scroll { get; }

        public override Cost ActionCost => Cost.Free;

        public override Decision CanExecute()
        {
            return this.Player.HasPassed ? Decision.False(Exceptions.CannotTurnInScrollIfPassed) : Decision.True();
        }

        protected override void ExecuteAction()
        {
            this.Scroll.TurnInAction();
        }
    }
}
