namespace BoardGame.Coordinates
{
    public class HexLocation : CartesianLocation
    {
        public HexLocation(int x, int y)
            : base(x, y)
        {
        }

        public int Z { get { return -(this.X + this.Y); } }

        public override bool Equals(object obj)
        {
            var hex = obj as HexLocation;
            if (hex == null)
                return false;

            return hex.Z == this.Z && base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return this.Z ^ base.GetHashCode();
        }
    }
}
