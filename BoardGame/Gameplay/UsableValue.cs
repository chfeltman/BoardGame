namespace BoardGame.Gameplay
{
    public class UsableValue<T> : WrappedValue<T>
    {
        private bool refreshable;
        private T value;

        public UsableValue(T value, bool refreshable = false)
            : base(value)
        {
            this.refreshable = refreshable;
        }

        public bool Used { get; private set; }

        public override T Value
        {
            get
            {
                return this.Used ? this.DefaultValue : this.value;
            }
            set
            {
                this.value = value;
            }
        }

        public T Use()
        {
            var pVal = this.Value;
            this.Used = true;
            return pVal;
        }

        public void Refresh()
        {
            if(this.refreshable)
            {
                this.Used = false;
            }
        }

        protected virtual T DefaultValue => default(T);
    }
}
