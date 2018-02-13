namespace CustomCode.Test.BehaviorDrivenDevelopment.Tests
{
    using System;
    using Xunit;
    using Xunit.Sdk;

    /// <summary>
    /// Test cases for the <see cref="NullableLongValidator"/> type.
    /// </summary>
    [UnitTest]
    [Category("Assert", "LongValidation")]
    public sealed class NullableLongValidatorTest
    {
        #region long?.Be()

        [Fact(DisplayName = "long?.Be(long?)")]
        public void ValidateLongToBeValue()
        {
            // Given
            var validator = new NullableLongValidator(42);

            // When
            validator.Be(42);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "long?.Be(null)")]
        public void ValidateLongToBeNull()
        {
            // Given
            var validator = new NullableLongValidator(null);

            // When
            validator.Be(null);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "long?.Be(other)")]
        public void ValidateLongToBeValueViolated()
        {
            // Given
            var validator = new NullableLongValidator(42);

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

        #region long?.BeBetween()

        [Fact(DisplayName = "long?.BeBetween(long, long)")]
        public void ValidateLongToBeBetweenValues()
        {
            // Given
            var validator = new NullableLongValidator(42);

            // When
            validator.BeBetween(13, 100);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "long?.BeBetween(wrongMinimum, long)")]
        public void ValidateLongToBeBetweenValuesMinimumViolated()
        {
            // Given
            var validator = new NullableLongValidator(42);

            // When
            var exception = Assert.Throws<XunitException>(() => validator.BeBetween(65, 100, "that's the bottom line"));

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is \"42\"{rn}but was expected to be between \"65\" and \"100\"{rn}because that's the bottom line",
                exception.UserMessage);
        }

        [Fact(DisplayName = "long?.BeBetween(long, wrongMaximum)")]
        public void ValidateLongToBeBetweenValuesMaximumViolated()
        {
            // Given
            var validator = new NullableLongValidator(42);

            // When
            var exception = Assert.Throws<XunitException>(() => validator.BeBetween(13, 39, "that's the bottom line"));

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is \"42\"{rn}but was expected to be between \"13\" and \"39\"{rn}because that's the bottom line",
                exception.UserMessage);
        }

        [Fact(DisplayName = "long?.BeBetween(wrongMinimum, wrongMaximum)")]
        public void ValidateLongToBeBetweenValuesMinimumAndMaximumViolated()
        {
            // Given
            var validator = new NullableLongValidator(42);

            // When
            var exception = Assert.Throws<XunitException>(() => validator.BeBetween(100, 13, "that's the bottom line"));

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is \"42\"{rn}but was expected to be between \"100\" and \"13\"{rn}because that's the bottom line",
                exception.UserMessage);
        }

        [Fact(DisplayName = "long?.BeBetween(wrongMinimum, wrongMaximum)")]
        public void ValidateNullableLongToBeBetweenValuesMinimumAndMaximumViolated()
        {
            // Given
            var validator = new NullableLongValidator(null);

            // When
            var exception = Assert.Throws<XunitException>(() => validator.BeBetween(100, 13, "that's the bottom line"));

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is \"\"{rn}but was expected to be between \"100\" and \"13\"{rn}because that's the bottom line",
                exception.UserMessage);
        }

        #endregion

        #region long?.BeGreaterThan()

        [Fact(DisplayName = "long?.BeGreaterThan(long)")]
        public void ValidateLongToBeGreaterThanValue()
        {
            // Given
            var validator = new NullableLongValidator(42);

            // When
            validator.BeGreaterThan(13);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "long?.BeGreaterThan(wrongMinimum)")]
        public void ValidateLongToBeGreaterThanValueViolated()
        {
            // Given
            var validator = new NullableLongValidator(42);

            // When
            var exception = Assert.Throws<XunitException>(() => validator.BeGreaterThan(42, "that's the bottom line"));

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is \"42\"{rn}but was expected to be greater than \"42\"{rn}because that's the bottom line",
                exception.UserMessage);
        }

        [Fact(DisplayName = "long?.BeGreaterThan(wrongMinimum)")]
        public void ValidateNullableLongToBeGreaterThanValueViolated()
        {
            // Given
            var validator = new NullableLongValidator(null);

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

        #region long?.BeGreaterThanOrEqualTo()

        [Fact(DisplayName = "long?.BeGreaterThanOrEqualTo(smallerValue)")]
        public void ValidateLongToBeGreaterThanOrEqualToSmallerValue()
        {
            // Given
            var validator = new NullableLongValidator(42);

            // When
            validator.BeGreaterThanOrEqualTo(13);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "long?.BeGreaterThanOrEqualTo(equalValue)")]
        public void ValidateLongToBeGreaterThanOrEqualToEqualValue()
        {
            // Given
            var validator = new NullableLongValidator(42);

            // When
            validator.BeGreaterThanOrEqualTo(42);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "long?.BeGreaterThanOrEqualTo(wrongMinimum)")]
        public void ValidateLongToBeGreaterThanOrEqualToValueViolated()
        {
            // Given
            var validator = new NullableLongValidator(42);

            // When
            var exception = Assert.Throws<XunitException>(() => validator.BeGreaterThanOrEqualTo(65, "that's the bottom line"));

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is \"42\"{rn}but was expected to be greater than or equal to \"65\"{rn}because that's the bottom line",
                exception.UserMessage);
        }

        [Fact(DisplayName = "long?.BeGreaterThanOrEqualTo(wrongMinimum)")]
        public void ValidateNullableLongToBeGreaterThanOrEqualToValueViolated()
        {
            // Given
            var validator = new NullableLongValidator(null);

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

        #region long?.BeLessThan()

        [Fact(DisplayName = "long?.BeLessThan(long)")]
        public void ValidateLongToBeLessThanValue()
        {
            // Given
            var validator = new NullableLongValidator(42);

            // When
            validator.BeLessThan(65);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "long?.BeLessThan(wrongMinimum)")]
        public void ValidateLongToBeLessThanValueViolated()
        {
            // Given
            var validator = new NullableLongValidator(42);

            // When
            var exception = Assert.Throws<XunitException>(() => validator.BeLessThan(42, "that's the bottom line"));

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is \"42\"{rn}but was expected to be less than \"42\"{rn}because that's the bottom line",
                exception.UserMessage);
        }

        [Fact(DisplayName = "long?.BeLessThan(wrongMinimum)")]
        public void ValidateNullableLongToBeLessThanValueViolated()
        {
            // Given
            var validator = new NullableLongValidator(null);

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

        #region long?.BeLessThanOrEqualTo()

        [Fact(DisplayName = "long?.BeLessThanOrEqualTo(biggerValue)")]
        public void ValidateLongToBeLessThanOrEqualToBiggerValue()
        {
            // Given
            var validator = new NullableLongValidator(42);

            // When
            validator.BeLessThanOrEqualTo(65);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "long?.BeLessThanOrEqualTo(equalValue)")]
        public void ValidateLongToBeLessThanOrEqualToEqualValue()
        {
            // Given
            var validator = new NullableLongValidator(42);

            // When
            validator.BeLessThanOrEqualTo(42);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "long?.BeLessThanOrEqualTo(wrongMaximum)")]
        public void ValidateLongToBeLessThanOrEqualToValueViolated()
        {
            // Given
            var validator = new NullableLongValidator(42);

            // When
            var exception = Assert.Throws<XunitException>(() => validator.BeLessThanOrEqualTo(13, "that's the bottom line"));

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is \"42\"{rn}but was expected to be less than or equal to \"13\"{rn}because that's the bottom line",
                exception.UserMessage);
        }

        [Fact(DisplayName = "long?.BeLessThanOrEqualTo(wrongMaximum)")]
        public void ValidateNullableLongToBeLessThanOrEqualToValueViolated()
        {
            // Given
            var validator = new NullableLongValidator(null);

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

        #region long?.BeNegative()

        [Fact(DisplayName = "long?.BeNegative()")]
        public void ValidateSByteToBeNegative()
        {
            // Given
            var validator = new NullableLongValidator(-42);

            // When
            validator.BeNegative();

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "long?.BeNegative()")]
        public void ValidateNullableSByteToBeNegativeViolated()
        {
            // Given
            var validator = new NullableLongValidator(null);

            // When
            var exception = Assert.Throws<XunitException>(() => validator.BeNegative(because: "that's the bottom line"));

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is \"\"{rn}but was expected to have a negative value{rn}because that's the bottom line",
                exception.UserMessage);
        }

        [Fact(DisplayName = "long?.BeNegative()")]
        public void ValidateSByteToBeNegativeViolated()
        {
            // Given
            var validator = new NullableLongValidator(0);

            // When
            var exception = Assert.Throws<XunitException>(() => validator.BeNegative(because: "that's the bottom line"));

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is \"0\"{rn}but was expected to have a negative value{rn}because that's the bottom line",
                exception.UserMessage);
        }

        #endregion

        #region long?.BeNull()

        [Fact(DisplayName = "long?.BeNull()")]
        public void ValidateNullableLongToBeNull()
        {
            // Given
            var validator = new NullableLongValidator(null);

            // When
            validator.BeNull();

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "long?.BeNull()")]
        public void ValidateNullableLongToBeNullViolated()
        {
            // Given
            var validator = new NullableLongValidator(0);

            // When
            var exception = Assert.Throws<XunitException>(() => validator.BeNull());

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is \"0\"{rn}but was expected to be null",
                exception.UserMessage);
        }

        [Fact(DisplayName = "long?.BeNull(reason)")]
        public void ValidateNullableToBeNullWithReasonViolated()
        {
            // Given
            var validator = new NullableLongValidator(0);

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

        #region long?.BeOneOf()

        [Fact(DisplayName = "long?.BeOneOf(long?, long?)")]
        public void ValidateLongToBeOneOfExpectedValues()
        {
            // Given
            var validator = new NullableLongValidator(42);

            // When
            validator.BeOneOf(new long?[] { 10, 42 });

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "long?.BeOneOf(long?, long?)")]
        public void ValidateNullableLongToBeOneOfExpectedValues()
        {
            // Given
            var validator = new NullableLongValidator(null);

            // When
            validator.BeOneOf(new long?[] { 10, null });

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "long?.BeOneOf(other, other)")]
        public void ValidateLongToBeOneOfViolated()
        {
            // Given
            var validator = new NullableLongValidator(42);

            // When
            var exception = Assert.Throws<XunitException>(() => validator.BeOneOf(new long?[] { 13, 39 }, because: "that's the bottom line"));

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is \"42\"{rn}but was expected to be one of the following values: \"13\", \"39\"{rn}because that's the bottom line",
                exception.UserMessage);
        }

        #endregion

        #region long?.BePositive()

        [Fact(DisplayName = "long?.BePositive()")]
        public void ValidateSByteToBePositive()
        {
            // Given
            var validator = new NullableLongValidator(0);

            // When
            validator.BePositive();

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "long?.BePositive()")]
        public void ValidateNullableSByteToBePositiveViolated()
        {
            // Given
            var validator = new NullableLongValidator(null);

            // When
            var exception = Assert.Throws<XunitException>(() => validator.BePositive(because: "that's the bottom line"));

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is \"\"{rn}but was expected to have a positive value{rn}because that's the bottom line",
                exception.UserMessage);
        }

        [Fact(DisplayName = "long?.BePositive()")]
        public void ValidateSByteToBePositiveViolated()
        {
            // Given
            var validator = new NullableLongValidator(-42);

            // When
            var exception = Assert.Throws<XunitException>(() => validator.BePositive(because: "that's the bottom line"));

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is \"-42\"{rn}but was expected to have a positive value{rn}because that's the bottom line",
                exception.UserMessage);
        }

        #endregion
    }
}