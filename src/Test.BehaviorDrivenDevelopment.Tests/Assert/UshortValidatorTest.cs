namespace CustomCode.Test.BehaviorDrivenDevelopment.Tests
{
    using System;
    using Xunit;
    using Xunit.Sdk;

    /// <summary>
    /// Test cases for the <see cref="UshortValidator"/> type.
    /// </summary>
    [UnitTest]
    [Category("Assert", "UShortValidation")]
    public sealed class UshortValidatorTest
    {
        #region ushort.Be()

        [Fact(DisplayName = "ushort.Be(ushort)")]
        public void ValidateUShortToBeValue()
        {
            // Given
            var validator = new UshortValidator(42);

            // When
            validator.Be(42);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "ushort.Be(other)")]
        public void ValidateUShortToBeValueViolated()
        {
            // Given
            var validator = new UshortValidator(42);

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

        #region ushort.BeBetween()

        [Fact(DisplayName = "ushort.BeBetween(ushort, ushort)")]
        public void ValidateUShortToBeBetweenValues()
        {
            // Given
            var validator = new UshortValidator(42);

            // When
            validator.BeBetween(13, 130);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "ushort.BeBetween(wrongMinimum, ushort)")]
        public void ValidateUShortToBeBetweenValuesMinimumViolated()
        {
            // Given
            var validator = new UshortValidator(42);

            // When
            var exception = Assert.Throws<XunitException>(() => validator.BeBetween(65, 130, "that's the bottom line"));

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is \"42\"{rn}but was expected to be between \"65\" and \"130\"{rn}because that's the bottom line",
                exception.UserMessage);
        }

        [Fact(DisplayName = "ushort.BeBetween(ushort, wrongMaximum)")]
        public void ValidateUShortToBeBetweenValuesMaximumViolated()
        {
            // Given
            var validator = new UshortValidator(42);

            // When
            var exception = Assert.Throws<XunitException>(() => validator.BeBetween(13, 39, "that's the bottom line"));

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is \"42\"{rn}but was expected to be between \"13\" and \"39\"{rn}because that's the bottom line",
                exception.UserMessage);
        }

        [Fact(DisplayName = "ushort.BeBetween(wrongMinimum, wrongMaximum)")]
        public void ValidateUShortToBeBetweenValuesMinimumAndMaximumViolated()
        {
            // Given
            var validator = new UshortValidator(42);

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

        #region ushort.BeGreaterThan()

        [Fact(DisplayName = "ushort.BeGreaterThan(ushort)")]
        public void ValidateUShortToBeGreaterThanValue()
        {
            // Given
            var validator = new UshortValidator(42);

            // When
            validator.BeGreaterThan(13);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "ushort.BeGreaterThan(wrongMinimum)")]
        public void ValidateUShortToBeGreaterThanValueViolated()
        {
            // Given
            var validator = new UshortValidator(42);

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

        #region ushort.BeGreaterThanOrEqualTo()

        [Fact(DisplayName = "ushort.BeGreaterThanOrEqualTo(smallerValue)")]
        public void ValidateUShortToBeGreaterThanOrEqualToSmallerValue()
        {
            // Given
            var validator = new UshortValidator(42);

            // When
            validator.BeGreaterThanOrEqualTo(13);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "ushort.BeGreaterThanOrEqualTo(equalValue)")]
        public void ValidateUShortToBeGreaterThanOrEqualToEqualValue()
        {
            // Given
            var validator = new UshortValidator(42);

            // When
            validator.BeGreaterThanOrEqualTo(42);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "ushort.BeGreaterThanOrEqualTo(wrongMinimum)")]
        public void ValidateUShortToBeGreaterThanOrEqualToValueViolated()
        {
            // Given
            var validator = new UshortValidator(42);

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

        #region ushort.BeLessThan()

        [Fact(DisplayName = "ushort.BeLessThan(ushort)")]
        public void ValidateUShortToBeLessThanValue()
        {
            // Given
            var validator = new UshortValidator(42);

            // When
            validator.BeLessThan(65);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "ushort.BeLessThan(wrongMinimum)")]
        public void ValidateUShortToBeLessThanValueViolated()
        {
            // Given
            var validator = new UshortValidator(42);

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

        #region ushort.BeLessThanOrEqualTo()

        [Fact(DisplayName = "ushort.BeLessThanOrEqualTo(biggerValue)")]
        public void ValidateUShortToBeLessThanOrEqualToBiggerValue()
        {
            // Given
            var validator = new UshortValidator(42);

            // When
            validator.BeLessThanOrEqualTo(65);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "ushort.BeLessThanOrEqualTo(equalValue)")]
        public void ValidateUShortToBeLessThanOrEqualToEqualValue()
        {
            // Given
            var validator = new UshortValidator(42);

            // When
            validator.BeLessThanOrEqualTo(42);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "ushort.BeLessThanOrEqualTo(wrongMaximum)")]
        public void ValidateUShortToBeLessThanOrEqualToValueViolated()
        {
            // Given
            var validator = new UshortValidator(42);

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

        #region ushort.BeOneOf()

        [Fact(DisplayName = "ushort.BeOneOf(ushort, ushort)")]
        public void ValidateUShortToBeOneOfExpectedValues()
        {
            // Given
            var validator = new UshortValidator(42);

            // When
            validator.BeOneOf(new ushort[] { 10, 42 });

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "ushort.BeOneOf(other, other)")]
        public void ValidateUShortToBeOneOfViolated()
        {
            // Given
            var validator = new UshortValidator(42);

            // When
            var exception = Assert.Throws<XunitException>(() => validator.BeOneOf(new ushort[] { 13, 39 }, because: "that's the bottom line"));

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