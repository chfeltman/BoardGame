namespace BoardGame.Util
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class EnumNameLookup<T>
    {
        private static Dictionary<object, string> lookup = new Dictionary<object, string>();

        static EnumNameLookup()
        {
            var type = typeof(T);
            var values = Enum.GetValues(type);
            foreach (var value in values)
            {
                var member = type.GetMember(Enum.GetName(type, value));
                var attr = member[0].GetCustomAttributes(typeof(EnumName), false);

                if (!lookup.ContainsKey(value))
                {
                    lookup.Add(value, ((EnumName)attr[0]).Name);
                }
            }
        }

        public static string Lookup(T key)
        {
            if(EnumNameLookup<T>.lookup.ContainsKey(key))
            {
                return lookup[key];
            }

            return key.ToString();
        }

        public static T ReverseLookup(string value)
        {
            T key = default(T);
            if(EnumNameLookup<T>.lookup.ContainsValue(value))
            {
                key = (T)EnumNameLookup<T>.lookup.First(p => p.Value == value).Key;
            }

            return key;
        }
    }
}
