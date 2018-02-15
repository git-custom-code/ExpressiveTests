namespace CustomCode.Test.BehaviorDrivenDevelopment.Tests
{
    using System;
    using Xunit;
    using Xunit.Sdk;

    /// <summary>
    /// Test cases for the <see cref="NullableDoubleValidator"/> type.
    /// </summary>
    [UnitTest]
    [Category("Assert", "DoubleValidation")]
    public sealed class NullableDoubleValidatorTest
    {
        #region double?.Be()

        [Fact(DisplayName = "double?.Be(double?)")]
        public void ValidateDoubleToBeValue()
        {
            // Given
            var validator = new NullableDoubleValidator(42);

            // When
            validator.Be(42);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "double?.Be(null)")]
        public void ValidateDoubleToBeNull()
        {
            // Given
            var validator = new NullableDoubleValidator(null);

            // When
            validator.Be(null);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "double?.Be(other)")]
        public void ValidateDoubleToBeValueViolated()
        {
            // Given
            var validator = new NullableDoubleValidator(42);

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

        #region double?.BeApproximately()

        [Fact(DisplayName = "double?.BeApproximately(double)")]
        public void ValidateDoubleToBeApproximatelyValue()
        {
            // Given
            var validator = new NullableDoubleValidator(42.12345);

            // When
            validator.BeApproximately(42.123, 0.1);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "double?.BeApproximately(other)")]
        public void ValidateNullableDoubleToBeApproximatelyValueViolated()
        {
            // Given
            var validator = new NullableDoubleValidator(null);

            // When
            var exception = Assert.Throws<XunitException>(() => validator.BeApproximately(42, 0.01, "that's the bottom line"));

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is \"\"{rn}but was expected to be approximately \"42\" (+/- 0,01){rn}because that's the bottom line",
                exception.UserMessage);
        }

        [Fact(DisplayName = "double?.BeApproximately(other)")]
        public void ValidateDoubleToBeApproximatelyValueViolated()
        {
            // Given
            var validator = new NullableDoubleValidator(42.12345);

            // When
            var exception = Assert.Throws<XunitException>(() => validator.BeApproximately(42, 0.01, "that's the bottom line"));

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is \"42,12345\"{rn}but was expected to be approximately \"42\" (+/- 0,01){rn}because that's the bottom line",
                exception.UserMessage);
        }

        #endregion

        #region double?.BeBetween()

        [Fact(DisplayName = "double?.BeBetween(double, double)")]
        public void ValidateDoubleToBeBetweenValues()
        {
            // Given
            var validator = new NullableDoubleValidator(42);

            // When
            validator.BeBetween(13, 100);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "double?.BeBetween(wrongMinimum, double)")]
        public void ValidateDoubleToBeBetweenValuesMinimumViolated()
        {
            // Given
            var validator = new NullableDoubleValidator(42);

            // When
            var exception = Assert.Throws<XunitException>(() => validator.BeBetween(65, 100, "that's the bottom line"));

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is \"42\"{rn}but was expected to be between \"65\" and \"100\"{rn}because that's the bottom line",
                exception.UserMessage);
        }

        [Fact(DisplayName = "double?.BeBetween(double, wrongMaximum)")]
        public void ValidateDoubleToBeBetweenValuesMaximumViolated()
        {
            // Given
            var validator = new NullableDoubleValidator(42);

            // When
            var exception = Assert.Throws<XunitException>(() => validator.BeBetween(13, 39, "that's the bottom line"));

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is \"42\"{rn}but was expected to be between \"13\" and \"39\"{rn}because that's the bottom line",
                exception.UserMessage);
        }

        [Fact(DisplayName = "double?.BeBetween(wrongMinimum, wrongMaximum)")]
        public void ValidateDoubleToBeBetweenValuesMinimumAndMaximumViolated()
        {
            // Given
            var validator = new NullableDoubleValidator(42);

            // When
            var exception = Assert.Throws<XunitException>(() => validator.BeBetween(100, 13, "that's the bottom line"));

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is \"42\"{rn}but was expected to be between \"100\" and \"13\"{rn}because that's the bottom line",
                exception.UserMessage);
        }

        [Fact(DisplayName = "double?.BeBetween(wrongMinimum, wrongMaximum)")]
        public void ValidateNullableDoubleToBeBetweenValuesMinimumAndMaximumViolated()
        {
            // Given
            var validator = new NullableDoubleValidator(null);

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

        #region double?.BeGreaterThan()

        [Fact(DisplayName = "double?.BeGreaterThan(double)")]
        public void ValidateDoubleToBeGreaterThanValue()
        {
            // Given
            var validator = new NullableDoubleValidator(42);

            // When
            validator.BeGreaterThan(13);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "double?.BeGreaterThan(wrongMinimum)")]
        public void ValidateDoubleToBeGreaterThanValueViolated()
        {
            // Given
            var validator = new NullableDoubleValidator(42);

            // When
            var exception = Assert.Throws<XunitException>(() => validator.BeGreaterThan(42, "that's the bottom line"));

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is \"42\"{rn}but was expected to be greater than \"42\"{rn}because that's the bottom line",
                exception.UserMessage);
        }

        [Fact(DisplayName = "double?.BeGreaterThan(wrongMinimum)")]
        public void ValidateNullableDoubleToBeGreaterThanValueViolated()
        {
            // Given
            var validator = new NullableDoubleValidator(null);

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

        #region double?.BeGreaterThanOrEqualTo()

        [Fact(DisplayName = "double?.BeGreaterThanOrEqualTo(smallerValue)")]
        public void ValidateDoubleToBeGreaterThanOrEqualToSmallerValue()
        {
            // Given
            var validator = new NullableDoubleValidator(42);

            // When
            validator.BeGreaterThanOrEqualTo(13);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "double?.BeGreaterThanOrEqualTo(equalValue)")]
        public void ValidateDoubleToBeGreaterThanOrEqualToEqualValue()
        {
            // Given
            var validator = new NullableDoubleValidator(42);

            // When
            validator.BeGreaterThanOrEqualTo(42);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "double?.BeGreaterThanOrEqualTo(wrongMinimum)")]
        public void ValidateDoubleToBeGreaterThanOrEqualToValueViolated()
        {
            // Given
            var validator = new NullableDoubleValidator(42);

            // When
            var exception = Assert.Throws<XunitException>(() => validator.BeGreaterThanOrEqualTo(65, "that's the bottom line"));

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is \"42\"{rn}but was expected to be greater than or equal to \"65\"{rn}because that's the bottom line",
                exception.UserMessage);
        }

        [Fact(DisplayName = "double?.BeGreaterThanOrEqualTo(wrongMinimum)")]
        public void ValidateNullableDoubleToBeGreaterThanOrEqualToValueViolated()
        {
            // Given
            var validator = new NullableDoubleValidator(null);

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

        #region double?.BeLessThan()

        [Fact(DisplayName = "double?.BeLessThan(double)")]
        public void ValidateDoubleToBeLessThanValue()
        {
            // Given
            var validator = new NullableDoubleValidator(42);

            // When
            validator.BeLessThan(65);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "double?.BeLessThan(wrongMinimum)")]
        public void ValidateDoubleToBeLessThanValueViolated()
        {
            // Given
            var validator = new NullableDoubleValidator(42);

            // When
            var exception = Assert.Throws<XunitException>(() => validator.BeLessThan(42, "that's the bottom line"));

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is \"42\"{rn}but was expected to be less than \"42\"{rn}because that's the bottom line",
                exception.UserMessage);
        }

        [Fact(DisplayName = "double?.BeLessThan(wrongMinimum)")]
        public void ValidateNullableDoubleToBeLessThanValueViolated()
        {
            // Given
            var validator = new NullableDoubleValidator(null);

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

        #region double?.BeLessThanOrEqualTo()

        [Fact(DisplayName = "double?.BeLessThanOrEqualTo(biggerValue)")]
        public void ValidateDoubleToBeLessThanOrEqualToBiggerValue()
        {
            // Given
            var validator = new NullableDoubleValidator(42);

            // When
            validator.BeLessThanOrEqualTo(65);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "double?.BeLessThanOrEqualTo(equalValue)")]
        public void ValidateDoubleToBeLessThanOrEqualToEqualValue()
        {
            // Given
            var validator = new NullableDoubleValidator(42);

            // When
            validator.BeLessThanOrEqualTo(42);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "double?.BeLessThanOrEqualTo(wrongMaximum)")]
        public void ValidateDoubleToBeLessThanOrEqualToValueViolated()
        {
            // Given
            var validator = new NullableDoubleValidator(42);

            // When
            var exception = Assert.Throws<XunitException>(() => validator.BeLessThanOrEqualTo(13, "that's the bottom line"));

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is \"42\"{rn}but was expected to be less than or equal to \"13\"{rn}because that's the bottom line",
                exception.UserMessage);
        }

        [Fact(DisplayName = "double?.BeLessThanOrEqualTo(wrongMaximum)")]
        public void ValidateNullableDoubleToBeLessThanOrEqualToValueViolated()
        {
            // Given
            var validator = new NullableDoubleValidator(null);

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

        #region double?.BeNegative()

        [Fact(DisplayName = "double?.BeNegative()")]
        public void ValidateSByteToBeNegative()
        {
            // Given
            var validator = new NullableDoubleValidator(-42);

            // When
            validator.BeNegative();

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "double?.BeNegative()")]
        public void ValidateNullableSByteToBeNegativeViolated()
        {
            // Given
            var validator = new NullableDoubleValidator(null);

            // When
            var exception = Assert.Throws<XunitException>(() => validator.BeNegative(because: "that's the bottom line"));

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is \"\"{rn}but was expected to have a negative value{rn}because that's the bottom line",
                exception.UserMessage);
        }

        [Fact(DisplayName = "double?.BeNegative()")]
        public void ValidateSByteToBeNegativeViolated()
        {
            // Given
            var validator = new NullableDoubleValidator(0);

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

        #region double?.BeNull()

        [Fact(DisplayName = "double?.BeNull()")]
        public void ValidateNullableDoubleToBeNull()
        {
            // Given
            var validator = new NullableDoubleValidator(null);

            // When
            validator.BeNull();

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "double?.BeNull()")]
        public void ValidateNullableDoubleToBeNullViolated()
        {
            // Given
            var validator = new NullableDoubleValidator(0);

            // When
            var exception = Assert.Throws<XunitException>(() => validator.BeNull());

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is \"0\"{rn}but was expected to be null",
                exception.UserMessage);
        }

        [Fact(DisplayName = "double?.BeNull(reason)")]
        public void ValidateNullableToBeNullWithReasonViolated()
        {
            // Given
            var validator = new NullableDoubleValidator(0);

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

        #region double?.BeOneOf()

        [Fact(DisplayName = "double?.BeOneOf(double?, double?)")]
        public void ValidateDoubleToBeOneOfExpectedValues()
        {
            // Given
            var validator = new NullableDoubleValidator(42);

            // When
            validator.BeOneOf(new double?[] { 10, 42 });

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "double?.BeOneOf(double?, double?)")]
        public void ValidateNullableDoubleToBeOneOfExpectedValues()
        {
            // Given
            var validator = new NullableDoubleValidator(null);

            // When
            validator.BeOneOf(new double?[] { 10, null });

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "double?.BeOneOf(other, other)")]
        public void ValidateDoubleToBeOneOfViolated()
        {
            // Given
            var validator = new NullableDoubleValidator(42);

            // When
            var exception = Assert.Throws<XunitException>(() => validator.BeOneOf(new double?[] { 13, 39 }, because: "that's the bottom line"));

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is \"42\"{rn}but was expected to be one of the following values: \"13\", \"39\"{rn}because that's the bottom line",
                exception.UserMessage);
        }

        #endregion

        #region double?.BePositive()

        [Fact(DisplayName = "double?.BePositive()")]
        public void ValidateSByteToBePositive()
        {
            // Given
            var validator = new NullableDoubleValidator(0);

            // When
            validator.BePositive();

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "double?.BePositive()")]
        public void ValidateNullableSByteToBePositiveViolated()
        {
            // Given
            var validator = new NullableDoubleValidator(null);

            // When
            var exception = Assert.Throws<XunitException>(() => validator.BePositive(because: "that's the bottom line"));

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is \"\"{rn}but was expected to have a positive value{rn}because that's the bottom line",
                exception.UserMessage);
        }

        [Fact(DisplayName = "double?.BePositive()")]
        public void ValidateSByteToBePositiveViolated()
        {
            // Given
            var validator = new NullableDoubleValidator(-42);

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