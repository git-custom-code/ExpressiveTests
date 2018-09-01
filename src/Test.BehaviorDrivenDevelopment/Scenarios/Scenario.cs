namespace CustomCode.Test.BehaviorDrivenDevelopment
{
    using System;
    using System.ComponentModel;
    using System.Threading;
    using System.Threading.Tasks;
    using Xunit.Abstractions;
    using Xunit.Sdk;

    /// <summary>
    /// Implementation of the <see cref="IXunitTestCase"/> and <see cref="ITestCase"/> interfaces
    /// for the <see cref="ScenarioAttribute"/>.
    /// </summary>
    public sealed class Scenario : XunitTestCase
    {
        #region Dependencies

        /// <summary>
        /// Creates a new instance of the <see cref="Scenario"/> type.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Called by the de-serializer; should only be called by deriving classes for de-serialization purposes")]
        public Scenario()
        { }

        /// <summary>
        /// Creates a new instance of the <see cref="Scenario"/> type.
        /// </summary>
        /// <param name="messageSink"> The message sink used to send diagnostic messages. </param>
        /// <param name="testMethodDisplay"> Default method display to use (when not customized). </param>
        /// <param name="testMethodDisplayOptions"> Default method display options to use (when not customized). </param>
        /// <param name="testMethod"> The test method this test case belongs to. </param>
        /// <param name="enableOutput"> A flag indicating whether or not the test will write additional output. </param>
        public Scenario(
            IMessageSink messageSink,
            TestMethodDisplay testMethodDisplay,
            TestMethodDisplayOptions testMethodDisplayOptions,
            ITestMethod testMethod,
            bool enableOutput)
            : base(messageSink, testMethodDisplay, testMethodDisplayOptions, testMethod)
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

        /// <inheritdoc />
        public override Task<RunSummary> RunAsync(
            IMessageSink diagnosticMessageSink,
            IMessageBus messageBus,
            object[] constructorArguments,
            ExceptionAggregator aggregator,
            CancellationTokenSource cancellationTokenSource)
        {
            var runner = new ScenarioRunner(
                this,
                base.DisplayName,
                base.SkipReason,
                constructorArguments,
                base.TestMethodArguments,
                messageBus,
                aggregator,
                cancellationTokenSource,
                EnableOutput);
            return runner.RunAsync();
        }

        #endregion
    }
}