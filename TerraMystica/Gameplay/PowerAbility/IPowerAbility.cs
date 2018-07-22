namespace TerraMystica.Gameplay.PowerAbility
{
    using BoardGame.Gameplay;

    interface IPowerAbility
    {
        bool Used { get; }

        Cost Cost { get; }

        Decision CanExecute();

        void Execute();
    }
}
