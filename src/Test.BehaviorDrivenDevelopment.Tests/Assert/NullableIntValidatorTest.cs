namespace CustomCode.Test.BehaviorDrivenDevelopment.Tests
{
    using System;
    using Xunit;
    using Xunit.Sdk;

    /// <summary>
    /// Test cases for the <see cref="NullableIntValidator"/> type.
    /// </summary>
    [UnitTest]
    [Category("Assert", "IntegerValidation")]
    public sealed class NullableIntValidatorTest
    {
        #region int?.Be()

        [Fact(DisplayName = "int?.Be(int?)")]
        public void ValidateIntToBeValue()
        {
            // Given
            var validator = new NullableIntValidator(42);

            // When
            validator.Be(42);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "int?.Be(null)")]
        public void ValidateIntToBeNull()
        {
            // Given
            var validator = new NullableIntValidator(null);

            // When
            validator.Be(null);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "int?.Be(other)")]
        public void ValidateIntToBeValueViolated()
        {
            // Given
            var validator = new NullableIntValidator(42);

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

        #region int?.BeBetween()

        [Fact(DisplayName = "int?.BeBetween(int, int)")]
        public void ValidateIntToBeBetweenValues()
        {
            // Given
            var validator = new NullableIntValidator(42);

            // When
            validator.BeBetween(13, 100);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "int?.BeBetween(wrongMinimum, int)")]
        public void ValidateIntToBeBetweenValuesMinimumViolated()
        {
            // Given
            var validator = new NullableIntValidator(42);

            // When
            var exception = Assert.Throws<XunitException>(() => validator.BeBetween(65, 100, "that's the bottom line"));

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is \"42\"{rn}but was expected to be between \"65\" and \"100\"{rn}because that's the bottom line",
                exception.UserMessage);
        }

        [Fact(DisplayName = "int?.BeBetween(int, wrongMaximum)")]
        public void ValidateIntToBeBetweenValuesMaximumViolated()
        {
            // Given
            var validator = new NullableIntValidator(42);

            // When
            var exception = Assert.Throws<XunitException>(() => validator.BeBetween(13, 39, "that's the bottom line"));

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is \"42\"{rn}but was expected to be between \"13\" and \"39\"{rn}because that's the bottom line",
                exception.UserMessage);
        }

        [Fact(DisplayName = "int?.BeBetween(wrongMinimum, wrongMaximum)")]
        public void ValidateIntToBeBetweenValuesMinimumAndMaximumViolated()
        {
            // Given
            var validator = new NullableIntValidator(42);

            // When
            var exception = Assert.Throws<XunitException>(() => validator.BeBetween(100, 13, "that's the bottom line"));

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is \"42\"{rn}but was expected to be between \"100\" and \"13\"{rn}because that's the bottom line",
                exception.UserMessage);
        }

        [Fact(DisplayName = "int?.BeBetween(wrongMinimum, wrongMaximum)")]
        public void ValidateNullableIntToBeBetweenValuesMinimumAndMaximumViolated()
        {
            // Given
            var validator = new NullableIntValidator(null);

            // When
            var exception = Assert.Throws<XunitException>(() => validator.BeBetween(100, 13, "that's the bottom line"));

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is \"\"{rn}but was expected to be between \"100\" and \"13\"{rn}because that's the bottom line",
                exception.UserMessage);
        }

        #endregion

        #region int?.BeGreaterThan()

        [Fact(DisplayName = "int?.BeGreaterThan(int)")]
        public void ValidateIntToBeGreaterThanValue()
        {
            // Given
            var validator = new NullableIntValidator(42);

            // When
            validator.BeGreaterThan(13);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "int?.BeGreaterThan(wrongMinimum)")]
        public void ValidateIntToBeGreaterThanValueViolated()
        {
            // Given
            var validator = new NullableIntValidator(42);

            // When
            var exception = Assert.Throws<XunitException>(() => validator.BeGreaterThan(42, "that's the bottom line"));

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is \"42\"{rn}but was expected to be greater than \"42\"{rn}because that's the bottom line",
                exception.UserMessage);
        }

        [Fact(DisplayName = "int?.BeGreaterThan(wrongMinimum)")]
        public void ValidateNullableIntToBeGreaterThanValueViolated()
        {
            // Given
            var validator = new NullableIntValidator(null);

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

        #region int?.BeGreaterThanOrEqualTo()

        [Fact(DisplayName = "int?.BeGreaterThanOrEqualTo(smallerValue)")]
        public void ValidateIntToBeGreaterThanOrEqualToSmallerValue()
        {
            // Given
            var validator = new NullableIntValidator(42);

            // When
            validator.BeGreaterThanOrEqualTo(13);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "int?.BeGreaterThanOrEqualTo(equalValue)")]
        public void ValidateIntToBeGreaterThanOrEqualToEqualValue()
        {
            // Given
            var validator = new NullableIntValidator(42);

            // When
            validator.BeGreaterThanOrEqualTo(42);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "int?.BeGreaterThanOrEqualTo(wrongMinimum)")]
        public void ValidateIntToBeGreaterThanOrEqualToValueViolated()
        {
            // Given
            var validator = new NullableIntValidator(42);

            // When
            var exception = Assert.Throws<XunitException>(() => validator.BeGreaterThanOrEqualTo(65, "that's the bottom line"));

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is \"42\"{rn}but was expected to be greater than or equal to \"65\"{rn}because that's the bottom line",
                exception.UserMessage);
        }

        [Fact(DisplayName = "int?.BeGreaterThanOrEqualTo(wrongMinimum)")]
        public void ValidateNullableIntToBeGreaterThanOrEqualToValueViolated()
        {
            // Given
            var validator = new NullableIntValidator(null);

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

        #region int?.BeLessThan()

        [Fact(DisplayName = "int?.BeLessThan(int)")]
        public void ValidateIntToBeLessThanValue()
        {
            // Given
            var validator = new NullableIntValidator(42);

            // When
            validator.BeLessThan(65);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "int?.BeLessThan(wrongMinimum)")]
        public void ValidateIntToBeLessThanValueViolated()
        {
            // Given
            var validator = new NullableIntValidator(42);

            // When
            var exception = Assert.Throws<XunitException>(() => validator.BeLessThan(42, "that's the bottom line"));

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is \"42\"{rn}but was expected to be less than \"42\"{rn}because that's the bottom line",
                exception.UserMessage);
        }

        [Fact(DisplayName = "int?.BeLessThan(wrongMinimum)")]
        public void ValidateNullableIntToBeLessThanValueViolated()
        {
            // Given
            var validator = new NullableIntValidator(null);

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

        #region int?.BeLessThanOrEqualTo()

        [Fact(DisplayName = "int?.BeLessThanOrEqualTo(biggerValue)")]
        public void ValidateIntToBeLessThanOrEqualToBiggerValue()
        {
            // Given
            var validator = new NullableIntValidator(42);

            // When
            validator.BeLessThanOrEqualTo(65);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "int?.BeLessThanOrEqualTo(equalValue)")]
        public void ValidateIntToBeLessThanOrEqualToEqualValue()
        {
            // Given
            var validator = new NullableIntValidator(42);

            // When
            validator.BeLessThanOrEqualTo(42);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "int?.BeLessThanOrEqualTo(wrongMaximum)")]
        public void ValidateIntToBeLessThanOrEqualToValueViolated()
        {
            // Given
            var validator = new NullableIntValidator(42);

            // When
            var exception = Assert.Throws<XunitException>(() => validator.BeLessThanOrEqualTo(13, "that's the bottom line"));

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is \"42\"{rn}but was expected to be less than or equal to \"13\"{rn}because that's the bottom line",
                exception.UserMessage);
        }

        [Fact(DisplayName = "int?.BeLessThanOrEqualTo(wrongMaximum)")]
        public void ValidateNullableIntToBeLessThanOrEqualToValueViolated()
        {
            // Given
            var validator = new NullableIntValidator(null);

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

        #region int?.BeNegative()

        [Fact(DisplayName = "int?.BeNegative()")]
        public void ValidateSByteToBeNegative()
        {
            // Given
            var validator = new NullableIntValidator(-42);

            // When
            validator.BeNegative();

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "int?.BeNegative()")]
        public void ValidateNullableSByteToBeNegativeViolated()
        {
            // Given
            var validator = new NullableIntValidator(null);

            // When
            var exception = Assert.Throws<XunitException>(() => validator.BeNegative(because: "that's the bottom line"));

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is \"\"{rn}but was expected to have a negative value{rn}because that's the bottom line",
                exception.UserMessage);
        }

        [Fact(DisplayName = "int?.BeNegative()")]
        public void ValidateSByteToBeNegativeViolated()
        {
            // Given
            var validator = new NullableIntValidator(0);

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

        #region int?.BeNull()

        [Fact(DisplayName = "int?.BeNull()")]
        public void ValidateNullableIntToBeNull()
        {
            // Given
            var validator = new NullableIntValidator(null);

            // When
            validator.BeNull();

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "int?.BeNull()")]
        public void ValidateNullableIntToBeNullViolated()
        {
            // Given
            var validator = new NullableIntValidator(0);

            // When
            var exception = Assert.Throws<XunitException>(() => validator.BeNull());

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is \"0\"{rn}but was expected to be null",
                exception.UserMessage);
        }

        [Fact(DisplayName = "int?.BeNull(reason)")]
        public void ValidateNullableToBeNullWithReasonViolated()
        {
            // Given
            var validator = new NullableIntValidator(0);

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

        #region int?.BeOneOf()

        [Fact(DisplayName = "int?.BeOneOf(int?, int?)")]
        public void ValidateIntToBeOneOfExpectedValues()
        {
            // Given
            var validator = new NullableIntValidator(42);

            // When
            validator.BeOneOf(new int?[] { 10, 42 });

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "int?.BeOneOf(int?, int?)")]
        public void ValidateNullableIntToBeOneOfExpectedValues()
        {
            // Given
            var validator = new NullableIntValidator(null);

            // When
            validator.BeOneOf(new int?[] { 10, null });

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "int?.BeOneOf(other, other)")]
        public void ValidateIntToBeOneOfViolated()
        {
            // Given
            var validator = new NullableIntValidator(42);

            // When
            var exception = Assert.Throws<XunitException>(() => validator.BeOneOf(new int?[] { 13, 39 }, because: "that's the bottom line"));

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is \"42\"{rn}but was expected to be one of the following values: \"13\", \"39\"{rn}because that's the bottom line",
                exception.UserMessage);
        }

        #endregion

        #region int?.BePositive()

        [Fact(DisplayName = "int?.BePositive()")]
        public void ValidateSByteToBePositive()
        {
            // Given
            var validator = new NullableIntValidator(0);

            // When
            validator.BePositive();

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "int?.BePositive()")]
        public void ValidateNullableSByteToBePositiveViolated()
        {
            // Given
            var validator = new NullableIntValidator(null);

            // When
            var exception = Assert.Throws<XunitException>(() => validator.BePositive(because: "that's the bottom line"));

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is \"\"{rn}but was expected to have a positive value{rn}because that's the bottom line",
                exception.UserMessage);
        }

        [Fact(DisplayName = "int?.BePositive()")]
        public void ValidateSByteToBePositiveViolated()
        {
            // Given
            var validator = new NullableIntValidator(-42);

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