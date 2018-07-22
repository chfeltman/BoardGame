namespace TerraMysticaUnitTests.TestResources
{
    using System.Collections.Generic;
    using BoardGame;
    using BoardGame.Gameplay;
    using TerraMystica.Gameplay;
    using TerraMystica.Gameplay.Cults;
    using TerraMystica.Races;
    using TerraMystica.Terrain;

    internal class TestRace : Race
    {
        public new Cost SpadeCost
        {
            get { return base.SpadeCost; }
            set { base.SpadeCost = value; }
        }

        public Cost TestSpadeUpgradeCost { get; set; } = new Cost(new PriestResource(1), new GoldResource(5), new WorkerResource(2));
        public override Cost SpadeUpgradeCost => this.TestSpadeUpgradeCost;

        public new int ShippingDistance
        {
            get { return base.ShippingDistance; }
            set { base.ShippingDistance = value; }
        }

        public Cost TestShippingUpgradeCost { get; set; } = new Cost(new PriestResource(1), new GoldResource(4));
        public override Cost ShippingUpgradeCost => this.TestShippingUpgradeCost;

        public new Cost DwellingCost
        {
            get { return base.DwellingCost; }
            set { base.DwellingCost = value; }
        }

        public override int StartingGold => 0;
        
        public override int StartingWorkers => 0;

        public override int StartingPriests => 0;

        public override int StartingDwellings => 0;

        public int TestStartingTotalPower { get; set; } = 12;
        public override int StartingTotalPower => this.TestStartingTotalPower;

        public int TestStartingBowlIPower { get; set; } = 7;
        public override int StartingBowlIPower => this.TestStartingBowlIPower;

        public override TerraMysticaCultTrackResources StartingCultResources { get; } = new TerraMysticaCultTrackResources(0, 0, 0, 0);

        public int TestMaxDwellings { get; set; } = 8;
        public override int MaxDwellings => this.TestMaxDwellings;

        public int TestMaxTradingHouses { get; set; } = 4;
        public override int MaxTradingHouses => this.TestMaxTradingHouses;

        public int TestMaxTemples { get; set; } = 3;
        public override int MaxTemples => this.TestMaxTemples;

        public int TestMaxStrongHolds { get; set; } = 1;
        public override int MaxStrongHolds => this.TestMaxStrongHolds;

        public int TestMaxSanctuaries { get; set; } = 1;
        public override int MaxSanctuaries => this.TestMaxSanctuaries;

        public int TestMaxShippingDistance { get; set; } = 4;
        public override int MaxShippingDistance => this.TestMaxShippingDistance;

        public int TestMaxPriests { get; set; } = 7;
        public override int MaxPriests => this.TestMaxPriests;

        public int TestMaxBridges { get; set; } = 3;
        public override int MaxBridges => this.TestMaxBridges;

        public Cost TestMinSpadeCost { get; set; } = new Cost(new WorkerResource(1));
        public override Cost MinSpadeCost => this.TestMinSpadeCost;

        public string TestName { get; set; }
        public override string Name => this.TestName;

        public TerrainType TestHomeTerrain { get; set; } = TerrainType.Lake;
        public override TerrainType HomeTerrain => this.TestHomeTerrain;

        public IEnumerable<BuildingUpgrade> TestUpgradeOptions { get; set; } = new List<BuildingUpgrade>
        {
            new BuildingUpgrade(BuildingType.Dwelling, new Cost(new GoldResource(1), new WorkerResource(2))),
        };

        public override IEnumerable<BuildingUpgrade> UpgradeOptions(Building building, IBoard<TerraTile> board)
        {
            return this.TestUpgradeOptions;
        }
    }
}
