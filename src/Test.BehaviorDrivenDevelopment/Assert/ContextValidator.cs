namespace CustomCode.Test.BehaviorDrivenDevelopment
{
    using Configuration;
    using System;
    using System.Runtime.CompilerServices;
    using Xunit.Sdk;

    /// <summary>
    /// Base type for custom validators that provides support for formatted validation exceptions
    /// as well as call context informations.
    /// </summary>
    /// <typeparam name="T"> The type of the value that is validated by this instance. </typeparam>
    public abstract class ContextValidator<T> : IFluentInterface
    {
        #region Logic

        /// <summary>
        /// Creates a new validation exception from the specified parameters.
        /// </summary>
        /// <param name="testMethodName">
        /// The name of the test method that contains the call to the validation method.
        /// </param>
        /// <param name="context"> The caller context that contains information about the validated type. </param>
        /// <param name="actual"> The actual value that was validated by this instance. </param>
        /// <param name="expected"> The expected value. </param>
        /// <param name="because">
        /// An optional reason why the <paramref name="actual"/> value should equal the <paramref name="expected"/> value.
        /// </param>
        /// <returns> An exception with the a formatted an human readable validation message. </returns>
        protected Exception ValidationException(string testMethodName, string context, string actual, string expected,
            string because = null)
        {
            var messageFormatter = TestConfiguration.GetMessageFormatterFor(testMethodName);
            var message = messageFormatter?.FormatMessage(context, actual, expected, because) ?? string.Empty;
            return new XunitException(message);
        }

        /// <summary>
        /// Gets the caller context for a given validation method.
        /// </summary>
        /// <param name="testMethodName">
        /// The name of the test method that contains the call to the validation method.
        /// </param>
        /// <param name="expected"> The expected value specified as validation method parameter. </param>
        /// <param name="sourceCodePath">
        /// The path to the source code file that contains the call to the validation method.
        /// </param>
        /// <param name="lineNumber"> The line number that contains the call to the validation method. </param>
        /// <param name="validationMethodName"> The name of the called validation method. </param>
        /// <returns> The parsed caller context or null. </returns>
        protected string GetContext(string testMethodName, T expected, string sourceCodePath, int lineNumber,
            [CallerMemberName] string validationMethodName = null)
        {
            var callerContext = TestConfiguration.GetCallerContextFor(testMethodName);
            var context = callerContext?.GetCallerContext(
                expected, testMethodName, validationMethodName, lineNumber, sourceCodePath);
            return context;
        }

        #endregion
    }
}