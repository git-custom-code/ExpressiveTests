namespace CustomCode.Test.BehaviorDrivenDevelopment.Tests
{
    using System;
    using Xunit;
    using Xunit.Sdk;

    /// <summary>
    /// Test cases for the <see cref="NullableInverseValidator{T}"/> type.
    /// </summary>
    [UnitTest]
    [Category("Assert", "NullableValidation")]
    public sealed class NullableInverseValidatorTest
    {
        #region Nullable.BeNull()

        [Fact(DisplayName = "((T?)null).NotBeNull()")]
        public void ValidateNullableNotToBeNull()
        {
            // Given
            var validator = new NullableInverseValidator<int>(0);

            // When
            validator.BeNull();

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "((T?)0).NotBeNull()")]
        public void ValidateNullableNotToBeNullViolated()
        {
            // Given
            var validator = new NullableValidator<int>(null);

            // When
            var exception = Assert.Throws<XunitException>(() => validator.BeNull());

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is \"0\"{rn}but was expected to be null",
                exception.UserMessage);
        }

        [Fact(DisplayName = "((T?)0).NotBeNull(reason)")]
        public void ValidateNullableNotToBeNullWithReasonViolated()
        {
            // Given
            var validator = new NullableValidator<int>(null);

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