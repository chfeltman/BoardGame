namespace TerraMystica.Util
{
    using System.Collections.Generic;
    using BoardGame.Util;
    using TerraMystica.Terrain;

    internal static class StringExtensions
    {
        public static IEnumerable<TerraTile> Parse(this string tileString)
        {
            var types = tileString.Split();
            foreach(var type in types)
            {
                if(!string.IsNullOrWhiteSpace(type))
                {
                    yield return new TerraTile()
                    {
                        Type = EnumNameLookup<TerrainType>.ReverseLookup(type.Trim())
                    };
                }
            }
        }
    }
}
