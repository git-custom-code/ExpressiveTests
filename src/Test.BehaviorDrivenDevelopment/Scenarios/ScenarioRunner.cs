namespace CustomCode.Test.BehaviorDrivenDevelopment
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Threading;
    using Xunit.Abstractions;
    using Xunit.Sdk;

    /// <summary>
    /// Implementation of a <see cref="TestCaseRunner{IXunitTestCase}"/> for the <see cref="ScenarioAttribute"/>.
    /// </summary>
    public sealed class ScenarioRunner : XunitTestCaseRunner
    {
        #region Dependencies

        /// <summary>
        /// Creates a new instance of the <see cref="ScenarioRunner"/> type.
        /// </summary>
        /// <param name="testCase"> The test case to be run. </param>
        /// <param name="displayName"> The display name of the test case. </param>
        /// <param name="skipReason"> The skip reason, if the test is to be skipped. </param>
        /// <param name="constructorArguments"> The arguments to be passed to the test class constructor. </param>
        /// <param name="testMethodArguments"> The arguments to be passed to the test method. </param>
        /// <param name="messageBus"> The message bus to report run status to. </param>
        /// <param name="aggregator"> The exception aggregator used to run code and collect exceptions. </param>
        /// <param name="cancellationTokenSource"> The task cancellation token source, used to cancel the test run. </param>
        /// <param name="enableOutput"> A flag indicating whether or not the test will write additional output. </param>
        public ScenarioRunner(
            IXunitTestCase testCase,
            string displayName,
            string skipReason,
            object[] constructorArguments,
            object[] testMethodArguments,
            IMessageBus messageBus,
            ExceptionAggregator aggregator,
            CancellationTokenSource cancellationTokenSource,
            bool enableOutput)
            : base(testCase, displayName, skipReason, constructorArguments, testMethodArguments, messageBus, aggregator, cancellationTokenSource)
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
        /// Creates the test runner used to run the given test.
        /// </summary>
        /// <param name="test"> The associated test. </param>
        /// <param name="messageBus"> The message bus to report run status to. </param>
        /// <param name="testClass"> The reflection type of the class under test. </param>
        /// <param name="constructorArguments"> The arguments to be passed to the test class constructor. </param>
        /// <param name="testMethod"> The reflection method info of the method under test. </param>
        /// <param name="testMethodArguments"> The arguments to be passed to the test method. </param>
        /// <param name="skipReason"> The skip reason, if the test is to be skipped. </param>
        /// <param name="beforeAfterAttributes">
        /// A collection of <see cref="BeforeAfterTestAttribute"/>s that should be executed before/after the test.
        /// </param>
        /// <param name="aggregator"> The exception aggregator used to run code and collect exceptions. </param>
        /// <param name="cancellationTokenSource"> The task cancellation token source, used to cancel the test run. </param>
        /// <returns> The test runner instance used to run the given test. </returns>
        protected override XunitTestRunner CreateTestRunner(
            ITest test,
            IMessageBus messageBus,
            Type testClass,
            object[] constructorArguments,
            MethodInfo testMethod,
            object[] testMethodArguments,
            string skipReason,
            IReadOnlyList<BeforeAfterTestAttribute> beforeAfterAttributes,
            ExceptionAggregator aggregator,
            CancellationTokenSource cancellationTokenSource)
        {
            return new ScenarioTestRunner(
                test,
                messageBus,
                testClass,
                constructorArguments,
                testMethod,
                testMethodArguments,
                skipReason,
                beforeAfterAttributes,
                new ExceptionAggregator(aggregator),
                cancellationTokenSource,
                EnableOutput);
        }

        #endregion
    }
}