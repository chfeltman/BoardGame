namespace TestUtil
{
    using BoardGame.Gameplay;
    using FluentAssertions;

    public static class FluentAssertionsExtensions
    {
        public static void ShouldBeHaveResult(this Decision desision, bool value)
        {
            desision.Result.ShouldBeEquivalentTo(value, "Reason for failure: {0}", value ? desision.Reason : "Unexpected success!");
        }
    }
}
