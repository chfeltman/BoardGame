namespace BoardGame.Util
{
    using System.Collections.Generic;
    using System.Linq;
    using BoardGame.Coordinates;

    public static class HexTileBuilder
    {
        /// <summary>
        /// Generates a hexagonal grid of tiles using a zig-zag layout pattern
        /// 
        /// height
        /// ^ 0 1 2 
        /// |  3 4 5
        /// | 6 7 8
        /// --> Width
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tileContent"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        public static IEnumerable<T> CreateHexGrid<T>(int width, int height, params T[] tileContent) where T : ITile
        {
            if (!tileContent.Any())
                return Enumerable.Empty<T>();

            var grid = new List<T>();

            for(int i = 0; i < height; i++)
            {
                var start = -(i / 2); // row location starts at 0 for 2 rows, then -1, then -2, etc
                var end = width + start; // Keep the same 'width' of each row
                for(int j = start; j < end; j++)
                {
                    var currContentPos = (i * width) + (j - start);
                    var location = new HexLocation(j, i);
                    T tile = default(T);
                    if (tileContent.Length > currContentPos)
                    {
                        tileContent[currContentPos].Location = location;
                        tile = tileContent[currContentPos];
                    }

                    grid.Add(tile);
                }
            }

            return grid;
        }
    }
}
