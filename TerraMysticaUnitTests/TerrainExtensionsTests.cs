namespace TerraMysticaUnitTests
{
    using System;
    using TerraMystica.Terrain;
    using TerraMystica.Util;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using FluentAssertions;

    [TestClass]
    public class TerrainExtensionsTests
    {
        [TestMethod]
        public void TestSpadeCost()
        {
            TerrainType.Desert.SpadeCost(TerrainType.Wasteland).ShouldBeEquivalentTo(1);
            TerrainType.Lake.SpadeCost(TerrainType.Wasteland).ShouldBeEquivalentTo(3);
        }
    }
}
