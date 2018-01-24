namespace CustomCode.Test.BehaviorDrivenDevelopment.Tests
{
    using System;
    using Xunit;
    using Xunit.Sdk;

    /// <summary>
    /// Test cases for the <see cref="LongInverseValidator"/> type.
    /// </summary>
    [UnitTest]
    [Category("Assert", "LongValidation")]
    public sealed class LongInverseValidatorTest
    {
        #region long.NotBe()

        [Fact(DisplayName = "long.NotBe(long)")]
        public void ValidateLongNotToBeValue()
        {
            // Given
            var validator = new LongInverseValidator(42);

            // When
            validator.Be(13);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "long.NotBe(other)")]
        public void ValidateLongNotToBeValueViolated()
        {
            // Given
            var validator = new LongInverseValidator(42);

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

        #region long.NotBeBetween()

        [Fact(DisplayName = "long.NotBeBetween(long, long)")]
        public void ValidateLongToNotBeBetweenSmallerValues()
        {
            // Given
            var validator = new LongInverseValidator(42);

            // When
            validator.BeBetween(13, 39);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "long.NotBeBetween(long, long)")]
        public void ValidateLongToNotBeBetweenBiggerValues()
        {
            // Given
            var validator = new LongInverseValidator(42);

            // When
            validator.BeBetween(65, 130);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "long.BeBetween(wrongMinimum, wrongMaximum)")]
        public void ValidateLongToBeBetweenValuesMinimumAndMaximumViolated()
        {
            // Given
            var validator = new LongInverseValidator(42);

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

        #region long.NotBeGreaterThan()
        
        [Fact(DisplayName = "long.NotBeGreaterThan(equalValue)")]
        public void ValidateLongToBeGreaterThanEqualValue()
        {
            // Given
            var validator = new LongInverseValidator(42);

            // When
            validator.BeGreaterThan(42);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "long.NotBeGreaterThan(biggerValue)")]
        public void ValidateLongToNotBeGreaterThanBiggerValue()
        {
            // Given
            var validator = new LongInverseValidator(42);

            // When
            validator.BeGreaterThan(65);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "long.NotBeGreaterThan(wrongMinimum)")]
        public void ValidateLongToNotBeGreaterThanValueViolated()
        {
            // Given
            var validator = new LongInverseValidator(42);

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

        #region long.NotBeGreaterThanOrEqualTo()

        [Fact(DisplayName = "long.NotBeGreaterThanOrEqualTo(long)")]
        public void ValidateLongNotToBeGreaterThanOrEqualToValue()
        {
            // Given
            var validator = new LongInverseValidator(42);

            // When
            validator.BeGreaterThanOrEqualTo(65);

            // Then
            Assert.True(true);
        }


        [Fact(DisplayName = "long.NotBeGreaterThanOrEqualTo(wrongMinimum)")]
        public void ValidateLongNotToBeGreaterThanOrEqualToValueViolated()
        {
            // Given
            var validator = new LongInverseValidator(42);

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

        #region long.NotBeLessThan()

        [Fact(DisplayName = "long.NotBeLessThan(equalValue)")]
        public void ValidateLongToBeLessThanEqualValue()
        {
            // Given
            var validator = new LongInverseValidator(42);

            // When
            validator.BeLessThan(42);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "long.NotBeLessThan(biggerValue)")]
        public void ValidateLongToNotBeLessThanBiggerValue()
        {
            // Given
            var validator = new LongInverseValidator(42);

            // When
            validator.BeLessThan(13);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "long.NotBeLessThan(wrongMaximum)")]
        public void ValidateLongToNotBeLessThanValueViolated()
        {
            // Given
            var validator = new LongInverseValidator(42);

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

        #region long.NotBeLessThanOrEqualTo()

        [Fact(DisplayName = "long.NotBeLessThanOrEqualTo(long)")]
        public void ValidateLongNotToBeLessThanOrEqualToValue()
        {
            // Given
            var validator = new LongInverseValidator(42);

            // When
            validator.BeLessThanOrEqualTo(13);

            // Then
            Assert.True(true);
        }


        [Fact(DisplayName = "long.NotBeLessThanOrEqualTo(wrongMinimum)")]
        public void ValidateLongNotToBeLessThanOrEqualToValueViolated()
        {
            // Given
            var validator = new LongInverseValidator(42);

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

        #region long.NotBeNegative()

        [Fact(DisplayName = "long.NotBeNegative()")]
        public void ValidateLongNotToBeNegative()
        {
            // Given
            var validator = new LongInverseValidator(0);

            // When
            validator.BeNegative();

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "long.NotBeNegative()")]
        public void ValidateLongNotToBeNegativeViolated()
        {
            // Given
            var validator = new LongInverseValidator(-42);

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

        #region long.NotBeOneOf()

        [Fact(DisplayName = "long.NotBeOneOf(other, other)")]
        public void ValidateLongNotToBeOneOfExpectedValues()
        {
            // Given
            var validator = new LongInverseValidator(42);

            // When
            validator.BeOneOf(new long[] { 10, 39 });

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "long.NotBeOneOf(long, long)")]
        public void ValidateLongNotToBeOneOfViolated()
        {
            // Given
            var validator = new LongInverseValidator(42);

            // When
            var exception = Assert.Throws<XunitException>(() => validator.BeOneOf(new long[] { 13, 42 }, because: "that's the bottom line"));

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is \"42\"{rn}but was expected not to be one of the following values: \"13\", \"42\"{rn}because that's the bottom line",
                exception.UserMessage);
        }

        #endregion

        #region long.NotBePositive()

        [Fact(DisplayName = "long.NotBePositive()")]
        public void ValidateLongToBePositive()
        {
            // Given
            var validator = new LongInverseValidator(-42);

            // When
            validator.BePositive();

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "long.NotBePositive()")]
        public void ValidateLongNotToBePositiveViolated()
        {
            // Given
            var validator = new LongInverseValidator(0);

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