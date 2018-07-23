namespace CommandLineInterface.Display
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    internal sealed class MenuDisplay
    {
        public MenuDisplay(TextWriter writer, IEnumerable<MenuOption> options)
        {
            this.Writer = writer;

            var counter = 1;
            this.Options = options.ToDictionary(o => counter++);
        }

        public TextWriter Writer { get; }

        public IReadOnlyDictionary<int, MenuOption> Options { get; }

        public void PrintMenu()
        {
            Writer.WriteLine("Options:");

            foreach(var option in this.Options)
            {
                Writer.WriteLine($"[{option.Key}]: {option.Value.Name}");
            }
        }
    }

    internal class MenuOption
    {
        public MenuOption(string name)
        {
            this.Name = name;
        }

        public string Name { get; }
    }

}
