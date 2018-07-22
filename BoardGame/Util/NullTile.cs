namespace BoardGame.Util
{
    public class NullTile : Tile
    {
        public NullTile(ILocation location) : 
            base()
        {
            this.Location = location;
        }
    }
}
