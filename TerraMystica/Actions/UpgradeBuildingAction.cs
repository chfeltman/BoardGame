namespace TerraMystica.Actions
{
    using System;
    using BoardGame;
    using BoardGame.Gameplay;
    using TerraMystica.Gameplay;
    using TerraMystica.Terrain;
    using TerraMystica.Player;
    using TerraMystica.Resources;

    internal class UpgradeBuildingAction : TerraMysticaAction
    {
        public UpgradeBuildingAction(IBoard<TerraTile> board, TerraMysticaPlayer player, Building building, BuildingUpgrade upgrade)
            : base(player)
        {
            if (board == null)
            {
                throw new ArgumentNullException(nameof(board));
            }

            if (building == null)
            {
                throw new ArgumentNullException(nameof(building));
            }

            if(upgrade == null)
            {
                throw new ArgumentNullException(nameof(upgrade));
            }

            this.Board = board;
            this.Building = building;
            this.Upgrade = upgrade;
        }

        public IBoard<TerraTile> Board { get; private set; }

        public Building Building { get; private set; }

        public BuildingUpgrade Upgrade { get; private set; }

        public override Cost ActionCost => this.Upgrade.Cost;

        public override Decision CanExecute()
        {
            Decision decision;
            var tile = this.Board.TileForLocation(this.Building.Location);
            if (tile?.Building == null)
            {
                decision = Decision.False(Exceptions.CannotUpgradeBuildingNotFound);
            }
            else if (tile.Owner != this.Player)
            {
                decision = Decision.False(Exceptions.OwnedByOtherPlayer);
            }
            else
            {
                decision = base.CanExecute();
            }

            return decision;
        }

        protected override void ExecuteAction()
        {
            this.Player.Race.UpgradeBuilding(this.Building, this.Upgrade);
        }
    }
}
