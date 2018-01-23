namespace CustomCode.Test.BehaviorDrivenDevelopment.Tests
{
    using System;
    using Xunit;
    using Xunit.Sdk;

    /// <summary>
    /// Test cases for the <see cref="IntValidator"/> type.
    /// </summary>
    [UnitTest]
    [Category("Assert", "IntegerValidation")]
    public sealed class IntValidatorTest
    {
        #region int.Be()

        [Fact(DisplayName = "int.Be(int)")]
        public void ValidateIntegerToBeValue()
        {
            // Given
            var validator = new IntValidator(42);

            // When
            validator.Be(42);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "int.Be(other)")]
        public void ValidateIntegerToBeValueViolated()
        {
            // Given
            var validator = new IntValidator(42);

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

        #region int.BeBetween()

        [Fact(DisplayName = "int.BeBetween(int, int)")]
        public void ValidateIntegerToBeBetweenValues()
        {
            // Given
            var validator = new IntValidator(42);

            // When
            validator.BeBetween(13, 130);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "int.BeBetween(wrongMinimum, int)")]
        public void ValidateIntegerToBeBetweenValuesMinimumViolated()
        {
            // Given
            var validator = new IntValidator(42);

            // When
            var exception = Assert.Throws<XunitException>(() => validator.BeBetween(65, 130, "that's the bottom line"));

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is \"42\"{rn}but was expected to be between \"65\" and \"130\"{rn}because that's the bottom line",
                exception.UserMessage);
        }

        [Fact(DisplayName = "int.BeBetween(int, wrongMaximum)")]
        public void ValidateIntegerToBeBetweenValuesMaximumViolated()
        {
            // Given
            var validator = new IntValidator(42);

            // When
            var exception = Assert.Throws<XunitException>(() => validator.BeBetween(13, 39, "that's the bottom line"));

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is \"42\"{rn}but was expected to be between \"13\" and \"39\"{rn}because that's the bottom line",
                exception.UserMessage);
        }

        [Fact(DisplayName = "int.BeBetween(wrongMinimum, wrongMaximum)")]
        public void ValidateIntegerToBeBetweenValuesMinimumAndMaximumViolated()
        {
            // Given
            var validator = new IntValidator(42);

            // When
            var exception = Assert.Throws<XunitException>(() => validator.BeBetween(130, 13, "that's the bottom line"));

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is \"42\"{rn}but was expected to be between \"130\" and \"13\"{rn}because that's the bottom line",
                exception.UserMessage);
        }

        #endregion

        #region int.BeGreaterThan()

        [Fact(DisplayName = "int.BeGreaterThan(int)")]
        public void ValidateIntegerToBeGreaterThanValue()
        {
            // Given
            var validator = new IntValidator(42);

            // When
            validator.BeGreaterThan(13);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "int.BeGreaterThan(wrongMinimum)")]
        public void ValidateIntegerToBeGreaterThanValueViolated()
        {
            // Given
            var validator = new IntValidator(42);

            // When
            var exception = Assert.Throws<XunitException>(() => validator.BeGreaterThan(42, "that's the bottom line"));

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is \"42\"{rn}but was expected to be greater than \"42\"{rn}because that's the bottom line",
                exception.UserMessage);
        }

        #endregion

        #region int.BeGreaterThanOrEqualTo()

        [Fact(DisplayName = "int.BeGreaterThanOrEqualTo(smallerValue)")]
        public void ValidateIntegerToBeGreaterThanOrEqualToSmallerValue()
        {
            // Given
            var validator = new IntValidator(42);

            // When
            validator.BeGreaterThanOrEqualTo(13);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "int.BeGreaterThanOrEqualTo(equalValue)")]
        public void ValidateIntegerToBeGreaterThanOrEqualToEqualValue()
        {
            // Given
            var validator = new IntValidator(42);

            // When
            validator.BeGreaterThanOrEqualTo(42);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "int.BeGreaterThanOrEqualTo(wrongMinimum)")]
        public void ValidateIntegerToBeGreaterThanOrEqualToValueViolated()
        {
            // Given
            var validator = new IntValidator(42);

            // When
            var exception = Assert.Throws<XunitException>(() => validator.BeGreaterThanOrEqualTo(65, "that's the bottom line"));

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is \"42\"{rn}but was expected to be greater than or equal to \"65\"{rn}because that's the bottom line",
                exception.UserMessage);
        }

        #endregion

        #region int.BeLessThan()

        [Fact(DisplayName = "int.BeLessThan(int)")]
        public void ValidateIntegerToBeLessThanValue()
        {
            // Given
            var validator = new IntValidator(42);

            // When
            validator.BeLessThan(65);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "int.BeLessThan(wrongMinimum)")]
        public void ValidateIntegerToBeLessThanValueViolated()
        {
            // Given
            var validator = new IntValidator(42);

            // When
            var exception = Assert.Throws<XunitException>(() => validator.BeLessThan(42, "that's the bottom line"));

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is \"42\"{rn}but was expected to be less than \"42\"{rn}because that's the bottom line",
                exception.UserMessage);
        }

        #endregion

        #region int.BeLessThanOrEqualTo()

        [Fact(DisplayName = "int.BeLessThanOrEqualTo(biggerValue)")]
        public void ValidateIntegerToBeLessThanOrEqualToBiggerValue()
        {
            // Given
            var validator = new IntValidator(42);

            // When
            validator.BeLessThanOrEqualTo(65);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "int.BeLessThanOrEqualTo(equalValue)")]
        public void ValidateIntegerToBeLessThanOrEqualToEqualValue()
        {
            // Given
            var validator = new IntValidator(42);

            // When
            validator.BeLessThanOrEqualTo(42);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "int.BeLessThanOrEqualTo(wrongMaximum)")]
        public void ValidateIntegerToBeLessThanOrEqualToValueViolated()
        {
            // Given
            var validator = new IntValidator(42);

            // When
            var exception = Assert.Throws<XunitException>(() => validator.BeLessThanOrEqualTo(13, "that's the bottom line"));

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is \"42\"{rn}but was expected to be less than or equal to \"13\"{rn}because that's the bottom line",
                exception.UserMessage);
        }

        #endregion

        #region int.BeNegative()

        [Fact(DisplayName = "int.BeNegative()")]
        public void ValidateIntegerToBeNegative()
        {
            // Given
            var validator = new IntValidator(-42);

            // When
            validator.BeNegative();

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "int.BeNegative()")]
        public void ValidateIntegerToBeNegativeViolated()
        {
            // Given
            var validator = new IntValidator(0);

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

        #region int.BeOneOf()

        [Fact(DisplayName = "int.BeOneOf(int, int)")]
        public void ValidateIntegerToBeOneOfExpectedValues()
        {
            // Given
            var validator = new IntValidator(42);

            // When
            validator.BeOneOf(new[] { 10, 42 });

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "int.BeOneOf(other, other)")]
        public void ValidateIntegerToBeOneOfViolated()
        {
            // Given
            var validator = new IntValidator(42);

            // When
            var exception = Assert.Throws<XunitException>(() => validator.BeOneOf(new[] { 13, 39 }, because: "that's the bottom line"));

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is \"42\"{rn}but was expected to be one of the following values: \"13\", \"39\"{rn}because that's the bottom line",
                exception.UserMessage);
        }

        #endregion

        #region int.BePositive()

        [Fact(DisplayName = "int.BePositive()")]
        public void ValidateIntegerToBePositive()
        {
            // Given
            var validator = new IntValidator(0);

            // When
            validator.BePositive();

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "int.BePositive()")]
        public void ValidateIntegerToBePositiveViolated()
        {
            // Given
            var validator = new IntValidator(-42);

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