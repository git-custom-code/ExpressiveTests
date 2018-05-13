namespace CustomCode.Test.BehaviorDrivenDevelopment.Tests
{
    using System;
    using Xunit;
    using Xunit.Sdk;

    /// <summary>
    /// Test cases for the <see cref="EnumInverseValidator{T}"/> type.
    /// </summary>
    [UnitTest]
    [Category("Assert", "EnumValidation")]
    public sealed class EnumInversValidatorTest
    {
        #region enum.NotBe()

        [Fact(DisplayName = "enum.NotBe(enum)")]
        public void ValidateEnumNotToBeValue()
        {
            // Given
            var validator = new EnumInverseValidator<StringComparison>(StringComparison.Ordinal);

            // When
            validator.Be(StringComparison.InvariantCulture);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "enum.NotBe(other)")]
        public void ValidateEnumNotToBeValueViolated()
        {
            // Given
            var validator = new EnumInverseValidator<StringComparison>(StringComparison.Ordinal);

            // When
            var exception = Assert.Throws<XunitException>(() => validator.Be(StringComparison.Ordinal, "that's the bottom line"));

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is \"{StringComparison.Ordinal}\"{rn}but was expected not to be \"{StringComparison.Ordinal}\"{rn}because that's the bottom line",
                exception.UserMessage);
        }

        #endregion
    }
}