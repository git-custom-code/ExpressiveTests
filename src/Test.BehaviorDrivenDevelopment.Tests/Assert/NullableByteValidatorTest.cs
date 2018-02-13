namespace CustomCode.Test.BehaviorDrivenDevelopment.Tests
{
    using System;
    using Xunit;
    using Xunit.Sdk;

    /// <summary>
    /// Test cases for the <see cref="NullableByteValidator"/> type.
    /// </summary>
    [UnitTest]
    [Category("Assert", "ByteValidation")]
    public sealed class NullableByteValidatorTest
    {
        #region byte?.Be()

        [Fact(DisplayName = "byte?.Be(byte?)")]
        public void ValidateByteToBeValue()
        {
            // Given
            var validator = new NullableByteValidator(42);

            // When
            validator.Be(42);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "byte?.Be(null)")]
        public void ValidateByteToBeNull()
        {
            // Given
            var validator = new NullableByteValidator(null);

            // When
            validator.Be(null);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "byte?.Be(other)")]
        public void ValidateByteToBeValueViolated()
        {
            // Given
            var validator = new NullableByteValidator(42);

            // When
            var exception = Assert.Throws<XunitException>(() => validator.Be(13, "that's the bottom line"));

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is \"42\"{rn}but was expected to be \"13\"{rn}because that's the bottom line",
                exception.UserMessage);
        }

        #endregion

        #region byte?.BeBetween()

        [Fact(DisplayName = "byte?.BeBetween(byte, byte)")]
        public void ValidateByteToBeBetweenValues()
        {
            // Given
            var validator = new NullableByteValidator(42);

            // When
            validator.BeBetween(13, 130);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "byte?.BeBetween(wrongMinimum, byte)")]
        public void ValidateByteToBeBetweenValuesMinimumViolated()
        {
            // Given
            var validator = new NullableByteValidator(42);

            // When
            var exception = Assert.Throws<XunitException>(() => validator.BeBetween(65, 130, "that's the bottom line"));

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is \"42\"{rn}but was expected to be between \"65\" and \"130\"{rn}because that's the bottom line",
                exception.UserMessage);
        }

        [Fact(DisplayName = "byte?.BeBetween(byte, wrongMaximum)")]
        public void ValidateByteToBeBetweenValuesMaximumViolated()
        {
            // Given
            var validator = new NullableByteValidator(42);

            // When
            var exception = Assert.Throws<XunitException>(() => validator.BeBetween(13, 39, "that's the bottom line"));

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is \"42\"{rn}but was expected to be between \"13\" and \"39\"{rn}because that's the bottom line",
                exception.UserMessage);
        }

        [Fact(DisplayName = "byte?.BeBetween(wrongMinimum, wrongMaximum)")]
        public void ValidateByteToBeBetweenValuesMinimumAndMaximumViolated()
        {
            // Given
            var validator = new NullableByteValidator(42);

            // When
            var exception = Assert.Throws<XunitException>(() => validator.BeBetween(130, 13, "that's the bottom line"));

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is \"42\"{rn}but was expected to be between \"130\" and \"13\"{rn}because that's the bottom line",
                exception.UserMessage);
        }

        [Fact(DisplayName = "byte?.BeBetween(wrongMinimum, wrongMaximum)")]
        public void ValidateNullableByteToBeBetweenValuesMinimumAndMaximumViolated()
        {
            // Given
            var validator = new NullableByteValidator(null);

            // When
            var exception = Assert.Throws<XunitException>(() => validator.BeBetween(130, 13, "that's the bottom line"));

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is \"\"{rn}but was expected to be between \"130\" and \"13\"{rn}because that's the bottom line",
                exception.UserMessage);
        }

        #endregion

        #region byte?.BeGreaterThan()

        [Fact(DisplayName = "byte?.BeGreaterThan(byte)")]
        public void ValidateByteToBeGreaterThanValue()
        {
            // Given
            var validator = new NullableByteValidator(42);

            // When
            validator.BeGreaterThan(13);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "byte?.BeGreaterThan(wrongMinimum)")]
        public void ValidateByteToBeGreaterThanValueViolated()
        {
            // Given
            var validator = new NullableByteValidator(42);

            // When
            var exception = Assert.Throws<XunitException>(() => validator.BeGreaterThan(42, "that's the bottom line"));

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is \"42\"{rn}but was expected to be greater than \"42\"{rn}because that's the bottom line",
                exception.UserMessage);
        }

        [Fact(DisplayName = "byte?.BeGreaterThan(wrongMinimum)")]
        public void ValidateNullableByteToBeGreaterThanValueViolated()
        {
            // Given
            var validator = new NullableByteValidator(null);

            // When
            var exception = Assert.Throws<XunitException>(() => validator.BeGreaterThan(42, "that's the bottom line"));

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is \"\"{rn}but was expected to be greater than \"42\"{rn}because that's the bottom line",
                exception.UserMessage);
        }

        #endregion

        #region byte?.BeGreaterThanOrEqualTo()

        [Fact(DisplayName = "byte?.BeGreaterThanOrEqualTo(smallerValue)")]
        public void ValidateByteToBeGreaterThanOrEqualToSmallerValue()
        {
            // Given
            var validator = new NullableByteValidator(42);

            // When
            validator.BeGreaterThanOrEqualTo(13);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "byte?.BeGreaterThanOrEqualTo(equalValue)")]
        public void ValidateByteToBeGreaterThanOrEqualToEqualValue()
        {
            // Given
            var validator = new NullableByteValidator(42);

            // When
            validator.BeGreaterThanOrEqualTo(42);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "byte?.BeGreaterThanOrEqualTo(wrongMinimum)")]
        public void ValidateByteToBeGreaterThanOrEqualToValueViolated()
        {
            // Given
            var validator = new NullableByteValidator(42);

            // When
            var exception = Assert.Throws<XunitException>(() => validator.BeGreaterThanOrEqualTo(65, "that's the bottom line"));

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is \"42\"{rn}but was expected to be greater than or equal to \"65\"{rn}because that's the bottom line",
                exception.UserMessage);
        }

        [Fact(DisplayName = "byte?.BeGreaterThanOrEqualTo(wrongMinimum)")]
        public void ValidateNullableByteToBeGreaterThanOrEqualToValueViolated()
        {
            // Given
            var validator = new NullableByteValidator(null);

            // When
            var exception = Assert.Throws<XunitException>(() => validator.BeGreaterThanOrEqualTo(65, "that's the bottom line"));

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is \"\"{rn}but was expected to be greater than or equal to \"65\"{rn}because that's the bottom line",
                exception.UserMessage);
        }

        #endregion

        #region byte?.BeLessThan()

        [Fact(DisplayName = "byte?.BeLessThan(byte)")]
        public void ValidateByteToBeLessThanValue()
        {
            // Given
            var validator = new NullableByteValidator(42);

            // When
            validator.BeLessThan(65);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "byte?.BeLessThan(wrongMinimum)")]
        public void ValidateByteToBeLessThanValueViolated()
        {
            // Given
            var validator = new NullableByteValidator(42);

            // When
            var exception = Assert.Throws<XunitException>(() => validator.BeLessThan(42, "that's the bottom line"));

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is \"42\"{rn}but was expected to be less than \"42\"{rn}because that's the bottom line",
                exception.UserMessage);
        }

        [Fact(DisplayName = "byte?.BeLessThan(wrongMinimum)")]
        public void ValidateNullableByteToBeLessThanValueViolated()
        {
            // Given
            var validator = new NullableByteValidator(null);

            // When
            var exception = Assert.Throws<XunitException>(() => validator.BeLessThan(42, "that's the bottom line"));

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is \"\"{rn}but was expected to be less than \"42\"{rn}because that's the bottom line",
                exception.UserMessage);
        }

        #endregion

        #region byte?.BeLessThanOrEqualTo()

        [Fact(DisplayName = "byte?.BeLessThanOrEqualTo(biggerValue)")]
        public void ValidateByteToBeLessThanOrEqualToBiggerValue()
        {
            // Given
            var validator = new NullableByteValidator(42);

            // When
            validator.BeLessThanOrEqualTo(65);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "byte?.BeLessThanOrEqualTo(equalValue)")]
        public void ValidateByteToBeLessThanOrEqualToEqualValue()
        {
            // Given
            var validator = new NullableByteValidator(42);

            // When
            validator.BeLessThanOrEqualTo(42);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "byte?.BeLessThanOrEqualTo(wrongMaximum)")]
        public void ValidateByteToBeLessThanOrEqualToValueViolated()
        {
            // Given
            var validator = new NullableByteValidator(42);

            // When
            var exception = Assert.Throws<XunitException>(() => validator.BeLessThanOrEqualTo(13, "that's the bottom line"));

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is \"42\"{rn}but was expected to be less than or equal to \"13\"{rn}because that's the bottom line",
                exception.UserMessage);
        }

        [Fact(DisplayName = "byte?.BeLessThanOrEqualTo(wrongMaximum)")]
        public void ValidateNullableByteToBeLessThanOrEqualToValueViolated()
        {
            // Given
            var validator = new NullableByteValidator(null);

            // When
            var exception = Assert.Throws<XunitException>(() => validator.BeLessThanOrEqualTo(13, "that's the bottom line"));

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is \"\"{rn}but was expected to be less than or equal to \"13\"{rn}because that's the bottom line",
                exception.UserMessage);
        }

        #endregion

        #region byte?.BeNull()

        [Fact(DisplayName = "byte?.BeNull()")]
        public void ValidateNullableByteToBeNull()
        {
            // Given
            var validator = new NullableByteValidator(null);

            // When
            validator.BeNull();

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "byte?.BeNull()")]
        public void ValidateNullableByteToBeNullViolated()
        {
            // Given
            var validator = new NullableByteValidator(0);

            // When
            var exception = Assert.Throws<XunitException>(() => validator.BeNull());

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is \"0\"{rn}but was expected to be null",
                exception.UserMessage);
        }

        [Fact(DisplayName = "byte?.BeNull(reason)")]
        public void ValidateNullableToBeNullWithReasonViolated()
        {
            // Given
            var validator = new NullableByteValidator(0);

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

        #region byte?.BeOneOf()

        [Fact(DisplayName = "byte?.BeOneOf(byte?, byte?)")]
        public void ValidateByteToBeOneOfExpectedValues()
        {
            // Given
            var validator = new NullableByteValidator(42);

            // When
            validator.BeOneOf(new byte?[] { 10, 42 });

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "byte?.BeOneOf(byte?, byte?)")]
        public void ValidateNullableByteToBeOneOfExpectedValues()
        {
            // Given
            var validator = new NullableByteValidator(null);

            // When
            validator.BeOneOf(new byte?[] { 10, null });

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "byte?.BeOneOf(other, other)")]
        public void ValidateByteToBeOneOfViolated()
        {
            // Given
            var validator = new NullableByteValidator(42);

            // When
            var exception = Assert.Throws<XunitException>(() => validator.BeOneOf(new byte?[] { 13, 39 }, because: "that's the bottom line"));

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is \"42\"{rn}but was expected to be one of the following values: \"13\", \"39\"{rn}because that's the bottom line",
                exception.UserMessage);
        }

        #endregion
    }
}