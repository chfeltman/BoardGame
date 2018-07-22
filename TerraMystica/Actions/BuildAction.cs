namespace TerraMystica.Actions
{
    using System;
    using BoardGame;
    using BoardGame.Gameplay;
    using TerraMystica.Gameplay;
    using TerraMystica.Terrain;
    using TerraMystica.Player;
    using TerraMystica.Resources;
    using TerraMystica.Util;

    internal class BuildAction : TerraMysticaAction
    {
        public BuildAction(IBoard<TerraTile> board, TerraMysticaPlayer player, ILocation location)
            : base(player)
        {
            if (board == null)
            {
                throw new ArgumentNullException(nameof(board));
            }

            if (location == null)
            {
                throw new ArgumentNullException(nameof(location));
            }

            if (player == null)
            {
                throw new ArgumentNullException(nameof(player));
            }

            this.Board = board;
            this.Location = location;
        }

        public ILocation Location { get; private set; }

        public IBoard<TerraTile> Board { get; private set; }

        public override Cost ActionCost => this.Player.Race.DwellingCost;

        public override Decision CanExecute()
        {
            Decision decision;
            var tile = this.Board.TileForLocation(this.Location);
            if(!tile.Type.HasFlag(this.Player?.Race?.HomeTerrain))
            {
                decision = Decision.False(Exceptions.CannotBuildNotHomeTerrain);
            }
            else if(tile.Owner != null)
            {
                decision = Decision.False(Exceptions.CannotBuildOwned);
            }
            else if (tile.Building != null)
            {
                decision = Decision.False(Exceptions.CannotBuildExistingBuilding);
            }
            else
            {
                decision = base.CanExecute();
            }

            return decision;
        }

        protected override void ExecuteAction()
        {
            var tile = this.Board.TileForLocation(this.Location);
            tile.Building = new Building(BuildingType.Dwelling, this.Location);
            tile.Owner = this.Player;
        }
    }
}
