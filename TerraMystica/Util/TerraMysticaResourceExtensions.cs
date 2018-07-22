namespace TerraMystica.Util
{
    using System.Linq;
    using BoardGame;
    using BoardGame.Gameplay;
    using TerraMystica.Gameplay;
    using TerraMystica.Gameplay.Cults;

    internal static class TerraMysticaResourceExtensions
    {
        public static ICultTrackResource ResourceForType(this TerraMysticaCultTrackResources cultResources, CultType type)
        {
            return cultResources.AllResources.Values.First(r => (r as ICultTrackResource).Type == type) as ICultTrackResource;
        }

        public static Cost ToCost(this IReadOnlyResource resource)
        {
            return new Cost(resource);
        }
    }
}
