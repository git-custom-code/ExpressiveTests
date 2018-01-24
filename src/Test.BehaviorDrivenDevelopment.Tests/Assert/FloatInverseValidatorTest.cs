namespace CustomCode.Test.BehaviorDrivenDevelopment.Tests
{
    using System;
    using Xunit;
    using Xunit.Sdk;

    /// <summary>
    /// Test cases for the <see cref="FloatInverseValidator"/> type.
    /// </summary>
    [UnitTest]
    [Category("Assert", "FloatValidation")]
    public sealed class FloatInverseValidatorTest
    {
        #region float.NotBe()

        [Fact(DisplayName = "float.NotBe(float)")]
        public void ValidateFloatNotToBeValue()
        {
            // Given
            var validator = new FloatInverseValidator(42);

            // When
            validator.Be(13);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "float.NotBe(other)")]
        public void ValidateFloatNotToBeValueViolated()
        {
            // Given
            var validator = new FloatInverseValidator(42);

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

        #region float.NotBeApproximately()

        [Fact(DisplayName = "float.NotBeApproximately(float)")]
        public void ValidateFloatToBeApproximatelyValue()
        {
            // Given
            var validator = new FloatInverseValidator(42.2f);

            // When
            validator.BeApproximately(42f, 0.1f);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "float.NotBeApproximately(other)")]
        public void ValidateFloatToBeApproximatelyValueViolated()
        {
            // Given
            var validator = new FloatInverseValidator(42.12345f);

            // When
            var exception = Assert.Throws<XunitException>(() => validator.BeApproximately(42.12f, 0.01f, "that's the bottom line"));

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is \"42,12345\"{rn}but was expected to be approximately \"42,12\" (+/- 0,01){rn}because that's the bottom line",
                exception.UserMessage);
        }

        #endregion

        #region float.NotBeBetween()

        [Fact(DisplayName = "float.NotBeBetween(float, float)")]
        public void ValidateFloatToNotBeBetweenSmallerValues()
        {
            // Given
            var validator = new FloatInverseValidator(42);

            // When
            validator.BeBetween(13, 39);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "float.NotBeBetween(float, float)")]
        public void ValidateFloatToNotBeBetweenBiggerValues()
        {
            // Given
            var validator = new FloatInverseValidator(42);

            // When
            validator.BeBetween(65, 130);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "float.BeBetween(wrongMinimum, wrongMaximum)")]
        public void ValidateFloatToBeBetweenValuesMinimumAndMaximumViolated()
        {
            // Given
            var validator = new FloatInverseValidator(42);

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

        #region float.NotBeGreaterThan()
        
        [Fact(DisplayName = "float.NotBeGreaterThan(equalValue)")]
        public void ValidateFloatToBeGreaterThanEqualValue()
        {
            // Given
            var validator = new FloatInverseValidator(42);

            // When
            validator.BeGreaterThan(42);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "float.NotBeGreaterThan(biggerValue)")]
        public void ValidateFloatToNotBeGreaterThanBiggerValue()
        {
            // Given
            var validator = new FloatInverseValidator(42);

            // When
            validator.BeGreaterThan(65);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "float.NotBeGreaterThan(wrongMinimum)")]
        public void ValidateFloatToNotBeGreaterThanValueViolated()
        {
            // Given
            var validator = new FloatInverseValidator(42);

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

        #region float.NotBeGreaterThanOrEqualTo()

        [Fact(DisplayName = "float.NotBeGreaterThanOrEqualTo(float)")]
        public void ValidateFloatNotToBeGreaterThanOrEqualToValue()
        {
            // Given
            var validator = new FloatInverseValidator(42);

            // When
            validator.BeGreaterThanOrEqualTo(65);

            // Then
            Assert.True(true);
        }


        [Fact(DisplayName = "float.NotBeGreaterThanOrEqualTo(wrongMinimum)")]
        public void ValidateFloatNotToBeGreaterThanOrEqualToValueViolated()
        {
            // Given
            var validator = new FloatInverseValidator(42);

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

        #region float.NotBeLessThan()

        [Fact(DisplayName = "float.NotBeLessThan(equalValue)")]
        public void ValidateFloatToBeLessThanEqualValue()
        {
            // Given
            var validator = new FloatInverseValidator(42);

            // When
            validator.BeLessThan(42);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "float.NotBeLessThan(biggerValue)")]
        public void ValidateFloatToNotBeLessThanBiggerValue()
        {
            // Given
            var validator = new FloatInverseValidator(42);

            // When
            validator.BeLessThan(13);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "float.NotBeLessThan(wrongMaximum)")]
        public void ValidateFloatToNotBeLessThanValueViolated()
        {
            // Given
            var validator = new FloatInverseValidator(42);

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

        #region float.NotBeLessThanOrEqualTo()

        [Fact(DisplayName = "float.NotBeLessThanOrEqualTo(float)")]
        public void ValidateFloatNotToBeLessThanOrEqualToValue()
        {
            // Given
            var validator = new FloatInverseValidator(42);

            // When
            validator.BeLessThanOrEqualTo(13);

            // Then
            Assert.True(true);
        }


        [Fact(DisplayName = "float.NotBeLessThanOrEqualTo(wrongMinimum)")]
        public void ValidateFloatNotToBeLessThanOrEqualToValueViolated()
        {
            // Given
            var validator = new FloatInverseValidator(42);

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

        #region float.NotBeNegative()

        [Fact(DisplayName = "float.NotBeNegative()")]
        public void ValidateFloatNotToBeNegative()
        {
            // Given
            var validator = new FloatInverseValidator(0);

            // When
            validator.BeNegative();

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "float.NotBeNegative()")]
        public void ValidateFloatNotToBeNegativeViolated()
        {
            // Given
            var validator = new FloatInverseValidator(-42);

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

        #region float.NotBeOneOf()

        [Fact(DisplayName = "float.NotBeOneOf(other, other)")]
        public void ValidateFloatNotToBeOneOfExpectedValues()
        {
            // Given
            var validator = new FloatInverseValidator(42);

            // When
            validator.BeOneOf(new float[] { 10, 39 });

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "float.NotBeOneOf(float, float)")]
        public void ValidateFloatNotToBeOneOfViolated()
        {
            // Given
            var validator = new FloatInverseValidator(42);

            // When
            var exception = Assert.Throws<XunitException>(() => validator.BeOneOf(new float[] { 13, 42 }, because: "that's the bottom line"));

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is \"42\"{rn}but was expected not to be one of the following values: \"13\", \"42\"{rn}because that's the bottom line",
                exception.UserMessage);
        }

        #endregion

        #region float.NotBePositive()

        [Fact(DisplayName = "float.NotBePositive()")]
        public void ValidateFloatToBePositive()
        {
            // Given
            var validator = new FloatInverseValidator(-42);

            // When
            validator.BePositive();

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "float.NotBePositive()")]
        public void ValidateFloatNotToBePositiveViolated()
        {
            // Given
            var validator = new FloatInverseValidator(0);

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