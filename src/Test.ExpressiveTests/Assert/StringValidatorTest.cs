namespace Test.ExpressiveTests
{
    using global::ExpressiveTests;
    using System;
    using Xunit;
    using Xunit.Sdk;

    public class StringValidatorTest
    {
        #region string.Be()

        [Fact(DisplayName = "string.Be(string)")]
        public void ValidateStringToBeValue()
        {
            var validator = new StringValidator("string");

            validator.Be("string");

            Assert.True(true);
        }

        [Fact(DisplayName = "string.Be(string)")]
        public void ValidateNullStringToBeNull()
        {
            var validator = new StringValidator(null);

            validator.Be(null);

            Assert.True(true);
        }

        [Fact(DisplayName = "string.Be(other)")]
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

        #endregion

        #region string.StartWith()

        [Fact(DisplayName = "string.StartWith(str)")]
        public void ValidateStringStartWithValue()
        {
            var validator = new StringValidator("string");

            validator.StartWith("str");

            Assert.True(true);
        }

        [Fact(DisplayName = "string.StartWith(other)")]
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
        public void ValidateStringEndWithValue()
        {
            var validator = new StringValidator("string");

            validator.EndWith("ing");

            Assert.True(true);
        }

        [Fact(DisplayName = "string.EndWith(other)")]
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