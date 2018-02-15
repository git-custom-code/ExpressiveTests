namespace CustomCode.Test.BehaviorDrivenDevelopment.Tests
{
    using System;
    using Xunit;
    using Xunit.Sdk;

    /// <summary>
    /// Test cases for the <see cref="NullableDecimalValidator"/> type.
    /// </summary>
    [UnitTest]
    [Category("Assert", "DecimalValidation")]
    public sealed class NullableDecimalValidatorTest
    {
        #region decimal?.Be()

        [Fact(DisplayName = "decimal?.Be(decimal?)")]
        public void ValidateDecimalToBeValue()
        {
            // Given
            var validator = new NullableDecimalValidator(42);

            // When
            validator.Be(42);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "decimal?.Be(null)")]
        public void ValidateDecimalToBeNull()
        {
            // Given
            var validator = new NullableDecimalValidator(null);

            // When
            validator.Be(null);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "decimal?.Be(other)")]
        public void ValidateDecimalToBeValueViolated()
        {
            // Given
            var validator = new NullableDecimalValidator(42);

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

        #region decimal?.BeApproximately()

        [Fact(DisplayName = "decimal?.BeApproximately(decimal)")]
        public void ValidateDecimalToBeApproximatelyValue()
        {
            // Given
            var validator = new NullableDecimalValidator(42.12345m);

            // When
            validator.BeApproximately(42.123m, 0.1m);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "decimal?.BeApproximately(other)")]
        public void ValidateNullableDecimalToBeApproximatelyValueViolated()
        {
            // Given
            var validator = new NullableDecimalValidator(null);

            // When
            var exception = Assert.Throws<XunitException>(() => validator.BeApproximately(42m, 0.01m, "that's the bottom line"));

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is \"\"{rn}but was expected to be approximately \"42\" (+/- 0,01){rn}because that's the bottom line",
                exception.UserMessage);
        }

        [Fact(DisplayName = "decimal?.BeApproximately(other)")]
        public void ValidateDecimalToBeApproximatelyValueViolated()
        {
            // Given
            var validator = new NullableDecimalValidator(42.12345m);

            // When
            var exception = Assert.Throws<XunitException>(() => validator.BeApproximately(42m, 0.01m, "that's the bottom line"));

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is \"42,12345\"{rn}but was expected to be approximately \"42\" (+/- 0,01){rn}because that's the bottom line",
                exception.UserMessage);
        }

        #endregion

        #region decimal?.BeBetween()

        [Fact(DisplayName = "decimal?.BeBetween(decimal, decimal)")]
        public void ValidateDecimalToBeBetweenValues()
        {
            // Given
            var validator = new NullableDecimalValidator(42);

            // When
            validator.BeBetween(13, 100);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "decimal?.BeBetween(wrongMinimum, decimal)")]
        public void ValidateDecimalToBeBetweenValuesMinimumViolated()
        {
            // Given
            var validator = new NullableDecimalValidator(42);

            // When
            var exception = Assert.Throws<XunitException>(() => validator.BeBetween(65, 100, "that's the bottom line"));

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is \"42\"{rn}but was expected to be between \"65\" and \"100\"{rn}because that's the bottom line",
                exception.UserMessage);
        }

        [Fact(DisplayName = "decimal?.BeBetween(decimal, wrongMaximum)")]
        public void ValidateDecimalToBeBetweenValuesMaximumViolated()
        {
            // Given
            var validator = new NullableDecimalValidator(42);

            // When
            var exception = Assert.Throws<XunitException>(() => validator.BeBetween(13, 39, "that's the bottom line"));

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is \"42\"{rn}but was expected to be between \"13\" and \"39\"{rn}because that's the bottom line",
                exception.UserMessage);
        }

        [Fact(DisplayName = "decimal?.BeBetween(wrongMinimum, wrongMaximum)")]
        public void ValidateDecimalToBeBetweenValuesMinimumAndMaximumViolated()
        {
            // Given
            var validator = new NullableDecimalValidator(42);

            // When
            var exception = Assert.Throws<XunitException>(() => validator.BeBetween(100, 13, "that's the bottom line"));

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is \"42\"{rn}but was expected to be between \"100\" and \"13\"{rn}because that's the bottom line",
                exception.UserMessage);
        }

        [Fact(DisplayName = "decimal?.BeBetween(wrongMinimum, wrongMaximum)")]
        public void ValidateNullableDecimalToBeBetweenValuesMinimumAndMaximumViolated()
        {
            // Given
            var validator = new NullableDecimalValidator(null);

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

        #region decimal?.BeGreaterThan()

        [Fact(DisplayName = "decimal?.BeGreaterThan(decimal)")]
        public void ValidateDecimalToBeGreaterThanValue()
        {
            // Given
            var validator = new NullableDecimalValidator(42);

            // When
            validator.BeGreaterThan(13);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "decimal?.BeGreaterThan(wrongMinimum)")]
        public void ValidateDecimalToBeGreaterThanValueViolated()
        {
            // Given
            var validator = new NullableDecimalValidator(42);

            // When
            var exception = Assert.Throws<XunitException>(() => validator.BeGreaterThan(42, "that's the bottom line"));

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is \"42\"{rn}but was expected to be greater than \"42\"{rn}because that's the bottom line",
                exception.UserMessage);
        }

        [Fact(DisplayName = "decimal?.BeGreaterThan(wrongMinimum)")]
        public void ValidateNullableDecimalToBeGreaterThanValueViolated()
        {
            // Given
            var validator = new NullableDecimalValidator(null);

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

        #region decimal?.BeGreaterThanOrEqualTo()

        [Fact(DisplayName = "decimal?.BeGreaterThanOrEqualTo(smallerValue)")]
        public void ValidateDecimalToBeGreaterThanOrEqualToSmallerValue()
        {
            // Given
            var validator = new NullableDecimalValidator(42);

            // When
            validator.BeGreaterThanOrEqualTo(13);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "decimal?.BeGreaterThanOrEqualTo(equalValue)")]
        public void ValidateDecimalToBeGreaterThanOrEqualToEqualValue()
        {
            // Given
            var validator = new NullableDecimalValidator(42);

            // When
            validator.BeGreaterThanOrEqualTo(42);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "decimal?.BeGreaterThanOrEqualTo(wrongMinimum)")]
        public void ValidateDecimalToBeGreaterThanOrEqualToValueViolated()
        {
            // Given
            var validator = new NullableDecimalValidator(42);

            // When
            var exception = Assert.Throws<XunitException>(() => validator.BeGreaterThanOrEqualTo(65, "that's the bottom line"));

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is \"42\"{rn}but was expected to be greater than or equal to \"65\"{rn}because that's the bottom line",
                exception.UserMessage);
        }

        [Fact(DisplayName = "decimal?.BeGreaterThanOrEqualTo(wrongMinimum)")]
        public void ValidateNullableDecimalToBeGreaterThanOrEqualToValueViolated()
        {
            // Given
            var validator = new NullableDecimalValidator(null);

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

        #region decimal?.BeLessThan()

        [Fact(DisplayName = "decimal?.BeLessThan(decimal)")]
        public void ValidateDecimalToBeLessThanValue()
        {
            // Given
            var validator = new NullableDecimalValidator(42);

            // When
            validator.BeLessThan(65);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "decimal?.BeLessThan(wrongMinimum)")]
        public void ValidateDecimalToBeLessThanValueViolated()
        {
            // Given
            var validator = new NullableDecimalValidator(42);

            // When
            var exception = Assert.Throws<XunitException>(() => validator.BeLessThan(42, "that's the bottom line"));

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is \"42\"{rn}but was expected to be less than \"42\"{rn}because that's the bottom line",
                exception.UserMessage);
        }

        [Fact(DisplayName = "decimal?.BeLessThan(wrongMinimum)")]
        public void ValidateNullableDecimalToBeLessThanValueViolated()
        {
            // Given
            var validator = new NullableDecimalValidator(null);

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

        #region decimal?.BeLessThanOrEqualTo()

        [Fact(DisplayName = "decimal?.BeLessThanOrEqualTo(biggerValue)")]
        public void ValidateDecimalToBeLessThanOrEqualToBiggerValue()
        {
            // Given
            var validator = new NullableDecimalValidator(42);

            // When
            validator.BeLessThanOrEqualTo(65);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "decimal?.BeLessThanOrEqualTo(equalValue)")]
        public void ValidateDecimalToBeLessThanOrEqualToEqualValue()
        {
            // Given
            var validator = new NullableDecimalValidator(42);

            // When
            validator.BeLessThanOrEqualTo(42);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "decimal?.BeLessThanOrEqualTo(wrongMaximum)")]
        public void ValidateDecimalToBeLessThanOrEqualToValueViolated()
        {
            // Given
            var validator = new NullableDecimalValidator(42);

            // When
            var exception = Assert.Throws<XunitException>(() => validator.BeLessThanOrEqualTo(13, "that's the bottom line"));

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is \"42\"{rn}but was expected to be less than or equal to \"13\"{rn}because that's the bottom line",
                exception.UserMessage);
        }

        [Fact(DisplayName = "decimal?.BeLessThanOrEqualTo(wrongMaximum)")]
        public void ValidateNullableDecimalToBeLessThanOrEqualToValueViolated()
        {
            // Given
            var validator = new NullableDecimalValidator(null);

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

        #region decimal?.BeNegative()

        [Fact(DisplayName = "decimal?.BeNegative()")]
        public void ValidateSByteToBeNegative()
        {
            // Given
            var validator = new NullableDecimalValidator(-42);

            // When
            validator.BeNegative();

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "decimal?.BeNegative()")]
        public void ValidateNullableSByteToBeNegativeViolated()
        {
            // Given
            var validator = new NullableDecimalValidator(null);

            // When
            var exception = Assert.Throws<XunitException>(() => validator.BeNegative(because: "that's the bottom line"));

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is \"\"{rn}but was expected to have a negative value{rn}because that's the bottom line",
                exception.UserMessage);
        }

        [Fact(DisplayName = "decimal?.BeNegative()")]
        public void ValidateSByteToBeNegativeViolated()
        {
            // Given
            var validator = new NullableDecimalValidator(0);

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

        #region decimal?.BeNull()

        [Fact(DisplayName = "decimal?.BeNull()")]
        public void ValidateNullableDecimalToBeNull()
        {
            // Given
            var validator = new NullableDecimalValidator(null);

            // When
            validator.BeNull();

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "decimal?.BeNull()")]
        public void ValidateNullableDecimalToBeNullViolated()
        {
            // Given
            var validator = new NullableDecimalValidator(0);

            // When
            var exception = Assert.Throws<XunitException>(() => validator.BeNull());

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is \"0\"{rn}but was expected to be null",
                exception.UserMessage);
        }

        [Fact(DisplayName = "decimal?.BeNull(reason)")]
        public void ValidateNullableToBeNullWithReasonViolated()
        {
            // Given
            var validator = new NullableDecimalValidator(0);

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

        #region decimal?.BeOneOf()

        [Fact(DisplayName = "decimal?.BeOneOf(decimal?, decimal?)")]
        public void ValidateDecimalToBeOneOfExpectedValues()
        {
            // Given
            var validator = new NullableDecimalValidator(42);

            // When
            validator.BeOneOf(new decimal?[] { 10, 42 });

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "decimal?.BeOneOf(decimal?, decimal?)")]
        public void ValidateNullableDecimalToBeOneOfExpectedValues()
        {
            // Given
            var validator = new NullableDecimalValidator(null);

            // When
            validator.BeOneOf(new decimal?[] { 10, null });

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "decimal?.BeOneOf(other, other)")]
        public void ValidateDecimalToBeOneOfViolated()
        {
            // Given
            var validator = new NullableDecimalValidator(42);

            // When
            var exception = Assert.Throws<XunitException>(() => validator.BeOneOf(new decimal?[] { 13, 39 }, because: "that's the bottom line"));

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is \"42\"{rn}but was expected to be one of the following values: \"13\", \"39\"{rn}because that's the bottom line",
                exception.UserMessage);
        }

        #endregion

        #region decimal?.BePositive()

        [Fact(DisplayName = "decimal?.BePositive()")]
        public void ValidateSByteToBePositive()
        {
            // Given
            var validator = new NullableDecimalValidator(0);

            // When
            validator.BePositive();

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "decimal?.BePositive()")]
        public void ValidateNullableSByteToBePositiveViolated()
        {
            // Given
            var validator = new NullableDecimalValidator(null);

            // When
            var exception = Assert.Throws<XunitException>(() => validator.BePositive(because: "that's the bottom line"));

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is \"\"{rn}but was expected to have a positive value{rn}because that's the bottom line",
                exception.UserMessage);
        }

        [Fact(DisplayName = "decimal?.BePositive()")]
        public void ValidateSByteToBePositiveViolated()
        {
            // Given
            var validator = new NullableDecimalValidator(-42);

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