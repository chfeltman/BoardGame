namespace CommandLineInterface
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using BoardGame;
    using BoardGame.Coordinates;
    using Display;
    using TerraMystica.Actions;
    using TerraMystica.Player;
    using TerraMystica.Races;
    using TerraMystica.Terrain;
    using Util;

    class Program
    {
        public static IBoard<TerraTile> Board { get; set; }

        public static TextWriter Writer { get; set; }

        public static TileDisplay TileDisplay { get; set; }

        public static BoardDisplay BoardDisplay { get; set; }

        public static MenuDisplay MenuDisplay { get; set; }

        public static TerraMysticaPlayer Player { get; set; }

        static void Main(string[] args)
        {
            Board = new DemoBuilder().Build();
            Writer = Console.Out;
            TileDisplay= new TileDisplay(new DisplayFactory());

            BoardDisplay = new BoardDisplay(Writer, TileDisplay);

            MenuDisplay = new MenuDisplay(Writer, new List<MenuOption>
            {
                new MenuOption("Build"),
            });

            Player = new TerraMysticaPlayer("Player 1", new Mermaids());
            Player.Resources.Gold.Add(100);
            Player.Resources.Workers.Add(100);

            BoardDisplay.PrintHeader = true;
            PrintLoop();

            Console.WriteLine($"{Player.Name}, Build a damn Dwelling!");
            Console.ReadKey();

            Console.Clear();

            var tile = Board.TileForLocation(new HexLocation(3, 0));
            var buildAction = new BuildAction(Board, Player, tile.Location);

            buildAction.Execute();

            PrintLoop();
            Console.WriteLine($"Good, good. Now dance for me!");

            Console.ReadKey();
        }

        public static void PrintLoop()
        {
            BoardDisplay.PrintBoard(Board);
            MenuDisplay.PrintMenu();
            Console.WriteLine();
        }
    }
}
