namespace CustomCode.Test.BehaviorDrivenDevelopment.Tests
{
    using System;
    using Xunit;
    using Xunit.Sdk;

    /// <summary>
    /// Test cases for the <see cref="NullableSbyteInverseValidator"/> type.
    /// </summary>
    [UnitTest]
    [Category("Assert", "SByteValidation")]
    public sealed class NullableSbyteInverseValidatorTest
    {
        #region sbyte?.NotBe()

        [Fact(DisplayName = "sbyte?.NotBe(sbyte?)")]
        public void ValidateSbyteNotToBeValue()
        {
            // Given
            var validator = new NullableSbyteInverseValidator(42);

            // When
            validator.Be(13);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "sbyte?.NotBe(null)")]
        public void ValidateSbyteNotToBeNull()
        {
            // Given
            var validator = new NullableSbyteInverseValidator(42);

            // When
            validator.Be(null);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "sbyte?.NotBe(other)")]
        public void ValidateSbyteNotToBeValueViolated()
        {
            // Given
            var validator = new NullableSbyteInverseValidator(42);

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

        #region sbyte?.NotBeBetween()

        [Fact(DisplayName = "sbyte?.NotBeBetween(sbyte, sbyte)")]
        public void ValidateSbyteToNotBeBetweenSmallerValues()
        {
            // Given
            var validator = new NullableSbyteInverseValidator(42);

            // When
            validator.BeBetween(13, 39);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "sbyte?.NotBeBetween(sbyte, sbyte)")]
        public void ValidateSbyteToNotBeBetweenBiggerValues()
        {
            // Given
            var validator = new NullableSbyteInverseValidator(42);

            // When
            validator.BeBetween(65, 100);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "sbyte?.NotBeBetween(sbyte, sbyte)")]
        public void ValidateNullableSbyteToNotBeBetweenValues()
        {
            // Given
            var validator = new NullableSbyteInverseValidator(null);

            // When
            validator.BeBetween(65, 100);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "sbyte?.BeBetween(wrongMinimum, wrongMaximum)")]
        public void ValidateSbyteToBeBetweenValuesMinimumAndMaximumViolated()
        {
            // Given
            var validator = new NullableSbyteInverseValidator(42);

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

        #region sbyte?.NotBeGreaterThan()

        [Fact(DisplayName = "sbyte?.NotBeGreaterThan(equalValue)")]
        public void ValidateSbyteToBeGreaterThanEqualValue()
        {
            // Given
            var validator = new NullableSbyteInverseValidator(42);

            // When
            validator.BeGreaterThan(42);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "sbyte?.NotBeGreaterThan(biggerValue)")]
        public void ValidateSbyteToNotBeGreaterThanBiggerValue()
        {
            // Given
            var validator = new NullableSbyteInverseValidator(42);

            // When
            validator.BeGreaterThan(65);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "sbyte?.NotBeGreaterThan(biggerValue)")]
        public void ValidateNullableSbyteToNotBeGreaterThanBiggerValue()
        {
            // Given
            var validator = new NullableSbyteInverseValidator(null);

            // When
            validator.BeGreaterThan(65);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "sbyte?.NotBeGreaterThan(wrongMinimum)")]
        public void ValidateSbyteToNotBeGreaterThanValueViolated()
        {
            // Given
            var validator = new NullableSbyteInverseValidator(42);

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

        #region sbyte?.NotBeGreaterThanOrEqualTo()

        [Fact(DisplayName = "sbyte?.NotBeGreaterThanOrEqualTo(sbyte)")]
        public void ValidateSbyteNotToBeGreaterThanOrEqualToValue()
        {
            // Given
            var validator = new NullableSbyteInverseValidator(42);

            // When
            validator.BeGreaterThanOrEqualTo(65);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "sbyte?.NotBeGreaterThanOrEqualTo(sbyte)")]
        public void ValidateNullableSbyteNotToBeGreaterThanOrEqualToValue()
        {
            // Given
            var validator = new NullableSbyteInverseValidator(null);

            // When
            validator.BeGreaterThanOrEqualTo(65);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "sbyte?.NotBeGreaterThanOrEqualTo(wrongMinimum)")]
        public void ValidateSbyteNotToBeGreaterThanOrEqualToValueViolated()
        {
            // Given
            var validator = new NullableSbyteInverseValidator(42);

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

        #region sbyte?.NotBeLessThan()

        [Fact(DisplayName = "sbyte?.NotBeLessThan(equalValue)")]
        public void ValidateSbyteToBeLessThanEqualValue()
        {
            // Given
            var validator = new NullableSbyteInverseValidator(42);

            // When
            validator.BeLessThan(42);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "sbyte?.NotBeLessThan(biggerValue)")]
        public void ValidateSbyteToNotBeLessThanBiggerValue()
        {
            // Given
            var validator = new NullableSbyteInverseValidator(42);

            // When
            validator.BeLessThan(13);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "sbyte?.NotBeLessThan(biggerValue)")]
        public void ValidateNullableSbyteToNotBeLessThanBiggerValue()
        {
            // Given
            var validator = new NullableSbyteInverseValidator(null);

            // When
            validator.BeLessThan(13);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "sbyte?.NotBeLessThan(wrongMaximum)")]
        public void ValidateSbyteToNotBeLessThanValueViolated()
        {
            // Given
            var validator = new NullableSbyteInverseValidator(42);

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

        #region sbyte?.NotBeLessThanOrEqualTo()

        [Fact(DisplayName = "sbyte?.NotBeLessThanOrEqualTo(sbyte)")]
        public void ValidateSbyteNotToBeLessThanOrEqualToValue()
        {
            // Given
            var validator = new NullableSbyteInverseValidator(42);

            // When
            validator.BeLessThanOrEqualTo(13);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "sbyte?.NotBeLessThanOrEqualTo(sbyte)")]
        public void ValidateNullableSbyteNotToBeLessThanOrEqualToValue()
        {
            // Given
            var validator = new NullableSbyteInverseValidator(null);

            // When
            validator.BeLessThanOrEqualTo(13);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "sbyte?.NotBeLessThanOrEqualTo(wrongMinimum)")]
        public void ValidateSbyteNotToBeLessThanOrEqualToValueViolated()
        {
            // Given
            var validator = new NullableSbyteInverseValidator(42);

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

        #region sbyte?.NotBeNegative()

        [Fact(DisplayName = "sbyte?.NotBeNegative()")]
        public void ValidateSByteNotToBeNegative()
        {
            // Given
            var validator = new NullableSbyteInverseValidator(0);

            // When
            validator.BeNegative();

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "sbyte?.NotBeNegative()")]
        public void ValidateNullableSByteNotToBeNegative()
        {
            // Given
            var validator = new NullableSbyteInverseValidator(null);

            // When
            validator.BeNegative();

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "sbyte?.NotBeNegative()")]
        public void ValidateSByteNotToBeNegativeViolated()
        {
            // Given
            var validator = new NullableSbyteInverseValidator(-42);

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

        #region sbyte?.BeNull()

        [Fact(DisplayName = "sbyte?.NotBeNull()")]
        public void ValidateNullableSbyteNotToBeNull()
        {
            // Given
            var validator = new NullableSbyteInverseValidator(0);

            // When
            validator.BeNull();

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "sbyte?.NotBeNull()")]
        public void ValidateNullableSbyteNotToBeNullViolated()
        {
            // Given
            var validator = new NullableSbyteInverseValidator(null);

            // When
            var exception = Assert.Throws<XunitException>(() => validator.BeNull());

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is null{rn}but was expected not to be null",
                exception.UserMessage);
        }

        [Fact(DisplayName = "sbyte?.NotBeNull(reason)")]
        public void ValidateNullableSbyteNotToBeNullWithReasonViolated()
        {
            // Given
            var validator = new NullableSbyteInverseValidator(null);

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

        #region sbyte?.NotBeOneOf()

        [Fact(DisplayName = "sbyte?.NotBeOneOf(other, other)")]
        public void ValidateSbyteNotToBeOneOfExpectedValues()
        {
            // Given
            var validator = new NullableSbyteInverseValidator(42);

            // When
            validator.BeOneOf(new sbyte?[] { 10, 39 });

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "sbyte?.NotBeOneOf(sbyte?, sbyte?)")]
        public void ValidateSbyteNotToBeOneOfViolated()
        {
            // Given
            var validator = new NullableSbyteInverseValidator(42);

            // When
            var exception = Assert.Throws<XunitException>(() => validator.BeOneOf(new sbyte?[] { 13, 42 }, because: "that's the bottom line"));

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is \"42\"{rn}but was expected not to be one of the following values: \"13\", \"42\"{rn}because that's the bottom line",
                exception.UserMessage);
        }

        [Fact(DisplayName = "sbyte?.NotBeOneOf(sbyte?, sbyte?)")]
        public void ValidateNullableSbyteNotToBeOneOfViolated()
        {
            // Given
            var validator = new NullableSbyteInverseValidator(null);

            // When
            var exception = Assert.Throws<XunitException>(() => validator.BeOneOf(new sbyte?[] { null, 42 }, because: "that's the bottom line"));

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is \"\"{rn}but was expected not to be one of the following values: \"\", \"42\"{rn}because that's the bottom line",
                exception.UserMessage);
        }

        #endregion

        #region sbyte?.NotBePositive()

        [Fact(DisplayName = "sbyte?.NotBePositive()")]
        public void ValidateSByteToBePositive()
        {
            // Given
            var validator = new NullableSbyteInverseValidator(-42);

            // When
            validator.BePositive();

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "sbyte?.NotBePositive()")]
        public void ValidateNullableSByteToBePositive()
        {
            // Given
            var validator = new NullableSbyteInverseValidator(null);

            // When
            validator.BePositive();

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "sbyte?.NotBePositive()")]
        public void ValidateSByteNotToBePositiveViolated()
        {
            // Given
            var validator = new NullableSbyteInverseValidator(0);

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