namespace CustomCode.Test.BehaviorDrivenDevelopment.Tests
{
    using System;
    using Xunit;
    using Xunit.Sdk;

    /// <summary>
    /// Test cases for the <see cref="SbyteValidator"/> type.
    /// </summary>
    [UnitTest]
    [Category("Assert", "SByteValidation")]
    public sealed class SbyteValidatorTest
    {
        #region sbyte.Be()

        [Fact(DisplayName = "sbyte.Be(sbyte)")]
        public void ValidateSByteToBeValue()
        {
            // Given
            var validator = new SbyteValidator(42);

            // When
            validator.Be(42);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "sbyte.Be(other)")]
        public void ValidateSByteToBeValueViolated()
        {
            // Given
            var validator = new SbyteValidator(42);

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

        #region sbyte.BeBetween()

        [Fact(DisplayName = "sbyte.BeBetween(sbyte, sbyte)")]
        public void ValidateSByteToBeBetweenValues()
        {
            // Given
            var validator = new SbyteValidator(42);

            // When
            validator.BeBetween(13, 65);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "sbyte.BeBetween(wrongMinimum, sbyte)")]
        public void ValidateSByteToBeBetweenValuesMinimumViolated()
        {
            // Given
            var validator = new SbyteValidator(42);

            // When
            var exception = Assert.Throws<XunitException>(() => validator.BeBetween(65, 100, "that's the bottom line"));

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is \"42\"{rn}but was expected to be between \"65\" and \"100\"{rn}because that's the bottom line",
                exception.UserMessage);
        }

        [Fact(DisplayName = "sbyte.BeBetween(sbyte, wrongMaximum)")]
        public void ValidateSByteToBeBetweenValuesMaximumViolated()
        {
            // Given
            var validator = new SbyteValidator(42);

            // When
            var exception = Assert.Throws<XunitException>(() => validator.BeBetween(13, 39, "that's the bottom line"));

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is \"42\"{rn}but was expected to be between \"13\" and \"39\"{rn}because that's the bottom line",
                exception.UserMessage);
        }

        [Fact(DisplayName = "sbyte.BeBetween(wrongMinimum, wrongMaximum)")]
        public void ValidateSByteToBeBetweenValuesMinimumAndMaximumViolated()
        {
            // Given
            var validator = new SbyteValidator(42);

            // When
            var exception = Assert.Throws<XunitException>(() => validator.BeBetween(65, 13, "that's the bottom line"));

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is \"42\"{rn}but was expected to be between \"65\" and \"13\"{rn}because that's the bottom line",
                exception.UserMessage);
        }

        #endregion

        #region sbyte.BeGreaterThan()

        [Fact(DisplayName = "sbyte.BeGreaterThan(sbyte)")]
        public void ValidateSByteToBeGreaterThanValue()
        {
            // Given
            var validator = new SbyteValidator(42);

            // When
            validator.BeGreaterThan(13);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "sbyte.BeGreaterThan(wrongMinimum)")]
        public void ValidateSByteToBeGreaterThanValueViolated()
        {
            // Given
            var validator = new SbyteValidator(42);

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

        #region sbyte.BeGreaterThanOrEqualTo()

        [Fact(DisplayName = "sbyte.BeGreaterThanOrEqualTo(smallerValue)")]
        public void ValidateSByteToBeGreaterThanOrEqualToSmallerValue()
        {
            // Given
            var validator = new SbyteValidator(42);

            // When
            validator.BeGreaterThanOrEqualTo(13);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "sbyte.BeGreaterThanOrEqualTo(equalValue)")]
        public void ValidateSByteToBeGreaterThanOrEqualToEqualValue()
        {
            // Given
            var validator = new SbyteValidator(42);

            // When
            validator.BeGreaterThanOrEqualTo(42);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "sbyte.BeGreaterThanOrEqualTo(wrongMinimum)")]
        public void ValidateSByteToBeGreaterThanOrEqualToValueViolated()
        {
            // Given
            var validator = new SbyteValidator(42);

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

        #region sbyte.BeLessThan()

        [Fact(DisplayName = "sbyte.BeLessThan(sbyte)")]
        public void ValidateSByteToBeLessThanValue()
        {
            // Given
            var validator = new SbyteValidator(42);

            // When
            validator.BeLessThan(65);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "sbyte.BeLessThan(wrongMinimum)")]
        public void ValidateSByteToBeLessThanValueViolated()
        {
            // Given
            var validator = new SbyteValidator(42);

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

        #region sbyte.BeLessThanOrEqualTo()

        [Fact(DisplayName = "sbyte.BeLessThanOrEqualTo(biggerValue)")]
        public void ValidateSByteToBeLessThanOrEqualToBiggerValue()
        {
            // Given
            var validator = new SbyteValidator(42);

            // When
            validator.BeLessThanOrEqualTo(65);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "sbyte.BeLessThanOrEqualTo(equalValue)")]
        public void ValidateSByteToBeLessThanOrEqualToEqualValue()
        {
            // Given
            var validator = new SbyteValidator(42);

            // When
            validator.BeLessThanOrEqualTo(42);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "sbyte.BeLessThanOrEqualTo(wrongMaximum)")]
        public void ValidateSByteToBeLessThanOrEqualToValueViolated()
        {
            // Given
            var validator = new SbyteValidator(42);

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

        #region sbyte.BeNegative()

        [Fact(DisplayName = "sbyte.BeNegative()")]
        public void ValidateSByteToBeNegative()
        {
            // Given
            var validator = new SbyteValidator(-42);

            // When
            validator.BeNegative();

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "sbyte.BeNegative()")]
        public void ValidateSByteToBeNegativeViolated()
        {
            // Given
            var validator = new SbyteValidator(0);

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

        #region sbyte.BeOneOf()

        [Fact(DisplayName = "sbyte.BeOneOf(sbyte, sbyte)")]
        public void ValidateSByteToBeOneOfExpectedValues()
        {
            // Given
            var validator = new SbyteValidator(42);

            // When
            validator.BeOneOf(new sbyte[] { 10, 42 });

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "sbyte.BeOneOf(other, other)")]
        public void ValidateSByteToBeOneOfViolated()
        {
            // Given
            var validator = new SbyteValidator(42);

            // When
            var exception = Assert.Throws<XunitException>(() => validator.BeOneOf(new sbyte[] { 13, 39 }, because: "that's the bottom line"));

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is \"42\"{rn}but was expected to be one of the following values: \"13\", \"39\"{rn}because that's the bottom line",
                exception.UserMessage);
        }

        #endregion

        #region sbyte.BePositive()

        [Fact(DisplayName = "sbyte.BePositive()")]
        public void ValidateSByteToBePositive()
        {
            // Given
            var validator = new SbyteValidator(0);

            // When
            validator.BePositive();

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "sbyte.BePositive()")]
        public void ValidateSByteToBePositiveViolated()
        {
            // Given
            var validator = new SbyteValidator(-42);

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