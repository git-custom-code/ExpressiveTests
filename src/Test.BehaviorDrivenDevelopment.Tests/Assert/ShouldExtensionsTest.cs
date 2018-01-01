namespace CustomCode.Test.BehaviorDrivenDevelopment.Tests
{
    using Xunit;

    /// <summary>
    /// Test cases for the <see cref="ShouldExtensions"/> type.
    /// </summary>
    [UnitTest]
    [Category("Assert")]
    public sealed class ShouldExtensionsTest
    {
        [Fact(DisplayName = "string.Should()")]
        [Category("Should")]
        public void UseShouldExtensionWithStrings()
        {
            // Given
            var @string = "string";

            // When
            var validator = @string.Should();

            // Then
            Assert.NotNull(validator);
            Assert.IsType<StringValidator>(validator);
        }

        [Fact(DisplayName = "string.ShouldNot()")]
        [Category("ShouldNot")]
        public void UseShouldNotExtensionWithStrings()
        {
            // Given
            var @string = "string";

            // When
            var validator = @string.ShouldNot();

            // Then
            Assert.NotNull(validator);
            Assert.IsType<StringInverseValidator>(validator);
        }
    }
}