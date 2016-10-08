namespace ExpressiveTests
{
    using Configuration;
    using System;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using Xunit.Sdk;

    /// <summary>
    /// Base type for custom validators that provides support for formatted validation exceptions
    /// as well as call context informations.
    /// </summary>
    /// <typeparam name="T"> The type of the value that is validated by this instance. </typeparam>
    public abstract class ContextValidator<T>
    {
        #region Dependencies

        /// <summary>
        /// Default ctor.
        /// </summary>
        public ContextValidator()
        {
            CallerContext = TestConfiguration.CallerContext;
            MessageFormatter = TestConfiguration.MessageFormatter;
        }

        /// <summary>
        /// Injection ctor.
        /// </summary>
        /// <param name="callerContext"> The caller context that can be used to enrich assert messages. </param>
        /// <param name="messageFormatter"> The formatter used to format the assertion message. </param>
        public ContextValidator(ICallerContext callerContext, IMessageFormatter messageFormatter)
        {
            CallerContext = callerContext;
            MessageFormatter = messageFormatter;
        }

        /// <summary>
        /// The caller context that can be used to enrich assert messages.
        /// </summary>
        private ICallerContext CallerContext { get; }

        /// <summary>
        /// The formatter used to format the assertion message.
        /// </summary>
        private IMessageFormatter MessageFormatter { get; }

        #endregion

        #region Logic

        /// <summary>
        /// Creates a new validation exception from the specified parameters.
        /// </summary>
        /// <param name="context"> The caller context that contains information about the validated type. </param>
        /// <param name="actual"> The actual value that was validated by this instance. </param>
        /// <param name="expected"> The expected value. </param>
        /// <param name="because">
        /// An optional reason why the <paramref name="actual"/> value should equal the <paramref name="expected"/> value.
        /// </param>
        /// <returns> An exception with the a formatted an human readable validation message. </returns>
        protected Exception ValidationException(string context, string actual, string expected, string because = null)
        {
            var message = MessageFormatter?.FormatMessage(context, actual, expected, because) ?? string.Empty;
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
            var context = CallerContext?.GetCallerContext(
                expected, testMethodName, validationMethodName, lineNumber, sourceCodePath);
            return context;
        }

        /// <summary>
        /// Used to hide object members from intellisense for the fluent interface.
        /// </summary>
        /// <remarks>
        /// Note that there is currently a bug with VS 2015 that will display the GetType nevertheless.
        /// See https://github.com/dotnet/roslyn/issues/4434 for more details.
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new Type GetType()
        {
            return base.GetType();
        }

        /// <summary>
        /// Used to hide object members from intellisense for the fluent interface.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        /// <summary>
        /// Used to hide object members from intellisense for the fluent interface.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        /// <summary>
        /// Used to hide object members from intellisense for the fluent interface.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override string ToString()
        {
            return base.ToString();
        }

        #endregion
    }
}