namespace TerraMystica.Gameplay.Cults
{
    using System.Collections.Generic;
    using System.Linq;
    using BoardGame;
    using BoardGame.Util;

    internal class TerraMysticaCultTrackResources
    {
        private ResourceCollection<ICultTrackResource> resources;

        public TerraMysticaCultTrackResources(int fire, int water, int earth, int wind)
        {
            this.resources = new ResourceCollection<ICultTrackResource>()
            {
                new FireCultResource(fire),
                new WaterCultResource(water),
                new EarthCultResource(earth),
                new WindCultResource(wind)
            };
        }

        public ICultTrackResource Fire => this.resources[FireCultResource.Key];

        public ICultTrackResource Water => this.resources[WaterCultResource.Key];

        public ICultTrackResource Earth => this.resources[EarthCultResource.Key];

        public ICultTrackResource Wind => this.resources[WindCultResource.Key];

        public IReadOnlyDictionary<string, IResource> AllResources => this.resources.ToDictionary(r => r.Name, r => r as IResource);
    }
}
