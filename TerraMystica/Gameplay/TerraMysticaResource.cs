namespace TerraMystica.Gameplay
{
    using BoardGame;
    using TerraMystica.Gameplay.Cults;
    using TerraMystica.Resources;

    internal abstract class TerraMysticaResource : IResource
    {
        public TerraMysticaResource(int amount, string name)
        {
            this.Amount = amount;
            this.Name = name;
        }

        public string Name { get; }

        public int Amount { get; protected set; }

        public virtual bool AllowNegative { get; } = false;

        public void Add(int value)
        {
            this.Amount += value;
        }

        public void Remove(int value)
        {
            if(!this.AllowNegative && this.Amount - value < 0)
            {
                value = this.Amount;
            }

            this.Amount -= value;
        }
    }

    internal class GoldResource : TerraMysticaResource
    {
        public static string Key = GameStrings.Gold;

        public GoldResource(int amount) : base(amount, Key) { }
    }

    internal class PriestResource : TerraMysticaResource
    {
        public static string Key = GameStrings.Priest;

        public PriestResource(int amount) : base(amount, Key) { }
    }

    internal class WorkerResource : TerraMysticaResource
    {
        public static string Key = GameStrings.Worker;

        public WorkerResource(int amount) : base(amount, Key) { }
    }

    internal class PowerResource : TerraMysticaResource
    {
        public static string Key = GameStrings.Power;

        public PowerResource(int amount) : base(amount, Key) { }
    }

    internal interface ICultTrackResource : IResource
    {
        CultType Type { get; }
    }

    internal class FireCultResource : TerraMysticaResource, ICultTrackResource
    {
        public static string Key = GameStrings.FireCult;

        public CultType Type => CultType.Fire;

        public FireCultResource(int amount) : base(amount, Key) { }
    }

    internal class WaterCultResource : TerraMysticaResource, ICultTrackResource
    {
        public static string Key = GameStrings.WaterCult;

        public CultType Type => CultType.Water;

        public WaterCultResource(int amount) : base(amount, Key) { }
    }

    internal class EarthCultResource : TerraMysticaResource, ICultTrackResource
    {
        public static string Key = GameStrings.EarthCult;

        public CultType Type => CultType.Earth;

        public EarthCultResource(int amount) : base(amount, Key) { }
    }

    internal class WindCultResource : TerraMysticaResource, ICultTrackResource
    {
        public static string Key = GameStrings.WindCult;

        public CultType Type => CultType.Wind;

        public WindCultResource(int amount) : base(amount, Key) { }
    }

    internal class SpadeResource : TerraMysticaResource
    {
        public static string Key = GameStrings.Spade;

        public SpadeResource(int amount) : base(amount, Key) { }
    }
}
