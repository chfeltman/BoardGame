namespace CommandLineInterface.Util
{
    using System;
    using BoardGame.Util;

    internal abstract class EnumNameDisplay<TEnum> : ColoredConsolePrint
    {
        public EnumNameDisplay(ConsoleColor foregroundColor) : base(foregroundColor) { }

        public abstract TEnum Type { get; }

        public override string GetText() => EnumNameLookup<TEnum>.Lookup(this.Type);
    }
}
