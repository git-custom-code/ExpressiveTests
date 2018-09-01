namespace CustomCode.Test.BehaviorDrivenDevelopment
{
    using Synchronization;
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Threading;
    using System.Threading.Tasks;
    using Xunit.Abstractions;
    using Xunit.Sdk;

    /// <summary>
    /// Implementation of a <see cref="TestRunner{IXunitTestCase}"/> for the <see cref="ScenarioAttribute"/>.
    /// </summary>
    public class ScenarioTestRunner : XunitTestRunner
    {
        #region Dependencies

        /// <summary>
        /// Creates a new instance of the <see cref="ScenarioTestRunner"/> type.
        /// </summary>
        /// <param name="test"> The test that this invocation belongs to. </param>
        /// <param name="messageBus"> The message bus to report run status to. </param>
        /// <param name="testClass"> The test class that the test method belongs to. </param>
        /// <param name="constructorArguments"> The arguments to be passed to the test class constructor. </param>
        /// <param name="testMethod"> The test method that will be invoked. </param>
        /// <param name="testMethodArguments"> The arguments to be passed to the test method. </param>
        /// <param name="skipReason"> The skip reason, if the test is to be skipped. </param>
        /// <param name="beforeAfterAttributes"> The list of <see cref="BeforeAfterTestAttribute"/>s for this test. </param>
        /// <param name="aggregator"> The exception aggregator used to run code and collect exceptions. </param>
        /// <param name="cancellationTokenSource"> The task cancellation token source, used to cancel the test run. </param>
        /// <param name="enableOutput"> A flag indicating whether or not the test will write additional output. </param>
        public ScenarioTestRunner(
            ITest test,
            IMessageBus messageBus,
            Type testClass,
            object[] constructorArguments,
            MethodInfo testMethod,
            object[] testMethodArguments,
            string skipReason,
            IReadOnlyList<BeforeAfterTestAttribute> beforeAfterAttributes,
            ExceptionAggregator aggregator,
            CancellationTokenSource cancellationTokenSource,
            bool enableOutput)
            : base(test, messageBus, testClass, constructorArguments, testMethod, testMethodArguments, skipReason, beforeAfterAttributes, aggregator, cancellationTokenSource)
        {
            EnableOutput = enableOutput;
        }

        #endregion

        #region Data

        /// <summary>
        /// Gets or sets a flag indicating whether or not the test will write additional output.
        /// </summary>>
        public bool EnableOutput { get; }

        #endregion

        #region Logic

        /// <summary>
        /// Invoke the test method.
        /// </summary>
        /// <param name="aggregator"> The exception aggregator used to run code and collect exceptions. </param>
        /// <returns> A tuple that conains the ellapsed time and the test output. </returns>
        protected async override Task<Tuple<decimal, string>> InvokeTestAsync(ExceptionAggregator aggregator)
        {
            TestContext.EnableOutput = EnableOutput;

            if (EnableOutput)
            {
                TestOutputHelper output = null;
                decimal item = default;
                string message = default;

                try
                {
                    output = new TestOutputHelper();
                    output.Initialize(base.MessageBus, base.Test);
                    TestContext.TestOutput = output;

                    item = await InvokeTestMethodAsync(aggregator);
                }
                finally
                {
                    if (output != null)
                    {
                        message = output.Output;
                        output.Uninitialize();
                        TestContext.TestOutput = null;
                    }
                }

                return Tuple.Create(item, message);
            }
            else
            {
                decimal item = await InvokeTestMethodAsync(aggregator);
                return Tuple.Create(item, string.Empty);
            }
        }

        #endregion
    }
}