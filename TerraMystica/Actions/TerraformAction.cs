namespace TerraMystica.Actions
{
    using System;
    using BoardGame;
    using BoardGame.Gameplay;
    using TerraMystica.Gameplay;
    using TerraMystica.Player;
    using TerraMystica.Terrain;
    using TerraMystica.Resources;
    using TerraMystica.Util;

    internal class TerraformAction : TerraMysticaAction
    {
        public TerraformAction(IBoard<TerraTile> board, TerraMysticaPlayer player, ILocation location, TerrainType target)
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

            if (target == TerrainType.Void)
            {
                throw new InvalidOperationException(string.Format(Exceptions.InvalidVoidTerraform));
            }

            this.Board = board;
            this.Location = location;
            this.Target = target;
        }

        public ILocation Location { get; }

        public IBoard<TerraTile> Board { get; }

        public TerrainType Target { get; }

        public override Cost ActionCost => new Cost(new SpadeResource(this.Board.TileForLocation(this.Location).Type.SpadeCost(this.Target)));

        public override Decision CanExecute()
        {
            Decision decision;
            var tile = this.Board.TileForLocation(this.Location);
            if(tile.Owner != null)
            {
                decision = Decision.False(Exceptions.CannotTerraformOwned);
            }
            else if(tile.Type.HasFlag(this.Target))
            {
                decision = Decision.False(Exceptions.CannotTerraformSameType);
            }
            else if(!this.Player.CanAfford(this.ActionCost.Resources))
            {
                decision = Decision.False(Exceptions.CannotAfford);
            }
            else
            {
                decision = base.CanExecute();
            }

            return decision;
        }

        protected override void ExecuteAction()
        {
            this.Board.TileForLocation(this.Location).Type = this.Target;
        }   
    }
}
