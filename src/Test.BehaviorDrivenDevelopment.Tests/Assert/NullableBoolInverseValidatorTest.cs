namespace CustomCode.Test.BehaviorDrivenDevelopment.Tests
{
    using System;
    using Xunit;
    using Xunit.Sdk;

    /// <summary>
    /// Test cases for the <see cref="NullableBoolInverseValidator"/> type.
    /// </summary>
    [UnitTest]
    [Category("Assert", "BooleanValidation")]
    public sealed class NullableBoolInverseValidatorTest
    {
        #region bool?.NotBe()

        [Fact(DisplayName = "bool?.NotBe(bool?)")]
        public void ValidateBooleanNotToBeValue()
        {
            // Given
            var validator = new NullableBoolInverseValidator(true);

            // When
            validator.Be(false);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "bool?.NotBe(null)")]
        public void ValidateBooleanNotToBeNull()
        {
            // Given
            var validator = new NullableBoolInverseValidator(true);

            // When
            validator.Be(null);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "bool?.NotBe(other)")]
        public void ValidateBooleanNotToBeValueViolated()
        {
            // Given
            var validator = new NullableBoolInverseValidator(true);

            // When
            var exception = Assert.Throws<XunitException>(() => validator.Be(true, "that's the bottom line"));

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is \"True\"{rn}but was expected not to be \"True\"{rn}because that's the bottom line",
                exception.UserMessage);
        }

        #endregion

        #region bool?.NotBeFalse()

        [Fact(DisplayName = "bool?.NotBeFalse()")]
        public void ValidateBooleanNotToBeFalse()
        {
            // Given
            var validator = new NullableBoolInverseValidator(true);

            // When
            validator.BeFalse();

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "bool?.NotBeFalse()")]
        public void ValidateNullableBooleanNotToBeFalse()
        {
            // Given
            var validator = new NullableBoolInverseValidator(null);

            // When
            validator.BeFalse();

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "bool?.NotBeFalse()")]
        public void ValidateBooleanNotToBeFalseViolated()
        {
            // Given
            var validator = new NullableBoolInverseValidator(false);

            // When
            var exception = Assert.Throws<XunitException>(() => validator.BeFalse(because: "that's the bottom line"));

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is \"False\"{rn}but was expected not to be false{rn}because that's the bottom line",
                exception.UserMessage);
        }

        #endregion

        #region bool?.BeNull()

        [Fact(DisplayName = "bool?.NotBeNull()")]
        public void ValidateNullableNotToBeNull()
        {
            // Given
            var validator = new NullableBoolInverseValidator(false);

            // When
            validator.BeNull();

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "bool?.NotBeNull(reason)")]
        public void ValidateNullableNotToBeNullWithReasonViolated()
        {
            // Given
            var validator = new NullableBoolInverseValidator(null);

            // When
            var exception = Assert.Throws<XunitException>(() => validator.BeNull("that's the bottom line"));

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is null{rn}but was expected not to be null{rn}because that's the bottom line",
                exception.UserMessage);
        }

        #endregion

        #region bool?.NotBeTrue()

        [Fact(DisplayName = "bool?.NotBeTrue()")]
        public void ValidateBooleanNotToBeTrue()
        {
            // Given
            var validator = new NullableBoolInverseValidator(false);

            // When
            validator.BeTrue();

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "bool?.NotBeTrue()")]
        public void ValidateNullableBooleanNotToBeTrue()
        {
            // Given
            var validator = new NullableBoolInverseValidator(null);

            // When
            validator.BeTrue();

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "bool?.NotBeTrue()")]
        public void ValidateBooleanNotToBeTrueViolated()
        {
            // Given
            var validator = new NullableBoolInverseValidator(true);

            // When
            var exception = Assert.Throws<XunitException>(() => validator.BeTrue(because: "that's the bottom line"));

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is \"True\"{rn}but was expected not to be true{rn}because that's the bottom line",
                exception.UserMessage);
        }

        #endregion
    }
}