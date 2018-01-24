namespace CustomCode.Test.BehaviorDrivenDevelopment.Tests
{
    using System;
    using Xunit;
    using Xunit.Sdk;

    /// <summary>
    /// Test cases for the <see cref="UlongInverseValidator"/> type.
    /// </summary>
    [UnitTest]
    [Category("Assert", "ULongValidation")]
    public sealed class UlongInverseValidatorTest
    {
        #region ulong.NotBe()

        [Fact(DisplayName = "ulong.NotBe(ulong)")]
        public void ValidateULongNotToBeValue()
        {
            // Given
            var validator = new UlongInverseValidator(42);

            // When
            validator.Be(13);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "ulong.NotBe(other)")]
        public void ValidateULongNotToBeValueViolated()
        {
            // Given
            var validator = new UlongInverseValidator(42);

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

        #region ulong.NotBeBetween()

        [Fact(DisplayName = "ulong.NotBeBetween(ulong, ulong)")]
        public void ValidateULongToNotBeBetweenSmallerValues()
        {
            // Given
            var validator = new UlongInverseValidator(42);

            // When
            validator.BeBetween(13, 39);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "ulong.NotBeBetween(ulong, ulong)")]
        public void ValidateULongToNotBeBetweenBiggerValues()
        {
            // Given
            var validator = new UlongInverseValidator(42);

            // When
            validator.BeBetween(65, 130);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "ulong.BeBetween(wrongMinimum, wrongMaximum)")]
        public void ValidateULongToBeBetweenValuesMinimumAndMaximumViolated()
        {
            // Given
            var validator = new UlongInverseValidator(42);

            // When
            var exception = Assert.Throws<XunitException>(() => validator.BeBetween(13, 130, "that's the bottom line"));

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is \"42\"{rn}but was expected not to be between \"13\" and \"130\"{rn}because that's the bottom line",
                exception.UserMessage);
        }

        #endregion

        #region ulong.NotBeGreaterThan()

        [Fact(DisplayName = "ulong.NotBeGreaterThan(equalValue)")]
        public void ValidateULongToBeGreaterThanEqualValue()
        {
            // Given
            var validator = new UlongInverseValidator(42);

            // When
            validator.BeGreaterThan(42);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "ulong.NotBeGreaterThan(biggerValue)")]
        public void ValidateULongToNotBeGreaterThanBiggerValue()
        {
            // Given
            var validator = new UlongInverseValidator(42);

            // When
            validator.BeGreaterThan(65);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "ulong.NotBeGreaterThan(wrongMinimum)")]
        public void ValidateULongToNotBeGreaterThanValueViolated()
        {
            // Given
            var validator = new UlongInverseValidator(42);

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

        #region ulong.NotBeGreaterThanOrEqualTo()

        [Fact(DisplayName = "ulong.NotBeGreaterThanOrEqualTo(ulong)")]
        public void ValidateULongNotToBeGreaterThanOrEqualToValue()
        {
            // Given
            var validator = new UlongInverseValidator(42);

            // When
            validator.BeGreaterThanOrEqualTo(65);

            // Then
            Assert.True(true);
        }


        [Fact(DisplayName = "ulong.NotBeGreaterThanOrEqualTo(wrongMinimum)")]
        public void ValidateULongNotToBeGreaterThanOrEqualToValueViolated()
        {
            // Given
            var validator = new UlongInverseValidator(42);

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

        #region ulong.NotBeLessThan()

        [Fact(DisplayName = "ulong.NotBeLessThan(equalValue)")]
        public void ValidateULongToBeLessThanEqualValue()
        {
            // Given
            var validator = new UlongInverseValidator(42);

            // When
            validator.BeLessThan(42);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "ulong.NotBeLessThan(biggerValue)")]
        public void ValidateULongToNotBeLessThanBiggerValue()
        {
            // Given
            var validator = new UlongInverseValidator(42);

            // When
            validator.BeLessThan(13);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "ulong.NotBeLessThan(wrongMaximum)")]
        public void ValidateULongToNotBeLessThanValueViolated()
        {
            // Given
            var validator = new UlongInverseValidator(42);

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

        #region ulong.NotBeLessThanOrEqualTo()

        [Fact(DisplayName = "ulong.NotBeLessThanOrEqualTo(ulong)")]
        public void ValidateULongNotToBeLessThanOrEqualToValue()
        {
            // Given
            var validator = new UlongInverseValidator(42);

            // When
            validator.BeLessThanOrEqualTo(13);

            // Then
            Assert.True(true);
        }


        [Fact(DisplayName = "ulong.NotBeLessThanOrEqualTo(wrongMinimum)")]
        public void ValidateULongNotToBeLessThanOrEqualToValueViolated()
        {
            // Given
            var validator = new UlongInverseValidator(42);

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

        #region ulong.NotBeOneOf()

        [Fact(DisplayName = "ulong.NotBeOneOf(other, other)")]
        public void ValidateULongNotToBeOneOfExpectedValues()
        {
            // Given
            var validator = new UlongInverseValidator(42);

            // When
            validator.BeOneOf(new ulong[] { 10, 39 });

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "ulong.NotBeOneOf(ulong, ulong)")]
        public void ValidateULongNotToBeOneOfViolated()
        {
            // Given
            var validator = new UlongInverseValidator(42);

            // When
            var exception = Assert.Throws<XunitException>(() => validator.BeOneOf(new ulong[] { 13, 42 }, because: "that's the bottom line"));

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is \"42\"{rn}but was expected not to be one of the following values: \"13\", \"42\"{rn}because that's the bottom line",
                exception.UserMessage);
        }

        #endregion
    }
}