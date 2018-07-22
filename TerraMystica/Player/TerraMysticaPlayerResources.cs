namespace TerraMystica.Player
{
    using System.Collections.Generic;
    using System.Linq;
    using BoardGame;
    using BoardGame.Util;
    using TerraMystica.Gameplay;
    using TerraMystica.Gameplay.Cults;

    internal class TerraMysticaPlayerResources
    {
        private ResourceCollection<TerraMysticaResource> resources;

        public TerraMysticaPlayerResources(int gold, int workers, int priests, Power power, TerraMysticaCultTrackResources cultResources)
        {
            this.resources = new ResourceCollection<TerraMysticaResource>()
            {
                new GoldResource(gold),
                new WorkerResource(workers),
                new PriestResource(priests),
            };

            this.Power = power;
            this.CultResources = cultResources;
        }

        public TerraMysticaResource Gold => this.resources[GoldResource.Key];

        public TerraMysticaResource Workers => this.resources[WorkerResource.Key];

        public TerraMysticaResource Priests => this.resources[PriestResource.Key];

        public Power Power { get; }

        public TerraMysticaCultTrackResources CultResources { get; }

        public IReadOnlyDictionary<string, IResource> AllResources => this.resources
                            .Concat(new IResource[] { this.Power })
                            .Concat(this.CultResources.AllResources.Values)
                            .ToDictionary(s => s.Name);

        public void Add(params TerraMysticaResource[] resources)
        {
            foreach (var resource in resources)
            {
                if (!this.resources.Contains(resource.Name))
                {
                    this.resources.Add(resource);
                }
                else
                {
                    this.resources[resource.Name].Add(resource.Amount);
                }
            }
        }

        public void Remove(params TerraMysticaResource[] resources)
        {
            foreach (var resource in resources)
            {
                if (this.resources.Contains(resource.Name))
                {
                    this.resources[resource.Name].Remove(resource.Amount);
                }
            }
        }
    }
}
