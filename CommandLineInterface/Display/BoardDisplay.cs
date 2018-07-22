namespace CommandLineInterface.Display
{
    using System;
    using System.IO;
    using System.Linq;
    using BoardGame;
    using TerraMystica.Terrain;

    internal class BoardDisplay : TextDisplay
    {
        public BoardDisplay(TextWriter writer, TileDisplay tileDisplay) 
            : base(writer)
        {
            this.TileDisplay = tileDisplay;
        }

        public TileDisplay TileDisplay { get; }

        public bool PrintHeader { get; set; }

        public void PrintBoard(IBoard<TerraTile> board)
        {
            if(this.PrintHeader)
            {
                Writer.WriteLine("Board Width: " + board.Width);
                Writer.WriteLine("Board Height: " + board.Height);
            }

            var rows = board.Tiles.Select(t => Tuple.Create(t.Location.Y, t))
                            .GroupBy(t => t.Item1)
                            .OrderBy(t => t.Key);

            for (int i = 0; i < rows.Count(); i++)
            {
                if (i % 2 == 1)
                {
                    Writer.Write(" ");
                }

                var row = rows.ElementAt(i).Select(t => t.Item2).OrderBy(t => t.Location.X);
                for (int j = 0; j < row.Count(); j++)
                {
                    var tile = row.ElementAt(j);
                    if (tile != null)
                    {
                        this.TileDisplay.PrintTile(tile);
                    }
                    else
                    {
                        Writer.Write(" ");
                    }

                    Writer.Write(" ");
                }

                Writer.WriteLine();
            }
        }
    }
}
