namespace BoardGame.Gameplay.Control
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class TurnBasedControl<T> where T : class, IPlayer
    {
        private T[] players;

        public TurnBasedControl(IEnumerable<T> players)
        {
            if(players == null)
            {
                throw new ArgumentNullException(nameof(players));
            }

            if(players.Count() == 0)
            {
                throw new ArgumentException("Player count must be at least 1");
            }

            this.players = players.ToArray();

            this.PreviousPlayer = null;
            this.CurrentPlayer = this.players[0];
        }

        public IEnumerable<T> Players => this.players;

        public virtual IEnumerable<T> TurnOrder()
        {
            return this.Players;
        }

        public virtual T PreviousPlayer { get; protected set; }

        public virtual T CurrentPlayer { get; protected set; }

        public virtual T NextPlayer
        {
            get
            {
                int index;
                var count = this.players.Count();
                for(index = 0; index < count; index++)
                {
                    if(this.players[index] == this.CurrentPlayer)
                    {
                        index++;
                        break;
                    }
                }

                index = index % count;

                return this.players[index];
            }
        }

        public virtual void MoveToNextPlayer()
        {
            this.PreviousPlayer = this.CurrentPlayer;
            this.CurrentPlayer = this.NextPlayer;
        }
    }
}
