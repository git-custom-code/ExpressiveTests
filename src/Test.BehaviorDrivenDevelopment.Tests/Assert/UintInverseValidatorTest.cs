namespace CustomCode.Test.BehaviorDrivenDevelopment.Tests
{
    using System;
    using Xunit;
    using Xunit.Sdk;

    /// <summary>
    /// Test cases for the <see cref="UintInverseValidator"/> type.
    /// </summary>
    [UnitTest]
    [Category("Assert", "UIntValidation")]
    public sealed class UintInverseValidatorTest
    {
        #region uint.NotBe()

        [Fact(DisplayName = "uint.NotBe(uint)")]
        public void ValidateUIntNotToBeValue()
        {
            // Given
            var validator = new UintInverseValidator(42);

            // When
            validator.Be(13);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "uint.NotBe(other)")]
        public void ValidateUIntNotToBeValueViolated()
        {
            // Given
            var validator = new UintInverseValidator(42);

            // When
            var exception = Assert.Throws<XunitException>(() => validator.Be(42, "that's the bottom line"));

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is \"42\"{rn}but was expected not to be \"42\"{rn}because that's the bottom line",
                exception.UserMessage);
        }

        #endregion

        #region uint.NotBeBetween()

        [Fact(DisplayName = "uint.NotBeBetween(uint, uint)")]
        public void ValidateUIntToNotBeBetweenSmallerValues()
        {
            // Given
            var validator = new UintInverseValidator(42);

            // When
            validator.BeBetween(13, 39);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "uint.NotBeBetween(uint, uint)")]
        public void ValidateUIntToNotBeBetweenBiggerValues()
        {
            // Given
            var validator = new UintInverseValidator(42);

            // When
            validator.BeBetween(65, 130);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "uint.BeBetween(wrongMinimum, wrongMaximum)")]
        public void ValidateUIntToBeBetweenValuesMinimumAndMaximumViolated()
        {
            // Given
            var validator = new UintInverseValidator(42);

            // When
            var exception = Assert.Throws<XunitException>(() => validator.BeBetween(13, 130, "that's the bottom line"));

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is \"42\"{rn}but was expected not to be between \"13\" and \"130\"{rn}because that's the bottom line",
                exception.UserMessage);
        }

        #endregion

        #region uint.NotBeGreaterThan()

        [Fact(DisplayName = "uint.NotBeGreaterThan(equalValue)")]
        public void ValidateUIntToBeGreaterThanEqualValue()
        {
            // Given
            var validator = new UintInverseValidator(42);

            // When
            validator.BeGreaterThan(42);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "uint.NotBeGreaterThan(biggerValue)")]
        public void ValidateUIntToNotBeGreaterThanBiggerValue()
        {
            // Given
            var validator = new UintInverseValidator(42);

            // When
            validator.BeGreaterThan(65);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "uint.NotBeGreaterThan(wrongMinimum)")]
        public void ValidateUIntToNotBeGreaterThanValueViolated()
        {
            // Given
            var validator = new UintInverseValidator(42);

            // When
            var exception = Assert.Throws<XunitException>(() => validator.BeGreaterThan(13, "that's the bottom line"));

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is \"42\"{rn}but was expected not to be greater than \"13\"{rn}because that's the bottom line",
                exception.UserMessage);
        }

        #endregion

        #region uint.NotBeGreaterThanOrEqualTo()

        [Fact(DisplayName = "uint.NotBeGreaterThanOrEqualTo(uint)")]
        public void ValidateUIntNotToBeGreaterThanOrEqualToValue()
        {
            // Given
            var validator = new UintInverseValidator(42);

            // When
            validator.BeGreaterThanOrEqualTo(65);

            // Then
            Assert.True(true);
        }


        [Fact(DisplayName = "uint.NotBeGreaterThanOrEqualTo(wrongMinimum)")]
        public void ValidateUIntNotToBeGreaterThanOrEqualToValueViolated()
        {
            // Given
            var validator = new UintInverseValidator(42);

            // When
            var exception = Assert.Throws<XunitException>(() => validator.BeGreaterThanOrEqualTo(42, "that's the bottom line"));

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is \"42\"{rn}but was expected not to be greater than or equal to \"42\"{rn}because that's the bottom line",
                exception.UserMessage);
        }

        #endregion

        #region uint.NotBeLessThan()

        [Fact(DisplayName = "uint.NotBeLessThan(equalValue)")]
        public void ValidateUIntToBeLessThanEqualValue()
        {
            // Given
            var validator = new UintInverseValidator(42);

            // When
            validator.BeLessThan(42);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "uint.NotBeLessThan(biggerValue)")]
        public void ValidateUIntToNotBeLessThanBiggerValue()
        {
            // Given
            var validator = new UintInverseValidator(42);

            // When
            validator.BeLessThan(13);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "uint.NotBeLessThan(wrongMaximum)")]
        public void ValidateUIntToNotBeLessThanValueViolated()
        {
            // Given
            var validator = new UintInverseValidator(42);

            // When
            var exception = Assert.Throws<XunitException>(() => validator.BeLessThan(65, "that's the bottom line"));

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is \"42\"{rn}but was expected not to be less than \"65\"{rn}because that's the bottom line",
                exception.UserMessage);
        }

        #endregion

        #region uint.NotBeLessThanOrEqualTo()

        [Fact(DisplayName = "uint.NotBeLessThanOrEqualTo(uint)")]
        public void ValidateUIntNotToBeLessThanOrEqualToValue()
        {
            // Given
            var validator = new UintInverseValidator(42);

            // When
            validator.BeLessThanOrEqualTo(13);

            // Then
            Assert.True(true);
        }


        [Fact(DisplayName = "uint.NotBeLessThanOrEqualTo(wrongMinimum)")]
        public void ValidateUIntNotToBeLessThanOrEqualToValueViolated()
        {
            // Given
            var validator = new UintInverseValidator(42);

            // When
            var exception = Assert.Throws<XunitException>(() => validator.BeLessThanOrEqualTo(42, "that's the bottom line"));

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is \"42\"{rn}but was expected not to be less than or equal to \"42\"{rn}because that's the bottom line",
                exception.UserMessage);
        }

        #endregion

        #region uint.NotBeOneOf()

        [Fact(DisplayName = "uint.NotBeOneOf(other, other)")]
        public void ValidateUIntNotToBeOneOfExpectedValues()
        {
            // Given
            var validator = new UintInverseValidator(42);

            // When
            validator.BeOneOf(new uint[] { 10, 39 });

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "uint.NotBeOneOf(uint, uint)")]
        public void ValidateUIntNotToBeOneOfViolated()
        {
            // Given
            var validator = new UintInverseValidator(42);

            // When
            var exception = Assert.Throws<XunitException>(() => validator.BeOneOf(new uint[] { 13, 42 }, because: "that's the bottom line"));

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is \"42\"{rn}but was expected not to be one of the following values: \"13\", \"42\"{rn}because that's the bottom line",
                exception.UserMessage);
        }

        #endregion
    }
}