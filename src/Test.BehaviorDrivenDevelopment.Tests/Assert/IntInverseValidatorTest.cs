namespace CustomCode.Test.BehaviorDrivenDevelopment.Tests
{
    using System;
    using Xunit;
    using Xunit.Sdk;

    /// <summary>
    /// Test cases for the <see cref="IntInverseValidator"/> type.
    /// </summary>
    [UnitTest]
    [Category("Assert", "IntegerValidation")]
    public sealed class IntInvereseValidatorTest
    {
        #region int.NotBe()

        [Fact(DisplayName = "int.NotBe(int)")]
        public void ValidateIntegerNotToBeValue()
        {
            // Given
            var validator = new IntInverseValidator(42);

            // When
            validator.Be(13);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "int.NotBe(other)")]
        public void ValidateIntegerNotToBeValueViolated()
        {
            // Given
            var validator = new IntInverseValidator(42);

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

        #region int.NotBeBetween()

        [Fact(DisplayName = "int.NotBeBetween(int, int)")]
        public void ValidateIntegerToNotBeBetweenSmallerValues()
        {
            // Given
            var validator = new IntInverseValidator(42);

            // When
            validator.BeBetween(13, 39);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "int.NotBeBetween(int, int)")]
        public void ValidateIntegerToNotBeBetweenBiggerValues()
        {
            // Given
            var validator = new IntInverseValidator(42);

            // When
            validator.BeBetween(65, 130);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "int.BeBetween(wrongMinimum, wrongMaximum)")]
        public void ValidateIntegerToBeBetweenValuesMinimumAndMaximumViolated()
        {
            // Given
            var validator = new IntInverseValidator(42);

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

        #region int.NotBeGreaterThan()
        
        [Fact(DisplayName = "int.NotBeGreaterThan(equalValue)")]
        public void ValidateIntegerToBeGreaterThanEqualValue()
        {
            // Given
            var validator = new IntInverseValidator(42);

            // When
            validator.BeGreaterThan(42);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "int.NotBeGreaterThan(biggerValue)")]
        public void ValidateIntegerToNotBeGreaterThanBiggerValue()
        {
            // Given
            var validator = new IntInverseValidator(42);

            // When
            validator.BeGreaterThan(65);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "int.NotBeGreaterThan(wrongMinimum)")]
        public void ValidateIntegerToNotBeGreaterThanValueViolated()
        {
            // Given
            var validator = new IntInverseValidator(42);

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

        #region int.NotBeGreaterThanOrEqualTo()

        [Fact(DisplayName = "int.NotBeGreaterThanOrEqualTo(int)")]
        public void ValidateIntegerNotToBeGreaterThanOrEqualToValue()
        {
            // Given
            var validator = new IntInverseValidator(42);

            // When
            validator.BeGreaterThanOrEqualTo(65);

            // Then
            Assert.True(true);
        }


        [Fact(DisplayName = "int.NotBeGreaterThanOrEqualTo(wrongMinimum)")]
        public void ValidateIntegerNotToBeGreaterThanOrEqualToValueViolated()
        {
            // Given
            var validator = new IntInverseValidator(42);

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

        #region int.NotBeLessThan()

        [Fact(DisplayName = "int.NotBeLessThan(equalValue)")]
        public void ValidateIntegerToBeLessThanEqualValue()
        {
            // Given
            var validator = new IntInverseValidator(42);

            // When
            validator.BeLessThan(42);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "int.NotBeLessThan(biggerValue)")]
        public void ValidateIntegerToNotBeLessThanBiggerValue()
        {
            // Given
            var validator = new IntInverseValidator(42);

            // When
            validator.BeLessThan(13);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "int.NotBeLessThan(wrongMaximum)")]
        public void ValidateIntegerToNotBeLessThanValueViolated()
        {
            // Given
            var validator = new IntInverseValidator(42);

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

        #region int.NotBeLessThanOrEqualTo()

        [Fact(DisplayName = "int.NotBeLessThanOrEqualTo(int)")]
        public void ValidateIntegerNotToBeLessThanOrEqualToValue()
        {
            // Given
            var validator = new IntInverseValidator(42);

            // When
            validator.BeLessThanOrEqualTo(13);

            // Then
            Assert.True(true);
        }


        [Fact(DisplayName = "int.NotBeLessThanOrEqualTo(wrongMinimum)")]
        public void ValidateIntegerNotToBeLessThanOrEqualToValueViolated()
        {
            // Given
            var validator = new IntInverseValidator(42);

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

        #region int.NotBeNegative()

        [Fact(DisplayName = "int.NotBeNegative()")]
        public void ValidateIntegerNotToBeNegative()
        {
            // Given
            var validator = new IntInverseValidator(0);

            // When
            validator.BeNegative();

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "int.NotBeNegative()")]
        public void ValidateIntegerNotToBeNegativeViolated()
        {
            // Given
            var validator = new IntInverseValidator(-42);

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

        #region int.BeOneOf()

        [Fact(DisplayName = "int.NotBeOneOf(other, other)")]
        public void ValidateIntegerNotToBeOneOfExpectedValues()
        {
            // Given
            var validator = new IntInverseValidator(42);

            // When
            validator.BeOneOf(new[] { 10, 39 });

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "int.NotBeOneOf(int, int)")]
        public void ValidateIntegerNotToBeOneOfViolated()
        {
            // Given
            var validator = new IntInverseValidator(42);

            // When
            var exception = Assert.Throws<XunitException>(() => validator.BeOneOf(new[] { 13, 42 }, because: "that's the bottom line"));

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is \"42\"{rn}but was expected not to be one of the following values: \"13\", \"42\"{rn}because that's the bottom line",
                exception.UserMessage);
        }

        #endregion

        #region int.NotBePositive()

        [Fact(DisplayName = "int.NotBePositive()")]
        public void ValidateIntegerToBePositive()
        {
            // Given
            var validator = new IntInverseValidator(-42);

            // When
            validator.BePositive();

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "int.NotBePositive()")]
        public void ValidateIntegerNotToBePositiveViolated()
        {
            // Given
            var validator = new IntInverseValidator(0);

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