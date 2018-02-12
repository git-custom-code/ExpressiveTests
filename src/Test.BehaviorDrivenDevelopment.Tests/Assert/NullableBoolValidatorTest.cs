namespace CustomCode.Test.BehaviorDrivenDevelopment.Tests
{
    using System;
    using Xunit;
    using Xunit.Sdk;

    /// <summary>
    /// Test cases for the <see cref="NullableBoolValidator"/> type.
    /// </summary>
    [UnitTest]
    [Category("Assert", "BooleanValidation")]
    public sealed class NullableBoolValidatorTest
    {
        #region bool?.Be()

        [Fact(DisplayName = "bool?.Be(bool?)")]
        public void ValidateBooleanToBeValue()
        {
            // Given
            var validator = new NullableBoolValidator(true);

            // When
            validator.Be(true);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "bool?.Be(null)")]
        public void ValidateBooleanToBeNull()
        {
            // Given
            var validator = new NullableBoolValidator(null);

            // When
            validator.Be(null);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "bool?.Be(other)")]
        public void ValidateBooleanToBeValueViolated()
        {
            // Given
            var validator = new NullableBoolValidator(true);

            // When
            var exception = Assert.Throws<XunitException>(() => validator.Be(false, "that's the bottom line"));

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is \"True\"{rn}but was expected to be \"False\"{rn}because that's the bottom line",
                exception.UserMessage);
        }

        #endregion

        #region bool?.BeFalse()

        [Fact(DisplayName = "bool?.BeFalse()")]
        public void ValidateBooleanToBeFalse()
        {
            // Given
            var validator = new NullableBoolValidator(false);

            // When
            validator.BeFalse();

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "bool?.BeFalse()")]
        public void ValidateBooleanToBeFalseViolated()
        {
            // Given
            var validator = new NullableBoolValidator(true);

            // When
            var exception = Assert.Throws<XunitException>(() => validator.BeFalse(because: "that's the bottom line"));

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is \"True\"{rn}but was expected to be false{rn}because that's the bottom line",
                exception.UserMessage);
        }

        [Fact(DisplayName = "bool?.BeFalse()")]
        public void ValidateNullableBooleanToBeFalseViolated()
        {
            // Given
            var validator = new NullableBoolValidator(null);

            // When
            var exception = Assert.Throws<XunitException>(() => validator.BeFalse(because: "that's the bottom line"));

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is \"\"{rn}but was expected to be false{rn}because that's the bottom line",
                exception.UserMessage);
        }

        #endregion

        #region bool?.BeNull()

        [Fact(DisplayName = "bool?.BeNull()")]
        public void ValidateNullableToBeNull()
        {
            // Given
            var validator = new NullableBoolValidator(null);

            // When
            validator.BeNull();

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "bool?.BeNull(reason)")]
        public void ValidateNullableToBeNullWithReasonViolated()
        {
            // Given
            var validator = new NullableBoolValidator(true);

            // When
            var exception = Assert.Throws<XunitException>(() => validator.BeNull("that's the bottom line"));

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is \"True\"{rn}but was expected to be null{rn}because that's the bottom line",
                exception.UserMessage);
        }

        #endregion

        #region bool?.BeTrue()

        [Fact(DisplayName = "bool?.BeTrue()")]
        public void ValidateBooleanToBeTrue()
        {
            // Given
            var validator = new NullableBoolValidator(true);

            // When
            validator.BeTrue();

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "bool?.BeTrue()")]
        public void ValidateBooleanToBeTrueViolated()
        {
            // Given
            var validator = new NullableBoolValidator(false);

            // When
            var exception = Assert.Throws<XunitException>(() => validator.BeTrue(because: "that's the bottom line"));

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is \"False\"{rn}but was expected to be true{rn}because that's the bottom line",
                exception.UserMessage);
        }

        [Fact(DisplayName = "bool?.BeTrue()")]
        public void ValidateNullableBooleanToBeTrueViolated()
        {
            // Given
            var validator = new NullableBoolValidator(null);

            // When
            var exception = Assert.Throws<XunitException>(() => validator.BeTrue(because: "that's the bottom line"));

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is \"\"{rn}but was expected to be true{rn}because that's the bottom line",
                exception.UserMessage);
        }

        #endregion
    }
}