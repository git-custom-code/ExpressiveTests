namespace ExpressiveTests.Configuration
{
    using System.Diagnostics.Contracts;

    /// <summary>
    /// Use implementations of this interface to display custom formatted validation error messages.
    /// </summary>
    [ContractClass(typeof(ContractClassForIMessageFormatter))]
    public interface IMessageFormatter
    {
        /// <summary>
        /// Creates a formatted validation message from the given parameters.
        /// </summary>
        /// <param name="context"> The caller context that contains information about the validated type. </param>
        /// <param name="actualValue"> The actual value that was validated by this instance. </param>
        /// <param name="expectation"> The expected value. </param>
        /// <param name="reason">
        /// An optional reason why the <paramref name="actualValue"/> should satisfy the <paramref name="expectation"/>.
        /// </param>
        /// <returns> A formatted and human readable validation message. </returns>
        string FormatMessage(string context, string actualValue, string expectation, string reason);
    }

    #region Contracts

    /// <summary>
    /// Code contracts for the <see cref="IMessageFormatter"/> interface.
    /// </summary>
    [ContractClassFor(typeof(IMessageFormatter))]
    abstract class ContractClassForIMessageFormatter : IMessageFormatter
    {
        /// <summary>
        /// Code contracts for the <see cref="FormatMessage(string, string, string, string)"/> method.
        /// </summary>
        public string FormatMessage(string context, string actualValue, string expectation, string reason)
        {
            Contract.Requires(!string.IsNullOrEmpty(context));
            Contract.Requires(!string.IsNullOrEmpty(actualValue));
            Contract.Requires(!string.IsNullOrEmpty(expectation));
            Contract.Ensures(!string.IsNullOrEmpty(Contract.Result<string>()));

            return default(string);
        }
    }

    #endregion
}