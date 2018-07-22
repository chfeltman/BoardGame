namespace TerraMystica.Util
{
    using System.Collections.Generic;
    using System.Linq;
    using BoardGame;
    using TerraMystica.Player;

    internal static class TerraMysticaPlayerExtensions
    {
        public static bool CanAfford(this TerraMysticaPlayer player, IEnumerable<IReadOnlyResource> cost)
        {
            return cost.All(c =>
                player.Resources.AllResources.ContainsKey(c.Name) &&
                player.Resources.AllResources[c.Name].Amount >= c.Amount);
        }
    }
}
