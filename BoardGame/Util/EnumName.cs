namespace BoardGame.Util
{
    using System;

    [AttributeUsage(AttributeTargets.All)]
    public class EnumName : Attribute
    {
        public object Type { get; set; }

        public string Name { get; set; }

        public EnumName(string name)
        {
            this.Name = name;
        }
    }
}
