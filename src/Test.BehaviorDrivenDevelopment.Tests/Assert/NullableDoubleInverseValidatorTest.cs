namespace CustomCode.Test.BehaviorDrivenDevelopment.Tests
{
    using System;
    using Xunit;
    using Xunit.Sdk;

    /// <summary>
    /// Test cases for the <see cref="NullableDoubleInverseValidator"/> type.
    /// </summary>
    [UnitTest]
    [Category("Assert", "DoubleValidation")]
    public sealed class NullableDoubleInverseValidatorTest
    {
        #region double?.NotBe()

        [Fact(DisplayName = "double?.NotBe(double?)")]
        public void ValidateDoubleNotToBeValue()
        {
            // Given
            var validator = new NullableDoubleInverseValidator(42);

            // When
            validator.Be(13);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "double?.NotBe(null)")]
        public void ValidateDoubleNotToBeNull()
        {
            // Given
            var validator = new NullableDoubleInverseValidator(42);

            // When
            validator.Be(null);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "double?.NotBe(other)")]
        public void ValidateDoubleNotToBeValueViolated()
        {
            // Given
            var validator = new NullableDoubleInverseValidator(42);

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

        #region double?.NotBeApproximately()

        [Fact(DisplayName = "double?.NotBeApproximately(double)")]
        public void ValidateDoubleToBeApproximatelyValue()
        {
            // Given
            var validator = new NullableDoubleInverseValidator(42.2);

            // When
            validator.BeApproximately(42, 0.1);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "double?.NotBeApproximately(double)")]
        public void ValidateNullableDoubleToBeApproximatelyValue()
        {
            // Given
            var validator = new NullableDoubleInverseValidator(null);

            // When
            validator.BeApproximately(42, 0.1);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "double?.NotBeApproximately(other)")]
        public void ValidateDoubleToBeApproximatelyValueViolated()
        {
            // Given
            var validator = new NullableDoubleInverseValidator(42.12345);

            // When
            var exception = Assert.Throws<XunitException>(() => validator.BeApproximately(42.12, 0.01, "that's the bottom line"));

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is \"42,12345\"{rn}but was expected to be approximately \"42,12\" (+/- 0,01){rn}because that's the bottom line",
                exception.UserMessage);
        }

        #endregion

        #region double?.NotBeBetween()

        [Fact(DisplayName = "double?.NotBeBetween(double, double)")]
        public void ValidateDoubleToNotBeBetweenSmallerValues()
        {
            // Given
            var validator = new NullableDoubleInverseValidator(42);

            // When
            validator.BeBetween(13, 39);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "double?.NotBeBetween(double, double)")]
        public void ValidateDoubleToNotBeBetweenBiggerValues()
        {
            // Given
            var validator = new NullableDoubleInverseValidator(42);

            // When
            validator.BeBetween(65, 100);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "double?.NotBeBetween(double, double)")]
        public void ValidateNullableDoubleToNotBeBetweenValues()
        {
            // Given
            var validator = new NullableDoubleInverseValidator(null);

            // When
            validator.BeBetween(65, 100);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "double?.BeBetween(wrongMinimum, wrongMaximum)")]
        public void ValidateDoubleToBeBetweenValuesMinimumAndMaximumViolated()
        {
            // Given
            var validator = new NullableDoubleInverseValidator(42);

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

        #region double?.NotBeGreaterThan()

        [Fact(DisplayName = "double?.NotBeGreaterThan(equalValue)")]
        public void ValidateDoubleToBeGreaterThanEqualValue()
        {
            // Given
            var validator = new NullableDoubleInverseValidator(42);

            // When
            validator.BeGreaterThan(42);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "double?.NotBeGreaterThan(biggerValue)")]
        public void ValidateDoubleToNotBeGreaterThanBiggerValue()
        {
            // Given
            var validator = new NullableDoubleInverseValidator(42);

            // When
            validator.BeGreaterThan(65);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "double?.NotBeGreaterThan(biggerValue)")]
        public void ValidateNullableDoubleToNotBeGreaterThanBiggerValue()
        {
            // Given
            var validator = new NullableDoubleInverseValidator(null);

            // When
            validator.BeGreaterThan(65);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "double?.NotBeGreaterThan(wrongMinimum)")]
        public void ValidateDoubleToNotBeGreaterThanValueViolated()
        {
            // Given
            var validator = new NullableDoubleInverseValidator(42);

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

        #region double?.NotBeGreaterThanOrEqualTo()

        [Fact(DisplayName = "double?.NotBeGreaterThanOrEqualTo(double)")]
        public void ValidateDoubleNotToBeGreaterThanOrEqualToValue()
        {
            // Given
            var validator = new NullableDoubleInverseValidator(42);

            // When
            validator.BeGreaterThanOrEqualTo(65);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "double?.NotBeGreaterThanOrEqualTo(double)")]
        public void ValidateNullableDoubleNotToBeGreaterThanOrEqualToValue()
        {
            // Given
            var validator = new NullableDoubleInverseValidator(null);

            // When
            validator.BeGreaterThanOrEqualTo(65);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "double?.NotBeGreaterThanOrEqualTo(wrongMinimum)")]
        public void ValidateDoubleNotToBeGreaterThanOrEqualToValueViolated()
        {
            // Given
            var validator = new NullableDoubleInverseValidator(42);

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

        #region double?.NotBeLessThan()

        [Fact(DisplayName = "double?.NotBeLessThan(equalValue)")]
        public void ValidateDoubleToBeLessThanEqualValue()
        {
            // Given
            var validator = new NullableDoubleInverseValidator(42);

            // When
            validator.BeLessThan(42);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "double?.NotBeLessThan(biggerValue)")]
        public void ValidateDoubleToNotBeLessThanBiggerValue()
        {
            // Given
            var validator = new NullableDoubleInverseValidator(42);

            // When
            validator.BeLessThan(13);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "double?.NotBeLessThan(biggerValue)")]
        public void ValidateNullableDoubleToNotBeLessThanBiggerValue()
        {
            // Given
            var validator = new NullableDoubleInverseValidator(null);

            // When
            validator.BeLessThan(13);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "double?.NotBeLessThan(wrongMaximum)")]
        public void ValidateDoubleToNotBeLessThanValueViolated()
        {
            // Given
            var validator = new NullableDoubleInverseValidator(42);

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

        #region double?.NotBeLessThanOrEqualTo()

        [Fact(DisplayName = "double?.NotBeLessThanOrEqualTo(double)")]
        public void ValidateDoubleNotToBeLessThanOrEqualToValue()
        {
            // Given
            var validator = new NullableDoubleInverseValidator(42);

            // When
            validator.BeLessThanOrEqualTo(13);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "double?.NotBeLessThanOrEqualTo(double)")]
        public void ValidateNullableDoubleNotToBeLessThanOrEqualToValue()
        {
            // Given
            var validator = new NullableDoubleInverseValidator(null);

            // When
            validator.BeLessThanOrEqualTo(13);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "double?.NotBeLessThanOrEqualTo(wrongMinimum)")]
        public void ValidateDoubleNotToBeLessThanOrEqualToValueViolated()
        {
            // Given
            var validator = new NullableDoubleInverseValidator(42);

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

        #region double?.NotBeNegative()

        [Fact(DisplayName = "double?.NotBeNegative()")]
        public void ValidateSByteNotToBeNegative()
        {
            // Given
            var validator = new NullableDoubleInverseValidator(0);

            // When
            validator.BeNegative();

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "double?.NotBeNegative()")]
        public void ValidateNullableSByteNotToBeNegative()
        {
            // Given
            var validator = new NullableDoubleInverseValidator(null);

            // When
            validator.BeNegative();

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "double?.NotBeNegative()")]
        public void ValidateSByteNotToBeNegativeViolated()
        {
            // Given
            var validator = new NullableDoubleInverseValidator(-42);

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

        #region double?.BeNull()

        [Fact(DisplayName = "double?.NotBeNull()")]
        public void ValidateNullableDoubleNotToBeNull()
        {
            // Given
            var validator = new NullableDoubleInverseValidator(0);

            // When
            validator.BeNull();

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "double?.NotBeNull()")]
        public void ValidateNullableDoubleNotToBeNullViolated()
        {
            // Given
            var validator = new NullableDoubleInverseValidator(null);

            // When
            var exception = Assert.Throws<XunitException>(() => validator.BeNull());

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is null{rn}but was expected not to be null",
                exception.UserMessage);
        }

        [Fact(DisplayName = "double?.NotBeNull(reason)")]
        public void ValidateNullableDoubleNotToBeNullWithReasonViolated()
        {
            // Given
            var validator = new NullableDoubleInverseValidator(null);

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

        #region double?.NotBeOneOf()

        [Fact(DisplayName = "double?.NotBeOneOf(other, other)")]
        public void ValidateDoubleNotToBeOneOfExpectedValues()
        {
            // Given
            var validator = new NullableDoubleInverseValidator(42);

            // When
            validator.BeOneOf(new double?[] { 10, 39 });

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "double?.NotBeOneOf(double?, double?)")]
        public void ValidateDoubleNotToBeOneOfViolated()
        {
            // Given
            var validator = new NullableDoubleInverseValidator(42);

            // When
            var exception = Assert.Throws<XunitException>(() => validator.BeOneOf(new double?[] { 13, 42 }, because: "that's the bottom line"));

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is \"42\"{rn}but was expected not to be one of the following values: \"13\", \"42\"{rn}because that's the bottom line",
                exception.UserMessage);
        }

        [Fact(DisplayName = "double?.NotBeOneOf(double?, double?)")]
        public void ValidateNullableDoubleNotToBeOneOfViolated()
        {
            // Given
            var validator = new NullableDoubleInverseValidator(null);

            // When
            var exception = Assert.Throws<XunitException>(() => validator.BeOneOf(new double?[] { null, 42 }, because: "that's the bottom line"));

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is \"\"{rn}but was expected not to be one of the following values: \"\", \"42\"{rn}because that's the bottom line",
                exception.UserMessage);
        }

        #endregion

        #region double?.NotBePositive()

        [Fact(DisplayName = "double?.NotBePositive()")]
        public void ValidateSByteToBePositive()
        {
            // Given
            var validator = new NullableDoubleInverseValidator(-42);

            // When
            validator.BePositive();

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "double?.NotBePositive()")]
        public void ValidateNullableSByteToBePositive()
        {
            // Given
            var validator = new NullableDoubleInverseValidator(null);

            // When
            validator.BePositive();

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "double?.NotBePositive()")]
        public void ValidateSByteNotToBePositiveViolated()
        {
            // Given
            var validator = new NullableDoubleInverseValidator(0);

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