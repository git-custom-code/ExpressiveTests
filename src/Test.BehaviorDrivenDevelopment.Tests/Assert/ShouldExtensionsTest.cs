namespace CustomCode.Test.BehaviorDrivenDevelopment.Tests
{
    using Xunit;

    /// <summary>
    /// Test cases for the <see cref="ShouldExtensions"/> type.
    /// </summary>
    public sealed class ShouldExtensionsTest
    {
        [UnitTest]
        [Fact(DisplayName = "string.Should()")]
        public void UseShouldExtensionWithStrings()
        {
            var @string = "string";

            var validator = @string.Should();

            Assert.NotNull(validator);
            Assert.IsType<StringValidator>(validator);
        }

        [UnitTest]
        [Fact(DisplayName = "string.ShouldNot()")]
        public void UseShouldNotExtensionWithStrings()
        {
            var @string = "string";

            var validator = @string.ShouldNot();

            Assert.NotNull(validator);
            Assert.IsType<StringInverseValidator>(validator);
        }
    }
}