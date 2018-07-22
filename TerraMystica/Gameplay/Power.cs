namespace TerraMystica.Gameplay
{
    using System;
    using System.Globalization;
    using BoardGame;
    using TerraMystica.Resources;

    internal class Power : IResource
    {
        private int powerCache = 12;
        private int bowl1 = 7;
        private int bowl2 = 5;
        private int bowl3 = 0;

        /// <summary>
        /// Creates the standard bowls of power
        /// Total: 12
        /// Bowl I: 7
        /// Bowl II: 5
        /// Bowl III: 0
        /// </summary>
        public Power()
            : this(12, 7)
        {
        }

        /// <summary>
        /// Creates specialized bowls of power
        /// Total: 12
        /// Bowl I: Provieded Value
        /// Bowl II: 12 - Bowl I
        /// </summary>
        /// <param name="bowl1">The starting amount of power in bowl I</param>
        public Power(int bowl1)
            : this(12, bowl1)
        {
        }

        /// <summary>
        /// Creates customized bowls of power
        /// Total: Total provided
        /// Bowl I: Provided value
        /// Bowl II: Total Provided - Bowl I
        /// </summary>
        /// <param name="total">The starting total amount of power</param>
        /// <param name="bowl1">The starting amount of power in bowl I</param>
        public Power(int total, int bowl1)
        {
            if(total < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(total), Exceptions.NegativeValueNotAllowed);
            }

            if (bowl1 < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(total), Exceptions.NegativeValueNotAllowed);
            }

            this.powerCache = total;
            if (bowl1 > this.powerCache)
            {
                throw new ArgumentOutOfRangeException(nameof(bowl1), string.Format(CultureInfo.CurrentCulture, Exceptions.PowerInBowlExceedsTotal, 1, this.powerCache));
            }

            this.bowl1 = bowl1;
            this.bowl2 = this.powerCache - bowl1;
        }

        public int Total { get { return this.powerCache; } }

        public int Usable { get { return this.bowl3; } }

        public int Burnable { get { return this.bowl2; } }

        public int Charging { get { return this.bowl1; } }

        public int Amount => Usable + Burnable; 

        public string Name { get; } = GameStrings.Power;

        public bool CanUse(int power)
        {
            return this.Usable + this.Burnable >= power;
        }

        public int AmountNeededToBurnToUse(int power)
        {
            var diff = this.Usable - power;
            return diff >= 0 ? 0 : -diff;
        }

        public void Use(int power)
        {
            if(!this.CanUse(power))
            {
                throw new InvalidOperationException(string.Format(Exceptions.NeedMorePower, power, this.Usable + this.Burnable));
            }

            var diff = this.Usable - power;
            if(diff >= 0)
            {
                this.bowl3 = diff;
                this.bowl1 += power;
            }
            else
            {
                this.bowl1 += this.bowl3;
                this.bowl3 = 0;
                this.bowl2 += diff; // Note diff is negative
            }

            this.powerCache = this.bowl1 + this.bowl2 + this.bowl3;
        }

        public void Gain(int power)
        {
            if (power < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(power), Exceptions.NegativeValueNotAllowed);
            }

            if (power != 0 && this.bowl1 != 0)
            {
                var d = this.bowl1 - power;
                if (d >= 0)
                {
                    this.bowl2 += power;
                    this.bowl1 = d;
                    power = 0;
                }
                else
                {
                    this.bowl2 += Math.Min(power + d, this.bowl1);
                    this.bowl1 = 0;
                    power = -d;
                }
            }

            if (power != 0 && this.bowl2 != 0)
            {
                var d = this.bowl2 - power;
                if (d >= 0)
                {
                    this.bowl2 = d;
                    this.bowl3 += power;
                }
                else
                {
                    this.bowl2 = 0;
                    this.bowl3 += Math.Min(power + d, this.powerCache);
                }
            }
        }

        public void Add(int value)
        {
            this.Gain(value);
        }

        public void Remove(int value)
        {
            this.Use(value);
        }

        public static Power operator +(Power p, int power)
        {
            p.Gain(power);
            return p;
        }
    }
}
