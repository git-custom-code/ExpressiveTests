namespace CustomCode.Test.BehaviorDrivenDevelopment.Tests
{
    using System;
    using System.IO;
    using Xunit;
    using Xunit.Abstractions;
    using Xunit.Sdk;

    /// <summary>
    /// Test cases for the <see cref="ByteInverseValidator"/> type.
    /// </summary>
    [UnitTest]
    [Category("Assert", "ByteValidation")]
    public sealed class ByteInvereseValidatorTest
    {
        #region byte.NotBe()

        [Fact(DisplayName = "byte.NotBe(byte)")]
        public void ValidateByteNotToBeValue()
        {
            // Given
            var validator = new ByteInverseValidator(42);

            // When
            validator.Be(13);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "byte.NotBe(other)")]
        public void ValidateByteNotToBeValueViolated()
        {
            // Given
            var validator = new ByteInverseValidator(42);

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

        #region byte.NotBeBetween()

        [Fact(DisplayName = "byte.NotBeBetween(byte, byte)")]
        public void ValidateByteToNotBeBetweenSmallerValues()
        {
            // Given
            var validator = new ByteInverseValidator(42);

            // When
            validator.BeBetween(13, 39);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "byte.NotBeBetween(byte, byte)")]
        public void ValidateByteToNotBeBetweenBiggerValues()
        {
            // Given
            var validator = new ByteInverseValidator(42);

            // When
            validator.BeBetween(65, 130);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "byte.BeBetween(wrongMinimum, wrongMaximum)")]
        public void ValidateByteToBeBetweenValuesMinimumAndMaximumViolated()
        {
            // Given
            var validator = new ByteInverseValidator(42);

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

        #region byte.NotBeGreaterThan()

        [Fact(DisplayName = "byte.NotBeGreaterThan(equalValue)")]
        public void ValidateByteToBeGreaterThanEqualValue()
        {
            // Given
            var validator = new ByteInverseValidator(42);

            // When
            validator.BeGreaterThan(42);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "byte.NotBeGreaterThan(biggerValue)")]
        public void ValidateByteToNotBeGreaterThanBiggerValue()
        {
            // Given
            var validator = new ByteInverseValidator(42);

            // When
            validator.BeGreaterThan(65);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "byte.NotBeGreaterThan(wrongMinimum)")]
        public void ValidateByteToNotBeGreaterThanValueViolated()
        {
            // Given
            var validator = new ByteInverseValidator(42);

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

        #region byte.NotBeGreaterThanOrEqualTo()

        [Fact(DisplayName = "byte.NotBeGreaterThanOrEqualTo(byte)")]
        public void ValidateByteNotToBeGreaterThanOrEqualToValue()
        {
            // Given
            var validator = new ByteInverseValidator(42);

            // When
            validator.BeGreaterThanOrEqualTo(65);

            // Then
            Assert.True(true);
        }


        [Fact(DisplayName = "byte.NotBeGreaterThanOrEqualTo(wrongMinimum)")]
        public void ValidateByteNotToBeGreaterThanOrEqualToValueViolated()
        {
            // Given
            var validator = new ByteInverseValidator(42);

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

        #region byte.NotBeLessThan()

        [Fact(DisplayName = "byte.NotBeLessThan(equalValue)")]
        public void ValidateByteToBeLessThanEqualValue()
        {
            // Given
            var validator = new ByteInverseValidator(42);

            // When
            validator.BeLessThan(42);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "byte.NotBeLessThan(biggerValue)")]
        public void ValidateByteToNotBeLessThanBiggerValue()
        {
            // Given
            var validator = new ByteInverseValidator(42);

            // When
            validator.BeLessThan(13);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "byte.NotBeLessThan(wrongMaximum)")]
        public void ValidateByteToNotBeLessThanValueViolated()
        {
            // Given
            var validator = new ByteInverseValidator(42);

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

        #region byte.NotBeLessThanOrEqualTo()

        [Fact(DisplayName = "byte.NotBeLessThanOrEqualTo(byte)")]
        public void ValidateByteNotToBeLessThanOrEqualToValue()
        {
            // Given
            var validator = new ByteInverseValidator(42);

            // When
            validator.BeLessThanOrEqualTo(13);

            // Then
            Assert.True(true);
        }


        [Fact(DisplayName = "byte.NotBeLessThanOrEqualTo(wrongMinimum)")]
        public void ValidateByteNotToBeLessThanOrEqualToValueViolated()
        {
            // Given
            var validator = new ByteInverseValidator(42);

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

        #region byte.NotBeOneOf()

        [Fact(DisplayName = "byte.NotBeOneOf(other, other)")]
        public void ValidateByteNotToBeOneOfExpectedValues()
        {
            // Given
            var validator = new ByteInverseValidator(42);

            // When
            validator.BeOneOf(new byte[] { 10, 39 });

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "byte.NotBeOneOf(byte, byte)")]
        public void ValidateByteNotToBeOneOfViolated()
        {
            // Given
            var validator = new ByteInverseValidator(42);

            // When
            var exception = Assert.Throws<XunitException>(() => validator.BeOneOf(new byte[] { 13, 42 }, because: "that's the bottom line"));

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