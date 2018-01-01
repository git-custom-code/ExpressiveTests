namespace CustomCode.Test.BehaviorDrivenDevelopment.Configuration.Tests
{
    using System;
    using Xunit;
    using Xunit.Sdk;

    /// <summary>
    /// Test cases for the <see cref="TestConfiguration"/> type.
    /// </summary>
    [UnitTest]
    [Category("Configuration")]
    public sealed class TestConfigurationTest
    {
        #region Mockup

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

        #endregion

        [Fact(DisplayName = "Override caller context")]
        public void OverrideCallerContextSuccess()
        {
            // Given

            // When
            TestConfiguration.SetCallerContextFor(nameof(TestConfigurationTest.OverrideCallerContextSuccess), new MockContext());
            var validator = new StringValidator("foo"); // use a StringValidator here as one implementation of a ContextValidator
            var exception = Assert.Throws<XunitException>(() => validator.Be("bar"));

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal($"{rn}MockContext{rn}is \"foo\"{rn}but was expected to be \"bar\"", exception.Message);
        }

        [Fact(DisplayName = "Override message formatter")]
        public void OverrideMessageFormatterSuccess()
        {
            // Given

            // When
            TestConfiguration.SetMessageFormatterFor(nameof(TestConfigurationTest.OverrideMessageFormatterSuccess), new MockFormatter());
            var validator = new StringValidator("foo"); // use a StringValidator here as one implementation of a ContextValidator
            var exception = Assert.Throws<XunitException>(() => validator.Be("bar"));

            // Then
            Assert.NotNull(exception);
            Assert.Equal("MockMessage", exception.Message);
        }

        [Fact(DisplayName = "Reset caller context to default")]
        public void ResetCallerContextSuccess()
        {
            // Given

            // When
            TestConfiguration.ResetCallerContextFor(nameof(TestConfigurationTest.ResetCallerContextSuccess));
            var callerContext = TestConfiguration.GetCallerContextFor(nameof(TestConfigurationTest.ResetCallerContextSuccess));

            // Then
            Assert.NotNull(callerContext);
            Assert.IsType<RoslynCallerContext>(callerContext);
        }

        [Fact(DisplayName = "Reset message formatter to default")]
        public void ResetMessageFormatterSuccess()
        {
            // Given

            // When
            TestConfiguration.ResetMessageFormatterFor(nameof(TestConfigurationTest.ResetMessageFormatterSuccess));
            var formatter = TestConfiguration.GetMessageFormatterFor(nameof(TestConfigurationTest.ResetMessageFormatterSuccess));

            // Then
            Assert.NotNull(formatter);
            Assert.IsType<MessageFormatter>(formatter);
        }
    }
}