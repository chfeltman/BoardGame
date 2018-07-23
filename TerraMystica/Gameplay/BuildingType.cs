namespace TerraMystica.Gameplay
{
    using BoardGame.Util;

    public enum BuildingType
    {
        [EnumName("v")]
        Void,

        [EnumName("d")]
        Dwelling,

        [EnumName("r")]
        TradingHouse,

        [EnumName("t")]
        Temple,

        [EnumName("h")]
        StrongHold,

        [EnumName("s")]
        Sanctuary,
    }
}
