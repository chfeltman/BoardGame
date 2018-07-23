namespace CommandLineInterface.Util
{
    using System;

    internal class ColoredConsolePrint : IPrint
    {
        public ColoredConsolePrint(ConsoleColor foregroundColor)
        {
            this.ForegroundColor = foregroundColor;
        }

        public ConsoleColor ForegroundColor { get; set; }

        public virtual void Print()
        {
            Console.ForegroundColor = this.ForegroundColor;
            Console.Write(this.GetText());
            Console.ResetColor();
        }

        public virtual string GetText() => string.Empty;
    }
}
