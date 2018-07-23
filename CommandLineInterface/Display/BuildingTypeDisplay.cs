namespace CommandLineInterface.Display
{
    using System;
    using TerraMystica.Gameplay;
    using Util;

    internal abstract class BuildingTypeDisplay : EnumNameDisplay<BuildingType>
    {
        protected BuildingTypeDisplay(ConsoleColor foregroundColor) : base(foregroundColor) { }

        public override void Print()
        {
            Console.BackgroundColor = ConsoleColor.White;
            base.Print();
        }
    }

    internal class DwellingBuildingDisplay : BuildingTypeDisplay
    {
        public DwellingBuildingDisplay(ConsoleColor foreground) : base(foreground) { }

        public override BuildingType Type => BuildingType.Dwelling;
    }

    internal class TradingHouseBuildingDisplay : BuildingTypeDisplay
    {
        public TradingHouseBuildingDisplay(ConsoleColor foreground) : base(foreground) { }

        public override BuildingType Type => BuildingType.TradingHouse;
    }

    internal class TempleBuildingDisplay : BuildingTypeDisplay
    {
        public TempleBuildingDisplay(ConsoleColor foreground) : base(foreground) { }

        public override BuildingType Type => BuildingType.Temple;
    }

    internal class StrongHoldBuildingDisplay : BuildingTypeDisplay
    {
        public StrongHoldBuildingDisplay(ConsoleColor foreground) : base(foreground) { }

        public override BuildingType Type => BuildingType.StrongHold;
    }

    internal class SanctuaryBuildingDisplay : BuildingTypeDisplay
    {
        public SanctuaryBuildingDisplay(ConsoleColor foreground) : base(foreground) { }

        public override BuildingType Type => BuildingType.Sanctuary;
    }

    internal class VoidBuildingDisplay : BuildingTypeDisplay
    {
        public VoidBuildingDisplay() : base(ConsoleColor.Black) { }

        public override BuildingType Type => BuildingType.Void;

        public override void Print()
        {
            Console.Write(" ");
        }
    }
}
