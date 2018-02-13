namespace CustomCode.Test.BehaviorDrivenDevelopment.Tests
{
    using System;
    using Xunit;
    using Xunit.Sdk;

    /// <summary>
    /// Test cases for the <see cref="NullableUintValidator"/> type.
    /// </summary>
    [UnitTest]
    [Category("Assert", "UIntValidation")]
    public sealed class NullableUintValidatorTest
    {
        #region uint?.Be()

        [Fact(DisplayName = "uint?.Be(uint?)")]
        public void ValidateUintToBeValue()
        {
            // Given
            var validator = new NullableUintValidator(42);

            // When
            validator.Be(42);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "uint?.Be(null)")]
        public void ValidateUintToBeNull()
        {
            // Given
            var validator = new NullableUintValidator(null);

            // When
            validator.Be(null);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "uint?.Be(other)")]
        public void ValidateUintToBeValueViolated()
        {
            // Given
            var validator = new NullableUintValidator(42);

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

        #region uint?.BeBetween()

        [Fact(DisplayName = "uint?.BeBetween(uint, uint)")]
        public void ValidateUintToBeBetweenValues()
        {
            // Given
            var validator = new NullableUintValidator(42);

            // When
            validator.BeBetween(13, 130);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "uint?.BeBetween(wrongMinimum, uint)")]
        public void ValidateUintToBeBetweenValuesMinimumViolated()
        {
            // Given
            var validator = new NullableUintValidator(42);

            // When
            var exception = Assert.Throws<XunitException>(() => validator.BeBetween(65, 130, "that's the bottom line"));

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is \"42\"{rn}but was expected to be between \"65\" and \"130\"{rn}because that's the bottom line",
                exception.UserMessage);
        }

        [Fact(DisplayName = "uint?.BeBetween(uint, wrongMaximum)")]
        public void ValidateUintToBeBetweenValuesMaximumViolated()
        {
            // Given
            var validator = new NullableUintValidator(42);

            // When
            var exception = Assert.Throws<XunitException>(() => validator.BeBetween(13, 39, "that's the bottom line"));

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is \"42\"{rn}but was expected to be between \"13\" and \"39\"{rn}because that's the bottom line",
                exception.UserMessage);
        }

        [Fact(DisplayName = "uint?.BeBetween(wrongMinimum, wrongMaximum)")]
        public void ValidateUintToBeBetweenValuesMinimumAndMaximumViolated()
        {
            // Given
            var validator = new NullableUintValidator(42);

            // When
            var exception = Assert.Throws<XunitException>(() => validator.BeBetween(130, 13, "that's the bottom line"));

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is \"42\"{rn}but was expected to be between \"130\" and \"13\"{rn}because that's the bottom line",
                exception.UserMessage);
        }

        [Fact(DisplayName = "uint?.BeBetween(wrongMinimum, wrongMaximum)")]
        public void ValidateNullableUintToBeBetweenValuesMinimumAndMaximumViolated()
        {
            // Given
            var validator = new NullableUintValidator(null);

            // When
            var exception = Assert.Throws<XunitException>(() => validator.BeBetween(130, 13, "that's the bottom line"));

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is \"\"{rn}but was expected to be between \"130\" and \"13\"{rn}because that's the bottom line",
                exception.UserMessage);
        }

        #endregion

        #region uint?.BeGreaterThan()

        [Fact(DisplayName = "uint?.BeGreaterThan(uint)")]
        public void ValidateUintToBeGreaterThanValue()
        {
            // Given
            var validator = new NullableUintValidator(42);

            // When
            validator.BeGreaterThan(13);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "uint?.BeGreaterThan(wrongMinimum)")]
        public void ValidateUintToBeGreaterThanValueViolated()
        {
            // Given
            var validator = new NullableUintValidator(42);

            // When
            var exception = Assert.Throws<XunitException>(() => validator.BeGreaterThan(42, "that's the bottom line"));

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is \"42\"{rn}but was expected to be greater than \"42\"{rn}because that's the bottom line",
                exception.UserMessage);
        }

        [Fact(DisplayName = "uint?.BeGreaterThan(wrongMinimum)")]
        public void ValidateNullableUintToBeGreaterThanValueViolated()
        {
            // Given
            var validator = new NullableUintValidator(null);

            // When
            var exception = Assert.Throws<XunitException>(() => validator.BeGreaterThan(42, "that's the bottom line"));

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is \"\"{rn}but was expected to be greater than \"42\"{rn}because that's the bottom line",
                exception.UserMessage);
        }

        #endregion

        #region uint?.BeGreaterThanOrEqualTo()

        [Fact(DisplayName = "uint?.BeGreaterThanOrEqualTo(smallerValue)")]
        public void ValidateUintToBeGreaterThanOrEqualToSmallerValue()
        {
            // Given
            var validator = new NullableUintValidator(42);

            // When
            validator.BeGreaterThanOrEqualTo(13);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "uint?.BeGreaterThanOrEqualTo(equalValue)")]
        public void ValidateUintToBeGreaterThanOrEqualToEqualValue()
        {
            // Given
            var validator = new NullableUintValidator(42);

            // When
            validator.BeGreaterThanOrEqualTo(42);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "uint?.BeGreaterThanOrEqualTo(wrongMinimum)")]
        public void ValidateUintToBeGreaterThanOrEqualToValueViolated()
        {
            // Given
            var validator = new NullableUintValidator(42);

            // When
            var exception = Assert.Throws<XunitException>(() => validator.BeGreaterThanOrEqualTo(65, "that's the bottom line"));

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is \"42\"{rn}but was expected to be greater than or equal to \"65\"{rn}because that's the bottom line",
                exception.UserMessage);
        }

        [Fact(DisplayName = "uint?.BeGreaterThanOrEqualTo(wrongMinimum)")]
        public void ValidateNullableUintToBeGreaterThanOrEqualToValueViolated()
        {
            // Given
            var validator = new NullableUintValidator(null);

            // When
            var exception = Assert.Throws<XunitException>(() => validator.BeGreaterThanOrEqualTo(65, "that's the bottom line"));

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is \"\"{rn}but was expected to be greater than or equal to \"65\"{rn}because that's the bottom line",
                exception.UserMessage);
        }

        #endregion

        #region uint?.BeLessThan()

        [Fact(DisplayName = "uint?.BeLessThan(uint)")]
        public void ValidateUintToBeLessThanValue()
        {
            // Given
            var validator = new NullableUintValidator(42);

            // When
            validator.BeLessThan(65);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "uint?.BeLessThan(wrongMinimum)")]
        public void ValidateUintToBeLessThanValueViolated()
        {
            // Given
            var validator = new NullableUintValidator(42);

            // When
            var exception = Assert.Throws<XunitException>(() => validator.BeLessThan(42, "that's the bottom line"));

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is \"42\"{rn}but was expected to be less than \"42\"{rn}because that's the bottom line",
                exception.UserMessage);
        }

        [Fact(DisplayName = "uint?.BeLessThan(wrongMinimum)")]
        public void ValidateNullableUintToBeLessThanValueViolated()
        {
            // Given
            var validator = new NullableUintValidator(null);

            // When
            var exception = Assert.Throws<XunitException>(() => validator.BeLessThan(42, "that's the bottom line"));

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is \"\"{rn}but was expected to be less than \"42\"{rn}because that's the bottom line",
                exception.UserMessage);
        }

        #endregion

        #region uint?.BeLessThanOrEqualTo()

        [Fact(DisplayName = "uint?.BeLessThanOrEqualTo(biggerValue)")]
        public void ValidateUintToBeLessThanOrEqualToBiggerValue()
        {
            // Given
            var validator = new NullableUintValidator(42);

            // When
            validator.BeLessThanOrEqualTo(65);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "uint?.BeLessThanOrEqualTo(equalValue)")]
        public void ValidateUintToBeLessThanOrEqualToEqualValue()
        {
            // Given
            var validator = new NullableUintValidator(42);

            // When
            validator.BeLessThanOrEqualTo(42);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "uint?.BeLessThanOrEqualTo(wrongMaximum)")]
        public void ValidateUintToBeLessThanOrEqualToValueViolated()
        {
            // Given
            var validator = new NullableUintValidator(42);

            // When
            var exception = Assert.Throws<XunitException>(() => validator.BeLessThanOrEqualTo(13, "that's the bottom line"));

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is \"42\"{rn}but was expected to be less than or equal to \"13\"{rn}because that's the bottom line",
                exception.UserMessage);
        }

        [Fact(DisplayName = "uint?.BeLessThanOrEqualTo(wrongMaximum)")]
        public void ValidateNullableUintToBeLessThanOrEqualToValueViolated()
        {
            // Given
            var validator = new NullableUintValidator(null);

            // When
            var exception = Assert.Throws<XunitException>(() => validator.BeLessThanOrEqualTo(13, "that's the bottom line"));

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is \"\"{rn}but was expected to be less than or equal to \"13\"{rn}because that's the bottom line",
                exception.UserMessage);
        }

        #endregion

        #region uint?.BeNull()

        [Fact(DisplayName = "uint?.BeNull()")]
        public void ValidateNullableUintToBeNull()
        {
            // Given
            var validator = new NullableUintValidator(null);

            // When
            validator.BeNull();

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "uint?.BeNull()")]
        public void ValidateNullableUintToBeNullViolated()
        {
            // Given
            var validator = new NullableUintValidator(0);

            // When
            var exception = Assert.Throws<XunitException>(() => validator.BeNull());

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is \"0\"{rn}but was expected to be null",
                exception.UserMessage);
        }

        [Fact(DisplayName = "uint?.BeNull(reason)")]
        public void ValidateNullableToBeNullWithReasonViolated()
        {
            // Given
            var validator = new NullableUintValidator(0);

            // When
            var exception = Assert.Throws<XunitException>(() => validator.BeNull("that's the bottom line"));

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is \"0\"{rn}but was expected to be null{rn}because that's the bottom line",
                exception.UserMessage);
        }

        #endregion

        #region uint?.BeOneOf()

        [Fact(DisplayName = "uint?.BeOneOf(uint?, uint?)")]
        public void ValidateUintToBeOneOfExpectedValues()
        {
            // Given
            var validator = new NullableUintValidator(42);

            // When
            validator.BeOneOf(new uint?[] { 10, 42 });

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "uint?.BeOneOf(uint?, uint?)")]
        public void ValidateNullableUintToBeOneOfExpectedValues()
        {
            // Given
            var validator = new NullableUintValidator(null);

            // When
            validator.BeOneOf(new uint?[] { 10, null });

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "uint?.BeOneOf(other, other)")]
        public void ValidateUintToBeOneOfViolated()
        {
            // Given
            var validator = new NullableUintValidator(42);

            // When
            var exception = Assert.Throws<XunitException>(() => validator.BeOneOf(new uint?[] { 13, 39 }, because: "that's the bottom line"));

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is \"42\"{rn}but was expected to be one of the following values: \"13\", \"39\"{rn}because that's the bottom line",
                exception.UserMessage);
        }

        #endregion
    }
}