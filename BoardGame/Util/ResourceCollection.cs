namespace BoardGame.Util
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
   
    public class ResourceCollection<T> : KeyedCollection<string, T> where T : IResource
    {
        protected override string GetKeyForItem(T item)
        {
            return item.Name;
        }

        public void AddRange(IEnumerable<T> items)
        {
            foreach(var item in items)
            {
                this.Add(item);
            }
        }
    }
}
