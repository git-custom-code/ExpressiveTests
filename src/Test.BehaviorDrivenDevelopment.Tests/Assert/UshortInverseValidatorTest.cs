namespace CustomCode.Test.BehaviorDrivenDevelopment.Tests
{
    using System;
    using Xunit;
    using Xunit.Sdk;

    /// <summary>
    /// Test cases for the <see cref="UshortInverseValidator"/> type.
    /// </summary>
    [UnitTest]
    [Category("Assert", "UShortValidation")]
    public sealed class UshortInvereseValidatorTest
    {
        #region ushort.NotBe()

        [Fact(DisplayName = "ushort.NotBe(ushort)")]
        public void ValidateUShortNotToBeValue()
        {
            // Given
            var validator = new UshortInverseValidator(42);

            // When
            validator.Be(13);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "ushort.NotBe(other)")]
        public void ValidateUShortNotToBeValueViolated()
        {
            // Given
            var validator = new UshortInverseValidator(42);

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

        #region ushort.NotBeBetween()

        [Fact(DisplayName = "ushort.NotBeBetween(ushort, ushort)")]
        public void ValidateUShortToNotBeBetweenSmallerValues()
        {
            // Given
            var validator = new UshortInverseValidator(42);

            // When
            validator.BeBetween(13, 39);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "ushort.NotBeBetween(ushort, ushort)")]
        public void ValidateUShortToNotBeBetweenBiggerValues()
        {
            // Given
            var validator = new UshortInverseValidator(42);

            // When
            validator.BeBetween(65, 130);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "ushort.BeBetween(wrongMinimum, wrongMaximum)")]
        public void ValidateUShortToBeBetweenValuesMinimumAndMaximumViolated()
        {
            // Given
            var validator = new UshortInverseValidator(42);

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

        #region ushort.NotBeGreaterThan()

        [Fact(DisplayName = "ushort.NotBeGreaterThan(equalValue)")]
        public void ValidateUShortToBeGreaterThanEqualValue()
        {
            // Given
            var validator = new UshortInverseValidator(42);

            // When
            validator.BeGreaterThan(42);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "ushort.NotBeGreaterThan(biggerValue)")]
        public void ValidateUShortToNotBeGreaterThanBiggerValue()
        {
            // Given
            var validator = new UshortInverseValidator(42);

            // When
            validator.BeGreaterThan(65);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "ushort.NotBeGreaterThan(wrongMinimum)")]
        public void ValidateUShortToNotBeGreaterThanValueViolated()
        {
            // Given
            var validator = new UshortInverseValidator(42);

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

        #region ushort.NotBeGreaterThanOrEqualTo()

        [Fact(DisplayName = "ushort.NotBeGreaterThanOrEqualTo(ushort)")]
        public void ValidateUShortNotToBeGreaterThanOrEqualToValue()
        {
            // Given
            var validator = new UshortInverseValidator(42);

            // When
            validator.BeGreaterThanOrEqualTo(65);

            // Then
            Assert.True(true);
        }


        [Fact(DisplayName = "ushort.NotBeGreaterThanOrEqualTo(wrongMinimum)")]
        public void ValidateUShortNotToBeGreaterThanOrEqualToValueViolated()
        {
            // Given
            var validator = new UshortInverseValidator(42);

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

        #region ushort.NotBeLessThan()

        [Fact(DisplayName = "ushort.NotBeLessThan(equalValue)")]
        public void ValidateUShortToBeLessThanEqualValue()
        {
            // Given
            var validator = new UshortInverseValidator(42);

            // When
            validator.BeLessThan(42);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "ushort.NotBeLessThan(biggerValue)")]
        public void ValidateUShortToNotBeLessThanBiggerValue()
        {
            // Given
            var validator = new UshortInverseValidator(42);

            // When
            validator.BeLessThan(13);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "ushort.NotBeLessThan(wrongMaximum)")]
        public void ValidateUShortToNotBeLessThanValueViolated()
        {
            // Given
            var validator = new UshortInverseValidator(42);

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

        #region ushort.NotBeLessThanOrEqualTo()

        [Fact(DisplayName = "ushort.NotBeLessThanOrEqualTo(ushort)")]
        public void ValidateUShortNotToBeLessThanOrEqualToValue()
        {
            // Given
            var validator = new UshortInverseValidator(42);

            // When
            validator.BeLessThanOrEqualTo(13);

            // Then
            Assert.True(true);
        }


        [Fact(DisplayName = "ushort.NotBeLessThanOrEqualTo(wrongMinimum)")]
        public void ValidateUShortNotToBeLessThanOrEqualToValueViolated()
        {
            // Given
            var validator = new UshortInverseValidator(42);

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

        #region ushort.NotBeOneOf()

        [Fact(DisplayName = "ushort.NotBeOneOf(other, other)")]
        public void ValidateUShortNotToBeOneOfExpectedValues()
        {
            // Given
            var validator = new UshortInverseValidator(42);

            // When
            validator.BeOneOf(new ushort[] { 10, 39 });

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "ushort.NotBeOneOf(ushort, ushort)")]
        public void ValidateUShortNotToBeOneOfViolated()
        {
            // Given
            var validator = new UshortInverseValidator(42);

            // When
            var exception = Assert.Throws<XunitException>(() => validator.BeOneOf(new ushort[] { 13, 42 }, because: "that's the bottom line"));

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