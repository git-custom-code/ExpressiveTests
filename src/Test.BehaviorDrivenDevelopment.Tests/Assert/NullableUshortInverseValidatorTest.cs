namespace CustomCode.Test.BehaviorDrivenDevelopment.Tests
{
    using System;
    using Xunit;
    using Xunit.Sdk;

    /// <summary>
    /// Test cases for the <see cref="NullableUshortInverseValidator"/> type.
    /// </summary>
    [UnitTest]
    [Category("Assert", "UShortValidation")]
    public sealed class NullableUshortInverseValidatorTest
    {
        #region ushort?.NotBe()

        [Fact(DisplayName = "ushort?.NotBe(ushort?)")]
        public void ValidateUshortNotToBeValue()
        {
            // Given
            var validator = new NullableUshortInverseValidator(42);

            // When
            validator.Be(13);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "ushort?.NotBe(null)")]
        public void ValidateUshortNotToBeNull()
        {
            // Given
            var validator = new NullableUshortInverseValidator(42);

            // When
            validator.Be(null);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "ushort?.NotBe(other)")]
        public void ValidateUshortNotToBeValueViolated()
        {
            // Given
            var validator = new NullableUshortInverseValidator(42);

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

        #region ushort?.NotBeBetween()

        [Fact(DisplayName = "ushort?.NotBeBetween(ushort, ushort)")]
        public void ValidateUshortToNotBeBetweenSmallerValues()
        {
            // Given
            var validator = new NullableUshortInverseValidator(42);

            // When
            validator.BeBetween(13, 39);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "ushort?.NotBeBetween(ushort, ushort)")]
        public void ValidateUshortToNotBeBetweenBiggerValues()
        {
            // Given
            var validator = new NullableUshortInverseValidator(42);

            // When
            validator.BeBetween(65, 130);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "ushort?.NotBeBetween(ushort, ushort)")]
        public void ValidateNullableUshortToNotBeBetweenValues()
        {
            // Given
            var validator = new NullableUshortInverseValidator(null);

            // When
            validator.BeBetween(65, 130);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "ushort?.BeBetween(wrongMinimum, wrongMaximum)")]
        public void ValidateUshortToBeBetweenValuesMinimumAndMaximumViolated()
        {
            // Given
            var validator = new NullableUshortInverseValidator(42);

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

        #region ushort?.NotBeGreaterThan()

        [Fact(DisplayName = "ushort?.NotBeGreaterThan(equalValue)")]
        public void ValidateUshortToBeGreaterThanEqualValue()
        {
            // Given
            var validator = new NullableUshortInverseValidator(42);

            // When
            validator.BeGreaterThan(42);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "ushort?.NotBeGreaterThan(biggerValue)")]
        public void ValidateUshortToNotBeGreaterThanBiggerValue()
        {
            // Given
            var validator = new NullableUshortInverseValidator(42);

            // When
            validator.BeGreaterThan(65);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "ushort?.NotBeGreaterThan(biggerValue)")]
        public void ValidateNullableUshortToNotBeGreaterThanBiggerValue()
        {
            // Given
            var validator = new NullableUshortInverseValidator(null);

            // When
            validator.BeGreaterThan(65);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "ushort?.NotBeGreaterThan(wrongMinimum)")]
        public void ValidateUshortToNotBeGreaterThanValueViolated()
        {
            // Given
            var validator = new NullableUshortInverseValidator(42);

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

        #region ushort?.NotBeGreaterThanOrEqualTo()

        [Fact(DisplayName = "ushort?.NotBeGreaterThanOrEqualTo(ushort)")]
        public void ValidateUshortNotToBeGreaterThanOrEqualToValue()
        {
            // Given
            var validator = new NullableUshortInverseValidator(42);

            // When
            validator.BeGreaterThanOrEqualTo(65);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "ushort?.NotBeGreaterThanOrEqualTo(ushort)")]
        public void ValidateNullableUshortNotToBeGreaterThanOrEqualToValue()
        {
            // Given
            var validator = new NullableUshortInverseValidator(null);

            // When
            validator.BeGreaterThanOrEqualTo(65);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "ushort?.NotBeGreaterThanOrEqualTo(wrongMinimum)")]
        public void ValidateUshortNotToBeGreaterThanOrEqualToValueViolated()
        {
            // Given
            var validator = new NullableUshortInverseValidator(42);

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

        #region ushort?.NotBeLessThan()

        [Fact(DisplayName = "ushort?.NotBeLessThan(equalValue)")]
        public void ValidateUshortToBeLessThanEqualValue()
        {
            // Given
            var validator = new NullableUshortInverseValidator(42);

            // When
            validator.BeLessThan(42);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "ushort?.NotBeLessThan(biggerValue)")]
        public void ValidateUshortToNotBeLessThanBiggerValue()
        {
            // Given
            var validator = new NullableUshortInverseValidator(42);

            // When
            validator.BeLessThan(13);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "ushort?.NotBeLessThan(biggerValue)")]
        public void ValidateNullableUshortToNotBeLessThanBiggerValue()
        {
            // Given
            var validator = new NullableUshortInverseValidator(null);

            // When
            validator.BeLessThan(13);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "ushort?.NotBeLessThan(wrongMaximum)")]
        public void ValidateUshortToNotBeLessThanValueViolated()
        {
            // Given
            var validator = new NullableUshortInverseValidator(42);

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

        #region ushort?.NotBeLessThanOrEqualTo()

        [Fact(DisplayName = "ushort?.NotBeLessThanOrEqualTo(ushort)")]
        public void ValidateUshortNotToBeLessThanOrEqualToValue()
        {
            // Given
            var validator = new NullableUshortInverseValidator(42);

            // When
            validator.BeLessThanOrEqualTo(13);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "ushort?.NotBeLessThanOrEqualTo(ushort)")]
        public void ValidateNullableUshortNotToBeLessThanOrEqualToValue()
        {
            // Given
            var validator = new NullableUshortInverseValidator(null);

            // When
            validator.BeLessThanOrEqualTo(13);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "ushort?.NotBeLessThanOrEqualTo(wrongMinimum)")]
        public void ValidateUshortNotToBeLessThanOrEqualToValueViolated()
        {
            // Given
            var validator = new NullableUshortInverseValidator(42);

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

        #region ushort?.BeNull()

        [Fact(DisplayName = "ushort?.NotBeNull()")]
        public void ValidateNullableUshortNotToBeNull()
        {
            // Given
            var validator = new NullableUshortInverseValidator(0);

            // When
            validator.BeNull();

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "ushort?.NotBeNull()")]
        public void ValidateNullableUshortNotToBeNullViolated()
        {
            // Given
            var validator = new NullableUshortInverseValidator(null);

            // When
            var exception = Assert.Throws<XunitException>(() => validator.BeNull());

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is null{rn}but was expected not to be null",
                exception.UserMessage);
        }

        [Fact(DisplayName = "ushort?.NotBeNull(reason)")]
        public void ValidateNullableUshortNotToBeNullWithReasonViolated()
        {
            // Given
            var validator = new NullableUshortInverseValidator(null);

            // When
            var exception = Assert.Throws<XunitException>(() => validator.BeNull("that's the bottom line"));

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is null{rn}but was expected not to be null{rn}because that's the bottom line",
                exception.UserMessage);
        }

        #endregion

        #region ushort?.NotBeOneOf()

        [Fact(DisplayName = "ushort?.NotBeOneOf(other, other)")]
        public void ValidateUshortNotToBeOneOfExpectedValues()
        {
            // Given
            var validator = new NullableUshortInverseValidator(42);

            // When
            validator.BeOneOf(new ushort?[] { 10, 39 });

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "ushort?.NotBeOneOf(ushort?, ushort?)")]
        public void ValidateUshortNotToBeOneOfViolated()
        {
            // Given
            var validator = new NullableUshortInverseValidator(42);

            // When
            var exception = Assert.Throws<XunitException>(() => validator.BeOneOf(new ushort?[] { 13, 42 }, because: "that's the bottom line"));

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is \"42\"{rn}but was expected not to be one of the following values: \"13\", \"42\"{rn}because that's the bottom line",
                exception.UserMessage);
        }

        [Fact(DisplayName = "ushort?.NotBeOneOf(ushort?, ushort?)")]
        public void ValidateNullableUshortNotToBeOneOfViolated()
        {
            // Given
            var validator = new NullableUshortInverseValidator(null);

            // When
            var exception = Assert.Throws<XunitException>(() => validator.BeOneOf(new ushort?[] { null, 42 }, because: "that's the bottom line"));

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is \"\"{rn}but was expected not to be one of the following values: \"\", \"42\"{rn}because that's the bottom line",
                exception.UserMessage);
        }

        #endregion
    }
}