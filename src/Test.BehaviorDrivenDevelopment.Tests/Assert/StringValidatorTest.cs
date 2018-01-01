namespace CustomCode.Test.BehaviorDrivenDevelopment.Tests
{
    using System;
    using Xunit;
    using Xunit.Sdk;

    /// <summary>
    /// Test cases for the <see cref="StringValidator"/> type.
    /// </summary>
    [UnitTest]
    [Category("Assert", "StringValidation")]
    public sealed class StringValidatorTest
    {
        #region string.Be()

        [Fact(DisplayName = "string.Be(string)")]
        public void ValidateStringToBeValue()
        {
            // Given
            var validator = new StringValidator("string");

            // When
            validator.Be("string");

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "null.Be(null)")]
        public void ValidateNullStringToBeNull()
        {
            // Given
            var validator = new StringValidator(null);

            // When
            validator.Be(null);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "string.Be(other)")]
        public void ValidateStringToBeValueViolated()
        {
            // Given
            var validator = new StringValidator("string");

            // When
            var exception = Assert.Throws<XunitException>(() => validator.Be("other", "that's the bottom line"));

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is \"string\"{rn}but was expected to be \"other\"{rn}because that's the bottom line",
                exception.UserMessage);
        }

        [Fact(DisplayName = "null.Be(other)")]
        public void ValidateNullStringToBeValueViolated()
        {
            // Given
            var validator = new StringValidator(null);

            // When
            var exception = Assert.Throws<XunitException>(() => validator.Be("other"));

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is \"\"{rn}but was expected to be \"other\"",
                exception.UserMessage);
        }

        [Fact(DisplayName = "string.Be(null)")]
        public void ValidateStringToBeNullViolated()
        {
            // Given
            var validator = new StringValidator("string");

            // When
            var exception = Assert.Throws<XunitException>(() => validator.Be(null));

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is \"string\"{rn}but was expected to be \"\"",
                exception.UserMessage);
        }

        [Fact(DisplayName = "string.Be(STRING)")]
        public void ValidateStringToBeCaseSensitiveValueViolated()
        {
            // Given
            var validator = new StringValidator("string");

            // When
            var exception = Assert.Throws<XunitException>(() => validator.Be("STRING"));

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is \"string\"{rn}but was expected to be \"STRING\"",
                exception.UserMessage);
        }

        [Fact(DisplayName = "string.Be(string, ignoreCase: true)")]
        public void ValidateStringToBeCaseInsensitiveValue()
        {
            // Given
            var validator = new StringValidator("string");

            // When
            validator.Be("STRING", ignoreCase: true);

            // Then
            Assert.True(true);
        }

        #endregion

        #region string.StartWith()

        [Fact(DisplayName = "string.StartWith(str)")]
        public void ValidateStringStartWithValue()
        {
            // Given
            var validator = new StringValidator("string");

            // When
            validator.StartWith("str");

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "string.StartWith(other)")]
        public void ValidateStringStartWithValueViolated()
        {
            // Given
            var validator = new StringValidator("string");

            // When
            var exception = Assert.Throws<XunitException>(() => validator.StartWith("other", "that's the bottom line"));

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is \"string\"{rn}but was expected to start with \"other\"{rn}because that's the bottom line",
                exception.UserMessage);
        }

        [Fact(DisplayName = "null.StartWith(other)")]
        public void ValidateNullStringStartWithValueViolated()
        {
            // Given
            var validator = new StringValidator(null);

            // When
            var exception = Assert.Throws<XunitException>(() => validator.StartWith("other"));

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is \"\"{rn}but was expected to start with \"other\"",
                exception.UserMessage);
        }

        [Fact(DisplayName = "string.StartWith(null)")]
        public void ValidateStringStartWithNullViolated()
        {
            // Given
            var validator = new StringValidator("string");

            // When
            var exception = Assert.Throws<XunitException>(() => validator.StartWith(null));

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is \"string\"{rn}but was expected to start with \"\"",
                exception.UserMessage);
        }

        [Fact(DisplayName = "null.StartWith(null)")]
        public void ValidateNullStringStartWithNullViolated()
        {
            // Given
            var validator = new StringValidator(null);

            // When
            var exception = Assert.Throws<XunitException>(() => validator.StartWith(null));

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is \"\"{rn}but was expected to start with \"\"",
                exception.UserMessage);
        }

        #endregion

        #region string.EndWith()

        [Fact(DisplayName = "string.EndWith(ing)")]
        public void ValidateStringEndWithValue()
        {
            // Given
            var validator = new StringValidator("string");

            // When
            validator.EndWith("ing");

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "string.EndWith(other)")]
        public void ValidateStringEndWithValueViolated()
        {
            // Given
            var validator = new StringValidator("string");

            // When
            var exception = Assert.Throws<XunitException>(() => validator.EndWith("other", "that's the bottom line"));

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is \"string\"{rn}but was expected to end with \"other\"{rn}because that's the bottom line",
                exception.UserMessage);
        }

        [Fact(DisplayName = "null.EndWith(other)")]
        public void ValidateNullStringEndWithValueViolated()
        {
            // Given
            var validator = new StringValidator(null);

            // When
            var exception = Assert.Throws<XunitException>(() => validator.EndWith("other"));

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is \"\"{rn}but was expected to end with \"other\"",
                exception.UserMessage);
        }

        [Fact(DisplayName = "string.EndWith(null)")]
        public void ValidateStringEndWithNullViolated()
        {
            // Given
            var validator = new StringValidator("string");

            // When
            var exception = Assert.Throws<XunitException>(() => validator.EndWith(null));

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is \"string\"{rn}but was expected to end with \"\"",
                exception.UserMessage);
        }

        [Fact(DisplayName = "null.EndWith(null)")]
        public void ValidateNullStringEndWithNullViolated()
        {
            // Given
            var validator = new StringValidator(null);

            // When
            var exception = Assert.Throws<XunitException>(() => validator.EndWith(null));

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is \"\"{rn}but was expected to end with \"\"",
                exception.UserMessage);
        }

        #endregion
    }
}