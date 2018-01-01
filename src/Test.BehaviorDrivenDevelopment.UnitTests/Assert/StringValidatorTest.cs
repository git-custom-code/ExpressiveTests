namespace CustomCode.Test.BehaviorDrivenDevelopment.Tests
{
    using System;
    using Xunit;
    using Xunit.Sdk;

    /// <summary>
    /// Test cases for the <see cref="StringValidator"/> type.
    /// </summary>
    public sealed class StringValidatorTest
    {
        #region string.Be()

        [Fact(DisplayName = "string.Be(string)")]
        [UnitTest]
        public void ValidateStringToBeValue()
        {
            var validator = new StringValidator("string");

            validator.Be("string");

            Assert.True(true);
        }

        [Fact(DisplayName = "null.Be(null)")]
        [UnitTest]
        public void ValidateNullStringToBeNull()
        {
            var validator = new StringValidator(null);

            validator.Be(null);

            Assert.True(true);
        }

        [Fact(DisplayName = "string.Be(other)")]
        [UnitTest]
        public void ValidateStringToBeValueViolated()
        {
            var validator = new StringValidator("string");

            var exception = Assert.Throws<XunitException>(() => validator.Be("other", "that's the bottom line"));

            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is \"string\"{rn}but was expected to be \"other\"{rn}because that's the bottom line",
                exception.UserMessage);
        }

        [Fact(DisplayName = "null.Be(other)")]
        [UnitTest]
        public void ValidateNullStringToBeValueViolated()
        {
            var validator = new StringValidator(null);

            var exception = Assert.Throws<XunitException>(() => validator.Be("other"));

            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is \"\"{rn}but was expected to be \"other\"",
                exception.UserMessage);
        }

        [Fact(DisplayName = "string.Be(null)")]
        [UnitTest]
        public void ValidateStringToBeNullViolated()
        {
            var validator = new StringValidator("string");

            var exception = Assert.Throws<XunitException>(() => validator.Be(null));

            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is \"string\"{rn}but was expected to be \"\"",
                exception.UserMessage);
        }

        [Fact(DisplayName = "string.Be(STRING)")]
        [UnitTest]
        public void ValidateStringToBeCaseSensitiveValueViolated()
        {
            var validator = new StringValidator("string");

            var exception = Assert.Throws<XunitException>(() => validator.Be("STRING"));

            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is \"string\"{rn}but was expected to be \"STRING\"",
                exception.UserMessage);
        }

        [Fact(DisplayName = "string.Be(string, ignoreCase: true)")]
        [UnitTest]
        public void ValidateStringToBeCaseInsensitiveValue()
        {
            var validator = new StringValidator("string");

            validator.Be("STRING", ignoreCase: true);

            Assert.True(true);
        }

        #endregion

        #region string.StartWith()

        [Fact(DisplayName = "string.StartWith(str)")]
        [UnitTest]
        public void ValidateStringStartWithValue()
        {
            var validator = new StringValidator("string");

            validator.StartWith("str");

            Assert.True(true);
        }

        [Fact(DisplayName = "string.StartWith(other)")]
        [UnitTest]
        public void ValidateStringStartWithValueViolated()
        {
            var validator = new StringValidator("string");

            var exception = Assert.Throws<XunitException>(() => validator.StartWith("other", "that's the bottom line"));

            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is \"string\"{rn}but was expected to start with \"other\"{rn}because that's the bottom line",
                exception.UserMessage);
        }

        [Fact(DisplayName = "null.StartWith(other)")]
        [UnitTest]
        public void ValidateNullStringStartWithValueViolated()
        {
            var validator = new StringValidator(null);

            var exception = Assert.Throws<XunitException>(() => validator.StartWith("other"));

            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is \"\"{rn}but was expected to start with \"other\"",
                exception.UserMessage);
        }

        [Fact(DisplayName = "string.StartWith(null)")]
        [UnitTest]
        public void ValidateStringStartWithNullViolated()
        {
            var validator = new StringValidator("string");

            var exception = Assert.Throws<XunitException>(() => validator.StartWith(null));

            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is \"string\"{rn}but was expected to start with \"\"",
                exception.UserMessage);
        }

        [Fact(DisplayName = "null.StartWith(null)")]
        [UnitTest]
        public void ValidateNullStringStartWithNullViolated()
        {
            var validator = new StringValidator(null);

            var exception = Assert.Throws<XunitException>(() => validator.StartWith(null));

            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is \"\"{rn}but was expected to start with \"\"",
                exception.UserMessage);
        }

        #endregion

        #region string.EndWith()

        [Fact(DisplayName = "string.EndWith(ing)")]
        [UnitTest]
        public void ValidateStringEndWithValue()
        {
            var validator = new StringValidator("string");

            validator.EndWith("ing");

            Assert.True(true);
        }

        [Fact(DisplayName = "string.EndWith(other)")]
        [UnitTest]
        public void ValidateStringEndWithValueViolated()
        {
            var validator = new StringValidator("string");

            var exception = Assert.Throws<XunitException>(() => validator.EndWith("other", "that's the bottom line"));

            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is \"string\"{rn}but was expected to end with \"other\"{rn}because that's the bottom line",
                exception.UserMessage);
        }

        [Fact(DisplayName = "null.EndWith(other)")]
        [UnitTest]
        public void ValidateNullStringEndWithValueViolated()
        {
            var validator = new StringValidator(null);

            var exception = Assert.Throws<XunitException>(() => validator.EndWith("other"));

            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is \"\"{rn}but was expected to end with \"other\"",
                exception.UserMessage);
        }

        [Fact(DisplayName = "string.EndWith(null)")]
        [UnitTest]
        public void ValidateStringEndWithNullViolated()
        {
            var validator = new StringValidator("string");

            var exception = Assert.Throws<XunitException>(() => validator.EndWith(null));

            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is \"string\"{rn}but was expected to end with \"\"",
                exception.UserMessage);
        }

        [Fact(DisplayName = "null.EndWith(null)")]
        [UnitTest]
        public void ValidateNullStringEndWithNullViolated()
        {
            var validator = new StringValidator(null);

            var exception = Assert.Throws<XunitException>(() => validator.EndWith(null));

            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is \"\"{rn}but was expected to end with \"\"",
                exception.UserMessage);
        }

        #endregion
    }
}