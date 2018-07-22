namespace CommandLineInterface.Display
{
    using System;
    using System.IO;
    using BoardGame.Util;
    using TerraMystica.Terrain;

    internal interface ITerrainTypeDisplay
    {
        TerrainType Type { get; }

        void Print();
    }

    internal abstract class TerrainTypeConsoleDisplay : ITerrainTypeDisplay
    {
        public abstract ConsoleColor ForegroundColor { get; }

        public abstract TerrainType Type { get; }

        public virtual void Print()
        {
            Console.ForegroundColor = this.ForegroundColor;
            Console.Write(EnumNameLookup<TerrainType>.Lookup(this.Type));
            Console.ResetColor();
        }
    }

    internal class LakeConsoleDisplay : TerrainTypeConsoleDisplay
    {
        public override ConsoleColor ForegroundColor => ConsoleColor.DarkBlue;

        public override TerrainType Type => TerrainType.Lake;
    }

    internal class SwampConsoleDisplay : TerrainTypeConsoleDisplay
    {
        public override ConsoleColor ForegroundColor => ConsoleColor.DarkGray;

        public override TerrainType Type => TerrainType.Swamp;
    }

    internal class PlainConsoleDisplay : TerrainTypeConsoleDisplay
    {
        public override ConsoleColor ForegroundColor => ConsoleColor.DarkGreen;

        public override TerrainType Type => TerrainType.Plain;
    }

    internal class DesertConsoleDisplay : TerrainTypeConsoleDisplay
    {
        public override ConsoleColor ForegroundColor => ConsoleColor.Yellow;

        public override TerrainType Type => TerrainType.Desert;
    }

    internal class WastelandConsoleDisplay : TerrainTypeConsoleDisplay
    {
        public override ConsoleColor ForegroundColor => ConsoleColor.DarkRed;

        public override TerrainType Type => TerrainType.Wasteland;
    }

    internal class MountainConsoleDisplay : TerrainTypeConsoleDisplay
    {
        public override ConsoleColor ForegroundColor => ConsoleColor.Gray;

        public override TerrainType Type => TerrainType.Mountain;
    }

    internal class ForestConsoleDisplay : TerrainTypeConsoleDisplay
    {
        public override ConsoleColor ForegroundColor => ConsoleColor.Green;

        public override TerrainType Type => TerrainType.Forest;
    }

    internal class RiverConsoleDisplay : TerrainTypeConsoleDisplay
    {
        public override ConsoleColor ForegroundColor => ConsoleColor.Blue;

        public override TerrainType Type => TerrainType.River;
    }

    internal class VoidConsoleDisplay : TerrainTypeConsoleDisplay
    {
        public override ConsoleColor ForegroundColor => ConsoleColor.Black;

        public override TerrainType Type => TerrainType.Void;

        public override void Print()
        {
            Console.Write(" ");
        }
    }
}
