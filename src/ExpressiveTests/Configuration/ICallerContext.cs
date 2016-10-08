﻿namespace ExpressiveTests.Configuration
{
    using System.Diagnostics.Contracts;

    /// <summary>
    /// Use implementations of this interface to obtain information about the type (name) and property (name) that
    /// was used to call a validation extension method on.
    /// </summary>
    [ContractClass(typeof(ContractClassForICallerContext))]
    public interface ICallerContext
    {
        /// <summary>
        /// Gets the caller context for a given validation method.
        /// </summary>
        /// <param name="expected"> The expected value specified as validation method parameter. </param>
        /// <param name="testMethodName">
        /// The name of the test method that contains the call to the validation method.
        /// </param>
        /// <param name="validationMethodName"> The name of the called validation method. </param>
        /// <param name="lineNumber"> The line number that contains the call to the validation method. </param>
        /// <param name="sourceCodePath">
        /// The path to the source code file that contains the call to the validation method.
        /// </param>
        /// <returns> The parsed caller context or null. </returns>
        string GetCallerContext<T>(T expected, string testMethodName, string validationMethodName,
            int lineNumber, string sourceCodePath);
    }

    #region Contracts

    /// <summary>
    /// Code contracts for the <see cref="ICallerContext"/> interface.
    /// </summary>
    [ContractClassFor(typeof(ICallerContext))]
    abstract class ContractClassForICallerContext : ICallerContext
    {
        /// <summary>
        /// Code contracts for the <see cref="GetCallerContext{T}(T, string, string, int, string)"/> method.
        /// </summary>
        public string GetCallerContext<T>(T expected, string testMethodName, string validationMethodName,
            int lineNumber, string sourceCodePath)
        {
            Contract.Requires(!string.IsNullOrEmpty(testMethodName));
            Contract.Requires(!string.IsNullOrEmpty(validationMethodName));
            Contract.Requires(lineNumber > 0);
            Contract.Requires(!string.IsNullOrEmpty(sourceCodePath));
            Contract.Ensures(!string.IsNullOrEmpty(Contract.Result<string>()));

            return default(string);
        }
    }

    #endregion
}