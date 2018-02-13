namespace CustomCode.Test.BehaviorDrivenDevelopment.Tests
{
    using System;
    using Xunit;
    using Xunit.Sdk;

    /// <summary>
    /// Test cases for the <see cref="NullableUshortValidator"/> type.
    /// </summary>
    [UnitTest]
    [Category("Assert", "UshortValidation")]
    public sealed class NullableUshortValidatorTest
    {
        #region ushort?.Be()

        [Fact(DisplayName = "ushort?.Be(ushort?)")]
        public void ValidateUshortToBeValue()
        {
            // Given
            var validator = new NullableUshortValidator(42);

            // When
            validator.Be(42);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "ushort?.Be(null)")]
        public void ValidateUshortToBeNull()
        {
            // Given
            var validator = new NullableUshortValidator(null);

            // When
            validator.Be(null);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "ushort?.Be(other)")]
        public void ValidateUshortToBeValueViolated()
        {
            // Given
            var validator = new NullableUshortValidator(42);

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

        #region ushort?.BeBetween()

        [Fact(DisplayName = "ushort?.BeBetween(ushort, ushort)")]
        public void ValidateUshortToBeBetweenValues()
        {
            // Given
            var validator = new NullableUshortValidator(42);

            // When
            validator.BeBetween(13, 130);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "ushort?.BeBetween(wrongMinimum, ushort)")]
        public void ValidateUshortToBeBetweenValuesMinimumViolated()
        {
            // Given
            var validator = new NullableUshortValidator(42);

            // When
            var exception = Assert.Throws<XunitException>(() => validator.BeBetween(65, 130, "that's the bottom line"));

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is \"42\"{rn}but was expected to be between \"65\" and \"130\"{rn}because that's the bottom line",
                exception.UserMessage);
        }

        [Fact(DisplayName = "ushort?.BeBetween(ushort, wrongMaximum)")]
        public void ValidateUshortToBeBetweenValuesMaximumViolated()
        {
            // Given
            var validator = new NullableUshortValidator(42);

            // When
            var exception = Assert.Throws<XunitException>(() => validator.BeBetween(13, 39, "that's the bottom line"));

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is \"42\"{rn}but was expected to be between \"13\" and \"39\"{rn}because that's the bottom line",
                exception.UserMessage);
        }

        [Fact(DisplayName = "ushort?.BeBetween(wrongMinimum, wrongMaximum)")]
        public void ValidateUshortToBeBetweenValuesMinimumAndMaximumViolated()
        {
            // Given
            var validator = new NullableUshortValidator(42);

            // When
            var exception = Assert.Throws<XunitException>(() => validator.BeBetween(130, 13, "that's the bottom line"));

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is \"42\"{rn}but was expected to be between \"130\" and \"13\"{rn}because that's the bottom line",
                exception.UserMessage);
        }

        [Fact(DisplayName = "ushort?.BeBetween(wrongMinimum, wrongMaximum)")]
        public void ValidateNullableUshortToBeBetweenValuesMinimumAndMaximumViolated()
        {
            // Given
            var validator = new NullableUshortValidator(null);

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

        #region ushort?.BeGreaterThan()

        [Fact(DisplayName = "ushort?.BeGreaterThan(ushort)")]
        public void ValidateUshortToBeGreaterThanValue()
        {
            // Given
            var validator = new NullableUshortValidator(42);

            // When
            validator.BeGreaterThan(13);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "ushort?.BeGreaterThan(wrongMinimum)")]
        public void ValidateUshortToBeGreaterThanValueViolated()
        {
            // Given
            var validator = new NullableUshortValidator(42);

            // When
            var exception = Assert.Throws<XunitException>(() => validator.BeGreaterThan(42, "that's the bottom line"));

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is \"42\"{rn}but was expected to be greater than \"42\"{rn}because that's the bottom line",
                exception.UserMessage);
        }

        [Fact(DisplayName = "ushort?.BeGreaterThan(wrongMinimum)")]
        public void ValidateNullableUshortToBeGreaterThanValueViolated()
        {
            // Given
            var validator = new NullableUshortValidator(null);

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

        #region ushort?.BeGreaterThanOrEqualTo()

        [Fact(DisplayName = "ushort?.BeGreaterThanOrEqualTo(smallerValue)")]
        public void ValidateUshortToBeGreaterThanOrEqualToSmallerValue()
        {
            // Given
            var validator = new NullableUshortValidator(42);

            // When
            validator.BeGreaterThanOrEqualTo(13);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "ushort?.BeGreaterThanOrEqualTo(equalValue)")]
        public void ValidateUshortToBeGreaterThanOrEqualToEqualValue()
        {
            // Given
            var validator = new NullableUshortValidator(42);

            // When
            validator.BeGreaterThanOrEqualTo(42);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "ushort?.BeGreaterThanOrEqualTo(wrongMinimum)")]
        public void ValidateUshortToBeGreaterThanOrEqualToValueViolated()
        {
            // Given
            var validator = new NullableUshortValidator(42);

            // When
            var exception = Assert.Throws<XunitException>(() => validator.BeGreaterThanOrEqualTo(65, "that's the bottom line"));

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is \"42\"{rn}but was expected to be greater than or equal to \"65\"{rn}because that's the bottom line",
                exception.UserMessage);
        }

        [Fact(DisplayName = "ushort?.BeGreaterThanOrEqualTo(wrongMinimum)")]
        public void ValidateNullableUshortToBeGreaterThanOrEqualToValueViolated()
        {
            // Given
            var validator = new NullableUshortValidator(null);

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

        #region ushort?.BeLessThan()

        [Fact(DisplayName = "ushort?.BeLessThan(ushort)")]
        public void ValidateUshortToBeLessThanValue()
        {
            // Given
            var validator = new NullableUshortValidator(42);

            // When
            validator.BeLessThan(65);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "ushort?.BeLessThan(wrongMinimum)")]
        public void ValidateUshortToBeLessThanValueViolated()
        {
            // Given
            var validator = new NullableUshortValidator(42);

            // When
            var exception = Assert.Throws<XunitException>(() => validator.BeLessThan(42, "that's the bottom line"));

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is \"42\"{rn}but was expected to be less than \"42\"{rn}because that's the bottom line",
                exception.UserMessage);
        }

        [Fact(DisplayName = "ushort?.BeLessThan(wrongMinimum)")]
        public void ValidateNullableUshortToBeLessThanValueViolated()
        {
            // Given
            var validator = new NullableUshortValidator(null);

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

        #region ushort?.BeLessThanOrEqualTo()

        [Fact(DisplayName = "ushort?.BeLessThanOrEqualTo(biggerValue)")]
        public void ValidateUshortToBeLessThanOrEqualToBiggerValue()
        {
            // Given
            var validator = new NullableUshortValidator(42);

            // When
            validator.BeLessThanOrEqualTo(65);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "ushort?.BeLessThanOrEqualTo(equalValue)")]
        public void ValidateUshortToBeLessThanOrEqualToEqualValue()
        {
            // Given
            var validator = new NullableUshortValidator(42);

            // When
            validator.BeLessThanOrEqualTo(42);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "ushort?.BeLessThanOrEqualTo(wrongMaximum)")]
        public void ValidateUshortToBeLessThanOrEqualToValueViolated()
        {
            // Given
            var validator = new NullableUshortValidator(42);

            // When
            var exception = Assert.Throws<XunitException>(() => validator.BeLessThanOrEqualTo(13, "that's the bottom line"));

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is \"42\"{rn}but was expected to be less than or equal to \"13\"{rn}because that's the bottom line",
                exception.UserMessage);
        }

        [Fact(DisplayName = "ushort?.BeLessThanOrEqualTo(wrongMaximum)")]
        public void ValidateNullableUshortToBeLessThanOrEqualToValueViolated()
        {
            // Given
            var validator = new NullableUshortValidator(null);

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

        #region ushort?.BeNull()

        [Fact(DisplayName = "ushort?.BeNull()")]
        public void ValidateNullableUshortToBeNull()
        {
            // Given
            var validator = new NullableUshortValidator(null);

            // When
            validator.BeNull();

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "ushort?.BeNull()")]
        public void ValidateNullableUshortToBeNullViolated()
        {
            // Given
            var validator = new NullableUshortValidator(0);

            // When
            var exception = Assert.Throws<XunitException>(() => validator.BeNull());

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is \"0\"{rn}but was expected to be null",
                exception.UserMessage);
        }

        [Fact(DisplayName = "ushort?.BeNull(reason)")]
        public void ValidateNullableToBeNullWithReasonViolated()
        {
            // Given
            var validator = new NullableUshortValidator(0);

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

        #region ushort?.BeOneOf()

        [Fact(DisplayName = "ushort?.BeOneOf(ushort?, ushort?)")]
        public void ValidateUshortToBeOneOfExpectedValues()
        {
            // Given
            var validator = new NullableUshortValidator(42);

            // When
            validator.BeOneOf(new ushort?[] { 10, 42 });

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "ushort?.BeOneOf(ushort?, ushort?)")]
        public void ValidateNullableUshortToBeOneOfExpectedValues()
        {
            // Given
            var validator = new NullableUshortValidator(null);

            // When
            validator.BeOneOf(new ushort?[] { 10, null });

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "ushort?.BeOneOf(other, other)")]
        public void ValidateUshortToBeOneOfViolated()
        {
            // Given
            var validator = new NullableUshortValidator(42);

            // When
            var exception = Assert.Throws<XunitException>(() => validator.BeOneOf(new ushort?[] { 13, 39 }, because: "that's the bottom line"));

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