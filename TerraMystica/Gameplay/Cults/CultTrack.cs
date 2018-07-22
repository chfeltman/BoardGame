namespace TerraMystica.Gameplay.Cults
{
    using System.Collections.Generic;
    using System.Linq;

    internal abstract class CultTrack
    {
        public static IReadOnlyList<PriestSlot> DefaultSlots
        {
            get
            {
                return new List<PriestSlot>
                {
                    new PriestSlot(3, true),
                    new PriestSlot(2, true),
                    new PriestSlot(2, true),
                    new PriestSlot(2, true),
                };
            }
        }

        public static IReadOnlyList<CultTrackBonus> DefaultBonuses
        {
            get
            {
                return new List<CultTrackBonus>
                {
                    new CultTrackBonus(2, new PowerResource(1)),
                    new CultTrackBonus(4, new PowerResource(1)),
                    new CultTrackBonus(6, new PowerResource(2)),
                    new CultTrackBonus(8, new PowerResource(2)),
                    new CultTrackBonus(10, new PowerResource(3)),
                };
            }
        }

        private IEnumerable<PriestSlot> slots;

        protected CultTrack(IEnumerable<PriestSlot> priestSlots = null, IEnumerable<CultTrackBonus> bonuses = null)
        {
            this.slots = priestSlots?.ToList() ?? DefaultSlots;
            this.Bonuses = bonuses?.ToList() ?? DefaultBonuses;
        }

        public abstract CultType Type { get; }

        public IEnumerable<CultTrackBonus> Bonuses { get; }

        public IEnumerable<PriestSlot> UsableSlots => this.slots.Where(s => !s.Used);
    }

    internal class WaterCultTrack : CultTrack
    {
        public WaterCultTrack(IEnumerable<PriestSlot> priestSlots = null, IEnumerable<CultTrackBonus> bonuses = null)
            : base(priestSlots, bonuses)
        {
        }

        public override CultType Type => CultType.Water;
    }

    internal class WindCultTrack : CultTrack
    {
        public WindCultTrack(IEnumerable<PriestSlot> priestSlots = null, IEnumerable<CultTrackBonus> bonuses = null)
            : base(priestSlots, bonuses)
        {
        }

        public override CultType Type => CultType.Wind;
    }

    internal class FireCultTrack : CultTrack
    {
        public FireCultTrack(IEnumerable<PriestSlot> priestSlots = null, IEnumerable<CultTrackBonus> bonuses = null)
            : base(priestSlots, bonuses)
        {
        }

        public override CultType Type => CultType.Fire;
    }

    internal class EarthCultTrack : CultTrack
    {
        public EarthCultTrack(IEnumerable<PriestSlot> priestSlots = null, IEnumerable<CultTrackBonus> bonuses = null)
            : base(priestSlots, bonuses)
        {
        }

        public override CultType Type => CultType.Earth;
    }
}
