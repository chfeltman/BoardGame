namespace BoardGame.Gameplay
{
    public class Decision
    {
        private Decision(bool result, string reason)
        {
            this.Result = result; 
            this.Reason = reason;
        }

        public bool Result { get; }

        public string Reason { get; }

        public static Decision False(string reason = null)
        {
            return new Decision(false, reason ?? string.Empty);
        }

        public static Decision True(string reason = null)
        {
            return new Decision(true, reason ?? string.Empty);
        }
    }
}
