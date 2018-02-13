namespace CustomCode.Test.BehaviorDrivenDevelopment.Tests
{
    using System;
    using Xunit;
    using Xunit.Sdk;

    /// <summary>
    /// Test cases for the <see cref="NullableUlongInverseValidator"/> type.
    /// </summary>
    [UnitTest]
    [Category("Assert", "ULongValidation")]
    public sealed class NullableUlongInverseValidatorTest
    {
        #region ulong?.NotBe()

        [Fact(DisplayName = "ulong?.NotBe(ulong?)")]
        public void ValidateUlongNotToBeValue()
        {
            // Given
            var validator = new NullableUlongInverseValidator(42);

            // When
            validator.Be(13);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "ulong?.NotBe(null)")]
        public void ValidateUlongNotToBeNull()
        {
            // Given
            var validator = new NullableUlongInverseValidator(42);

            // When
            validator.Be(null);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "ulong?.NotBe(other)")]
        public void ValidateUlongNotToBeValueViolated()
        {
            // Given
            var validator = new NullableUlongInverseValidator(42);

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

        #region ulong?.NotBeBetween()

        [Fact(DisplayName = "ulong?.NotBeBetween(ulong, ulong)")]
        public void ValidateUlongToNotBeBetweenSmallerValues()
        {
            // Given
            var validator = new NullableUlongInverseValidator(42);

            // When
            validator.BeBetween(13, 39);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "ulong?.NotBeBetween(ulong, ulong)")]
        public void ValidateUlongToNotBeBetweenBiggerValues()
        {
            // Given
            var validator = new NullableUlongInverseValidator(42);

            // When
            validator.BeBetween(65, 130);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "ulong?.NotBeBetween(ulong, ulong)")]
        public void ValidateNullableUlongToNotBeBetweenValues()
        {
            // Given
            var validator = new NullableUlongInverseValidator(null);

            // When
            validator.BeBetween(65, 130);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "ulong?.BeBetween(wrongMinimum, wrongMaximum)")]
        public void ValidateUlongToBeBetweenValuesMinimumAndMaximumViolated()
        {
            // Given
            var validator = new NullableUlongInverseValidator(42);

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

        #region ulong?.NotBeGreaterThan()

        [Fact(DisplayName = "ulong?.NotBeGreaterThan(equalValue)")]
        public void ValidateUlongToBeGreaterThanEqualValue()
        {
            // Given
            var validator = new NullableUlongInverseValidator(42);

            // When
            validator.BeGreaterThan(42);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "ulong?.NotBeGreaterThan(biggerValue)")]
        public void ValidateUlongToNotBeGreaterThanBiggerValue()
        {
            // Given
            var validator = new NullableUlongInverseValidator(42);

            // When
            validator.BeGreaterThan(65);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "ulong?.NotBeGreaterThan(biggerValue)")]
        public void ValidateNullableUlongToNotBeGreaterThanBiggerValue()
        {
            // Given
            var validator = new NullableUlongInverseValidator(null);

            // When
            validator.BeGreaterThan(65);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "ulong?.NotBeGreaterThan(wrongMinimum)")]
        public void ValidateUlongToNotBeGreaterThanValueViolated()
        {
            // Given
            var validator = new NullableUlongInverseValidator(42);

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

        #region ulong?.NotBeGreaterThanOrEqualTo()

        [Fact(DisplayName = "ulong?.NotBeGreaterThanOrEqualTo(ulong)")]
        public void ValidateUlongNotToBeGreaterThanOrEqualToValue()
        {
            // Given
            var validator = new NullableUlongInverseValidator(42);

            // When
            validator.BeGreaterThanOrEqualTo(65);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "ulong?.NotBeGreaterThanOrEqualTo(ulong)")]
        public void ValidateNullableUlongNotToBeGreaterThanOrEqualToValue()
        {
            // Given
            var validator = new NullableUlongInverseValidator(null);

            // When
            validator.BeGreaterThanOrEqualTo(65);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "ulong?.NotBeGreaterThanOrEqualTo(wrongMinimum)")]
        public void ValidateUlongNotToBeGreaterThanOrEqualToValueViolated()
        {
            // Given
            var validator = new NullableUlongInverseValidator(42);

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

        #region ulong?.NotBeLessThan()

        [Fact(DisplayName = "ulong?.NotBeLessThan(equalValue)")]
        public void ValidateUlongToBeLessThanEqualValue()
        {
            // Given
            var validator = new NullableUlongInverseValidator(42);

            // When
            validator.BeLessThan(42);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "ulong?.NotBeLessThan(biggerValue)")]
        public void ValidateUlongToNotBeLessThanBiggerValue()
        {
            // Given
            var validator = new NullableUlongInverseValidator(42);

            // When
            validator.BeLessThan(13);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "ulong?.NotBeLessThan(biggerValue)")]
        public void ValidateNullableUlongToNotBeLessThanBiggerValue()
        {
            // Given
            var validator = new NullableUlongInverseValidator(null);

            // When
            validator.BeLessThan(13);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "ulong?.NotBeLessThan(wrongMaximum)")]
        public void ValidateUlongToNotBeLessThanValueViolated()
        {
            // Given
            var validator = new NullableUlongInverseValidator(42);

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

        #region ulong?.NotBeLessThanOrEqualTo()

        [Fact(DisplayName = "ulong?.NotBeLessThanOrEqualTo(ulong)")]
        public void ValidateUlongNotToBeLessThanOrEqualToValue()
        {
            // Given
            var validator = new NullableUlongInverseValidator(42);

            // When
            validator.BeLessThanOrEqualTo(13);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "ulong?.NotBeLessThanOrEqualTo(ulong)")]
        public void ValidateNullableUlongNotToBeLessThanOrEqualToValue()
        {
            // Given
            var validator = new NullableUlongInverseValidator(null);

            // When
            validator.BeLessThanOrEqualTo(13);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "ulong?.NotBeLessThanOrEqualTo(wrongMinimum)")]
        public void ValidateUlongNotToBeLessThanOrEqualToValueViolated()
        {
            // Given
            var validator = new NullableUlongInverseValidator(42);

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

        #region ulong?.BeNull()

        [Fact(DisplayName = "ulong?.NotBeNull()")]
        public void ValidateNullableUlongNotToBeNull()
        {
            // Given
            var validator = new NullableUlongInverseValidator(0);

            // When
            validator.BeNull();

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "ulong?.NotBeNull()")]
        public void ValidateNullableUlongNotToBeNullViolated()
        {
            // Given
            var validator = new NullableUlongInverseValidator(null);

            // When
            var exception = Assert.Throws<XunitException>(() => validator.BeNull());

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is null{rn}but was expected not to be null",
                exception.UserMessage);
        }

        [Fact(DisplayName = "ulong?.NotBeNull(reason)")]
        public void ValidateNullableUlongNotToBeNullWithReasonViolated()
        {
            // Given
            var validator = new NullableUlongInverseValidator(null);

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

        #region ulong?.NotBeOneOf()

        [Fact(DisplayName = "ulong?.NotBeOneOf(other, other)")]
        public void ValidateUlongNotToBeOneOfExpectedValues()
        {
            // Given
            var validator = new NullableUlongInverseValidator(42);

            // When
            validator.BeOneOf(new ulong?[] { 10, 39 });

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "ulong?.NotBeOneOf(ulong?, ulong?)")]
        public void ValidateUlongNotToBeOneOfViolated()
        {
            // Given
            var validator = new NullableUlongInverseValidator(42);

            // When
            var exception = Assert.Throws<XunitException>(() => validator.BeOneOf(new ulong?[] { 13, 42 }, because: "that's the bottom line"));

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is \"42\"{rn}but was expected not to be one of the following values: \"13\", \"42\"{rn}because that's the bottom line",
                exception.UserMessage);
        }

        [Fact(DisplayName = "ulong?.NotBeOneOf(ulong?, ulong?)")]
        public void ValidateNullableUlongNotToBeOneOfViolated()
        {
            // Given
            var validator = new NullableUlongInverseValidator(null);

            // When
            var exception = Assert.Throws<XunitException>(() => validator.BeOneOf(new ulong?[] { null, 42 }, because: "that's the bottom line"));

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