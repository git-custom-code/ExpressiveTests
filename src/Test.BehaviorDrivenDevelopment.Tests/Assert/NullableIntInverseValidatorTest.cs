namespace CustomCode.Test.BehaviorDrivenDevelopment.Tests
{
    using System;
    using Xunit;
    using Xunit.Sdk;

    /// <summary>
    /// Test cases for the <see cref="NullableIntInverseValidator"/> type.
    /// </summary>
    [UnitTest]
    [Category("Assert", "IntegerValidation")]
    public sealed class NullableIntInverseValidatorTest
    {
        #region int?.NotBe()

        [Fact(DisplayName = "int?.NotBe(int?)")]
        public void ValidateIntNotToBeValue()
        {
            // Given
            var validator = new NullableIntInverseValidator(42);

            // When
            validator.Be(13);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "int?.NotBe(null)")]
        public void ValidateIntNotToBeNull()
        {
            // Given
            var validator = new NullableIntInverseValidator(42);

            // When
            validator.Be(null);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "int?.NotBe(other)")]
        public void ValidateIntNotToBeValueViolated()
        {
            // Given
            var validator = new NullableIntInverseValidator(42);

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

        #region int?.NotBeBetween()

        [Fact(DisplayName = "int?.NotBeBetween(int, int)")]
        public void ValidateIntToNotBeBetweenSmallerValues()
        {
            // Given
            var validator = new NullableIntInverseValidator(42);

            // When
            validator.BeBetween(13, 39);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "int?.NotBeBetween(int, int)")]
        public void ValidateIntToNotBeBetweenBiggerValues()
        {
            // Given
            var validator = new NullableIntInverseValidator(42);

            // When
            validator.BeBetween(65, 100);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "int?.NotBeBetween(int, int)")]
        public void ValidateNullableIntToNotBeBetweenValues()
        {
            // Given
            var validator = new NullableIntInverseValidator(null);

            // When
            validator.BeBetween(65, 100);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "int?.BeBetween(wrongMinimum, wrongMaximum)")]
        public void ValidateIntToBeBetweenValuesMinimumAndMaximumViolated()
        {
            // Given
            var validator = new NullableIntInverseValidator(42);

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

        #region int?.NotBeGreaterThan()

        [Fact(DisplayName = "int?.NotBeGreaterThan(equalValue)")]
        public void ValidateIntToBeGreaterThanEqualValue()
        {
            // Given
            var validator = new NullableIntInverseValidator(42);

            // When
            validator.BeGreaterThan(42);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "int?.NotBeGreaterThan(biggerValue)")]
        public void ValidateIntToNotBeGreaterThanBiggerValue()
        {
            // Given
            var validator = new NullableIntInverseValidator(42);

            // When
            validator.BeGreaterThan(65);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "int?.NotBeGreaterThan(biggerValue)")]
        public void ValidateNullableIntToNotBeGreaterThanBiggerValue()
        {
            // Given
            var validator = new NullableIntInverseValidator(null);

            // When
            validator.BeGreaterThan(65);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "int?.NotBeGreaterThan(wrongMinimum)")]
        public void ValidateIntToNotBeGreaterThanValueViolated()
        {
            // Given
            var validator = new NullableIntInverseValidator(42);

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

        #region int?.NotBeGreaterThanOrEqualTo()

        [Fact(DisplayName = "int?.NotBeGreaterThanOrEqualTo(int)")]
        public void ValidateIntNotToBeGreaterThanOrEqualToValue()
        {
            // Given
            var validator = new NullableIntInverseValidator(42);

            // When
            validator.BeGreaterThanOrEqualTo(65);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "int?.NotBeGreaterThanOrEqualTo(int)")]
        public void ValidateNullableIntNotToBeGreaterThanOrEqualToValue()
        {
            // Given
            var validator = new NullableIntInverseValidator(null);

            // When
            validator.BeGreaterThanOrEqualTo(65);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "int?.NotBeGreaterThanOrEqualTo(wrongMinimum)")]
        public void ValidateIntNotToBeGreaterThanOrEqualToValueViolated()
        {
            // Given
            var validator = new NullableIntInverseValidator(42);

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

        #region int?.NotBeLessThan()

        [Fact(DisplayName = "int?.NotBeLessThan(equalValue)")]
        public void ValidateIntToBeLessThanEqualValue()
        {
            // Given
            var validator = new NullableIntInverseValidator(42);

            // When
            validator.BeLessThan(42);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "int?.NotBeLessThan(biggerValue)")]
        public void ValidateIntToNotBeLessThanBiggerValue()
        {
            // Given
            var validator = new NullableIntInverseValidator(42);

            // When
            validator.BeLessThan(13);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "int?.NotBeLessThan(biggerValue)")]
        public void ValidateNullableIntToNotBeLessThanBiggerValue()
        {
            // Given
            var validator = new NullableIntInverseValidator(null);

            // When
            validator.BeLessThan(13);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "int?.NotBeLessThan(wrongMaximum)")]
        public void ValidateIntToNotBeLessThanValueViolated()
        {
            // Given
            var validator = new NullableIntInverseValidator(42);

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

        #region int?.NotBeLessThanOrEqualTo()

        [Fact(DisplayName = "int?.NotBeLessThanOrEqualTo(int)")]
        public void ValidateIntNotToBeLessThanOrEqualToValue()
        {
            // Given
            var validator = new NullableIntInverseValidator(42);

            // When
            validator.BeLessThanOrEqualTo(13);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "int?.NotBeLessThanOrEqualTo(int)")]
        public void ValidateNullableIntNotToBeLessThanOrEqualToValue()
        {
            // Given
            var validator = new NullableIntInverseValidator(null);

            // When
            validator.BeLessThanOrEqualTo(13);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "int?.NotBeLessThanOrEqualTo(wrongMinimum)")]
        public void ValidateIntNotToBeLessThanOrEqualToValueViolated()
        {
            // Given
            var validator = new NullableIntInverseValidator(42);

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

        #region int?.NotBeNegative()

        [Fact(DisplayName = "int?.NotBeNegative()")]
        public void ValidateSByteNotToBeNegative()
        {
            // Given
            var validator = new NullableIntInverseValidator(0);

            // When
            validator.BeNegative();

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "int?.NotBeNegative()")]
        public void ValidateNullableSByteNotToBeNegative()
        {
            // Given
            var validator = new NullableIntInverseValidator(null);

            // When
            validator.BeNegative();

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "int?.NotBeNegative()")]
        public void ValidateSByteNotToBeNegativeViolated()
        {
            // Given
            var validator = new NullableIntInverseValidator(-42);

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

        #region int?.BeNull()

        [Fact(DisplayName = "int?.NotBeNull()")]
        public void ValidateNullableIntNotToBeNull()
        {
            // Given
            var validator = new NullableIntInverseValidator(0);

            // When
            validator.BeNull();

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "int?.NotBeNull()")]
        public void ValidateNullableIntNotToBeNullViolated()
        {
            // Given
            var validator = new NullableIntInverseValidator(null);

            // When
            var exception = Assert.Throws<XunitException>(() => validator.BeNull());

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is null{rn}but was expected not to be null",
                exception.UserMessage);
        }

        [Fact(DisplayName = "int?.NotBeNull(reason)")]
        public void ValidateNullableIntNotToBeNullWithReasonViolated()
        {
            // Given
            var validator = new NullableIntInverseValidator(null);

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

        #region int?.NotBeOneOf()

        [Fact(DisplayName = "int?.NotBeOneOf(other, other)")]
        public void ValidateIntNotToBeOneOfExpectedValues()
        {
            // Given
            var validator = new NullableIntInverseValidator(42);

            // When
            validator.BeOneOf(new int?[] { 10, 39 });

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "int?.NotBeOneOf(int?, int?)")]
        public void ValidateIntNotToBeOneOfViolated()
        {
            // Given
            var validator = new NullableIntInverseValidator(42);

            // When
            var exception = Assert.Throws<XunitException>(() => validator.BeOneOf(new int?[] { 13, 42 }, because: "that's the bottom line"));

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is \"42\"{rn}but was expected not to be one of the following values: \"13\", \"42\"{rn}because that's the bottom line",
                exception.UserMessage);
        }

        [Fact(DisplayName = "int?.NotBeOneOf(int?, int?)")]
        public void ValidateNullableIntNotToBeOneOfViolated()
        {
            // Given
            var validator = new NullableIntInverseValidator(null);

            // When
            var exception = Assert.Throws<XunitException>(() => validator.BeOneOf(new int?[] { null, 42 }, because: "that's the bottom line"));

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is \"\"{rn}but was expected not to be one of the following values: \"\", \"42\"{rn}because that's the bottom line",
                exception.UserMessage);
        }

        #endregion

        #region int?.NotBePositive()

        [Fact(DisplayName = "int?.NotBePositive()")]
        public void ValidateSByteToBePositive()
        {
            // Given
            var validator = new NullableIntInverseValidator(-42);

            // When
            validator.BePositive();

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "int?.NotBePositive()")]
        public void ValidateNullableSByteToBePositive()
        {
            // Given
            var validator = new NullableIntInverseValidator(null);

            // When
            validator.BePositive();

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "int?.NotBePositive()")]
        public void ValidateSByteNotToBePositiveViolated()
        {
            // Given
            var validator = new NullableIntInverseValidator(0);

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