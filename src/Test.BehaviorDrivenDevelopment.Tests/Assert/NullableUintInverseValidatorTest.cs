namespace CustomCode.Test.BehaviorDrivenDevelopment.Tests
{
    using System;
    using Xunit;
    using Xunit.Sdk;

    /// <summary>
    /// Test cases for the <see cref="NullableUintInverseValidator"/> type.
    /// </summary>
    [UnitTest]
    [Category("Assert", "UintValidation")]
    public sealed class NullableUintInverseValidatorTest
    {
        #region uint?.NotBe()

        [Fact(DisplayName = "uint?.NotBe(uint?)")]
        public void ValidateUintNotToBeValue()
        {
            // Given
            var validator = new NullableUintInverseValidator(42);

            // When
            validator.Be(13);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "uint?.NotBe(null)")]
        public void ValidateUintNotToBeNull()
        {
            // Given
            var validator = new NullableUintInverseValidator(42);

            // When
            validator.Be(null);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "uint?.NotBe(other)")]
        public void ValidateUintNotToBeValueViolated()
        {
            // Given
            var validator = new NullableUintInverseValidator(42);

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

        #region uint?.NotBeBetween()

        [Fact(DisplayName = "uint?.NotBeBetween(uint, uint)")]
        public void ValidateUintToNotBeBetweenSmallerValues()
        {
            // Given
            var validator = new NullableUintInverseValidator(42);

            // When
            validator.BeBetween(13, 39);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "uint?.NotBeBetween(uint, uint)")]
        public void ValidateUintToNotBeBetweenBiggerValues()
        {
            // Given
            var validator = new NullableUintInverseValidator(42);

            // When
            validator.BeBetween(65, 130);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "uint?.NotBeBetween(uint, uint)")]
        public void ValidateNullableUintToNotBeBetweenValues()
        {
            // Given
            var validator = new NullableUintInverseValidator(null);

            // When
            validator.BeBetween(65, 130);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "uint?.BeBetween(wrongMinimum, wrongMaximum)")]
        public void ValidateUintToBeBetweenValuesMinimumAndMaximumViolated()
        {
            // Given
            var validator = new NullableUintInverseValidator(42);

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

        #region uint?.NotBeGreaterThan()

        [Fact(DisplayName = "uint?.NotBeGreaterThan(equalValue)")]
        public void ValidateUintToBeGreaterThanEqualValue()
        {
            // Given
            var validator = new NullableUintInverseValidator(42);

            // When
            validator.BeGreaterThan(42);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "uint?.NotBeGreaterThan(biggerValue)")]
        public void ValidateUintToNotBeGreaterThanBiggerValue()
        {
            // Given
            var validator = new NullableUintInverseValidator(42);

            // When
            validator.BeGreaterThan(65);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "uint?.NotBeGreaterThan(biggerValue)")]
        public void ValidateNullableUintToNotBeGreaterThanBiggerValue()
        {
            // Given
            var validator = new NullableUintInverseValidator(null);

            // When
            validator.BeGreaterThan(65);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "uint?.NotBeGreaterThan(wrongMinimum)")]
        public void ValidateUintToNotBeGreaterThanValueViolated()
        {
            // Given
            var validator = new NullableUintInverseValidator(42);

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

        #region uint?.NotBeGreaterThanOrEqualTo()

        [Fact(DisplayName = "uint?.NotBeGreaterThanOrEqualTo(uint)")]
        public void ValidateUintNotToBeGreaterThanOrEqualToValue()
        {
            // Given
            var validator = new NullableUintInverseValidator(42);

            // When
            validator.BeGreaterThanOrEqualTo(65);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "uint?.NotBeGreaterThanOrEqualTo(uint)")]
        public void ValidateNullableUintNotToBeGreaterThanOrEqualToValue()
        {
            // Given
            var validator = new NullableUintInverseValidator(null);

            // When
            validator.BeGreaterThanOrEqualTo(65);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "uint?.NotBeGreaterThanOrEqualTo(wrongMinimum)")]
        public void ValidateUintNotToBeGreaterThanOrEqualToValueViolated()
        {
            // Given
            var validator = new NullableUintInverseValidator(42);

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

        #region uint?.NotBeLessThan()

        [Fact(DisplayName = "uint?.NotBeLessThan(equalValue)")]
        public void ValidateUintToBeLessThanEqualValue()
        {
            // Given
            var validator = new NullableUintInverseValidator(42);

            // When
            validator.BeLessThan(42);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "uint?.NotBeLessThan(biggerValue)")]
        public void ValidateUintToNotBeLessThanBiggerValue()
        {
            // Given
            var validator = new NullableUintInverseValidator(42);

            // When
            validator.BeLessThan(13);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "uint?.NotBeLessThan(biggerValue)")]
        public void ValidateNullableUintToNotBeLessThanBiggerValue()
        {
            // Given
            var validator = new NullableUintInverseValidator(null);

            // When
            validator.BeLessThan(13);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "uint?.NotBeLessThan(wrongMaximum)")]
        public void ValidateUintToNotBeLessThanValueViolated()
        {
            // Given
            var validator = new NullableUintInverseValidator(42);

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

        #region uint?.NotBeLessThanOrEqualTo()

        [Fact(DisplayName = "uint?.NotBeLessThanOrEqualTo(uint)")]
        public void ValidateUintNotToBeLessThanOrEqualToValue()
        {
            // Given
            var validator = new NullableUintInverseValidator(42);

            // When
            validator.BeLessThanOrEqualTo(13);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "uint?.NotBeLessThanOrEqualTo(uint)")]
        public void ValidateNullableUintNotToBeLessThanOrEqualToValue()
        {
            // Given
            var validator = new NullableUintInverseValidator(null);

            // When
            validator.BeLessThanOrEqualTo(13);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "uint?.NotBeLessThanOrEqualTo(wrongMinimum)")]
        public void ValidateUintNotToBeLessThanOrEqualToValueViolated()
        {
            // Given
            var validator = new NullableUintInverseValidator(42);

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

        #region uint?.BeNull()

        [Fact(DisplayName = "uint?.NotBeNull()")]
        public void ValidateNullableUintNotToBeNull()
        {
            // Given
            var validator = new NullableUintInverseValidator(0);

            // When
            validator.BeNull();

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "uint?.NotBeNull()")]
        public void ValidateNullableUintNotToBeNullViolated()
        {
            // Given
            var validator = new NullableUintInverseValidator(null);

            // When
            var exception = Assert.Throws<XunitException>(() => validator.BeNull());

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is null{rn}but was expected not to be null",
                exception.UserMessage);
        }

        [Fact(DisplayName = "uint?.NotBeNull(reason)")]
        public void ValidateNullableUintNotToBeNullWithReasonViolated()
        {
            // Given
            var validator = new NullableUintInverseValidator(null);

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

        #region uint?.NotBeOneOf()

        [Fact(DisplayName = "uint?.NotBeOneOf(other, other)")]
        public void ValidateUintNotToBeOneOfExpectedValues()
        {
            // Given
            var validator = new NullableUintInverseValidator(42);

            // When
            validator.BeOneOf(new uint?[] { 10, 39 });

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "uint?.NotBeOneOf(uint?, uint?)")]
        public void ValidateUintNotToBeOneOfViolated()
        {
            // Given
            var validator = new NullableUintInverseValidator(42);

            // When
            var exception = Assert.Throws<XunitException>(() => validator.BeOneOf(new uint?[] { 13, 42 }, because: "that's the bottom line"));

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is \"42\"{rn}but was expected not to be one of the following values: \"13\", \"42\"{rn}because that's the bottom line",
                exception.UserMessage);
        }

        [Fact(DisplayName = "uint?.NotBeOneOf(uint?, uint?)")]
        public void ValidateNullableUintNotToBeOneOfViolated()
        {
            // Given
            var validator = new NullableUintInverseValidator(null);

            // When
            var exception = Assert.Throws<XunitException>(() => validator.BeOneOf(new uint?[] { null, 42 }, because: "that's the bottom line"));

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is \"\"{rn}but was expected not to be one of the following values: \"\", \"42\"{rn}because that's the bottom line",
                exception.UserMessage);
        }

        #endregion
    }
}