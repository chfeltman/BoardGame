namespace TerraMystica.Actions
{
    using BoardGame.Gameplay;

    interface IAction
    {
        Cost ActionCost { get; }
        Decision CanExecute();
        void Execute();
    }
}
