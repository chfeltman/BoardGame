namespace CommandLineInterface.Display
{
    using System.IO;

    internal class TextDisplay
    {
        public TextDisplay(TextWriter writer)
        {
            this.Writer = writer;
        }

        public TextWriter Writer { get; }
    }
}
