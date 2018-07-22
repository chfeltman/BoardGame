namespace TerraMystica.Gameplay.Cults
{
    using System;
    using System.Collections.Generic;
    using BoardGame.Gameplay;

    internal class PriestSlot : UsableValue<int>
    {
        public static PriestSlotComparer Comparer = new PriestSlotComparer();

        public PriestSlot(int value, bool permanentCost) 
            : base(value)
        {
            this.PermanentCost = permanentCost;
        }

        public bool PermanentCost { get; }

        internal class PriestSlotComparer : IEqualityComparer<PriestSlot>
        {
            public bool Equals(PriestSlot x, PriestSlot y)
            {
                return x.Value == y.Value && x.Used == y.Used;
            }

            public int GetHashCode(PriestSlot obj)
            {
                return obj.Value ^ (obj.Used ? 1 : 0);
            }
        }
    }
}
