namespace BoardGame
{
    public interface IResource : IReadOnlyResource
    {
        void Add(int value);

        void Remove(int value);
    }
}
