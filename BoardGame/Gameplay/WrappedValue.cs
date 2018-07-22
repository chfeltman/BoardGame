namespace BoardGame.Gameplay
{
    public class WrappedValue<T>
    {
        public WrappedValue(T value)
        {
            this.Value = value;
        }

        public virtual T Value { get; set; }
    }
}
