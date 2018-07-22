namespace TerraMystica.Util
{
    using System;
    using System.Collections.Generic;
    using TerraMystica.Terrain;

    public static class TerrainExtensions
    {
        private static Dictionary<TerrainType, int> terraformMap = new Dictionary<TerrainType, int>()
        {
            { TerrainType.Desert, 0},
            { TerrainType.Plain, 1},
            { TerrainType.Swamp, 2},
            { TerrainType.Lake, 3},
            { TerrainType.Forest, 4},
            { TerrainType.Mountain, 5},
            { TerrainType.Wasteland, 6},
        };

        public static int SpadeCost(this TerrainType fromType, TerrainType toType)
        {
            var direct = Math.Abs(terraformMap[fromType] - terraformMap[toType]);
            var indirect = terraformMap.Count - direct;
            return Math.Min(direct, indirect);
        }
    }
}
