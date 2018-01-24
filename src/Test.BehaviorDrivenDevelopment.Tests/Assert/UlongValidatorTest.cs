namespace CustomCode.Test.BehaviorDrivenDevelopment.Tests
{
    using System;
    using Xunit;
    using Xunit.Sdk;

    /// <summary>
    /// Test cases for the <see cref="UlongValidator"/> type.
    /// </summary>
    [UnitTest]
    [Category("Assert", "ULongValidation")]
    public sealed class UlongValidatorTest
    {
        #region ulong.Be()

        [Fact(DisplayName = "ulong.Be(ulong)")]
        public void ValidateULongToBeValue()
        {
            // Given
            var validator = new UlongValidator(42);

            // When
            validator.Be(42);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "ulong.Be(other)")]
        public void ValidateULongToBeValueViolated()
        {
            // Given
            var validator = new UlongValidator(42);

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

        #region ulong.BeBetween()

        [Fact(DisplayName = "ulong.BeBetween(ulong, ulong)")]
        public void ValidateULongToBeBetweenValues()
        {
            // Given
            var validator = new UlongValidator(42);

            // When
            validator.BeBetween(13, 130);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "ulong.BeBetween(wrongMinimum, ulong)")]
        public void ValidateULongToBeBetweenValuesMinimumViolated()
        {
            // Given
            var validator = new UlongValidator(42);

            // When
            var exception = Assert.Throws<XunitException>(() => validator.BeBetween(65, 130, "that's the bottom line"));

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is \"42\"{rn}but was expected to be between \"65\" and \"130\"{rn}because that's the bottom line",
                exception.UserMessage);
        }

        [Fact(DisplayName = "ulong.BeBetween(ulong, wrongMaximum)")]
        public void ValidateULongToBeBetweenValuesMaximumViolated()
        {
            // Given
            var validator = new UlongValidator(42);

            // When
            var exception = Assert.Throws<XunitException>(() => validator.BeBetween(13, 39, "that's the bottom line"));

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is \"42\"{rn}but was expected to be between \"13\" and \"39\"{rn}because that's the bottom line",
                exception.UserMessage);
        }

        [Fact(DisplayName = "ulong.BeBetween(wrongMinimum, wrongMaximum)")]
        public void ValidateULongToBeBetweenValuesMinimumAndMaximumViolated()
        {
            // Given
            var validator = new UlongValidator(42);

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

        #region ulong.BeGreaterThan()

        [Fact(DisplayName = "ulong.BeGreaterThan(ulong)")]
        public void ValidateULongToBeGreaterThanValue()
        {
            // Given
            var validator = new UlongValidator(42);

            // When
            validator.BeGreaterThan(13);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "ulong.BeGreaterThan(wrongMinimum)")]
        public void ValidateULongToBeGreaterThanValueViolated()
        {
            // Given
            var validator = new UlongValidator(42);

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

        #region ulong.BeGreaterThanOrEqualTo()

        [Fact(DisplayName = "ulong.BeGreaterThanOrEqualTo(smallerValue)")]
        public void ValidateULongToBeGreaterThanOrEqualToSmallerValue()
        {
            // Given
            var validator = new UlongValidator(42);

            // When
            validator.BeGreaterThanOrEqualTo(13);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "ulong.BeGreaterThanOrEqualTo(equalValue)")]
        public void ValidateULongToBeGreaterThanOrEqualToEqualValue()
        {
            // Given
            var validator = new UlongValidator(42);

            // When
            validator.BeGreaterThanOrEqualTo(42);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "ulong.BeGreaterThanOrEqualTo(wrongMinimum)")]
        public void ValidateULongToBeGreaterThanOrEqualToValueViolated()
        {
            // Given
            var validator = new UlongValidator(42);

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

        #region ulong.BeLessThan()

        [Fact(DisplayName = "ulong.BeLessThan(ulong)")]
        public void ValidateULongToBeLessThanValue()
        {
            // Given
            var validator = new UlongValidator(42);

            // When
            validator.BeLessThan(65);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "ulong.BeLessThan(wrongMinimum)")]
        public void ValidateULongToBeLessThanValueViolated()
        {
            // Given
            var validator = new UlongValidator(42);

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

        #region ulong.BeLessThanOrEqualTo()

        [Fact(DisplayName = "ulong.BeLessThanOrEqualTo(biggerValue)")]
        public void ValidateULongToBeLessThanOrEqualToBiggerValue()
        {
            // Given
            var validator = new UlongValidator(42);

            // When
            validator.BeLessThanOrEqualTo(65);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "ulong.BeLessThanOrEqualTo(equalValue)")]
        public void ValidateULongToBeLessThanOrEqualToEqualValue()
        {
            // Given
            var validator = new UlongValidator(42);

            // When
            validator.BeLessThanOrEqualTo(42);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "ulong.BeLessThanOrEqualTo(wrongMaximum)")]
        public void ValidateULongToBeLessThanOrEqualToValueViolated()
        {
            // Given
            var validator = new UlongValidator(42);

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

        #region ulong.BeOneOf()

        [Fact(DisplayName = "ulong.BeOneOf(ulong, ulong)")]
        public void ValidateULongToBeOneOfExpectedValues()
        {
            // Given
            var validator = new UlongValidator(42);

            // When
            validator.BeOneOf(new ulong[] { 10, 42 });

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "ulong.BeOneOf(other, other)")]
        public void ValidateULongToBeOneOfViolated()
        {
            // Given
            var validator = new UlongValidator(42);

            // When
            var exception = Assert.Throws<XunitException>(() => validator.BeOneOf(new ulong[] { 13, 39 }, because: "that's the bottom line"));

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