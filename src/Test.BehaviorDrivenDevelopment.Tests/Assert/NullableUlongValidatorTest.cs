namespace CustomCode.Test.BehaviorDrivenDevelopment.Tests
{
    using System;
    using Xunit;
    using Xunit.Sdk;

    /// <summary>
    /// Test cases for the <see cref="NullableUlongValidator"/> type.
    /// </summary>
    [UnitTest]
    [Category("Assert", "ULongValidation")]
    public sealed class NullableUlongValidatorTest
    {
        #region ulong?.Be()

        [Fact(DisplayName = "ulong?.Be(ulong?)")]
        public void ValidateUlongToBeValue()
        {
            // Given
            var validator = new NullableUlongValidator(42);

            // When
            validator.Be(42);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "ulong?.Be(null)")]
        public void ValidateUlongToBeNull()
        {
            // Given
            var validator = new NullableUlongValidator(null);

            // When
            validator.Be(null);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "ulong?.Be(other)")]
        public void ValidateUlongToBeValueViolated()
        {
            // Given
            var validator = new NullableUlongValidator(42);

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

        #region ulong?.BeBetween()

        [Fact(DisplayName = "ulong?.BeBetween(ulong, ulong)")]
        public void ValidateUlongToBeBetweenValues()
        {
            // Given
            var validator = new NullableUlongValidator(42);

            // When
            validator.BeBetween(13, 130);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "ulong?.BeBetween(wrongMinimum, ulong)")]
        public void ValidateUlongToBeBetweenValuesMinimumViolated()
        {
            // Given
            var validator = new NullableUlongValidator(42);

            // When
            var exception = Assert.Throws<XunitException>(() => validator.BeBetween(65, 130, "that's the bottom line"));

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is \"42\"{rn}but was expected to be between \"65\" and \"130\"{rn}because that's the bottom line",
                exception.UserMessage);
        }

        [Fact(DisplayName = "ulong?.BeBetween(ulong, wrongMaximum)")]
        public void ValidateUlongToBeBetweenValuesMaximumViolated()
        {
            // Given
            var validator = new NullableUlongValidator(42);

            // When
            var exception = Assert.Throws<XunitException>(() => validator.BeBetween(13, 39, "that's the bottom line"));

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is \"42\"{rn}but was expected to be between \"13\" and \"39\"{rn}because that's the bottom line",
                exception.UserMessage);
        }

        [Fact(DisplayName = "ulong?.BeBetween(wrongMinimum, wrongMaximum)")]
        public void ValidateUlongToBeBetweenValuesMinimumAndMaximumViolated()
        {
            // Given
            var validator = new NullableUlongValidator(42);

            // When
            var exception = Assert.Throws<XunitException>(() => validator.BeBetween(130, 13, "that's the bottom line"));

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is \"42\"{rn}but was expected to be between \"130\" and \"13\"{rn}because that's the bottom line",
                exception.UserMessage);
        }

        [Fact(DisplayName = "ulong?.BeBetween(wrongMinimum, wrongMaximum)")]
        public void ValidateNullableUlongToBeBetweenValuesMinimumAndMaximumViolated()
        {
            // Given
            var validator = new NullableUlongValidator(null);

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

        #region ulong?.BeGreaterThan()

        [Fact(DisplayName = "ulong?.BeGreaterThan(ulong)")]
        public void ValidateUlongToBeGreaterThanValue()
        {
            // Given
            var validator = new NullableUlongValidator(42);

            // When
            validator.BeGreaterThan(13);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "ulong?.BeGreaterThan(wrongMinimum)")]
        public void ValidateUlongToBeGreaterThanValueViolated()
        {
            // Given
            var validator = new NullableUlongValidator(42);

            // When
            var exception = Assert.Throws<XunitException>(() => validator.BeGreaterThan(42, "that's the bottom line"));

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is \"42\"{rn}but was expected to be greater than \"42\"{rn}because that's the bottom line",
                exception.UserMessage);
        }

        [Fact(DisplayName = "ulong?.BeGreaterThan(wrongMinimum)")]
        public void ValidateNullableUlongToBeGreaterThanValueViolated()
        {
            // Given
            var validator = new NullableUlongValidator(null);

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

        #region ulong?.BeGreaterThanOrEqualTo()

        [Fact(DisplayName = "ulong?.BeGreaterThanOrEqualTo(smallerValue)")]
        public void ValidateUlongToBeGreaterThanOrEqualToSmallerValue()
        {
            // Given
            var validator = new NullableUlongValidator(42);

            // When
            validator.BeGreaterThanOrEqualTo(13);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "ulong?.BeGreaterThanOrEqualTo(equalValue)")]
        public void ValidateUlongToBeGreaterThanOrEqualToEqualValue()
        {
            // Given
            var validator = new NullableUlongValidator(42);

            // When
            validator.BeGreaterThanOrEqualTo(42);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "ulong?.BeGreaterThanOrEqualTo(wrongMinimum)")]
        public void ValidateUlongToBeGreaterThanOrEqualToValueViolated()
        {
            // Given
            var validator = new NullableUlongValidator(42);

            // When
            var exception = Assert.Throws<XunitException>(() => validator.BeGreaterThanOrEqualTo(65, "that's the bottom line"));

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is \"42\"{rn}but was expected to be greater than or equal to \"65\"{rn}because that's the bottom line",
                exception.UserMessage);
        }

        [Fact(DisplayName = "ulong?.BeGreaterThanOrEqualTo(wrongMinimum)")]
        public void ValidateNullableUlongToBeGreaterThanOrEqualToValueViolated()
        {
            // Given
            var validator = new NullableUlongValidator(null);

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

        #region ulong?.BeLessThan()

        [Fact(DisplayName = "ulong?.BeLessThan(ulong)")]
        public void ValidateUlongToBeLessThanValue()
        {
            // Given
            var validator = new NullableUlongValidator(42);

            // When
            validator.BeLessThan(65);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "ulong?.BeLessThan(wrongMinimum)")]
        public void ValidateUlongToBeLessThanValueViolated()
        {
            // Given
            var validator = new NullableUlongValidator(42);

            // When
            var exception = Assert.Throws<XunitException>(() => validator.BeLessThan(42, "that's the bottom line"));

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is \"42\"{rn}but was expected to be less than \"42\"{rn}because that's the bottom line",
                exception.UserMessage);
        }

        [Fact(DisplayName = "ulong?.BeLessThan(wrongMinimum)")]
        public void ValidateNullableUlongToBeLessThanValueViolated()
        {
            // Given
            var validator = new NullableUlongValidator(null);

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

        #region ulong?.BeLessThanOrEqualTo()

        [Fact(DisplayName = "ulong?.BeLessThanOrEqualTo(biggerValue)")]
        public void ValidateUlongToBeLessThanOrEqualToBiggerValue()
        {
            // Given
            var validator = new NullableUlongValidator(42);

            // When
            validator.BeLessThanOrEqualTo(65);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "ulong?.BeLessThanOrEqualTo(equalValue)")]
        public void ValidateUlongToBeLessThanOrEqualToEqualValue()
        {
            // Given
            var validator = new NullableUlongValidator(42);

            // When
            validator.BeLessThanOrEqualTo(42);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "ulong?.BeLessThanOrEqualTo(wrongMaximum)")]
        public void ValidateUlongToBeLessThanOrEqualToValueViolated()
        {
            // Given
            var validator = new NullableUlongValidator(42);

            // When
            var exception = Assert.Throws<XunitException>(() => validator.BeLessThanOrEqualTo(13, "that's the bottom line"));

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is \"42\"{rn}but was expected to be less than or equal to \"13\"{rn}because that's the bottom line",
                exception.UserMessage);
        }

        [Fact(DisplayName = "ulong?.BeLessThanOrEqualTo(wrongMaximum)")]
        public void ValidateNullableUlongToBeLessThanOrEqualToValueViolated()
        {
            // Given
            var validator = new NullableUlongValidator(null);

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

        #region ulong?.BeNull()

        [Fact(DisplayName = "ulong?.BeNull()")]
        public void ValidateNullableUlongToBeNull()
        {
            // Given
            var validator = new NullableUlongValidator(null);

            // When
            validator.BeNull();

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "ulong?.BeNull()")]
        public void ValidateNullableUlongToBeNullViolated()
        {
            // Given
            var validator = new NullableUlongValidator(0);

            // When
            var exception = Assert.Throws<XunitException>(() => validator.BeNull());

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is \"0\"{rn}but was expected to be null",
                exception.UserMessage);
        }

        [Fact(DisplayName = "ulong?.BeNull(reason)")]
        public void ValidateNullableToBeNullWithReasonViolated()
        {
            // Given
            var validator = new NullableUlongValidator(0);

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

        #region ulong?.BeOneOf()

        [Fact(DisplayName = "ulong?.BeOneOf(ulong?, ulong?)")]
        public void ValidateUlongToBeOneOfExpectedValues()
        {
            // Given
            var validator = new NullableUlongValidator(42);

            // When
            validator.BeOneOf(new ulong?[] { 10, 42 });

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "ulong?.BeOneOf(ulong?, ulong?)")]
        public void ValidateNullableUlongToBeOneOfExpectedValues()
        {
            // Given
            var validator = new NullableUlongValidator(null);

            // When
            validator.BeOneOf(new ulong?[] { 10, null });

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "ulong?.BeOneOf(other, other)")]
        public void ValidateUlongToBeOneOfViolated()
        {
            // Given
            var validator = new NullableUlongValidator(42);

            // When
            var exception = Assert.Throws<XunitException>(() => validator.BeOneOf(new ulong?[] { 13, 39 }, because: "that's the bottom line"));

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