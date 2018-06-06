namespace CustomCode.Test.BehaviorDrivenDevelopment.Tests
{
    using System;
    using Xunit;
    using Xunit.Sdk;

    /// <summary>
    /// Test cases for the <see cref="EnumValidator{T}"/> type.
    /// </summary>
    [UnitTest]
    [Category("Assert", "EnumValidation")]
    public sealed class EnumValidatorTest
    {
        #region enum.Be()

        [Fact(DisplayName = "enum.Be(enum)")]
        public void ValidateEnumToBeValue()
        {
            // Given
            var validator = new EnumValidator<StringComparison>(StringComparison.Ordinal);

            // When
            validator.Be(StringComparison.Ordinal);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "enum.Be(other)")]
        public void ValidateEnumToBeValueViolated()
        {
            // Given
            var validator = new EnumValidator<StringComparison>(StringComparison.Ordinal);

            // When
            var exception = Assert.Throws<XunitException>(() => validator.Be(StringComparison.InvariantCulture, "that's the bottom line"));

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is \"{StringComparison.Ordinal}\"{rn}but was expected to be \"{StringComparison.InvariantCulture}\"{rn}because that's the bottom line",
                exception.UserMessage);
        }

        #endregion
    }
}