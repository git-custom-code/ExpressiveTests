namespace CustomCode.Test.BehaviorDrivenDevelopment.Tests
{
    using System;
    using Xunit;
    using Xunit.Sdk;

    /// <summary>
    /// Test cases for the <see cref="NullableValidator{T}"/> type.
    /// </summary>
    [UnitTest]
    [Category("Assert", "NullableValidation")]
    public sealed class NullableValidatorTest
    {
        #region Nullable.BeNull()

        [Fact(DisplayName = "((T?)null).BeNull()")]
        public void ValidateNullableToBeNull()
        {
            // Given
            var validator = new NullableValidator<int>(null);

            // When
            validator.BeNull();

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "((T?)0).BeNull()")]
        public void ValidateNullableToBeNullViolated()
        {
            // Given
            var validator = new NullableValidator<int>(0);

            // When
            var exception = Assert.Throws<XunitException>(() => validator.BeNull());

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is \"0\"{rn}but was expected to be null",
                exception.UserMessage);
        }

        [Fact(DisplayName = "((T?)0).BeNull(reason)")]
        public void ValidateNullableToBeNullWithReasonViolated()
        {
            // Given
            var validator = new NullableValidator<int>(0);

            // When
            var exception = Assert.Throws<XunitException>(() => validator.BeNull("that's the bottom line"));

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is \"0\"{rn}but was expected to be null{rn}because that's the bottom line",
                exception.UserMessage);
        }

        #endregion
    }
}