namespace BoardGame.Gameplay
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Cost
    {
        public static CostComparer Comparer = new CostComparer();

        public static Cost Free = new Cost(Enumerable.Empty<IReadOnlyResource>());

        public Cost(IEnumerable<IReadOnlyResource> resources, bool permanent = false)
        {
            this.Resources = resources.ToArray();
            this.Permanent = permanent;
        }

        public Cost(params IReadOnlyResource[] resources) 
            : this(false, resources)
        { }

        public Cost(bool permanent, params IReadOnlyResource[] resources)
        {
            this.Resources = resources;
            this.Permanent = permanent;
        }

        public IEnumerable<IReadOnlyResource> Resources { get; }

        public bool Permanent { get; }

        public class CostComparer : IEqualityComparer<Cost>
        {
            public bool Equals(Cost x, Cost y)
            {
                return x.Resources.All(r => y.Resources.Any(c => string.Equals(c.Name, r.Name, StringComparison.OrdinalIgnoreCase) && c.Amount == r.Amount));
            }

            public int GetHashCode(Cost obj)
            {
                return obj.Resources
                            .OrderBy(r => r.Name)
                            .Select(r => r.Amount)
                            .Aggregate((prev, curr) => prev ^ curr.GetHashCode());
            }
        }
    }
}
