namespace CommandLineInterface.Display
{
    using System;
    using TerraMystica.Terrain;
    using Util;

    internal abstract class TerrainTypeDisplay : EnumNameDisplay<TerrainType>
    {
        protected TerrainTypeDisplay(ConsoleColor foregroundColor) : base(foregroundColor) { }
    }

    internal class LakeTerrainDisplay : TerrainTypeDisplay
    {
        public LakeTerrainDisplay() : base(ConsoleColor.DarkBlue) { }

        public override TerrainType Type => TerrainType.Lake;
    }

    internal class SwampTerrainDisplay : TerrainTypeDisplay
    {
        public SwampTerrainDisplay() : base(ConsoleColor.DarkGray) { }

        public override TerrainType Type => TerrainType.Swamp;
    }

    internal class PlainTerrainDisplay : TerrainTypeDisplay
    {
        public PlainTerrainDisplay() : base(ConsoleColor.DarkGreen) { }

        public override TerrainType Type => TerrainType.Plain;
    }

    internal class DesertTerrainDisplay : TerrainTypeDisplay
    {
        public DesertTerrainDisplay() : base(ConsoleColor.Yellow) { }

        public override TerrainType Type => TerrainType.Desert;
    }

    internal class WastelandTerrainDisplay : TerrainTypeDisplay
    {
        public WastelandTerrainDisplay() : base(ConsoleColor.DarkRed) { }

        public override TerrainType Type => TerrainType.Wasteland;
    }

    internal class MountainTerrainDisplay : TerrainTypeDisplay
    {
        public MountainTerrainDisplay() : base(ConsoleColor.Gray) { }

        public override TerrainType Type => TerrainType.Mountain;
    }

    internal class ForestTerrainDisplay : TerrainTypeDisplay
    {
        public ForestTerrainDisplay() : base(ConsoleColor.Green) { }

        public override TerrainType Type => TerrainType.Forest;
    }

    internal class RiverTerrainDisplay : TerrainTypeDisplay
    {
        public RiverTerrainDisplay() : base(ConsoleColor.Blue) { }

        public override TerrainType Type => TerrainType.River;
    }

    internal class VoidTerrainDisplay : TerrainTypeDisplay
    {
        public VoidTerrainDisplay() : base(ConsoleColor.Black) { }

        public override TerrainType Type => TerrainType.Void;

        public override void Print()
        {
            Console.Write(" ");
        }
    }
}
