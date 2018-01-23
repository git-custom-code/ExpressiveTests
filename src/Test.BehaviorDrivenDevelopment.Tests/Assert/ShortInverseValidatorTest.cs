namespace CustomCode.Test.BehaviorDrivenDevelopment.Tests
{
    using System;
    using Xunit;
    using Xunit.Sdk;

    /// <summary>
    /// Test cases for the <see cref="ShortInverseValidator"/> type.
    /// </summary>
    [UnitTest]
    [Category("Assert", "ShortValidation")]
    public sealed class ShortInvereseValidatorTest
    {
        #region short.NotBe()

        [Fact(DisplayName = "short.NotBe(short)")]
        public void ValidateShortNotToBeValue()
        {
            // Given
            var validator = new ShortInverseValidator(42);

            // When
            validator.Be(13);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "short.NotBe(other)")]
        public void ValidateShortNotToBeValueViolated()
        {
            // Given
            var validator = new ShortInverseValidator(42);

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

        #region short.NotBeBetween()

        [Fact(DisplayName = "short.NotBeBetween(short, short)")]
        public void ValidateShortToNotBeBetweenSmallerValues()
        {
            // Given
            var validator = new ShortInverseValidator(42);

            // When
            validator.BeBetween(13, 39);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "short.NotBeBetween(short, short)")]
        public void ValidateShortToNotBeBetweenBiggerValues()
        {
            // Given
            var validator = new ShortInverseValidator(42);

            // When
            validator.BeBetween(65, 130);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "short.BeBetween(wrongMinimum, wrongMaximum)")]
        public void ValidateShortToBeBetweenValuesMinimumAndMaximumViolated()
        {
            // Given
            var validator = new ShortInverseValidator(42);

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

        #region short.NotBeGreaterThan()
        
        [Fact(DisplayName = "short.NotBeGreaterThan(equalValue)")]
        public void ValidateShortToBeGreaterThanEqualValue()
        {
            // Given
            var validator = new ShortInverseValidator(42);

            // When
            validator.BeGreaterThan(42);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "short.NotBeGreaterThan(biggerValue)")]
        public void ValidateShortToNotBeGreaterThanBiggerValue()
        {
            // Given
            var validator = new ShortInverseValidator(42);

            // When
            validator.BeGreaterThan(65);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "short.NotBeGreaterThan(wrongMinimum)")]
        public void ValidateShortToNotBeGreaterThanValueViolated()
        {
            // Given
            var validator = new ShortInverseValidator(42);

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

        #region short.NotBeGreaterThanOrEqualTo()

        [Fact(DisplayName = "short.NotBeGreaterThanOrEqualTo(short)")]
        public void ValidateShortNotToBeGreaterThanOrEqualToValue()
        {
            // Given
            var validator = new ShortInverseValidator(42);

            // When
            validator.BeGreaterThanOrEqualTo(65);

            // Then
            Assert.True(true);
        }


        [Fact(DisplayName = "short.NotBeGreaterThanOrEqualTo(wrongMinimum)")]
        public void ValidateShortNotToBeGreaterThanOrEqualToValueViolated()
        {
            // Given
            var validator = new ShortInverseValidator(42);

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

        #region short.NotBeLessThan()

        [Fact(DisplayName = "short.NotBeLessThan(equalValue)")]
        public void ValidateShortToBeLessThanEqualValue()
        {
            // Given
            var validator = new ShortInverseValidator(42);

            // When
            validator.BeLessThan(42);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "short.NotBeLessThan(biggerValue)")]
        public void ValidateShortToNotBeLessThanBiggerValue()
        {
            // Given
            var validator = new ShortInverseValidator(42);

            // When
            validator.BeLessThan(13);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "short.NotBeLessThan(wrongMaximum)")]
        public void ValidateShortToNotBeLessThanValueViolated()
        {
            // Given
            var validator = new ShortInverseValidator(42);

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

        #region short.NotBeLessThanOrEqualTo()

        [Fact(DisplayName = "short.NotBeLessThanOrEqualTo(short)")]
        public void ValidateShortNotToBeLessThanOrEqualToValue()
        {
            // Given
            var validator = new ShortInverseValidator(42);

            // When
            validator.BeLessThanOrEqualTo(13);

            // Then
            Assert.True(true);
        }


        [Fact(DisplayName = "short.NotBeLessThanOrEqualTo(wrongMinimum)")]
        public void ValidateShortNotToBeLessThanOrEqualToValueViolated()
        {
            // Given
            var validator = new ShortInverseValidator(42);

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

        #region short.NotBeNegative()

        [Fact(DisplayName = "short.NotBeNegative()")]
        public void ValidateShortNotToBeNegative()
        {
            // Given
            var validator = new ShortInverseValidator(0);

            // When
            validator.BeNegative();

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "short.NotBeNegative()")]
        public void ValidateShortNotToBeNegativeViolated()
        {
            // Given
            var validator = new ShortInverseValidator(-42);

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

        #region short.BeOneOf()

        [Fact(DisplayName = "short.NotBeOneOf(other, other)")]
        public void ValidateShortNotToBeOneOfExpectedValues()
        {
            // Given
            var validator = new ShortInverseValidator(42);

            // When
            validator.BeOneOf(new short[] { 10, 39 });

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "short.NotBeOneOf(short, short)")]
        public void ValidateShortNotToBeOneOfViolated()
        {
            // Given
            var validator = new ShortInverseValidator(42);

            // When
            var exception = Assert.Throws<XunitException>(() => validator.BeOneOf(new short[] { 13, 42 }, because: "that's the bottom line"));

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is \"42\"{rn}but was expected not to be one of the following values: \"13\", \"42\"{rn}because that's the bottom line",
                exception.UserMessage);
        }

        #endregion

        #region short.NotBePositive()

        [Fact(DisplayName = "short.NotBePositive()")]
        public void ValidateShortToBePositive()
        {
            // Given
            var validator = new ShortInverseValidator(-42);

            // When
            validator.BePositive();

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "short.NotBePositive()")]
        public void ValidateShortNotToBePositiveViolated()
        {
            // Given
            var validator = new ShortInverseValidator(0);

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