namespace CustomCode.Test.BehaviorDrivenDevelopment.Tests
{
    using System;
    using Xunit;
    using Xunit.Sdk;

    /// <summary>
    /// Test cases for the <see cref="StringInverseValidator"/> type.
    /// </summary>
    [UnitTest]
    [Category("Assert", "StringValidation")]
    public sealed class StringInverseValidatorTest
    {
        #region string.NotBe()

        [Fact(DisplayName = "string.NotBe(other)")]
        public void ValidateStringNotToBeValue()
        {
            // Given
            var validator = new StringInverseValidator("string");

            // When
            validator.Be("other");

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "null.NotBe(string)")]
        public void ValidateNullStringNotToBeValue()
        {
            // Given
            var validator = new StringInverseValidator(null);

            // When
            validator.Be("string");

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "string.NotBe(string)")]
        public void ValidateStringNotToBeValueViolated()
        {
            // Given
            var validator = new StringInverseValidator("string");

            // When
            var exception = Assert.Throws<XunitException>(() => validator.Be("string", "that's the bottom line"));

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is \"string\"{rn}but was expected not to be \"string\"{rn}because that's the bottom line",
                exception.UserMessage);
        }

        [Fact(DisplayName = "null.NotBe(null)")]
        public void ValidateNullStringNotToBeValueViolated()
        {
            // Given
            var validator = new StringInverseValidator(null);

            // When
            var exception = Assert.Throws<XunitException>(() => validator.Be(null));

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is \"\"{rn}but was expected not to be \"\"",
                exception.UserMessage);
        }

        [Fact(DisplayName = "string.NotBe(null)")]
        public void ValidateStringNotToBeNullValue()
        {
            // Given
            var validator = new StringInverseValidator("string");

            // When
            validator.Be(null);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "string.NotBe(STRING)")]
        public void ValidateStringNotToBeCaseSensitiveValue()
        {
            // Given
            var validator = new StringInverseValidator("string");

            // When
            validator.Be("STRING");

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "string.NotBe(STRING, ignoreCase: true)")]
        public void ValidateStringNotToBeCaseInsensitiveValue()
        {
            // Given
            var validator = new StringInverseValidator("string");

            // When
            var exception = Assert.Throws<XunitException>(() => validator.Be("STRING", ignoreCase: true));

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is \"string\"{rn}but was expected not to be \"STRING\"",
                exception.UserMessage);
        }

        #endregion

        #region string.NotBeEmpty()

        [Fact(DisplayName = "string.NotBeEmpty()")]
        public void ValidateStringNotToBeEmpty()
        {
            // Given
            var validator = new StringInverseValidator("string");

            // When
            validator.BeEmpty();

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "empty.NotBeEmpty()")]
        public void ValidateStringNotToBeEmptyViolated()
        {
            // Given
            var validator = new StringInverseValidator(string.Empty);

            // When
            var exception = Assert.Throws<XunitException>(() => validator.BeEmpty(because: "that's the bottom line"));

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is \"\"{rn}but was expected not to be empty{rn}because that's the bottom line",
                exception.UserMessage);
        }

        #endregion

        #region string.NotBeNull()

        [Fact(DisplayName = "string.NotBeNull()")]
        public void ValidateStringNotToBeNull()
        {
            // Given
            var validator = new StringInverseValidator("string");

            // When
            validator.BeNull();

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "null.NotBeNull()")]
        public void ValidateStringNotToBeNullViolated()
        {
            // Given
            var validator = new StringInverseValidator(null);

            // When
            var exception = Assert.Throws<XunitException>(() => validator.BeNull(because: "that's the bottom line"));

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is \"\"{rn}but was expected not to be null{rn}because that's the bottom line",
                exception.UserMessage);
        }

        #endregion

        #region string.NotBeNullOrEmpty()

        [Fact(DisplayName = "string.NotBeNullOrEmpty()")]
        public void ValidateStringNotToBeNullOrEmpty()
        {
            // Given
            var validator = new StringInverseValidator("string");

            // When
            validator.BeNullOrEmpty();

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "empty.NotBeNullOrEmpty()")]
        public void ValidateEmptyStringNotToBeNullOrEmptyValidated()
        {
            // Given
            var validator = new StringInverseValidator(string.Empty);

            // When
            var exception = Assert.Throws<XunitException>(() => validator.BeNullOrEmpty(because: "that's the bottom line"));

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is \"\"{rn}but was expected not to be null or empty{rn}because that's the bottom line",
                exception.UserMessage);
        }

        [Fact(DisplayName = "null.NotBeNullOrEmpty()")]
        public void ValidateNullStringNotToBeNullOrEmptyViolated()
        {
            // Given
            var validator = new StringInverseValidator(null);

            // When
            var exception = Assert.Throws<XunitException>(() => validator.BeNullOrEmpty(because: "that's the bottom line"));

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is \"\"{rn}but was expected not to be null or empty{rn}because that's the bottom line",
                exception.UserMessage);
        }

        #endregion

        #region string.NotContain()

        [Fact(DisplayName = "string.NotContain(other)")]
        public void ValidateStringNotContainsValue()
        {
            // Given
            var validator = new StringInverseValidator("string");

            // When
            validator.Contain("other");

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "string.NotContain(str)")]
        public void ValidateStringNotContainsStartValueViolated()
        {
            // Given
            var validator = new StringInverseValidator("string");

            // When
            var exception = Assert.Throws<XunitException>(() => validator.Contain("str", "that's the bottom line"));

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is \"string\"{rn}but was expected to not contain \"str\"{rn}because that's the bottom line",
                exception.UserMessage);
        }

        [Fact(DisplayName = "string.NotContain(ing)")]
        public void ValidateStringNotContainsEndValueViolated()
        {

            // Given
            var validator = new StringInverseValidator("string");

            // When
            var exception = Assert.Throws<XunitException>(() => validator.Contain("ing", "that's the bottom line"));

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is \"string\"{rn}but was expected to not contain \"ing\"{rn}because that's the bottom line",
                exception.UserMessage);
        }

        [Fact(DisplayName = "string.NotContain(TRI, ignoreCase)")]
        public void ValidateStringNotContainsValueIgnoreCaseViolated()
        {

            // Given
            var validator = new StringInverseValidator("string");

            // When
            var exception = Assert.Throws<XunitException>(() => validator.Contain("ING", ignoreCase: true, because: "that's the bottom line"));

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is \"string\"{rn}but was expected to not contain \"ING\"{rn}because that's the bottom line",
                exception.UserMessage);
        }

        [Fact(DisplayName = "string.NotContain(string)")]
        public void ValidateStringNotContainsValueViolated()
        {
            // Given
            var validator = new StringInverseValidator("string");

            // When
            var exception = Assert.Throws<XunitException>(() => validator.Contain("string", "that's the bottom line"));

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is \"string\"{rn}but was expected to not contain \"string\"{rn}because that's the bottom line",
                exception.UserMessage);
        }

        #endregion

        #region string.NotEndWith()

        [Fact(DisplayName = "string.NotEndWith(other)")]
        public void ValidateStringNotEndsWithValue()
        {
            // Given
            var validator = new StringInverseValidator("string");

            // When
            validator.EndWith("other");

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "string.NotEndWith(string)")]
        public void ValidateStringNotEndsWithValueViolated()
        {
            // Given
            var validator = new StringInverseValidator("string");

            // When
            var exception = Assert.Throws<XunitException>(() => validator.EndWith("string", "that's the bottom line"));

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is \"string\"{rn}but was expected not to end with \"string\"{rn}because that's the bottom line",
                exception.UserMessage);
        }

        [Fact(DisplayName = "null.NotEndWith(other)")]
        public void ValidateNullStringNotEndsWithValue()
        {
            // Given
            var validator = new StringInverseValidator(null);

            // When
            validator.EndWith("other");

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "string.NotEndWith(null)")]
        public void ValidateStringNotEndsWithNull()
        {
            // Given
            var validator = new StringInverseValidator("string");

            // When
            validator.EndWith(null);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "null.NotEndsWith(null)")]
        public void ValidateNullStringNotEndsWithNullViolated()
        {
            // Given
            var validator = new StringInverseValidator(null);

            // When
            var exception = Assert.Throws<XunitException>(() => validator.EndWith(null));

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is \"\"{rn}but was expected not to end with \"\"",
                exception.UserMessage);
        }

        #endregion

        #region string.NotMatch()

        [Fact(DisplayName = "string.NotMatch(string)")]
        public void ValidateStringNotMatchesValueViolated()
        {
            // Given
            var validator = new StringInverseValidator("string");

            // When
            var exception = Assert.Throws<XunitException>(() => validator.Match("string", "that's the bottom line"));

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is \"string\"{rn}but was expected to not match pattern \"string\"{rn}because that's the bottom line",
                exception.UserMessage);
        }

        [Fact(DisplayName = "string.NotMatch(st*ng)")]
        public void ValidateStringNotMatchesWildcardValueViolated()
        {
            // Given
            var validator = new StringInverseValidator("string");

            // When
            var exception = Assert.Throws<XunitException>(() => validator.Match("st*ng", "that's the bottom line"));

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is \"string\"{rn}but was expected to not match pattern \"st*ng\"{rn}because that's the bottom line",
                exception.UserMessage);
        }

        [Fact(DisplayName = "string.NotMatch(sT*Ng)")]
        public void ValidateStringNotMatchesWildcardIgnoreCaseValueViolated()
        {
            // Given
            var validator = new StringInverseValidator("string");

            // When
            var exception = Assert.Throws<XunitException>(() => validator.Match("sT*Ng", ignoreCase: true, because: "that's the bottom line"));

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is \"string\"{rn}but was expected to not match pattern \"sT*Ng\"{rn}because that's the bottom line",
                exception.UserMessage);
        }

        [Fact(DisplayName = "string.NotMatch(other)")]
        public void ValidateStringNotMatchesValue()
        {
            // Given
            var validator = new StringInverseValidator("string");

            // When
            validator.Match("other");

            // Then
            Assert.True(true);
        }

        #endregion

        #region string.NotMatchRegex()

        [Fact(DisplayName = "string.NotMatchRegex(string)")]
        public void ValidateStringNotMatchesRegexViolated()
        {
            // Given
            var validator = new StringInverseValidator("string");

            // When
            var exception = Assert.Throws<XunitException>(() => validator.MatchRegex("string", "that's the bottom line"));

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is \"string\"{rn}but was expected to not match regular expression \"string\"{rn}because that's the bottom line",
                exception.UserMessage);
        }

        [Fact(DisplayName = "string.NotMatchRegex(.*)")]
        public void ValidateStringNotMatchesRegexPatternViolated()
        {

            // Given
            var validator = new StringInverseValidator("string");

            // When
            var exception = Assert.Throws<XunitException>(() => validator.MatchRegex(".*", "that's the bottom line"));

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is \"string\"{rn}but was expected to not match regular expression \".*\"{rn}because that's the bottom line",
                exception.UserMessage);
        }

        [Fact(DisplayName = "string.NotMatchRegex(^.$)")]
        public void ValidateStringNotMatchesRegex()
        {
            // Given
            var validator = new StringInverseValidator("string");

            // When
            validator.MatchRegex("^.$");

            // Then
            Assert.True(true);
        }

        #endregion

        #region string.NotStartWith()

        [Fact(DisplayName = "string.NotStartWith(other)")]
        public void ValidateStringNotStartsWithValue()
        {
            // Given
            var validator = new StringInverseValidator("string");

            // When
            validator.StartWith("other");

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "string.NotStartWith(string)")]
        public void ValidateStringNotStartsWithValueViolated()
        {
            // Given
            var validator = new StringInverseValidator("string");

            // When
            var exception = Assert.Throws<XunitException>(() => validator.StartWith("string", "that's the bottom line"));

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is \"string\"{rn}but was expected not to start with \"string\"{rn}because that's the bottom line",
                exception.UserMessage);
        }

        [Fact(DisplayName = "null.NotStartWith(other)")]
        public void ValidateNullStringNotStartsWithValue()
        {
            // Given
            var validator = new StringInverseValidator(null);

            // When
            validator.StartWith("other");

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "string.NotStartWith(null)")]
        public void ValidateStringNotStartsWithNull()
        {
            // Given
            var validator = new StringInverseValidator("string");

            // When
            validator.StartWith(null);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "null.NotStartWith(null)")]
        public void ValidateNullStringNotStartsWithNullViolated()
        {
            // Given
            var validator = new StringInverseValidator(null);

            // When
            var exception = Assert.Throws<XunitException>(() => validator.StartWith(null));

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is \"\"{rn}but was expected not to start with \"\"",
                exception.UserMessage);
        }

        #endregion
    }
}