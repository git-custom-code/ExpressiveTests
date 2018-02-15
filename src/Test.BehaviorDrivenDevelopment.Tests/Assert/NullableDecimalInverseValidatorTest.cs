namespace CustomCode.Test.BehaviorDrivenDevelopment.Tests
{
    using System;
    using Xunit;
    using Xunit.Sdk;

    /// <summary>
    /// Test cases for the <see cref="NullableDecimalInverseValidator"/> type.
    /// </summary>
    [UnitTest]
    [Category("Assert", "DecimalValidation")]
    public sealed class NullableDecimalInverseValidatorTest
    {
        #region decimal?.NotBe()

        [Fact(DisplayName = "decimal?.NotBe(decimal?)")]
        public void ValidateDecimalNotToBeValue()
        {
            // Given
            var validator = new NullableDecimalInverseValidator(42);

            // When
            validator.Be(13);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "decimal?.NotBe(null)")]
        public void ValidateDecimalNotToBeNull()
        {
            // Given
            var validator = new NullableDecimalInverseValidator(42);

            // When
            validator.Be(null);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "decimal?.NotBe(other)")]
        public void ValidateDecimalNotToBeValueViolated()
        {
            // Given
            var validator = new NullableDecimalInverseValidator(42);

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

        #region decimal?.NotBeApproximately()

        [Fact(DisplayName = "decimal?.NotBeApproximately(decimal)")]
        public void ValidateDecimalToBeApproximatelyValue()
        {
            // Given
            var validator = new NullableDecimalInverseValidator(42.2m);

            // When
            validator.BeApproximately(42m, 0.1m);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "decimal?.NotBeApproximately(decimal)")]
        public void ValidateNullableDecimalToBeApproximatelyValue()
        {
            // Given
            var validator = new NullableDecimalInverseValidator(null);

            // When
            validator.BeApproximately(42m, 0.1m);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "decimal?.NotBeApproximately(other)")]
        public void ValidateDecimalToBeApproximatelyValueViolated()
        {
            // Given
            var validator = new NullableDecimalInverseValidator(42.12345m);

            // When
            var exception = Assert.Throws<XunitException>(() => validator.BeApproximately(42.12m, 0.01m, "that's the bottom line"));

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is \"42,12345\"{rn}but was expected to be approximately \"42,12\" (+/- 0,01){rn}because that's the bottom line",
                exception.UserMessage);
        }

        #endregion

        #region decimal?.NotBeBetween()

        [Fact(DisplayName = "decimal?.NotBeBetween(decimal, decimal)")]
        public void ValidateDecimalToNotBeBetweenSmallerValues()
        {
            // Given
            var validator = new NullableDecimalInverseValidator(42);

            // When
            validator.BeBetween(13, 39);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "decimal?.NotBeBetween(decimal, decimal)")]
        public void ValidateDecimalToNotBeBetweenBiggerValues()
        {
            // Given
            var validator = new NullableDecimalInverseValidator(42);

            // When
            validator.BeBetween(65, 100);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "decimal?.NotBeBetween(decimal, decimal)")]
        public void ValidateNullableDecimalToNotBeBetweenValues()
        {
            // Given
            var validator = new NullableDecimalInverseValidator(null);

            // When
            validator.BeBetween(65, 100);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "decimal?.BeBetween(wrongMinimum, wrongMaximum)")]
        public void ValidateDecimalToBeBetweenValuesMinimumAndMaximumViolated()
        {
            // Given
            var validator = new NullableDecimalInverseValidator(42);

            // When
            var exception = Assert.Throws<XunitException>(() => validator.BeBetween(13, 100, "that's the bottom line"));

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is \"42\"{rn}but was expected not to be between \"13\" and \"100\"{rn}because that's the bottom line",
                exception.UserMessage);
        }

        #endregion

        #region decimal?.NotBeGreaterThan()

        [Fact(DisplayName = "decimal?.NotBeGreaterThan(equalValue)")]
        public void ValidateDecimalToBeGreaterThanEqualValue()
        {
            // Given
            var validator = new NullableDecimalInverseValidator(42);

            // When
            validator.BeGreaterThan(42);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "decimal?.NotBeGreaterThan(biggerValue)")]
        public void ValidateDecimalToNotBeGreaterThanBiggerValue()
        {
            // Given
            var validator = new NullableDecimalInverseValidator(42);

            // When
            validator.BeGreaterThan(65);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "decimal?.NotBeGreaterThan(biggerValue)")]
        public void ValidateNullableDecimalToNotBeGreaterThanBiggerValue()
        {
            // Given
            var validator = new NullableDecimalInverseValidator(null);

            // When
            validator.BeGreaterThan(65);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "decimal?.NotBeGreaterThan(wrongMinimum)")]
        public void ValidateDecimalToNotBeGreaterThanValueViolated()
        {
            // Given
            var validator = new NullableDecimalInverseValidator(42);

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

        #region decimal?.NotBeGreaterThanOrEqualTo()

        [Fact(DisplayName = "decimal?.NotBeGreaterThanOrEqualTo(decimal)")]
        public void ValidateDecimalNotToBeGreaterThanOrEqualToValue()
        {
            // Given
            var validator = new NullableDecimalInverseValidator(42);

            // When
            validator.BeGreaterThanOrEqualTo(65);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "decimal?.NotBeGreaterThanOrEqualTo(decimal)")]
        public void ValidateNullableDecimalNotToBeGreaterThanOrEqualToValue()
        {
            // Given
            var validator = new NullableDecimalInverseValidator(null);

            // When
            validator.BeGreaterThanOrEqualTo(65);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "decimal?.NotBeGreaterThanOrEqualTo(wrongMinimum)")]
        public void ValidateDecimalNotToBeGreaterThanOrEqualToValueViolated()
        {
            // Given
            var validator = new NullableDecimalInverseValidator(42);

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

        #region decimal?.NotBeLessThan()

        [Fact(DisplayName = "decimal?.NotBeLessThan(equalValue)")]
        public void ValidateDecimalToBeLessThanEqualValue()
        {
            // Given
            var validator = new NullableDecimalInverseValidator(42);

            // When
            validator.BeLessThan(42);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "decimal?.NotBeLessThan(biggerValue)")]
        public void ValidateDecimalToNotBeLessThanBiggerValue()
        {
            // Given
            var validator = new NullableDecimalInverseValidator(42);

            // When
            validator.BeLessThan(13);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "decimal?.NotBeLessThan(biggerValue)")]
        public void ValidateNullableDecimalToNotBeLessThanBiggerValue()
        {
            // Given
            var validator = new NullableDecimalInverseValidator(null);

            // When
            validator.BeLessThan(13);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "decimal?.NotBeLessThan(wrongMaximum)")]
        public void ValidateDecimalToNotBeLessThanValueViolated()
        {
            // Given
            var validator = new NullableDecimalInverseValidator(42);

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

        #region decimal?.NotBeLessThanOrEqualTo()

        [Fact(DisplayName = "decimal?.NotBeLessThanOrEqualTo(decimal)")]
        public void ValidateDecimalNotToBeLessThanOrEqualToValue()
        {
            // Given
            var validator = new NullableDecimalInverseValidator(42);

            // When
            validator.BeLessThanOrEqualTo(13);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "decimal?.NotBeLessThanOrEqualTo(decimal)")]
        public void ValidateNullableDecimalNotToBeLessThanOrEqualToValue()
        {
            // Given
            var validator = new NullableDecimalInverseValidator(null);

            // When
            validator.BeLessThanOrEqualTo(13);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "decimal?.NotBeLessThanOrEqualTo(wrongMinimum)")]
        public void ValidateDecimalNotToBeLessThanOrEqualToValueViolated()
        {
            // Given
            var validator = new NullableDecimalInverseValidator(42);

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

        #region decimal?.NotBeNegative()

        [Fact(DisplayName = "decimal?.NotBeNegative()")]
        public void ValidateSByteNotToBeNegative()
        {
            // Given
            var validator = new NullableDecimalInverseValidator(0);

            // When
            validator.BeNegative();

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "decimal?.NotBeNegative()")]
        public void ValidateNullableSByteNotToBeNegative()
        {
            // Given
            var validator = new NullableDecimalInverseValidator(null);

            // When
            validator.BeNegative();

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "decimal?.NotBeNegative()")]
        public void ValidateSByteNotToBeNegativeViolated()
        {
            // Given
            var validator = new NullableDecimalInverseValidator(-42);

            // When
            var exception = Assert.Throws<XunitException>(() => validator.BeNegative(because: "that's the bottom line"));

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is \"-42\"{rn}but was expected not to have a negative value{rn}because that's the bottom line",
                exception.UserMessage);
        }

        #endregion

        #region decimal?.BeNull()

        [Fact(DisplayName = "decimal?.NotBeNull()")]
        public void ValidateNullableDecimalNotToBeNull()
        {
            // Given
            var validator = new NullableDecimalInverseValidator(0);

            // When
            validator.BeNull();

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "decimal?.NotBeNull()")]
        public void ValidateNullableDecimalNotToBeNullViolated()
        {
            // Given
            var validator = new NullableDecimalInverseValidator(null);

            // When
            var exception = Assert.Throws<XunitException>(() => validator.BeNull());

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is null{rn}but was expected not to be null",
                exception.UserMessage);
        }

        [Fact(DisplayName = "decimal?.NotBeNull(reason)")]
        public void ValidateNullableDecimalNotToBeNullWithReasonViolated()
        {
            // Given
            var validator = new NullableDecimalInverseValidator(null);

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

        #region decimal?.NotBeOneOf()

        [Fact(DisplayName = "decimal?.NotBeOneOf(other, other)")]
        public void ValidateDecimalNotToBeOneOfExpectedValues()
        {
            // Given
            var validator = new NullableDecimalInverseValidator(42);

            // When
            validator.BeOneOf(new decimal?[] { 10, 39 });

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "decimal?.NotBeOneOf(decimal?, decimal?)")]
        public void ValidateDecimalNotToBeOneOfViolated()
        {
            // Given
            var validator = new NullableDecimalInverseValidator(42);

            // When
            var exception = Assert.Throws<XunitException>(() => validator.BeOneOf(new decimal?[] { 13, 42 }, because: "that's the bottom line"));

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is \"42\"{rn}but was expected not to be one of the following values: \"13\", \"42\"{rn}because that's the bottom line",
                exception.UserMessage);
        }

        [Fact(DisplayName = "decimal?.NotBeOneOf(decimal?, decimal?)")]
        public void ValidateNullableDecimalNotToBeOneOfViolated()
        {
            // Given
            var validator = new NullableDecimalInverseValidator(null);

            // When
            var exception = Assert.Throws<XunitException>(() => validator.BeOneOf(new decimal?[] { null, 42 }, because: "that's the bottom line"));

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is \"\"{rn}but was expected not to be one of the following values: \"\", \"42\"{rn}because that's the bottom line",
                exception.UserMessage);
        }

        #endregion

        #region decimal?.NotBePositive()

        [Fact(DisplayName = "decimal?.NotBePositive()")]
        public void ValidateSByteToBePositive()
        {
            // Given
            var validator = new NullableDecimalInverseValidator(-42);

            // When
            validator.BePositive();

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "decimal?.NotBePositive()")]
        public void ValidateNullableSByteToBePositive()
        {
            // Given
            var validator = new NullableDecimalInverseValidator(null);

            // When
            validator.BePositive();

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "decimal?.NotBePositive()")]
        public void ValidateSByteNotToBePositiveViolated()
        {
            // Given
            var validator = new NullableDecimalInverseValidator(0);

            // When
            var exception = Assert.Throws<XunitException>(() => validator.BePositive(because: "that's the bottom line"));

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is \"0\"{rn}but was expected not to have a positive value{rn}because that's the bottom line",
                exception.UserMessage);
        }

        #endregion
    }
}