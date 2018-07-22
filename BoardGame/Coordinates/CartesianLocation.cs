namespace BoardGame.Coordinates
{
    public class CartesianLocation : ILocation
    {
        public CartesianLocation(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public int X { get; }

        public int Y { get; }

        public override bool Equals(object obj)
        {
            var cart = obj as CartesianLocation;
            if (cart == null)
                return false;

            return cart.X == this.X && cart.Y == this.Y;
        }

        public override int GetHashCode()
        {
            return this.X ^ this.Y ^ base.GetHashCode();
        }
    }
}
