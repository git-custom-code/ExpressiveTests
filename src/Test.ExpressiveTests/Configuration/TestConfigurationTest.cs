namespace Test.ExpressiveTests.Configuration
{
    using global::ExpressiveTests;
    using global::ExpressiveTests.Configuration;
    using System;
    using Xunit;
    using Xunit.Sdk;

    /// <summary>
    /// Test cases for the <see cref="TestConfiguration"/> type.
    /// </summary>
    public sealed class TestConfigurationTest
    {
        /// <summary>
        /// Mock for the <see cref="ICallerContext"/> interface.
        /// </summary>
        public sealed class MockContext : ICallerContext
        {
            public string GetCallerContext<T>(T expected, string testMethodName, string validationMethodName, int lineNumber, string sourceCodePath)
            {
                return "MockContext";
            }
        }

        /// <summary>
        /// Mock for the <see cref="IMessageFormatter"/> interface.
        /// </summary>
        public sealed class MockFormatter : IMessageFormatter
        {
            public string FormatMessage(string context, string actualValue, string expectation, string reason)
            {
                return "MockMessage";
            }
        }

        [Fact(DisplayName = "Override caller context")]
        [Trait("Category", "Configuration")]
        public void OverrideCallerContextSuccess()
        {
            // Given

            // When
            TestConfiguration.CallerContext = new MockContext();
            var validator = new StringValidator("foo"); // use a StringValidator here as one implementation of a ContextValidator
            var exception = Assert.Throws<XunitException>(() => validator.Be("bar"));

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal($"{rn}MockContext{rn}is \"foo\"{rn}but was expected to be \"bar\"", exception.Message);
        }

        [Fact(DisplayName = "Override message formatter")]
        [Trait("Category", "Configuration")]
        public void OverrideMessageFormatterSuccess()
        {
            // Given

            // When
            TestConfiguration.MessageFormatter = new MockFormatter();
            var validator = new StringValidator("foo"); // use a StringValidator here as one implementation of a ContextValidator
            var exception = Assert.Throws<XunitException>(() => validator.Be("bar"));

            // Then
            Assert.NotNull(exception);
            Assert.Equal("MockMessage", exception.Message);
        }

        [Fact(DisplayName = "Reset caller context to default")]
        [Trait("Category", "Configuration")]
        public void ResetCallerContextSuccess()
        {
            // Given

            // When
            TestConfiguration.CallerContext = null;
            var callerContext = TestConfiguration.CallerContext;

            // Then
            Assert.NotNull(callerContext);
            Assert.IsType<RoslynCallerContext>(callerContext);
        }

        [Fact(DisplayName = "Reset message formatter to default")]
        [Trait("Category", "Configuration")]
        public void ResetMessageFormatterSuccess()
        {
            // Given

            // When
            TestConfiguration.MessageFormatter = null;
            var formatter = TestConfiguration.MessageFormatter;

            // Then
            Assert.NotNull(formatter);
            Assert.IsType<MessageFormatter>(formatter);
        }
    }
}