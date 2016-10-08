namespace Test.ExpressiveTests
{
    using global::ExpressiveTests;
    using Xunit;

    public class ShouldExtensionsTest
    {
        [Fact(DisplayName = "string.Should()")]
        public void UseShouldExtensionWithStrings()
        {
            var @string = "string";

            var validator = @string.Should();

            Assert.NotNull(validator);
            Assert.IsType<StringValidator>(validator);
        }
    }
}