namespace CustomCode.Test.BehaviorDrivenDevelopment
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Xunit.Abstractions;
    using Xunit.Sdk;

    /// <summary>
    /// Implementation of an <see cref="IXunitTestCaseDiscoverer"/> for the <see cref="ScenarioAttribute"/>.
    /// </summary>
    public sealed class ScenarioAttributeDiscoverer : IXunitTestCaseDiscoverer
    {
        #region Dependencies

        /// <summary>
        /// Creates a new instance of the <see cref="ScenarioAttributeDiscoverer"/> type.
        /// </summary>
        /// <param name="diagnosticMessageSink"> The message sink used to send diagnostic messages. </param>
        public ScenarioAttributeDiscoverer(IMessageSink diagnosticMessageSink)
        {
            DecoratedDiscoverer = new FactDiscoverer(diagnosticMessageSink);
            MessageSink = diagnosticMessageSink ?? throw new ArgumentNullException(nameof(diagnosticMessageSink));
        }

        /// <summary>
        /// Gets the message sink used to send diagnostic messages.
        /// </summary>
        private IMessageSink MessageSink { get; }

        #endregion

        #region Data

        /// <summary>
        /// Gets the decorated <see cref="FactDiscoverer"/> that is used internally.
        /// </summary>
        private FactDiscoverer DecoratedDiscoverer { get; }

        #endregion

        #region Logic

        /// <inheritdoc />
        public IEnumerable<IXunitTestCase> Discover(
            ITestFrameworkDiscoveryOptions discoveryOptions,
            ITestMethod testMethod,
            IAttributeInfo factAttribute)
        {
            var testCases = DecoratedDiscoverer.Discover(discoveryOptions, testMethod, factAttribute);
            if (testCases.FirstOrDefault() is ExecutionErrorTestCase)
            {
                return testCases;
            }

            var enableOutput = factAttribute.GetNamedArgument<bool>(nameof(ScenarioAttribute.EnableOutput));
            var scenario = new Scenario(
                MessageSink,
                discoveryOptions.MethodDisplayOrDefault(),
                discoveryOptions.MethodDisplayOptionsOrDefault(),
                testMethod,
                enableOutput);
            return new IXunitTestCase[1] { scenario };
        }

        #endregion
    }
}