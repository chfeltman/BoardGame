namespace TerraMystica.Terrain
{
    using System;
    using BoardGame.Util;

    [Flags]
    public enum TerrainType
    {
        [EnumName("V")]
        Void,

        [EnumName("L")]
        Lake,

        [EnumName("S")]
        Swamp,

        [EnumName("P")]
        Plain,

        [EnumName("D")]
        Desert,

        [EnumName("W")]
        Wasteland,

        [EnumName("M")]
        Mountain,

        [EnumName("F")]
        Forest,

        [EnumName("R")]
        River,
    }
}
