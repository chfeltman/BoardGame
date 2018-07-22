namespace BoardGame
{
    public interface IReadOnlyResource
    {
        string Name { get; }

        int Amount { get; }
    }
}
