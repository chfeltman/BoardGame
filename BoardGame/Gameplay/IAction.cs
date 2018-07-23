namespace BoardGame.Gameplay
{
    public interface IAction
    {
        Cost ActionCost { get; }
        Decision CanExecute();
        void Execute();
    }
}
