namespace CustomCode.Test.BehaviorDrivenDevelopment.Tests
{
    using System;
    using Xunit;
    using Xunit.Sdk;

    /// <summary>
    /// Test cases for the <see cref="ShortValidator"/> type.
    /// </summary>
    [UnitTest]
    [Category("Assert", "ShortValidation")]
    public sealed class ShortValidatorTest
    {
        #region short.Be()

        [Fact(DisplayName = "short.Be(short)")]
        public void ValidateShortToBeValue()
        {
            // Given
            var validator = new ShortValidator(42);

            // When
            validator.Be(42);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "short.Be(other)")]
        public void ValidateShortToBeValueViolated()
        {
            // Given
            var validator = new ShortValidator(42);

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

        #region short.BeBetween()

        [Fact(DisplayName = "short.BeBetween(short, short)")]
        public void ValidateShortToBeBetweenValues()
        {
            // Given
            var validator = new ShortValidator(42);

            // When
            validator.BeBetween(13, 130);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "short.BeBetween(wrongMinimum, short)")]
        public void ValidateShortToBeBetweenValuesMinimumViolated()
        {
            // Given
            var validator = new ShortValidator(42);

            // When
            var exception = Assert.Throws<XunitException>(() => validator.BeBetween(65, 130, "that's the bottom line"));

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is \"42\"{rn}but was expected to be between \"65\" and \"130\"{rn}because that's the bottom line",
                exception.UserMessage);
        }

        [Fact(DisplayName = "short.BeBetween(short, wrongMaximum)")]
        public void ValidateShortToBeBetweenValuesMaximumViolated()
        {
            // Given
            var validator = new ShortValidator(42);

            // When
            var exception = Assert.Throws<XunitException>(() => validator.BeBetween(13, 39, "that's the bottom line"));

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is \"42\"{rn}but was expected to be between \"13\" and \"39\"{rn}because that's the bottom line",
                exception.UserMessage);
        }

        [Fact(DisplayName = "short.BeBetween(wrongMinimum, wrongMaximum)")]
        public void ValidateShortToBeBetweenValuesMinimumAndMaximumViolated()
        {
            // Given
            var validator = new ShortValidator(42);

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

        #region short.BeGreaterThan()

        [Fact(DisplayName = "short.BeGreaterThan(short)")]
        public void ValidateShortToBeGreaterThanValue()
        {
            // Given
            var validator = new ShortValidator(42);

            // When
            validator.BeGreaterThan(13);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "short.BeGreaterThan(wrongMinimum)")]
        public void ValidateShortToBeGreaterThanValueViolated()
        {
            // Given
            var validator = new ShortValidator(42);

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

        #region short.BeGreaterThanOrEqualTo()

        [Fact(DisplayName = "short.BeGreaterThanOrEqualTo(smallerValue)")]
        public void ValidateShortToBeGreaterThanOrEqualToSmallerValue()
        {
            // Given
            var validator = new ShortValidator(42);

            // When
            validator.BeGreaterThanOrEqualTo(13);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "short.BeGreaterThanOrEqualTo(equalValue)")]
        public void ValidateShortToBeGreaterThanOrEqualToEqualValue()
        {
            // Given
            var validator = new ShortValidator(42);

            // When
            validator.BeGreaterThanOrEqualTo(42);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "short.BeGreaterThanOrEqualTo(wrongMinimum)")]
        public void ValidateShortToBeGreaterThanOrEqualToValueViolated()
        {
            // Given
            var validator = new ShortValidator(42);

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

        #region short.BeLessThan()

        [Fact(DisplayName = "short.BeLessThan(short)")]
        public void ValidateShortToBeLessThanValue()
        {
            // Given
            var validator = new ShortValidator(42);

            // When
            validator.BeLessThan(65);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "short.BeLessThan(wrongMinimum)")]
        public void ValidateShortToBeLessThanValueViolated()
        {
            // Given
            var validator = new ShortValidator(42);

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

        #region short.BeLessThanOrEqualTo()

        [Fact(DisplayName = "short.BeLessThanOrEqualTo(biggerValue)")]
        public void ValidateShortToBeLessThanOrEqualToBiggerValue()
        {
            // Given
            var validator = new ShortValidator(42);

            // When
            validator.BeLessThanOrEqualTo(65);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "short.BeLessThanOrEqualTo(equalValue)")]
        public void ValidateShortToBeLessThanOrEqualToEqualValue()
        {
            // Given
            var validator = new ShortValidator(42);

            // When
            validator.BeLessThanOrEqualTo(42);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "short.BeLessThanOrEqualTo(wrongMaximum)")]
        public void ValidateShortToBeLessThanOrEqualToValueViolated()
        {
            // Given
            var validator = new ShortValidator(42);

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

        #region short.BeNegative()

        [Fact(DisplayName = "short.BeNegative()")]
        public void ValidateShortToBeNegative()
        {
            // Given
            var validator = new ShortValidator(-42);

            // When
            validator.BeNegative();

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "short.BeNegative()")]
        public void ValidateShortToBeNegativeViolated()
        {
            // Given
            var validator = new ShortValidator(0);

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

        #region short.BeOneOf()

        [Fact(DisplayName = "short.BeOneOf(short, short)")]
        public void ValidateShortToBeOneOfExpectedValues()
        {
            // Given
            var validator = new ShortValidator(42);

            // When
            validator.BeOneOf(new short[] { 10, 42 });

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "short.BeOneOf(other, other)")]
        public void ValidateShortToBeOneOfViolated()
        {
            // Given
            var validator = new ShortValidator(42);

            // When
            var exception = Assert.Throws<XunitException>(() => validator.BeOneOf(new short[] { 13, 39 }, because: "that's the bottom line"));

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is \"42\"{rn}but was expected to be one of the following values: \"13\", \"39\"{rn}because that's the bottom line",
                exception.UserMessage);
        }

        #endregion

        #region short.BePositive()

        [Fact(DisplayName = "short.BePositive()")]
        public void ValidateShortToBePositive()
        {
            // Given
            var validator = new ShortValidator(0);

            // When
            validator.BePositive();

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "short.BePositive()")]
        public void ValidateShortToBePositiveViolated()
        {
            // Given
            var validator = new ShortValidator(-42);

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