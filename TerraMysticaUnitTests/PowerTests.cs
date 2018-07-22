namespace TerraMysticaUnitTests
{
    using TerraMystica.Gameplay;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using FluentAssertions;

    [TestClass]
    public class PowerTests
    {
        [TestMethod]
        public void TestBowlsOfPowerCreate()
        {
            var p1 = new Power();
            var p2 = new Power(9);
            var p3 = new Power(200, 150);
            p1.Total.ShouldBeEquivalentTo(12);
            p1.Charging.ShouldBeEquivalentTo(7);
            p1.Burnable.ShouldBeEquivalentTo(5);
            p1.Usable.ShouldBeEquivalentTo(0);

            p2.Total.ShouldBeEquivalentTo(12);
            p2.Charging.ShouldBeEquivalentTo(9);
            p2.Burnable.ShouldBeEquivalentTo(3);
            p2.Usable.ShouldBeEquivalentTo(0);

            p3.Total.ShouldBeEquivalentTo(200);
            p3.Charging.ShouldBeEquivalentTo(150);
            p3.Burnable.ShouldBeEquivalentTo(50);
            p3.Usable.ShouldBeEquivalentTo(0);
        }

        [TestMethod]
        public void TestPowerMovement()
        {
            var p = new Power();
            p += 1;
            p.Charging.ShouldBeEquivalentTo(6);
            p.Burnable.ShouldBeEquivalentTo(6);

            p += 12;
            p.Charging.ShouldBeEquivalentTo(0);
            p.Burnable.ShouldBeEquivalentTo(6);
            p.Usable.ShouldBeEquivalentTo(6);

            p += 12;
            p.Burnable.ShouldBeEquivalentTo(0);
            p.Usable.ShouldBeEquivalentTo(12);

            p += 123456;
            p.Usable.ShouldBeEquivalentTo(12);

            p = new Power();
            p += 123456;
            p.Charging.ShouldBeEquivalentTo(0);
            p.Burnable.ShouldBeEquivalentTo(0);
            p.Usable.ShouldBeEquivalentTo(12);
        }

        [TestMethod]
        public void TestPowerCanUse()
        {
            var p = new Power();
            p += 100;

            var r = p.CanUse(100);
            r.ShouldBeEquivalentTo(false);
            r = p.CanUse(12);
            r.ShouldBeEquivalentTo(true);
        }

        [TestMethod]
        public void TestPowerBurnCheck()
        {
            var p = new Power();
            p += 24;

            var r = p.AmountNeededToBurnToUse(100);
            r.ShouldBeEquivalentTo(88);
        }

        [TestMethod]
        public void TestPowerUse_Success()
        {
            var p = new Power();
            p += 19;

            p.Total.ShouldBeEquivalentTo(12);
            p.Use(12);
            p.Total.ShouldBeEquivalentTo(12);
            p.Usable.ShouldBeEquivalentTo(0);
            p.Burnable.ShouldBeEquivalentTo(0);
            p.Charging.ShouldBeEquivalentTo(12);
        }

        [TestMethod, ExpectedException(typeof(System.InvalidOperationException))]
        public void TestPowerUse_Failure()
        {
            var p = new Power();
            p += 19;
            p.Use(24);
        }

        [TestMethod]
        public void TestPowerUse_Burn()
        {
            var p = new Power();
            p += 13;
            p.Use(8);

            p.Total.ShouldBeEquivalentTo(10);
            p.Usable.ShouldBeEquivalentTo(0);
            p.Burnable.ShouldBeEquivalentTo(4);
            p.Charging.ShouldBeEquivalentTo(6);
        }
    }
}
