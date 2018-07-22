namespace CommandLineInterface
{
    using System;
    using Display;

    class Program
    {
        static void Main(string[] args)
        {
            var board = new DemoBuilder().Build();
            var writer = Console.Out;
            var tileDisplay = new TileDisplay(new ITerrainTypeDisplay[]
            {
                new LakeConsoleDisplay(),
                new SwampConsoleDisplay(),
                new PlainConsoleDisplay(),
                new ForestConsoleDisplay(),
                new MountainConsoleDisplay(),
                new WastelandConsoleDisplay(),
                new DesertConsoleDisplay(),
                new RiverConsoleDisplay(),
                new VoidConsoleDisplay(),
            });

            var boardDisplay = new BoardDisplay(writer, tileDisplay);

            boardDisplay.PrintHeader = true;
            boardDisplay.PrintBoard(board);
        }
    }
}
