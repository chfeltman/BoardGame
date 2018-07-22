namespace TerraMystica.Races
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using BoardGame;
    using BoardGame.Gameplay;
    using TerraMystica.Gameplay;
    using TerraMystica.Gameplay.Cults;
    using TerraMystica.Terrain;

    internal abstract class Race
    {
        public virtual Cost SpadeCost { get; protected set; } = new Cost(new WorkerResource(3));

        public virtual Cost SpadeUpgradeCost { get; } = new Cost(new PriestResource(1), new GoldResource(5), new WorkerResource(2));

        public virtual int ShippingDistance { get; protected set; } = 0;

        public virtual Cost ShippingUpgradeCost { get; } = new Cost(new PriestResource(1), new GoldResource(4));

        public virtual Cost DwellingCost { get; protected set; } = new Cost(new WorkerResource(1), new GoldResource(2));

        public virtual int StartingGold => 15;

        public virtual int StartingWorkers => 3;

        public virtual int StartingPriests => 0;

        public virtual int StartingDwellings => 2;

        public virtual int StartingTotalPower => 12;

        public virtual int StartingBowlIPower => 7;

        public abstract TerraMysticaCultTrackResources StartingCultResources { get; }

        public virtual int MaxDwellings => 8;

        public virtual int MaxTradingHouses => 4;

        public virtual int MaxTemples => 3;

        public virtual int MaxStrongHolds => 1;

        public virtual int MaxSanctuaries => 1;

        public virtual int MaxShippingDistance => 4;

        public virtual int MaxPriests => 7;

        public virtual int MaxBridges => 3;

        public virtual Cost MinSpadeCost => new Cost(new WorkerResource(1));

        public abstract string Name { get; }

        public abstract TerrainType HomeTerrain { get; }

        public abstract IEnumerable<BuildingUpgrade> UpgradeOptions(Building building, IBoard<TerraTile> board);

        public virtual IEnumerable<IReadOnlyResource> Upkeep(IEnumerable<Building> placedBuildings)
        {
            var dwellingsPlaced = placedBuildings.Where(b => b.Type == BuildingType.Dwelling).Count();
            var tradingHousesPlaced = placedBuildings.Where(b => b.Type == BuildingType.TradingHouse).Count();
            var templesPlaced = placedBuildings.Where(b => b.Type == BuildingType.Temple).Count();
            var sanctuariesPlaced = placedBuildings.Where(b => b.Type == BuildingType.Sanctuary).Count();
            var strongHoldsPlaced = placedBuildings.Where(b => b.Type == BuildingType.Dwelling).Count();

            return new List<IReadOnlyResource>()
            {
                new WorkerResource(1 + dwellingsPlaced),
                new GoldResource(tradingHousesPlaced * 2),
                new PriestResource(templesPlaced + sanctuariesPlaced),
                new PowerResource((int)Math.Ceiling(tradingHousesPlaced / 2.0) + (strongHoldsPlaced * 4)),
            };
        }

        public virtual void UpgradeShippingDistance()
        {
            if(this.ShippingDistance != this.MaxShippingDistance)
            {
                this.ShippingDistance += 1;
            }
        }

        public virtual void UpgradeSpadeCost()
        {
            if(!Cost.Comparer.Equals(this.SpadeCost, this.MinSpadeCost))
            {
                var currentWorkerCost = this.SpadeCost.Resources.Single().Amount;
                this.SpadeCost = new Cost(new WorkerResource(currentWorkerCost - 1));
            }
        }

        public virtual void UpgradeBuilding(Building building, BuildingUpgrade upgrade)
        {
            building.Type = upgrade.NewType;
        }
    }
}
