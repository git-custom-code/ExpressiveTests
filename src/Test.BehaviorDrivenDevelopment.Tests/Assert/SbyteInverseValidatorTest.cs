namespace CustomCode.Test.BehaviorDrivenDevelopment.Tests
{
    using System;
    using Xunit;
    using Xunit.Sdk;

    /// <summary>
    /// Test cases for the <see cref="SbyteInverseValidator"/> type.
    /// </summary>
    [UnitTest]
    [Category("Assert", "SByteValidation")]
    public sealed class SbyteInverseValidatorTest
    {
        #region sbyte.NotBe()

        [Fact(DisplayName = "sbyte.NotBe(sbyte)")]
        public void ValidateSByteNotToBeValue()
        {
            // Given
            var validator = new SbyteInverseValidator(42);

            // When
            validator.Be(13);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "sbyte.NotBe(other)")]
        public void ValidateSByteNotToBeValueViolated()
        {
            // Given
            var validator = new SbyteInverseValidator(42);

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

        #region sbyte.NotBeBetween()

        [Fact(DisplayName = "sbyte.NotBeBetween(sbyte, sbyte)")]
        public void ValidateSByteToNotBeBetweenSmallerValues()
        {
            // Given
            var validator = new SbyteInverseValidator(42);

            // When
            validator.BeBetween(13, 39);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "sbyte.NotBeBetween(sbyte, sbyte)")]
        public void ValidateSByteToNotBeBetweenBiggerValues()
        {
            // Given
            var validator = new SbyteInverseValidator(42);

            // When
            validator.BeBetween(65, 100);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "sbyte.BeBetween(wrongMinimum, wrongMaximum)")]
        public void ValidateSByteToBeBetweenValuesMinimumAndMaximumViolated()
        {
            // Given
            var validator = new SbyteInverseValidator(42);

            // When
            var exception = Assert.Throws<XunitException>(() => validator.BeBetween(13, 100, "that's the bottom line"));

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is \"42\"{rn}but was expected not to be between \"13\" and \"100\"{rn}because that's the bottom line",
                exception.UserMessage);
        }

        #endregion

        #region sbyte.NotBeGreaterThan()
        
        [Fact(DisplayName = "sbyte.NotBeGreaterThan(equalValue)")]
        public void ValidateSByteToBeGreaterThanEqualValue()
        {
            // Given
            var validator = new SbyteInverseValidator(42);

            // When
            validator.BeGreaterThan(42);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "sbyte.NotBeGreaterThan(biggerValue)")]
        public void ValidateSByteToNotBeGreaterThanBiggerValue()
        {
            // Given
            var validator = new SbyteInverseValidator(42);

            // When
            validator.BeGreaterThan(65);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "sbyte.NotBeGreaterThan(wrongMinimum)")]
        public void ValidateSByteToNotBeGreaterThanValueViolated()
        {
            // Given
            var validator = new SbyteInverseValidator(42);

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

        #region sbyte.NotBeGreaterThanOrEqualTo()

        [Fact(DisplayName = "sbyte.NotBeGreaterThanOrEqualTo(sbyte)")]
        public void ValidateSByteNotToBeGreaterThanOrEqualToValue()
        {
            // Given
            var validator = new SbyteInverseValidator(42);

            // When
            validator.BeGreaterThanOrEqualTo(65);

            // Then
            Assert.True(true);
        }


        [Fact(DisplayName = "sbyte.NotBeGreaterThanOrEqualTo(wrongMinimum)")]
        public void ValidateSByteNotToBeGreaterThanOrEqualToValueViolated()
        {
            // Given
            var validator = new SbyteInverseValidator(42);

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

        #region sbyte.NotBeLessThan()

        [Fact(DisplayName = "sbyte.NotBeLessThan(equalValue)")]
        public void ValidateSByteToBeLessThanEqualValue()
        {
            // Given
            var validator = new SbyteInverseValidator(42);

            // When
            validator.BeLessThan(42);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "sbyte.NotBeLessThan(biggerValue)")]
        public void ValidateSByteToNotBeLessThanBiggerValue()
        {
            // Given
            var validator = new SbyteInverseValidator(42);

            // When
            validator.BeLessThan(13);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "sbyte.NotBeLessThan(wrongMaximum)")]
        public void ValidateSByteToNotBeLessThanValueViolated()
        {
            // Given
            var validator = new SbyteInverseValidator(42);

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

        #region sbyte.NotBeLessThanOrEqualTo()

        [Fact(DisplayName = "sbyte.NotBeLessThanOrEqualTo(sbyte)")]
        public void ValidateSByteNotToBeLessThanOrEqualToValue()
        {
            // Given
            var validator = new SbyteInverseValidator(42);

            // When
            validator.BeLessThanOrEqualTo(13);

            // Then
            Assert.True(true);
        }


        [Fact(DisplayName = "sbyte.NotBeLessThanOrEqualTo(wrongMinimum)")]
        public void ValidateSByteNotToBeLessThanOrEqualToValueViolated()
        {
            // Given
            var validator = new SbyteInverseValidator(42);

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

        #region sbyte.NotBeNegative()

        [Fact(DisplayName = "sbyte.NotBeNegative()")]
        public void ValidateSByteNotToBeNegative()
        {
            // Given
            var validator = new SbyteInverseValidator(0);

            // When
            validator.BeNegative();

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "sbyte.NotBeNegative()")]
        public void ValidateSByteNotToBeNegativeViolated()
        {
            // Given
            var validator = new SbyteInverseValidator(-42);

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

        #region sbyte.NotBeOneOf()

        [Fact(DisplayName = "sbyte.NotBeOneOf(other, other)")]
        public void ValidateSByteNotToBeOneOfExpectedValues()
        {
            // Given
            var validator = new SbyteInverseValidator(42);

            // When
            validator.BeOneOf(new sbyte[] { 10, 39 });

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "sbyte.NotBeOneOf(sbyte, sbyte)")]
        public void ValidateSByteNotToBeOneOfViolated()
        {
            // Given
            var validator = new SbyteInverseValidator(42);

            // When
            var exception = Assert.Throws<XunitException>(() => validator.BeOneOf(new sbyte[] { 13, 42 }, because: "that's the bottom line"));

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is \"42\"{rn}but was expected not to be one of the following values: \"13\", \"42\"{rn}because that's the bottom line",
                exception.UserMessage);
        }

        #endregion

        #region sbyte.NotBePositive()

        [Fact(DisplayName = "sbyte.NotBePositive()")]
        public void ValidateSByteToBePositive()
        {
            // Given
            var validator = new SbyteInverseValidator(-42);

            // When
            validator.BePositive();

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "sbyte.NotBePositive()")]
        public void ValidateSByteNotToBePositiveViolated()
        {
            // Given
            var validator = new SbyteInverseValidator(0);

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