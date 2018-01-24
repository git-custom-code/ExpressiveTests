namespace CustomCode.Test.BehaviorDrivenDevelopment.Tests
{
    using System;
    using Xunit;
    using Xunit.Sdk;

    /// <summary>
    /// Test cases for the <see cref="FloatValidator"/> type.
    /// </summary>
    [UnitTest]
    [Category("Assert", "FloatValidation")]
    public sealed class FloatValidatorTest
    {
        #region float.Be()

        [Fact(DisplayName = "float.Be(float)")]
        public void ValidateFloatToBeValue()
        {
            // Given
            var validator = new FloatValidator(42);

            // When
            validator.Be(42);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "float.Be(other)")]
        public void ValidateFloatToBeValueViolated()
        {
            // Given
            var validator = new FloatValidator(42);

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

        #region float.BeApproximately()

        [Fact(DisplayName = "float.BeApproximately(float)")]
        public void ValidateFloatToBeApproximatelyValue()
        {
            // Given
            var validator = new FloatValidator(42.12345f);

            // When
            validator.BeApproximately(42.123f, 0.1f);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "float.BeApproximately(other)")]
        public void ValidateFloatToBeApproximatelyValueViolated()
        {
            // Given
            var validator = new FloatValidator(42.12345f);

            // When
            var exception = Assert.Throws<XunitException>(() => validator.BeApproximately(42f, 0.01f, "that's the bottom line"));

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is \"42,12345\"{rn}but was expected to be approximately \"42\" (+/- 0,01){rn}because that's the bottom line",
                exception.UserMessage);
        }

        #endregion

        #region float.BeBetween()

        [Fact(DisplayName = "float.BeBetween(float, float)")]
        public void ValidateFloatToBeBetweenValues()
        {
            // Given
            var validator = new FloatValidator(42);

            // When
            validator.BeBetween(13, 130);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "float.BeBetween(wrongMinimum, float)")]
        public void ValidateFloatToBeBetweenValuesMinimumViolated()
        {
            // Given
            var validator = new FloatValidator(42);

            // When
            var exception = Assert.Throws<XunitException>(() => validator.BeBetween(65, 130, "that's the bottom line"));

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is \"42\"{rn}but was expected to be between \"65\" and \"130\"{rn}because that's the bottom line",
                exception.UserMessage);
        }

        [Fact(DisplayName = "float.BeBetween(float, wrongMaximum)")]
        public void ValidateFloatToBeBetweenValuesMaximumViolated()
        {
            // Given
            var validator = new FloatValidator(42);

            // When
            var exception = Assert.Throws<XunitException>(() => validator.BeBetween(13, 39, "that's the bottom line"));

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is \"42\"{rn}but was expected to be between \"13\" and \"39\"{rn}because that's the bottom line",
                exception.UserMessage);
        }

        [Fact(DisplayName = "float.BeBetween(wrongMinimum, wrongMaximum)")]
        public void ValidateFloatToBeBetweenValuesMinimumAndMaximumViolated()
        {
            // Given
            var validator = new FloatValidator(42);

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

        #region float.BeGreaterThan()

        [Fact(DisplayName = "float.BeGreaterThan(float)")]
        public void ValidateFloatToBeGreaterThanValue()
        {
            // Given
            var validator = new FloatValidator(42);

            // When
            validator.BeGreaterThan(13);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "float.BeGreaterThan(wrongMinimum)")]
        public void ValidateFloatToBeGreaterThanValueViolated()
        {
            // Given
            var validator = new FloatValidator(42);

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

        #region float.BeGreaterThanOrEqualTo()

        [Fact(DisplayName = "float.BeGreaterThanOrEqualTo(smallerValue)")]
        public void ValidateFloatToBeGreaterThanOrEqualToSmallerValue()
        {
            // Given
            var validator = new FloatValidator(42);

            // When
            validator.BeGreaterThanOrEqualTo(13);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "float.BeGreaterThanOrEqualTo(equalValue)")]
        public void ValidateFloatToBeGreaterThanOrEqualToEqualValue()
        {
            // Given
            var validator = new FloatValidator(42);

            // When
            validator.BeGreaterThanOrEqualTo(42);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "float.BeGreaterThanOrEqualTo(wrongMinimum)")]
        public void ValidateFloatToBeGreaterThanOrEqualToValueViolated()
        {
            // Given
            var validator = new FloatValidator(42);

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

        #region float.BeLessThan()

        [Fact(DisplayName = "float.BeLessThan(float)")]
        public void ValidateFloatToBeLessThanValue()
        {
            // Given
            var validator = new FloatValidator(42);

            // When
            validator.BeLessThan(65);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "float.BeLessThan(wrongMinimum)")]
        public void ValidateFloatToBeLessThanValueViolated()
        {
            // Given
            var validator = new FloatValidator(42);

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

        #region float.BeLessThanOrEqualTo()

        [Fact(DisplayName = "float.BeLessThanOrEqualTo(biggerValue)")]
        public void ValidateFloatToBeLessThanOrEqualToBiggerValue()
        {
            // Given
            var validator = new FloatValidator(42);

            // When
            validator.BeLessThanOrEqualTo(65);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "float.BeLessThanOrEqualTo(equalValue)")]
        public void ValidateFloatToBeLessThanOrEqualToEqualValue()
        {
            // Given
            var validator = new FloatValidator(42);

            // When
            validator.BeLessThanOrEqualTo(42);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "float.BeLessThanOrEqualTo(wrongMaximum)")]
        public void ValidateFloatToBeLessThanOrEqualToValueViolated()
        {
            // Given
            var validator = new FloatValidator(42);

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

        #region float.BeNegative()

        [Fact(DisplayName = "float.BeNegative()")]
        public void ValidateFloatToBeNegative()
        {
            // Given
            var validator = new FloatValidator(-42);

            // When
            validator.BeNegative();

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "float.BeNegative()")]
        public void ValidateFloatToBeNegativeViolated()
        {
            // Given
            var validator = new FloatValidator(0);

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

        #region float.BeOneOf()

        [Fact(DisplayName = "float.BeOneOf(float, float)")]
        public void ValidateFloatToBeOneOfExpectedValues()
        {
            // Given
            var validator = new FloatValidator(42);

            // When
            validator.BeOneOf(new float[] { 10, 42 });

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "float.BeOneOf(other, other)")]
        public void ValidateFloatToBeOneOfViolated()
        {
            // Given
            var validator = new FloatValidator(42);

            // When
            var exception = Assert.Throws<XunitException>(() => validator.BeOneOf(new float[] { 13, 39 }, because: "that's the bottom line"));

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is \"42\"{rn}but was expected to be one of the following values: \"13\", \"39\"{rn}because that's the bottom line",
                exception.UserMessage);
        }

        #endregion

        #region float.BePositive()

        [Fact(DisplayName = "float.BePositive()")]
        public void ValidateFloatToBePositive()
        {
            // Given
            var validator = new FloatValidator(0);

            // When
            validator.BePositive();

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "float.BePositive()")]
        public void ValidateFloatToBePositiveViolated()
        {
            // Given
            var validator = new FloatValidator(-42);

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